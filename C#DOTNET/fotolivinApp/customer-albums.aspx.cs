﻿using System;
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

public partial class customer_albums : System.Web.UI.Page
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
                albumId();
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
        viewalbumthumbpnl.Visible = false;
        
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
    protected void photobtn_Click(object sender, EventArgs e)
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
    protected void eventsddl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        albumId();
        if (eventsddl1.SelectedIndex == 0)
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
    public void albumId()
    {
        int digit = Convert.ToInt32("5");
        string allowedChars = "";
        allowedChars = "1,2,3,4,5,6,7,8,9,0";
        char[] sep = { ',' };
        string[] arr = allowedChars.Split(sep);
        string preimagename = "";
        string temp = "";
        Random rand = new Random();
        for (int i = 0; i < Convert.ToInt32(digit); i++)
        {
            temp = arr[rand.Next(0, arr.Length)];
            preimagename += temp;

        }
        string imageName = preimagename;
        albumidlbl.Text = imageName;
    }
    public void displayEvents()
    {
        string eventsPath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + companyidlbl.Text + "\\" + customeridlbl.Text + "\\" + "albums";
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
        string albumsPath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + companyidlbl.Text + "\\" + customeridlbl.Text + "\\" + "albums" + "\\" + s;
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
            albumsCoverPath1 = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + companyidlbl.Text + "\\" + customeridlbl.Text + "\\" + "albums" + "\\" + s + "\\" + d1.Name + "\\" + "thumb" + "\\" +  customeridlbl.Text + d1.Name + ".jpg";
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
    public void displayMainCover()
    {
        string coverPath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + companyidlbl.Text + "\\" + customeridlbl.Text + "\\" + "albumscover";
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
                    coverPath1 = coverPath + "\\" + customeridlbl.Text + "albumscover" + ".jpg";

                    dt.Rows.Add(coverPath1);
                }

            }

        }

        Repeater2.DataSource = dt;
        Repeater2.DataBind();
    }

    protected void eventsib2_Click(object sender, ImageClickEventArgs e)
    {
        
        DataList dl = (DataList)FindControl("eventsdl2");
        ImageButton b = sender as ImageButton;
        DataListItem di = (DataListItem)b.NamingContainer;
        Label l = (Label)di.FindControl("eventslbl2");
        string s = l.Text;
        string s1 = albumcategorynamelbl.Text;
        string url = "gallery-albums" + "?" + "gname=" + s1 + "&albumid=" + s;
        Response.Redirect(url);
        


    }

    protected void Refresh_Click(object sender, EventArgs e)
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
    protected void refresh1_Click(object sender, EventArgs e)
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

    protected void albumdirdelete_Click(object sender, ImageClickEventArgs e)
    {
        bool isdeleted;
        foreach (DataListItem item in eventsdl1.Items)
        {
            isdeleted = ((CheckBox)item.FindControl("eventschck1")).Checked;
            if (isdeleted)
            {
                try
                {
                    Label lbl = (Label)item.FindControl("eventslbl1");
                    string eventsPath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + companyidlbl.Text + "\\" + customeridlbl.Text + "\\" + "albums" + "\\" + lbl.Text;
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
                        string dltact = "delete from albumdetails where event='" + lbl.Text + "'";
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
    protected void albumthumbdelete_Click(object sender, ImageClickEventArgs e)
    {
        bool isdeleted;
        foreach (DataListItem item in eventsdl2.Items)
        {
            isdeleted = ((CheckBox)item.FindControl("eventschck2")).Checked;
            if (isdeleted)
            {
                try
                {
                    Label lbl = (Label)item.FindControl("eventslbl2");
                    string eventsPath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + companyidlbl.Text + "\\" + customeridlbl.Text + "\\" + "albums" + "\\" + albumcategorynamelbl.Text + "\\" + lbl.Text;
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
                        string dltact = "delete from albumdetails where albumid='" + lbl.Text + "'";
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
    }
}