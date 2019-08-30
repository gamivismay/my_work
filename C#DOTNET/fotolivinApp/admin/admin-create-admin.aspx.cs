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

public partial class admin_create_admin : System.Web.UI.Page
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

        string insert = "insert into admin values('" + fullnametb.Text + "','" + emailtb.Text + "','" + passwordtb.Text + "','" + phonetb.Text + "', '"+smsapikeytb.Text+"', '"+smsuseridtb.Text+"', '"+smssenderidtb.Text+"')";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
           
            SqlCommand cmd = new SqlCommand(insert, con);
            con.Open();
            cmd.ExecuteNonQuery();
            fullnametb.Text = "";
            emailtb.Text = "";
            phonetb.Text = "";
            smsapikeytb.Text = "";
            smsuseridtb.Text = "";
            smssenderidtb.Text = "";
            Page.RegisterStartupScript("UserMsg", "<script>alert('Account created.');if(alert){ window.location='admin-create-admin';}</script>");

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

            Page.RegisterStartupScript("UserMsg", "<script>alert('Account creation failed. Try again later');if(alert){ window.location='admin-create-admin';}</script>");

        }
        finally
        {
            con.Close();

        }
    } 
}