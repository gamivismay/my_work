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

public partial class admin_menu : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["au"] == null || Session["ap"] == null)
        {
            Response.Redirect("admin-login");
        }
        try
        {
            if (!IsPostBack)
            {
                adminDetails();
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
            Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later. If still problem persist than contact admin');if(alert){ window.location='admin-login';}</script>");

        }
    }
 
    protected void logoutbtn_Click(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "clearHistory", "ClearHistory();", true);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        Response.Cache.SetNoStore();
        Session.RemoveAll();
        Session.Abandon();
        Session.Clear();
        Response.Redirect("admin-login");
    }
    protected void dashboardbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("admin-dashboard");
    }
    protected void createnewadminbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("admin-create-admin");
    }
    
    protected void createnewcustomerbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("admin-create-account");
    }
    protected void createnewuserbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("admin-create-user");
    }
    protected void registeredcustomersbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("admin-registered-customers");
    }
    protected void registeredusersbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("admin-registered-users");
    }
    protected void productsbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("admin-products");
    }
    protected void orderhistorybtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("admin-order-history");
    }
    protected void notificationbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("admin-notification");
    }
    public void adminDetails()
    {
        string u1 = Session["au"].ToString();
        string p1 = Session["ap"].ToString();
        string s1 = "select fullname from admin where email='" + u1 + "'";
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
                companynamelbl.Text = "" + dr["fullname"].ToString();

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
            Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='admin-login';}</script>");

        }
        finally
        {
            con.Close();

        }
    }
}
