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

public partial class admin_create_account : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["au"] == null || Session["ap"] == null)
        {
            Response.Redirect("admin-login");
        }
    }
    protected void companycreateaccountbtn_Click(object sender, EventArgs e)
    {
        int digit = Convert.ToInt32("6");
        string allowedChars = "";
        allowedChars = "1,2,3,4,5,6,7,8,9,0";
        char[] sep = { ',' };
        string[] arr = allowedChars.Split(sep);
        string precompanyid = "";
        string temp = "";
        Random rand = new Random();
        for (int i = 0; i < Convert.ToInt32(digit); i++)
        {
            temp = arr[rand.Next(0, arr.Length)];
            precompanyid += temp;

        }
        string finalcompanyid = precompanyid;
        DateTime datetime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
        string about = "";
        string service = "";
        string achievement = "";
        string facebook = "";
        string instagram = "";
        string googleplus = "";
        string twitterlink = "";
        string youtubelink = "";
        string website = "";
        string sampleaccountid = "";
        string insert = "insert into companydetails values('" + fullnametb.Text + "','" + companynametb.Text + "','" + addresstb.Text + "','" + emailtb.Text + "','" + phonetb.Text + "','" + citytb.Text + "','" + statetb.Text + "','" + countrytb.Text + "','" + about + "','" + achievement + "','"+facebook+"','"+instagram+"','"+googleplus+"','"+twitterlink+"','"+youtubelink+"','"+website+"','" + smscredittb.Text + "','" + smsapikeytb.Text + "','" + smsuseridtb.Text + "','" + smssenderidtb.Text + "','" + finalcompanyid + "','"+sampleaccountid+"','" + passwordtb.Text + "','" + "" + "','"+""+"','" + datetime + "')";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            string companyidpath1 = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + finalcompanyid;
            Directory.CreateDirectory(Server.MapPath(companyidpath1));
            string companyidpath2 = System.Configuration.ConfigurationManager.AppSettings["customerDataPath1"] + finalcompanyid;
            Directory.CreateDirectory(Server.MapPath(companyidpath2));
            string companyprofimgpath = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + finalcompanyid + "\\" + "profileimage";
            Directory.CreateDirectory(Server.MapPath(companyprofimgpath));
            string companycoverimgpath = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + finalcompanyid + "\\" + "coverimage";
            Directory.CreateDirectory(Server.MapPath(companycoverimgpath));
            string companyexplorepath = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + finalcompanyid + "\\" + "explore";
            Directory.CreateDirectory(Server.MapPath(companyexplorepath));
            string companyexploreimagepath = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + finalcompanyid + "\\" + "explore" + "\\" + "photo";
            Directory.CreateDirectory(Server.MapPath(companyexploreimagepath));
            string companyproductpath = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + finalcompanyid + "\\" + "productdata";
            Directory.CreateDirectory(Server.MapPath(companyproductpath));
            string companyservicepath = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + finalcompanyid + "\\" + "service";
            Directory.CreateDirectory(Server.MapPath(companyservicepath));
            string companyadpath = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + finalcompanyid + "\\" + "addata";
            Directory.CreateDirectory(Server.MapPath(companyadpath));
            
            SqlCommand cmd = new SqlCommand(insert, con);
            con.Open();
            cmd.ExecuteNonQuery();
            fullnametb.Text = "";
            companynametb.Text = "";
            addresstb.Text = "";
            emailtb.Text = "";
            phonetb.Text = "";
            citytb.Text = "";
            statetb.Text = "";
            countrytb.Text = "";
            smscredittb.Text = "";
            smsapikeytb.Text = "";
            smsuseridtb.Text = "";
            smssenderidtb.Text = "";

            Page.RegisterStartupScript("UserMsg", "<script>alert('Account created.');if(alert){ window.location='admin-create-account';}</script>");

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

            Page.RegisterStartupScript("UserMsg", "<script>alert('Account creation failed. Try again later');if(alert){ window.location='admin-create-account';}</script>");

        }
        finally
        {
            con.Close();

        }
    } 
}