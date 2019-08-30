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

public partial class company_customer_albums : System.Web.UI.Page
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
        viewalbumthumbpnl.Visible = false;

    }
     public void customerDetails()
    {
        string coid1 = Session["ccoid"].ToString();
        string cid1 = Session["ccid"].ToString();
        customeridlbl.Text = cid1;
        companyidlbl.Text = coid1;
        
    }

    protected void backbtn_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("company-customer-profile");
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
    protected void photobtn_Click(object sender, EventArgs e)
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
    protected void videobtn_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("company-customer-videos");
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
        string eventsPath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath1"] + companyidlbl.Text + "\\" + customeridlbl.Text + "\\" + "albums";
        string eventsPath1;
        string eventsCoverPath1;
        DirectoryInfo dir = new DirectoryInfo(MapPath(eventsPath));
        DirectoryInfo[] d = dir.GetDirectories();
        DataTable dt = new DataTable();
        dt.Columns.Add("eventsPath1");
        dt.Columns.Add("eventsCoverPath1");
        foreach (DirectoryInfo d1 in d)
        {
            eventsPath1 = d1.Name;
            dt.Rows.Add(eventsPath1);
        }
        eventsdl1.DataSource = dt;
        eventsdl1.DataBind();
    }
    
    protected void eventsib1_Click(object sender, ImageClickEventArgs e)
    {
        
        viewalbumthumbpnl.Visible = true;
        DataList dl = (DataList)FindControl("eventsdl1");
        ImageButton b = sender as ImageButton;
        DataListItem di = (DataListItem)b.NamingContainer;
        Label l = (Label)di.FindControl("eventslbl1");
        string s = l.Text;
        albumcategorynamelbl.Text = s;
        string albumsPath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath1"] + companyidlbl.Text + "\\" + customeridlbl.Text + "\\" + "albums" + "\\" + s;
        string albumsPath1;
        string albumsCoverPath1;
        string albumsPhotoLikesPath1;
        string albumsPhotoViewsPath1;
        DirectoryInfo dir = new DirectoryInfo(MapPath(albumsPath));
        DirectoryInfo[] d = dir.GetDirectories();
        DataTable dt = new DataTable();
        dt.Columns.Add("albumsPath1");
        dt.Columns.Add("albumsCoverPath1");
        dt.Columns.Add("albumsPhotoLikesPath1");
        dt.Columns.Add("albumsPhotoViewsPath1");
        foreach (DirectoryInfo d1 in d)
        {
            string s1 = "select * from albumdetails where customerid='" + customeridlbl.Text + "' AND albumid='" + d1 + "' AND category='" + "cover" + "'";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd = new SqlCommand(s1, con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            string likes = "" + dr["likes"].ToString();
            string views = "" + dr["views"].ToString();
            albumsPhotoLikesPath1 = likes;
            albumsPhotoViewsPath1 = views;
            dr.Close();
            albumsPath1 = d1.Name;
            albumsCoverPath1 = System.Configuration.ConfigurationManager.AppSettings["customerDataPath1"] + companyidlbl.Text + "\\" + customeridlbl.Text + "\\" + "albums" + "\\" + s + "\\" + d1.Name + "\\" + "thumb" + "\\" + customeridlbl.Text + d1.Name + ".jpg";
            dt.Rows.Add(albumsPath1, albumsCoverPath1, albumsPhotoLikesPath1, albumsPhotoViewsPath1);
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

        
        eventsdl2.DataSource = dt;
        eventsdl2.DataBind();
    }
   
    protected void eventsib2_Click(object sender, ImageClickEventArgs e)
    {
        DataList dl = (DataList)FindControl("eventsdl2");
        ImageButton b = sender as ImageButton;
        DataListItem di = (DataListItem)b.NamingContainer;
        Label l = (Label)di.FindControl("eventslbl2");
        string s = l.Text;
        string s1 = albumcategorynamelbl.Text;
        string url = "company-gallery-albums" + "?" + "gname=" + s1 + "&albumid=" + s;
        Response.Redirect(url);

    }

   
}