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

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void signinbtn_Click(object sender, EventArgs e)
    {
        string s1 = "select email,password,companyid from companydetails where email='" + usernametb.Text + "' AND password='" + passwordtb.Text + "'";
        string s2 = "select email from admin where email='" + owneridtb.Text + "'";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd = new SqlCommand(s1, con);
            SqlCommand cmd2 = new SqlCommand(s2, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            da.Fill(dt);
            da2.Fill(dt2);
            if (dt.Rows.Count > 0 && dt2.Rows.Count > 0)
            {
                string id = "" + dt.Rows[0]["companyid"].ToString();
                string id2 = "" + dt2.Rows[0]["email"].ToString();
                Session["u"] = usernametb.Text;
                Session["p"] = passwordtb.Text;
                Session["coid"] = id;
                Session["oid"] = id2;
                Response.Redirect("dashboard");

            }
            else
            {
                Page.RegisterStartupScript("UserMsg", "<script>alert('Wrong username or password');if(alert){ window.location='login';}</script>");

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
            Page.RegisterStartupScript("UserMsg", "<script>alert('Login Failed. Try again later');if(alert){ window.location='login';}</script>");

        }
        finally
        {
            con.Close();

        }
    }
   
}