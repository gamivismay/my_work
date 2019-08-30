using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Net.Mail;
using System.Net;

public partial class customer_videos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["u"] == null || Session["p"] == null || Session["coid"] == null || Session["oid"] == null)
        {
            Response.Redirect("login");
        }
        try
        {
            if (!IsPostBack)
            {
                customerDetails();
                displayEvents();
                displayMainCover();
                videoId();
            }
        }
        catch (Exception ex)
        {
            Exception ex2 = ex;
            string errorMessage = string.Empty;
            while (ex2 != null)
            {
                errorMessage += ex2.ToString();
                ex2 = ex2.InnerException;
            }
            Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later. If still problem persist than contact admin');if(alert){ window.location='customer-profile';}</script>");

        }
        viewvideopnl.Visible = false;
        othereventpnl.Visible = true;
    }
     public void customerDetails()
    {
        string coid1 = Session["coid"].ToString();
        string cid1 = Session["cid"].ToString();
        customeridlbl.Text = cid1;
        companyidlbl.Text = coid1;
        
    }

    protected void backbtn_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("customer-profile");
        }
        catch (Exception ex)
        {
            Exception ex2 = ex;
            string errorMessage = string.Empty;
            while (ex2 != null)
            {
                errorMessage += ex2.ToString();
                ex2 = ex2.InnerException;
            }


        }
    }
    protected void photobtn_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("customer-photos");
        }
        catch (Exception ex)
        {
            Exception ex2 = ex;
            string errorMessage = string.Empty;
            while (ex2 != null)
            {
                errorMessage += ex2.ToString();
                ex2 = ex2.InnerException;
            }


        }
    }
    protected void albumbtn_Click(object sender, EventArgs e)
    {
        try
        {
             Response.Redirect("customer-albums");
        }
        catch (Exception ex)
        {
            Exception ex2 = ex;
            string errorMessage = string.Empty;
            while (ex2 != null)
            {
                errorMessage += ex2.ToString();
                ex2 = ex2.InnerException;
            }


        }
    }
    protected void eventsddl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        videoId();
        if (eventsddl1.SelectedIndex == 0)
        {
            othereventpnl.Visible = true;
            eventsddl.Text = othereventnametb.Text;
        }
        else if (eventsddl1.SelectedIndex != 0)
        {
            eventsddl.Text = eventsddl1.Text;
            othereventpnl.Visible = false;
            othereventnametb.Text = "";
        }
        
    }
    protected void donebtn_Click(object sender, EventArgs e)
    {
        othereventpnl.Visible = true;
        eventsddl.Text = othereventnametb.Text;
    }
    public void videoId()
    {
        int digit = Convert.ToInt32("5");
        string allowedChars = "";
        allowedChars = "1,2,3,4,5,6,7,8,9,0,A,B,C,D,E,F,G,H,I,J,K,L,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
        char[] sep = { ',' };
        string[] arr = allowedChars.Split(sep);
        string preimagename = "";
        string temp = "";
        Random rand = new Random();
        for (int i = 0; i < Convert.ToInt32(digit); i++)
        {
            temp = arr[rand.Next(0, arr.Length)];
            preimagename += temp;

        }
        string imageName = preimagename;
        videoidlbl.Text = imageName;
    }
    public void displayEvents()
    {
        string eventsPath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + companyidlbl.Text + "\\" + customeridlbl.Text + "\\" + "videos";
        string eventsPath1;
        string eventsCoverPath1;
        DirectoryInfo dir = new DirectoryInfo(MapPath(eventsPath));
        DirectoryInfo[] d = dir.GetDirectories();
        DataTable dt = new DataTable();
        dt.Columns.Add("eventsPath1");
        dt.Columns.Add("eventsCoverPath1");
        foreach (DirectoryInfo d1 in d)
        {
            eventsPath1 = d1.Name;
            eventsCoverPath1 = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + companyidlbl.Text + "\\" + customeridlbl.Text + "\\" + "videos" + "\\" + d1.Name + "\\" + "cover" + "\\" + companyidlbl.Text + customeridlbl.Text + d1.Name + ".jpg";
            dt.Rows.Add(eventsPath1, eventsCoverPath1);
        }
        eventsdl.DataSource = dt;
        eventsdl.DataBind();
    }
    public void displayMainCover()
    {
        string coverPath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + companyidlbl.Text + "\\" + customeridlbl.Text + "\\" + "videoscover";
        string coverPath1;
        DirectoryInfo dir = new DirectoryInfo(MapPath(coverPath));
        FileInfo[] file = dir.GetFiles();
        DataTable dt = new DataTable();
        dt.Columns.Add("coverPath1");
        foreach (FileInfo image in file)
        {
            if (image.Exists)
            {
                if (image.Extension.ToLower() == ".jpg" || image.Extension.ToLower() == ".jpeg")
                {
                    coverPath1 = coverPath + "\\" + customeridlbl.Text + "videoscover" + ".jpg";

                    dt.Rows.Add(coverPath1);
                }

            }

        }

        Repeater2.DataSource = dt;
        Repeater2.DataBind();
    }

    protected void eventsib_Click(object sender, ImageClickEventArgs e)
    {
        viewvideopnl.Visible = true;
        DataList dl = (DataList)FindControl("eventsdl");
        ImageButton b = sender as ImageButton;
        DataListItem di = (DataListItem)b.NamingContainer;
        Label l = (Label)di.FindControl("eventslbl");
        string s = l.Text;
        eventnamelbl.Text = s;
        string videosPath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + companyidlbl.Text + "\\" + customeridlbl.Text + "\\" + "videos" + "\\" + s;
        string videosPath1;
        string videosNamePath1;
        string videosSizePath1;
        string videosLikesPath1;
        string videosViewsPath1;
        string videosONPath1;
        {
            string s1 = "select originalname, videoname, videoextension,videosize, likes, views from videodetails where customerid='" + customeridlbl.Text + "' AND event='" + s + "'";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            try
            {
                SqlCommand cmd = new SqlCommand(s1, con);
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                da.Fill(dt);
                dt1.Columns.Add("videosPath1");
                dt1.Columns.Add("videosNamePath1");
                dt1.Columns.Add("videosSizePath1");
                dt1.Columns.Add("videosLikesPath1");
                dt1.Columns.Add("videosViewsPath1");
                dt1.Columns.Add("videosONPath1");
                foreach (DataRow dr in dt.Rows)
                {
                    string originalname = "" + dr["originalname"].ToString();
                    string video = "" + dr["videoname"].ToString();
                    string ext = "" + dr["videoextension"].ToString();
                    string size = "" + dr["videosize"].ToString();
                    string likes = "" + dr["likes"].ToString();
                    string views = "" + dr["views"].ToString();
                    long lBytes = Convert.ToInt32(size);
                    string sSize = string.Empty;


                    if (lBytes >= 1073741824)
                        size = String.Format("{0:##.##}", lBytes / 1073741824) + " GB";
                    else if (lBytes >= 1048576)
                        size = String.Format("{0:D}", lBytes / 1048576) + " MB";
                    else if (lBytes >= 1024)
                        size = String.Format("{0:##.##}", lBytes / 1024) + " KB";
                    else if (lBytes > 0 && lBytes < 1024)
                        size = lBytes.ToString() + " bytes";

                    videosLikesPath1 = likes;
                    videosSizePath1 = size;
                    videosViewsPath1 = views;

                    videosONPath1 = originalname;

                    videosPath1 = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + companyidlbl.Text + "\\" + customeridlbl.Text + "\\" + "videos" + "\\" + s + "\\" + video + ext;
                    videosNamePath1 = HttpUtility.HtmlEncode(Path.GetFileNameWithoutExtension(videosPath1));
                    dt1.Rows.Add(videosPath1, videosNamePath1, videosSizePath1, videosLikesPath1, videosViewsPath1, videosONPath1);
                }
                Repeater1.DataSource = dt1;
                Repeater1.DataBind();
            }

            catch (Exception ex)
            {
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }

            }
            finally
            {
                con.Close();

            }
        }


    }
    protected void Refresh_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("customer-videos");
        }
        catch (Exception ex)
        {
            Exception ex2 = ex;
            string errorMessage = string.Empty;
            while (ex2 != null)
            {
                errorMessage += ex2.ToString();
                ex2 = ex2.InnerException;
            }


        }
    }
    protected void refresh1_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("customer-videos");
        }
        catch (Exception ex)
        {
            Exception ex2 = ex;
            string errorMessage = string.Empty;
            while (ex2 != null)
            {
                errorMessage += ex2.ToString();
                ex2 = ex2.InnerException;
            }


        }
    }
    protected void videodelete_Click(object sender, ImageClickEventArgs e)
    {
        bool isdeleted;
        foreach (RepeaterItem item in Repeater1.Items)
        {
            isdeleted = ((CheckBox)item.FindControl("chck")).Checked;
            if (isdeleted)
            {
                try
                {

                    Label lbl = (Label)item.FindControl("filenamelbl");
                    string s = lbl.Text;
                    string videoPath1 = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + companyidlbl.Text + "\\" + customeridlbl.Text + "\\" + "videos" + "\\" + eventnamelbl.Text + "\\" + s + ".mp4";
                    string path1 = Server.MapPath(videoPath1);
                    string videoPath2 = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + companyidlbl.Text + "\\" + customeridlbl.Text + "\\" + "videos" + "\\" + eventnamelbl.Text + "\\" + "thumb" + "\\" + s + ".jpg";
                    string path2 = Server.MapPath(videoPath2);

                    if (File.Exists(path1))
                    {

                        File.Delete(path1);

                    }
                    if (File.Exists(path2))
                    {

                        File.Delete(path2);

                    }
                    try
                    {
                        string dltact = "delete from videodetails where videoname='" + lbl.Text + "'";
                        SqlConnection conact = new SqlConnection();
                        conact.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                        try
                        {
                            SqlCommand cmdact = new SqlCommand(dltact, conact);
                            conact.Open();
                            cmdact.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            Exception ex2 = ex;
                            string errorMessage = string.Empty;
                            while (ex2 != null)
                            {
                                errorMessage += ex2.ToString();
                                ex2 = ex2.InnerException;
                            }
                            Page.RegisterStartupScript("UserMsg", "<script>alert('It seems there is some problem..!! please try again later.');if(alert){ window.location='customer-videos';}</script>");

                        }
                        finally
                        {
                            conact.Close();
                        }
                    }

                    catch (Exception ex)
                    {
                        Exception ex2 = ex;
                        string errorMessage = string.Empty;
                        while (ex2 != null)
                        {
                            errorMessage += ex2.ToString();
                            ex2 = ex2.InnerException;
                        }
                        Page.RegisterStartupScript("UserMsg", "<script>alert('It seems there is some problem..!! please try again later.');if(alert){ window.location='customer-videos';}</script>");

                    }
                }

                catch (Exception ex)
                {
                    Exception ex2 = ex;
                    string errorMessage = string.Empty;
                    while (ex2 != null)
                    {
                        errorMessage += ex2.ToString();
                        ex2 = ex2.InnerException;
                    }

                }
            }
        }
        viewvideogallerypnl.Visible = true;
    }
    protected void videodirdelete_Click(object sender, ImageClickEventArgs e)
    {
        bool isdeleted;
        foreach (DataListItem item in eventsdl.Items)
        {
            isdeleted = ((CheckBox)item.FindControl("eventschck")).Checked;
            if (isdeleted)
            {
                try
                {
                    Label lbl = (Label)item.FindControl("eventslbl");
                    string eventsPath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + companyidlbl.Text + "\\" + customeridlbl.Text + "\\" + "videos" + "\\" + lbl.Text;
                    string strng = Server.MapPath(eventsPath);
                    try
                    {

                        if (Directory.Exists(strng))
                        {
                            foreach (string file in Directory.GetFiles(strng))
                            {
                                File.Delete(file);
                            }
                            foreach (string subfolder in Directory.GetDirectories(strng))
                            {
                                removedirectories(subfolder);
                            }
                            Directory.Delete(strng);

                        }


                    }
                    catch (Exception ex)
                    {
                        Exception ex22 = ex;
                        string errorMessage = string.Empty;
                        while (ex22 != null)
                        {
                            errorMessage += ex22.ToString();
                            ex22 = ex22.InnerException;
                        }
                    }
                    try
                    {
                        string dltact = "delete from videodetails where event='" + lbl.Text + "'";
                        SqlConnection conact = new SqlConnection();
                        conact.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                        try
                        {
                            SqlCommand cmdact = new SqlCommand(dltact, conact);
                            conact.Open();
                            cmdact.ExecuteNonQuery();

                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        finally
                        {
                            conact.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        Exception ex22 = ex;
                        string errorMessage = string.Empty;
                        while (ex22 != null)
                        {
                            errorMessage += ex22.ToString();
                            ex22 = ex22.InnerException;
                        }
                    }

                }

                catch (Exception ex)
                {
                    Exception ex2 = ex;
                    string errorMessage = string.Empty;
                    while (ex2 != null)
                    {
                        errorMessage += ex2.ToString();
                        ex2 = ex2.InnerException;
                    }

                }

            }
        }
        displayEvents();
    }
    public void removedirectories(string strng)
    {
        foreach (string file in Directory.GetFiles(strng))
        {
            File.Delete(file);
        }
        foreach (string subfolder in Directory.GetDirectories(strng))
        {
            removedirectories(subfolder);
        }
        Directory.Delete(strng);

    }
   
}