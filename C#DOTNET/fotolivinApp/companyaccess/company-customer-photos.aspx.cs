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

public partial class company_customer_photos : System.Web.UI.Page
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
    protected void albumbtn_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("company-customer-albums");
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
        string eventsPath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath1"] + companyidlbl.Text + "\\" + customeridlbl.Text + "\\" + "photos";
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
            eventsCoverPath1 = System.Configuration.ConfigurationManager.AppSettings["customerDataPath1"] + companyidlbl.Text + "\\" + customeridlbl.Text + "\\" + "photos" + "\\" + d1.Name + "\\" + "cover" + "\\" + customeridlbl.Text + d1.Name + ".jpg";
            dt.Rows.Add(eventsPath1, eventsCoverPath1);
        }
        eventsdl.DataSource = dt;
        eventsdl.DataBind();
    }
  
    protected void eventsib_Click(object sender, ImageClickEventArgs e)
    {
        DataList dl = (DataList)FindControl("eventsdl");
        ImageButton b = sender as ImageButton;
        DataListItem di = (DataListItem)b.NamingContainer;
        Label l = (Label)di.FindControl("eventslbl");
        string s = l.Text;
        string url = "company-gallery-photos" + "?" + "gname=" + s;
        Response.Redirect(url);
      
       
    }
   
}