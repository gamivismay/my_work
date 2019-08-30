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

public partial class company_gallery_photos : System.Web.UI.Page
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
        
    }
     public void customerDetails()
    {
        string coid1 = Session["ccoid"].ToString();
        string cid1 = Session["ccid"].ToString();
        customeridlbl.Text = cid1;
        companyidlbl.Text = coid1;
        gallerynamelbl.Text = Request.QueryString["gname"].ToString();
    }

    protected void backbtn_Click(object sender, EventArgs e)
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
  

    public void displayEvents()
    {
        eventnamelbl.Text = Request.QueryString["gname"].ToString();
        string s = eventnamelbl.Text;
        string photosPath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath1"] + companyidlbl.Text + "\\" + customeridlbl.Text + "\\" + "photos" + "\\" + s;
        string photosPath1;
        string photosNamePath1;
        string photosSizePath1;
        string photosLikesPath1;
        string photosViewsPath1;
        string photosONPath1;
        {
            string s1 = "select originalname, imagename, imageextension, imagesize, likes, views from photodetails where customerid='" + customeridlbl.Text + "' AND event='" + s + "' AND category='" + "photos" + "'";
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
                dt1.Columns.Add("photosPath1");
                dt1.Columns.Add("photosNamePath1");
                dt1.Columns.Add("photosSizePath1");
                dt1.Columns.Add("photosLikesPath1");
                dt1.Columns.Add("photosViewsPath1");
                dt1.Columns.Add("photosONPath1");
                foreach (DataRow dr in dt.Rows)
                {
                    string originalname = "" + dr["originalname"].ToString();
                    string image = "" + dr["imagename"].ToString();
                    string ext = "" + dr["imageextension"].ToString();
                    string size = "" + dr["imagesize"].ToString();
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

                    photosLikesPath1 = likes;
                    photosSizePath1 = size;
                    photosViewsPath1 = views;

                    photosONPath1 = originalname;

                    photosPath1 = System.Configuration.ConfigurationManager.AppSettings["customerDataPath1"] + companyidlbl.Text + "\\" + customeridlbl.Text + "\\" + "photos" + "\\" + s + "\\" + image + ext;
                    photosNamePath1 = HttpUtility.HtmlEncode(Path.GetFileName(photosPath1));
                    dt1.Rows.Add(photosPath1, photosNamePath1, photosSizePath1, photosLikesPath1, photosViewsPath1, photosONPath1);
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