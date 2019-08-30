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

public partial class admin_create_user : System.Web.UI.Page
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
        string address = "";
        string city = "";
        string state = "";
        string pincode = "";
        string accountname = "register";
        string devicetype = "";
        string devicetoken = "";
        string loginstatus = "0";
        string userstatus = "0";


        DateTime datetime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
        
        string insert = "insert into loginusers values('" + usernametb.Text + "','" + emailtb.Text + "','" + passwordtb.Text + "','"+phonetb.Text+"','"+address+"','"+city+"','"+state+"','"+pincode+"','"+birthdatetb.Text+"','"+companyidtb.Text+"','"+customeridtb.Text+"','"+accountname+"','"+devicetype+"','"+devicetoken+"','"+loginstatus+"','"+userstatus+"','" + datetime + "')";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            string userpath = System.Configuration.ConfigurationManager.AppSettings["userDataPath1"] + emailtb.Text;
            Directory.CreateDirectory(Server.MapPath(userpath));
            string orderpath = System.Configuration.ConfigurationManager.AppSettings["userDataPath1"] + emailtb.Text + "\\" + "order";
            Directory.CreateDirectory(Server.MapPath(orderpath));
                
            SqlCommand cmd = new SqlCommand(insert, con);
            con.Open();
            cmd.ExecuteNonQuery();
            Page.RegisterStartupScript("UserMsg", "<script>alert('Account created.');if(alert){ window.location='admin-create-user';}</script>");

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

            Page.RegisterStartupScript("UserMsg", "<script>alert('Account creation failed. Try again later');if(alert){ window.location='admin-create-user';}</script>");

        }
        finally
        {
            con.Close();

        }
    } 
}