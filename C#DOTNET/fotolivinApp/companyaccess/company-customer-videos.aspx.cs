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

public partial class company_customer_videos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["cu"] == null || Session["cp"] == null || Session["ccoid"] == null)
        {
            Response.Redirect("company-login");
        }
        try
        {
            if (!IsPostBack)
            {
                customerDetails();
                displayEvents();
               
                
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
            Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later. If still problem persist than contact admin');if(alert){ window.location='company-customer-profile';}</script>");

        }
        viewvideopnl.Visible = false;
    }
     public void customerDetails()
    {
        string coid1 = Session["ccoid"].ToString();
        string cid1 = Session["ccid"].ToString();
        customeridlbl.Text = cid1;
        companyidlbl.Text = coid1;
        
    }

    protected void backbtn_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("company-customer-profile");
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
            Response.Redirect("company-customer-photos");
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
            Response.Redirect("company-customer-albums");
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
   
   
    public void displayEvents()
    {
        string eventsPath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath1"] + companyidlbl.Text + "\\" + customeridlbl.Text + "\\" + "videos";
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
            eventsCoverPath1 = System.Configuration.ConfigurationManager.AppSettings["customerDataPath1"] + companyidlbl.Text + "\\" + customeridlbl.Text + "\\" + "videos" + "\\" + d1.Name + "\\" + "cover" + "\\" + customeridlbl.Text + d1.Name + ".jpg";
            dt.Rows.Add(eventsPath1, eventsCoverPath1);
        }
        eventsdl.DataSource = dt;
        eventsdl.DataBind();
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
        string videosPath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath1"] + companyidlbl.Text + "\\" + customeridlbl.Text + "\\" + "videos" + "\\" + s;
        string videosPath1;
        string videosNamePath1;
        string videosSizePath1;
        string videosLikesPath1;
        string videosViewsPath1;
        string videosONPath1;
        {
            string s1 = "select originalname, videoname, videoextension, videosize, likes, views from videodetails where customerid='" + customeridlbl.Text + "' AND event='" + s + "'";
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

                    videosPath1 = System.Configuration.ConfigurationManager.AppSettings["customerDataPath1"] + companyidlbl.Text + "\\" + customeridlbl.Text + "\\" + "videos" + "\\" + s + "\\" + video + ext;
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
   
   
}