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

public partial class menu : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["u"] == null || Session["p"] == null || Session["coid"] == null || Session["oid"] == null)
        {
            Response.Redirect("login");
        }
        try
        {
            if (!IsPostBack)
            {
                companyDetails();
                companyProfileImage();
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
            Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later. If still problem persist than contact admin');if(alert){ window.location='login';}</script>");

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
        Response.Redirect("login");
    }
    protected void dashboardbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("dashboard");
    }
    protected void createnewcustomerbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("create-account");
    }
    protected void registeredusersbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("registered-users");
    }
    protected void registeredcustomersbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("registered-customers");
    }
    protected void explorebtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("explore");
    }
    protected void products_Click(object sender, EventArgs e)
    {
        Response.Redirect("products");
    }
    protected void orderhistorybtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("order-history");
    }
    protected void smsbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("sms");
    }
    protected void offerbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("offer");
    }
    protected void aboutusbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("about-us");
    }
    protected void contactbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("contact-us");
    }
    protected void privacypolicybtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("privacy-policy");
    }
    protected void faqsbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("faqs");
    }

    public void companyDetails()
    {
        string coid1 = Session["coid"].ToString();
        string s1 = "select companyname, companyid from companydetails where companyid='"+coid1+"'";
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
                companynamelbl.Text = "" + dr["companyname"].ToString();
                companyidlbl.Text = "" + dr["companyid"].ToString();
                
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
            Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='login';}</script>");

        }
        finally
        {
            con.Close();

        }
    }
    public void companyProfileImage()
    {
        string companyProfImgPath = System.Configuration.ConfigurationManager.AppSettings["companyDataPath"] + companyidlbl.Text + "\\" + "profileimage";
        string companyProfImgPath1;
        DirectoryInfo dir = new DirectoryInfo(MapPath(companyProfImgPath));
        FileInfo[] file = dir.GetFiles();
        DataTable dt = new DataTable();
        dt.Columns.Add("companyProfImgPath1");
        foreach (FileInfo image in file)
        {
            if (image.Exists)
            {
                if (image.Extension.ToLower() == ".jpg" || image.Extension.ToLower() == ".jpeg")
                {
                    companyProfImgPath1 = companyProfImgPath + "\\" + companyidlbl.Text + "profile" + ".jpg";

                    dt.Rows.Add(companyProfImgPath1);
                }

            }
            
        }

        Repeater1.DataSource = dt;
        Repeater1.DataBind();
    }
}
