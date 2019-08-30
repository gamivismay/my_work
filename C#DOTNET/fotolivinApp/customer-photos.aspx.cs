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

public partial class customer_photos : System.Web.UI.Page
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
                customerDetails();
                displayEvents();
                displayMainCover();
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
            Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later. If still problem persist than contact admin');if(alert){ window.location='customer-profile';}</script>");

        }
        
        othereventpnl.Visible = true;
    }
     public void customerDetails()
    {
        string coid1 = Session["coid"].ToString();
        string cid1 = Session["cid"].ToString();
        customeridlbl.Text = cid1;
        companyidlbl.Text = coid1;
        
    }

    protected void backbtn_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("customer-profile");
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
            Response.Redirect("customer-videos");
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
            Response.Redirect("customer-albums");
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
    protected void eventsddl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        if(eventsddl1.SelectedIndex == 0)
        {
            othereventpnl.Visible = true;
            eventsddl.Text = othereventnametb.Text;
        }
        else if (eventsddl1.SelectedIndex != 0)
        {
            eventsddl.Text = eventsddl1.Text;
            othereventpnl.Visible = false;
            othereventnametb.Text = "";
        }
    }
    protected void donebtn_Click(object sender, EventArgs e)
    {
        othereventpnl.Visible = true;
        eventsddl.Text = othereventnametb.Text;
    }
    public void displayEvents()
    {
        string eventsPath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + companyidlbl.Text + "\\" + customeridlbl.Text + "\\" + "photos";
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
            eventsCoverPath1 = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + companyidlbl.Text + "\\" + customeridlbl.Text + "\\" + "photos" + "\\" + d1.Name + "\\" + "cover" + "\\" + customeridlbl.Text + d1.Name + ".jpg";
            dt.Rows.Add(eventsPath1, eventsCoverPath1);
        }
        eventsdl.DataSource = dt;
        eventsdl.DataBind();
    }
    public void displayMainCover()
    {
        string coverPath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + companyidlbl.Text + "\\" + customeridlbl.Text + "\\" + "photoscover";
        string coverPath1;
        DirectoryInfo dir = new DirectoryInfo(MapPath(coverPath));
        FileInfo[] file = dir.GetFiles();
        DataTable dt = new DataTable();
        dt.Columns.Add("coverPath1");
        foreach (FileInfo image in file)
        {
            if (image.Exists)
            {
                if (image.Extension.ToLower() == ".jpg" || image.Extension.ToLower() == ".jpeg")
                {
                    coverPath1 = coverPath + "\\" + customeridlbl.Text + "photoscover" + ".jpg";

                    dt.Rows.Add(coverPath1);
                }

            }

        }

        Repeater2.DataSource = dt;
        Repeater2.DataBind();
    }

    protected void eventsib_Click(object sender, ImageClickEventArgs e)
    {
        DataList dl = (DataList)FindControl("eventsdl");
        ImageButton b = sender as ImageButton;
        DataListItem di = (DataListItem)b.NamingContainer;
        Label l = (Label)di.FindControl("eventslbl");
        string s = l.Text;
        string url = "gallery-photos" + "?" + "gname=" + s;
        Response.Redirect(url);
      
       
    }
    public void removedirectories(string strng)
    {
        foreach (string file in Directory.GetFiles(strng))
        {
            File.Delete(file);
        }
        foreach (string subfolder in Directory.GetDirectories(strng))
        {
            removedirectories(subfolder);
        }
        Directory.Delete(strng);

    }
   
    protected void photodirdelete_Click(object sender, ImageClickEventArgs e)
    {
         bool isdeleted;
         foreach (DataListItem item in eventsdl.Items)
         {
             isdeleted = ((CheckBox)item.FindControl("eventschck")).Checked;
             if (isdeleted)
             {
                 try
                 {
                     Label lbl = (Label)item.FindControl("eventslbl");
                     string eventsPath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + companyidlbl.Text + "\\" + customeridlbl.Text + "\\" + "photos" + "\\" + lbl.Text;
                     string strng = Server.MapPath(eventsPath);
                     try
                     {

                         if (Directory.Exists(strng))
                         {
                             foreach (string file in Directory.GetFiles(strng))
                             {
                                 File.Delete(file);
                             }
                             foreach (string subfolder in Directory.GetDirectories(strng))
                             {
                                 removedirectories(subfolder);
                             }
                             Directory.Delete(strng);
                            
                         }


                     }
                     catch (Exception ex)
                     {
                         Exception ex22 = ex;
                         string errorMessage = string.Empty;
                         while (ex22 != null)
                         {
                             errorMessage += ex22.ToString();
                             ex22 = ex22.InnerException;
                         }
                     }
                     try
                     {
                         string dltact = "delete from photodetails where event='" + lbl.Text + "'";
                         SqlConnection conact = new SqlConnection();
                         conact.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                         try
                         {
                             SqlCommand cmdact = new SqlCommand(dltact, conact);
                             conact.Open();
                             cmdact.ExecuteNonQuery();

                         }
                         catch (Exception ex)
                         {
                             throw ex;
                         }
                         finally
                         {
                             conact.Close();
                         }
                     }
                     catch (Exception ex)
                     {
                         Exception ex22 = ex;
                         string errorMessage = string.Empty;
                         while (ex22 != null)
                         {
                             errorMessage += ex22.ToString();
                             ex22 = ex22.InnerException;
                         }
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

                 }

             }
         }
         displayEvents();
    }
    protected void Refresh_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("customer-photos");
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
    protected void refresh1_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("customer-photos");
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
    
}