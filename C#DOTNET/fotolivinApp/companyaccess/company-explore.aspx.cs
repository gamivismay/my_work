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

public partial class company_explore : System.Web.UI.Page
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


                viewsDetails();
                likesDetails();
                storageDetails();
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
            Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later. If still problem persist than contact admin');if(alert){ window.location='company-dashboard';}</script>");

        }
        productpanel.Visible = false;
    }
  
    public void viewsDetails()
    {
        string u1 = Session["cu"].ToString();
        string p1 = Session["cp"].ToString();
        string coid1 = Session["ccoid"].ToString();

        
        {
            string s1 = "select views from exploredetails where companyid='" + coid1 + "'";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            try
            {
                SqlCommand cmd = new SqlCommand(s1, con);
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                int a = 0;
                if (dt.Rows.Count > 0)
                    foreach (DataRow dr in dt.Rows)
                    {
                        a += Int32.Parse(dr["views"].ToString());
                        displayviews1.Text = a.ToString();
                    }
                else
                {
                    displayviews1.Text = a.ToString();
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
                Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='company-dashboard';}</script>");

            }
            finally
            {
                con.Close();

            }
        }
        displayviews2.Text = displayviews1.Text;
    }
    public void likesDetails()
    {
        string u1 = Session["cu"].ToString();
        string p1 = Session["cp"].ToString();
        string coid1 = Session["ccoid"].ToString();
        //string cid1 = Request.QueryString["cid"];
        {
            string s1 = "select likes from exploredetails where companyid='" + coid1 + "'";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            try
            {
                SqlCommand cmd = new SqlCommand(s1, con);
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                int a = 0;
                if (dt.Rows.Count > 0)
                    foreach (DataRow dr in dt.Rows)
                    {
                        a += Int32.Parse(dr["likes"].ToString());
                        displaylikes1.Text = a.ToString();
                    }
                else
                {
                    displaylikes1.Text = a.ToString();
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
                Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='company-dashboard';}</script>");

            }
            finally
            {
                con.Close();

            }
        }

        
        
        displaylikes2.Text = displaylikes1.Text;

    }
    public void storageDetails()
    {
        string u1 = Session["cu"].ToString();
        string p1 = Session["cp"].ToString();
        string coid1 = Session["ccoid"].ToString();
        //string cid1 = Request.QueryString["cid"];
        {
            string s1 = "select filesize from exploredetails where companyid='" + coid1 + "'";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            try
            {
                SqlCommand cmd = new SqlCommand(s1, con);
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Int64 a = 0;
                if (dt.Rows.Count > 0)
                    foreach (DataRow dr in dt.Rows)
                    {
                        a += Int64.Parse(dr["filesize"].ToString());
                        explorespacehf.Value = a.ToString();
                    }
                else
                {
                    explorespacehf.Value = a.ToString();
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
                Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='company-dashboard';}</script>");

            }
            finally
            {
                con.Close();

            }
        }



        long lBytes = Convert.ToInt64(explorespacehf.Value);
        ConvertBytes(lBytes);
        displayspace2.Text = displayspace1.Text;

    }
    public string ConvertBytes(long lBytes)
    {
        string sSize = string.Empty;
        displayspace1.Text = "0";

        if (lBytes >= 1073741824)
        {
            Int64 a = lBytes;
            Int64 b = 1073741824;
            double div = (double)a / b;
            displayspace1.Text = String.Format("{0:0.00}", div) + " GB";
        }
        else if (lBytes >= 1048576)
            displayspace1.Text = String.Format("{0:D}", lBytes / 1048576) + " MB";
        else if (lBytes >= 1024)
            displayspace1.Text = String.Format("{0:##.##}", lBytes / 1024) + " KB";
        else if (lBytes > 0 && lBytes < 1024)
            displayspace1.Text = lBytes.ToString() + " bytes";

        return displayspace1.Text;
    }


    protected void addbtn_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            addbtn.Text = "Please wait till image is uploaded..!!";
            string coid1 = Session["ccoid"].ToString();
            string exploreImage = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + coid1 + "\\" + "explore" + "\\" + "photo";
            string filename = FileUpload1.PostedFile.FileName;
            long size = FileUpload1.PostedFile.ContentLength;
            string type = FileUpload1.PostedFile.ContentType;
            System.Drawing.Image img = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream);
            int height = img.Height;
            int width = img.Width;
            string ext = Path.GetExtension(FileUpload1.PostedFile.FileName);
            int digit = Convert.ToInt32("8");
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
            string SaveAsImage = System.IO.Path.Combine(Server.MapPath(exploreImage + "/" + coid1 + imageName + ext));
            FileUpload1.PostedFile.SaveAs(SaveAsImage);
            string finalimagename = coid1 + imageName;

            DateTime datetime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            string s1 = "insert into exploredetails values('" + coid1 + "','" + "photo" + "','" + eventnamelist.Text + "','" + finalimagename + "','" + size + "','" + width + "','" + height + "','" + ext + "','" + locationtb.Text + "','"+DropDownList1.Text+"','" + imagepricetb.Text + "','" + "0" + "','" + "0" + "','" + datetime + "')";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            try
            {
                SqlCommand cmd = new SqlCommand(s1, con);
                con.Open();
                cmd.ExecuteNonQuery();
                Page.RegisterStartupScript("UserMsg", "<script>alert('Upload complete..!');if(alert){ window.location='company-explore';}</script>");

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
        else
        {
            Page.RegisterStartupScript("UserMsg", "<script>alert('Please upload a image..!');if(alert){ window.location='company-explore';}</script>");

        }
    }
  
    
    protected void updateinfobtn_Click(object sender, EventArgs e)
    {
        if (FileUpload2.HasFile)
        {
            productpanel.Visible = true;
            string coid1 = Session["ccoid"].ToString();

            DateTime datetime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));

            string exploreImage = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + coid1 + "\\" + "explore" + "\\" + "photo";
            
            string fileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
            long size = FileUpload2.PostedFile.ContentLength;
            string type = FileUpload2.PostedFile.ContentType;
            System.Drawing.Image img = System.Drawing.Image.FromStream(FileUpload2.PostedFile.InputStream);
            int height = img.Height;
            int width = img.Width;
            string ext = Path.GetExtension(FileUpload2.PostedFile.FileName);
            string fileext = Path.GetExtension(FileUpload2.PostedFile.FileName);
            string SaveAsImage = System.IO.Path.Combine(Server.MapPath(exploreImage + "/" + editfilenamelbl.Text + ext));
            FileUpload2.PostedFile.SaveAs(SaveAsImage);
            string insert = "update exploredetails set event = '" + DropDownList2.Text + "', filesize='"+size+"', filewidth='"+width+"',fileheight='"+height+"',fileextension='"+fileext+"', location = '" + editlocationtb.Text + "',sale='"+DropDownList3.Text+"', imageprice = '" + editimagepricetb.Text + "', date = '" + datetime + "' where filename = '" + editfilenamelbl.Text + "' AND companyid='"+coid1+"'";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            try
            {
                SqlCommand cmd = new SqlCommand(insert, con);
                con.Open();
                cmd.ExecuteNonQuery();
                Page.RegisterStartupScript("UserMsg", "<script>alert('Photo updated..!');if(alert){ window.location='company-explore';}</script>");

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
        else
        {
            productpanel.Visible = true;
            string coid1 = Session["ccoid"].ToString();

            DateTime datetime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            string insert = "update exploredetails set event = '" + DropDownList2.Text + "', location = '" + editlocationtb.Text + "',sale='" + DropDownList3.Text + "', imageprice = '" + editimagepricetb.Text + "', date = '" + datetime + "' where filename = '" + editfilenamelbl.Text + "' AND companyid='" + coid1 + "'";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            try
            {
                SqlCommand cmd = new SqlCommand(insert, con);
                con.Open();
                cmd.ExecuteNonQuery();
                Page.RegisterStartupScript("UserMsg", "<script>alert('Photo updated..!');if(alert){ window.location='company-explore';}</script>");

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
    protected void cancelbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("company-explore");
    }

    public void displayEvents()
    {
        string coid1 = Session["ccoid"].ToString();
        string id1;
        string event1;
        string filename1;
        string imageprice1;
        string views1;
        string likes1;
        string date1;
        string imagepath1;
        string location1;
        string fullname1;

        {
            string s1 = "select event, imageprice, views, likes, date, filename, fileextension, location from exploredetails where companyid='" + coid1 + "' order by id desc";
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
                dt1.Columns.Add("event1");
                dt1.Columns.Add("filename1");
                dt1.Columns.Add("imageprice1");
                dt1.Columns.Add("views1");
                dt1.Columns.Add("likes1");
                dt1.Columns.Add("date1");
                dt1.Columns.Add("imagepath1");
                dt1.Columns.Add("location1");
                dt1.Columns.Add("fullname1");
                foreach (DataRow dr in dt.Rows)
                {
                    string event2 = "" + dr["event"].ToString();
                    string filename2 = "" + dr["filename"].ToString();
                    string fileextension2 = "" + dr["fileextension"].ToString();
                    string imageprice2 = "" + dr["imageprice"].ToString();
                    string views2 = "" + dr["views"].ToString();
                    string likes2 = "" + dr["likes"].ToString();
                    string date2 = "" + dr["date"].ToString();
                    string location2 = "" + dr["location"].ToString();

                    string imagePath = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + coid1 + "\\" + "explore" + "\\" + "photo";


                    DirectoryInfo dir = new DirectoryInfo(MapPath(imagePath));
                    FileInfo[] file = dir.GetFiles();

                    event1 = event2;
                    filename1 = filename2;
                    imageprice1 = imageprice2;
                    views1 = views2;
                    likes1 = likes2;
                    date1 = date2;
                    location1 = location2;
                    imagepath1 = imagePath + "\\" + filename2 + fileextension2;
                    fullname1 = filename2 + fileextension2;

                    dt1.Rows.Add(event1, filename1, imageprice1, views1, likes1, date1, imagepath1, location1, fullname1);


                }
                Repeater2.DataSource = dt1;
                Repeater2.DataBind();
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

    protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            string coid1 = Session["ccoid"].ToString();

            string fullname = e.CommandArgument.ToString();
            string[] whole = fullname.Split('.');
            string filename = whole[0].ToString();
            try
            {

                string imagePath = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + coid1 + "\\" + "explore" + "\\" + "photo" + "\\" + fullname;
                string strng = Server.MapPath(imagePath);
                try
                {

                    File.Delete(strng);

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
                    string dltact = "delete from exploredetails where filename='" + filename + "' AND companyid='" + coid1 + "'";
                    SqlConnection conact = new SqlConnection();
                    conact.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    try
                    {
                        SqlCommand cmdact = new SqlCommand(dltact, conact);
                        conact.Open();
                        cmdact.ExecuteNonQuery();
                        displayEvents();
                        Page.RegisterStartupScript("UserMsg", "<script>alert('Date deleted..!');if(alert){ window.location='company-explore';}</script>");

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
        if (e.CommandName == "edit")
        {
            exploredetailspnl.Visible = false;
            statspnl.Visible = false;
            addpnl.Visible = false;
            productpanel.Visible = true;
            string coid1 = Session["ccoid"].ToString();
            string filename = Convert.ToString(e.CommandArgument);
            string s1 = "select * from exploredetails where filename='" + filename + "' AND companyid='" + coid1 + "'";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            try
            {
                SqlCommand cmd = new SqlCommand(s1, con);
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DropDownList2.SelectedValue = "" + dr["event"].ToString();
                    editfilenamelbl.Text = "" + dr["filename"].ToString();
                    editfilesizelbl.Text = "" + dr["filesize"].ToString();
                    editfilewidthlbl.Text = "" + dr["filewidth"].ToString();
                    editfileheightlbl.Text = "" + dr["fileheight"].ToString();
                    editfileextensionlbl.Text = "" + dr["fileextension"].ToString();
                    editlocationtb.Text = "" + dr["location"].ToString();
                    editimagepricetb.Text = "" + dr["imageprice"].ToString();
                    editviewlbl.Text = "" + dr["views"].ToString();
                    editlikelbl.Text = "" + dr["likes"].ToString();
                    editdatelbl.Text = "" + dr["date"].ToString();
                    DropDownList3.SelectedValue = "" + dr["sale"].ToString();
                    string exploreImage = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + coid1 + "\\" + "explore" + "\\" + "photo";
                    string exploreImage1;
                    DirectoryInfo dir = new DirectoryInfo(MapPath(exploreImage));
                    FileInfo[] file = dir.GetFiles();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("exploreImage1");
                    exploreImage1 = exploreImage + "\\" + filename + editfileextensionlbl.Text;
                    dt.Rows.Add(exploreImage1);
                    Repeater1.DataSource = dt;
                    Repeater1.DataBind();
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
                Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='company-explore';}</script>");

            }
            finally
            {
                con.Close();

            }
        }
    }

    //public void bindExploreDetails()
    //{
    //    string coid1 = Session["ccoid"].ToString();
    //    string s1 = "select id,event,filename,imageprice,views,likes,date, filename, fileextension from exploredetails where companyid='" + coid1 + "' order by id desc";
    //    SqlConnection con = new SqlConnection();
    //    con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    //    try
    //    {
    //        SqlCommand cmd = new SqlCommand(s1, con);
    //        con.Open();
    //        cmd.ExecuteNonQuery();
    //        SqlDataAdapter da = new SqlDataAdapter(cmd);
    //        DataTable dt = new DataTable();
    //        SqlDataReader dr = cmd.ExecuteReader();
    //        dr.Read();
    //        string filename = "" + dr["filename"].ToString();
    //        string ext = "" + dr["fileextension"].ToString();
    //        dr.Close();
    //        da.Fill(dt);

    //        string exploreImage = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + coid1 + "\\" + "explore" + "\\" + "photo" + "\\" + filename + ext;
    //        string filePath = Server.MapPath(exploreImage);



    //        GridView2.DataSource = dt;
    //        GridView2.DataBind();

    //    }

    //    catch (Exception ex)
    //    {
    //        Exception ex2 = ex;
    //        string errorMessage = string.Empty;
    //        while (ex2 != null)
    //        {
    //            errorMessage += ex2.ToString();
    //            ex2 = ex2.InnerException;
    //        }

    //    }
    //    finally
    //    {
    //        con.Close();

    //    }
    //}
    //protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    GridView2.PageIndex = e.NewPageIndex;
    //    GridView2.DataBind();
    //    bindExploreDetails();


    //}
    //protected void viewdetails_Command(object sender, CommandEventArgs e)
    //{

    //    productpanel.Visible = true;
    //    string coid1 = Session["ccoid"].ToString();
    //    string filename = Convert.ToString(e.CommandArgument);
    //    string s1 = "select * from exploredetails where filename='" + filename + "' AND companyid='" + coid1 + "'";
    //    SqlConnection con = new SqlConnection();
    //    con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    //    try
    //    {
    //        SqlCommand cmd = new SqlCommand(s1, con);
    //        con.Open();
    //        cmd.ExecuteNonQuery();
    //        SqlDataAdapter da = new SqlDataAdapter(cmd);
    //        SqlDataReader dr = cmd.ExecuteReader();
    //        while (dr.Read())
    //        {
    //            DropDownList2.SelectedValue = "" + dr["event"].ToString();
    //            editfilenamelbl.Text = "" + dr["filename"].ToString();
    //            editfilesizelbl.Text = "" + dr["filesize"].ToString();
    //            editfilewidthlbl.Text = "" + dr["filewidth"].ToString();
    //            editfileheightlbl.Text = "" + dr["fileheight"].ToString();
    //            editfileextensionlbl.Text = "" + dr["fileextension"].ToString();
    //            editlocationtb.Text = "" + dr["location"].ToString();
    //            editimagepricetb.Text = "" + dr["imageprice"].ToString();
    //            editviewlbl.Text = "" + dr["views"].ToString();
    //            editlikelbl.Text = "" + dr["likes"].ToString();
    //            editdatelbl.Text = "" + dr["date"].ToString();
    //            DropDownList3.SelectedValue = "" + dr["sale"].ToString();
    //            string exploreImage = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + coid1 + "\\" + "explore" + "\\" + "photo";
    //            string exploreImage1;
    //            DirectoryInfo dir = new DirectoryInfo(MapPath(exploreImage));
    //            FileInfo[] file = dir.GetFiles();
    //            DataTable dt = new DataTable();
    //            dt.Columns.Add("exploreImage1");
    //            exploreImage1 = exploreImage + "\\" + filename + editfileextensionlbl.Text;
    //            dt.Rows.Add(exploreImage1);
    //            Repeater1.DataSource = dt;
    //            Repeater1.DataBind();
    //        }
    //    }

    //    catch (Exception ex)
    //    {
    //        Exception ex2 = ex;
    //        string errorMessage = string.Empty;
    //        while (ex2 != null)
    //        {
    //            errorMessage += ex2.ToString();
    //            ex2 = ex2.InnerException;
    //        }
    //        Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='company-explore';}</script>");

    //    }
    //    finally
    //    {
    //        con.Close();

    //    }

    //}

}