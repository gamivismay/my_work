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

public partial class company_profile : System.Web.UI.Page
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
                displayProfileImage();
                displayCoverImage();
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
     public void companyDetails()
    {
        string coid1 = Session["coid"].ToString();
        string s1 = "select * from companydetails where companyid='" + coid1 + "'";
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
                editfullnametb.Text = "" + dr["fullname"].ToString();
                editcompanynametb.Text = "" + dr["companyname"].ToString();
                editaddresstb.Text = "" + dr["address"].ToString();
                editemailtb.Text = "" + dr["email"].ToString();
                editpasswordtb.Text = "" + dr["password"].ToString();
                editphonetb.Text = "" + dr["phone"].ToString();
                editcitytb.Text = "" + dr["city"].ToString();
                editstatetb.Text = "" + dr["state"].ToString();
                editcountrytb.Text = "" + dr["country"].ToString();
                editaboutinfotb.Text = "" + dr["about"].ToString();
                editachievementtb.Text = "" + dr["achievement"].ToString();
                editsmscreditslbl.Text = "" + dr["smscredit"].ToString();
                editsmssenderidlbl.Text = "" + dr["smssenderid"].ToString();
                editcompanyidlbl.Text = "" + dr["companyid"].ToString();
                editsampleaccountidlbl.Text = "" + dr["sampleaccountid"].ToString();
                editdatelbl.Text = "" + dr["date"].ToString();
                editfblinktb.Text = "" + dr["fblink"].ToString();
                editinstagramlinktb.Text = "" + dr["instagramlink"].ToString();
                editgooglepluslinktb.Text = "" + dr["googlepluslink"].ToString();
                edittwitterlinktb.Text = "" + dr["twitterlink"].ToString();
                edityoutubelinktb.Text = "" + dr["youtubelink"].ToString();
                editwebsitelinktb.Text = "" + dr["websitelink"].ToString();

                displaycompanyidlbl.Text = "" + dr["companyid"].ToString();
                displaycompanynamelbl.Text = "" + dr["companyname"].ToString();
            }
            dr.Close();
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
   
    
   
    protected void updateinfobtn_Click(object sender, EventArgs e)
    {
        if (editcompanynametb.Text == "")
        {
            editcompanynametb.Text = "null";
        }
        if (editaddresstb.Text == "")
        {
            editaddresstb.Text = "null";
        }
        if (editphonetb.Text == "")
        {
            editphonetb.Text = "null";
        }
        if (editaboutinfotb.Text == "")
        {
            editaboutinfotb.Text = "null";
        }
        if (editachievementtb.Text == "")
        {
            editachievementtb.Text = "null";
        }
        if(editfullnametb.Text == "")
        {
            editfullnametb.Text = "null";
        }
        if(editfblinktb.Text == "")
        {
            editfblinktb.Text = "null";
        }
        if(editinstagramlinktb.Text == "")
        {
            editinstagramlinktb.Text = "null";
        }
        if (editgooglepluslinktb.Text == "")
        {
            editgooglepluslinktb.Text = "null";
        }
        if (edittwitterlinktb.Text == "")
        {
            edittwitterlinktb.Text = "null";
        }
        if (edityoutubelinktb.Text == "")
        {
            edityoutubelinktb.Text = "null";
        }
        if (editwebsitelinktb.Text == "")
        {
            editwebsitelinktb.Text = "null";
        }
        string s1 = "update companydetails set fullname='" + editfullnametb.Text + "', companyname='" + editcompanynametb.Text + "',address='" + editaddresstb.Text + "',email='" + editemailtb.Text + "',phone='" + editphonetb.Text + "',city='" + editcitytb.Text + "',state='" + editstatetb.Text + "',country='" + editcountrytb.Text + "',about='" + editaboutinfotb.Text + "',achievement='" + editachievementtb.Text + "',fblink='" + editfblinktb.Text + "',instagramlink='" + editinstagramlinktb.Text + "',googlepluslink='" + editgooglepluslinktb.Text + "',twitterlink='" + edittwitterlinktb.Text + "',youtubelink='" + edityoutubelinktb.Text + "',websitelink='" + editwebsitelinktb.Text + "',password='" + editpasswordtb.Text + "', sampleaccountid='" + editsampleaccountidlbl.Text + "' where companyid='" + editcompanyidlbl.Text + "'";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd = new SqlCommand(s1, con);
            con.Open();
            cmd.ExecuteNonQuery();
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
    protected void photobtn_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("service");
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
    protected void videobtn_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("dashboard");
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

   public void displayProfileImage()
    {
        string companyid = Session["coid"].ToString();
        string companyProfImgPath = System.Configuration.ConfigurationManager.AppSettings["companyDataPath"] + companyid + "\\" + "profileimage"; ;
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
                    companyProfImgPath1 = companyProfImgPath + "\\" + companyid + "profile" + ".jpg";

                    dt.Rows.Add(companyProfImgPath1);
                }

            }

        }

        Repeater2.DataSource = dt;
        Repeater2.DataBind();
    }

    public void displayCoverImage()
    {
        string companyid = Session["coid"].ToString();
        string companyCoverImgPath = System.Configuration.ConfigurationManager.AppSettings["companyDataPath"] + companyid + "\\" + "coverimage";
        string companyCoverImgPath1;
        DirectoryInfo dir = new DirectoryInfo(MapPath(companyCoverImgPath));
        FileInfo[] file = dir.GetFiles();
        DataTable dt = new DataTable();
        dt.Columns.Add("companyCoverImgPath1");
        foreach (FileInfo image in file)
        {
            if (image.Exists)
            {
                if (image.Extension.ToLower() == ".jpg" || image.Extension.ToLower() == ".jpeg")
                {
                    companyCoverImgPath1 = companyCoverImgPath + "\\" + companyid + "cover" + ".jpg";

                    dt.Rows.Add(companyCoverImgPath1);
                }

            }

        }

        Repeater1.DataSource = dt;
        Repeater1.DataBind();
    }

   

    protected void refresh_Click(object sender, EventArgs e)
    {
        Response.Redirect("company-profile");
    }
}