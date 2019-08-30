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

public partial class admin_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void signinbtn_Click(object sender, EventArgs e)
    {
        string s1 = "select email,password from admin where email='" + usernametb.Text + "' AND password='" + passwordtb.Text + "'";
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
            if (dt.Rows.Count > 0)
            {
                Session["au"] = usernametb.Text;
                Session["ap"] = passwordtb.Text;
                Response.Redirect("admin-dashboard");
            }
            else
            {
                Page.RegisterStartupScript("UserMsg", "<script>alert('Wrong username or password');if(alert){ window.location='admin-login';}</script>");

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
            Page.RegisterStartupScript("UserMsg", "<script>alert('Login Failed. Try again later');if(alert){ window.location='admin-login';}</script>");

        }
        finally
        {
            con.Close();

        }
    }
   
}