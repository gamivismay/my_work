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

public partial class create_account : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["u"] == null || Session["p"] == null || Session["coid"] == null || Session["oid"] == null)
        {
            Response.Redirect("login");
        }
    }
  
    protected void customercreateaccountbtn_Click(object sender, EventArgs e)
    {
        int digit = Convert.ToInt32("6");
        string allowedChars = "";
        allowedChars = "1,2,3,4,5,6,7,8,9,0";
        char[] sep = { ',' };
        string[] arr = allowedChars.Split(sep);
        string precustomerid = "";
        string temp = "";
        Random rand = new Random();
        for (int i = 0; i < Convert.ToInt32(digit); i++)
        {
            temp = arr[rand.Next(0, arr.Length)];
            precustomerid += temp;

        }
        string coidlbl = ((Label)Master.FindControl("companyidlbl")).Text;
        string finalcustomerid = coidlbl + precustomerid;
        DateTime datetime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time")); 
        
        string insert = "insert into customerdetails values('"+coidlbl+"','"+finalcustomerid+"','"+customerfullnametb.Text+"','"+customersecondnametb.Text+"','"+customeremailtb.Text+"','"+customerphonetb.Text+"','"+customercitytb.Text+"','"+customerstatetb.Text+"','"+customercountrytb.Text+"','"+datetime+"')";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            string customergallerypath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + coidlbl + "\\" + finalcustomerid;
            Directory.CreateDirectory(Server.MapPath(customergallerypath));
            string customerphotospath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + coidlbl + "\\" + finalcustomerid + "\\" + "photos";
            Directory.CreateDirectory(Server.MapPath(customerphotospath));
            string customerphotosthumbpath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + coidlbl + "\\" + finalcustomerid + "\\" + "photoscover";
            Directory.CreateDirectory(Server.MapPath(customerphotosthumbpath));
            string customervideospath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + coidlbl + "\\" + finalcustomerid + "\\" + "videos";
            Directory.CreateDirectory(Server.MapPath(customervideospath));
            string customervideosthumbpath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + coidlbl + "\\" + finalcustomerid + "\\" + "videoscover";
            Directory.CreateDirectory(Server.MapPath(customervideosthumbpath));
            string customeralbumspath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + coidlbl + "\\" + finalcustomerid + "\\" + "albums";
            Directory.CreateDirectory(Server.MapPath(customeralbumspath));
            string customeralbumsthumbpath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + coidlbl + "\\" + finalcustomerid + "\\" + "albumscover";
            Directory.CreateDirectory(Server.MapPath(customeralbumsthumbpath));
            string customerprofimgpath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + coidlbl + "\\" + finalcustomerid + "\\" + "profileimage";
            Directory.CreateDirectory(Server.MapPath(customerprofimgpath));
            string customercoverimgpath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + coidlbl + "\\" + finalcustomerid + "\\" + "coverimage";
            Directory.CreateDirectory(Server.MapPath(customercoverimgpath));
            
            SqlCommand cmd = new SqlCommand(insert, con);
            con.Open();
            cmd.ExecuteNonQuery();
            customerfullnametb.Text = "";
            customersecondnametb.Text = "";
            customeremailtb.Text = "";
            customerphonetb.Text = "";
            customercitytb.Text = "";
            customerstatetb.Text = "";
            customercountrytb.Text = "";
            Page.RegisterStartupScript("UserMsg", "<script>alert('Account created..!');if(alert){ window.location='create-account';}</script>");

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
            Page.RegisterStartupScript("UserMsg", "<script>alert('Account creation failed. Try again later');if(alert){ window.location='create-account';}</script>");

        }
        finally
        {
            con.Close();

        }
    }
}