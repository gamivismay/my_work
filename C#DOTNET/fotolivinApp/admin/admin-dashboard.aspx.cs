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

public partial class admin_dashboard : System.Web.UI.Page
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
                userCount();
                companyDetails();
                customerCount();
                viewsDetails();
                likesDetails();
                storageDetails();
                companyCount();
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
            Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later. If still problem persist than contact admin');if(alert){ window.location='admin-dashboard';}</script>");

        }
    }
    public void companyDetails()
    {
        string u1 = Session["au"].ToString();
        string p1 = Session["ap"].ToString();
        string s1 = "select * from admin where email='"+u1+"'";
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
                editcompanynametb.Text = "" + dr["fullname"].ToString();
                editemailtb.Text = "" + dr["email"].ToString();
                editpasswordtb.Text = "" + dr["password"].ToString();
                editphonetb.Text = "" + dr["phone"].ToString();
                smsapikeytb.Text = "" + dr["smsapikey"].ToString();
                smsuseridtb.Text = "" + dr["smsuserid"].ToString();
                smssenderidtb.Text = "" + dr["smssenderid"].ToString();
 
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
    public void viewsDetails()
    {
        string u1 = Session["au"].ToString();
        string p1 = Session["ap"].ToString();
        {
            string s1 = "select views from albumdetails";
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
                int a = 0;
                if (dt.Rows.Count > 0)
                    foreach (DataRow dr in dt.Rows)
                    {
                        a += Int32.Parse(dr["views"].ToString());
                        albumsviewhf.Value = a.ToString();
                    }
                else
                {
                    albumsviewhf.Value = a.ToString();
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
        {
            string s1 = "select views from exploredetails";
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
                int a = 0;
                if (dt.Rows.Count > 0)
                    foreach (DataRow dr in dt.Rows)
                    {
                        a += Int32.Parse(dr["views"].ToString());
                        exploreviewhf.Value = a.ToString();
                    }
                else
                {
                    exploreviewhf.Value = a.ToString();
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
        {
            string s1 = "select views from photodetails";
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
                int a = 0;
                if (dt.Rows.Count > 0)
                    foreach (DataRow dr in dt.Rows)
                    {
                        a += Int32.Parse(dr["views"].ToString());
                        photoviewhf.Value = a.ToString();
                    }
                else
                {
                    photoviewhf.Value = a.ToString();
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
        {
            string s1 = "select views from videodetails";
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
                int a = 0;
                if (dt.Rows.Count > 0)
                    foreach (DataRow dr in dt.Rows)
                    {
                        a += Int32.Parse(dr["views"].ToString());
                        videoviewhf.Value = a.ToString();
                    }
                else
                {
                    videoviewhf.Value = a.ToString();
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
        displayviews1.Text = (Convert.ToInt32(albumsviewhf.Value) + Convert.ToInt32(exploreviewhf.Value) + Convert.ToInt32(photoviewhf.Value) + Convert.ToInt32(videoviewhf.Value)).ToString();
        displayviews2.Text = (Convert.ToInt32(albumsviewhf.Value) + Convert.ToInt32(exploreviewhf.Value) + Convert.ToInt32(photoviewhf.Value) + Convert.ToInt32(videoviewhf.Value)).ToString();
    }
    public void likesDetails()
    {
        string u1 = Session["au"].ToString();
        string p1 = Session["ap"].ToString();
        {
            string s1 = "select likes from albumdetails";
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
                int a = 0;
                if (dt.Rows.Count > 0)
                    foreach (DataRow dr in dt.Rows)
                    {
                        a += Int32.Parse(dr["likes"].ToString());
                        albumslikehf.Value = a.ToString();
                    }
                else
                {
                    albumslikehf.Value = a.ToString();
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
        {
            string s1 = "select likes from exploredetails";
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
                int a = 0;
                if (dt.Rows.Count > 0)
                    foreach (DataRow dr in dt.Rows)
                    {
                        a += Int32.Parse(dr["likes"].ToString());
                        explorelikehf.Value = a.ToString();
                    }
                else
                {
                    explorelikehf.Value = a.ToString();
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
        {
            string s1 = "select likes from photodetails";
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
                int a = 0;
                if (dt.Rows.Count > 0)
                    foreach (DataRow dr in dt.Rows)
                    {
                        a += Int32.Parse(dr["likes"].ToString());
                        photolikehf.Value = a.ToString();
                    }
                else
                {
                    photolikehf.Value = a.ToString();
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
        {
            string s1 = "select likes from videodetails";
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
                int a = 0;
                if (dt.Rows.Count > 0)
                    foreach (DataRow dr in dt.Rows)
                    {
                        a += Int32.Parse(dr["likes"].ToString());
                        videolikehf.Value = a.ToString();
                    }
                else
                {
                    videolikehf.Value = a.ToString();
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
        displaylikes1.Text = (Convert.ToInt32(albumslikehf.Value) + Convert.ToInt32(explorelikehf.Value) + Convert.ToInt32(photolikehf.Value) + Convert.ToInt32(videolikehf.Value)).ToString();
        displaylikes2.Text = (Convert.ToInt32(albumslikehf.Value) + Convert.ToInt32(explorelikehf.Value) + Convert.ToInt32(photolikehf.Value) + Convert.ToInt32(videolikehf.Value)).ToString();

    }
    public void storageDetails()
    {
        string u1 = Session["au"].ToString();
        string p1 = Session["ap"].ToString();
        {
            string s1 = "select filesize from albumdetails";
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
                Int64 a = 0;
                if (dt.Rows.Count > 0)
                    foreach (DataRow dr in dt.Rows)
                    {
                        a += Int64.Parse(dr["filesize"].ToString());
                        albumsspacehf.Value = a.ToString();
                    }
                else
                {
                    albumsspacehf.Value = a.ToString();
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
        {
            string s1 = "select filesize from exploredetails";
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
                Int64 a = 0;
                if (dt.Rows.Count > 0)
                    foreach (DataRow dr in dt.Rows)
                    {
                        a += Int64.Parse(dr["filesize"].ToString());
                        explorespacehf.Value = a.ToString();
                    }
                else
                {
                    explorespacehf.Value = a.ToString();
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
        {
            string s1 = "select imagesize from photodetails";
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
                Int64 a = 0;
                if (dt.Rows.Count > 0)
                    foreach (DataRow dr in dt.Rows)
                    {
                        a += Int64.Parse(dr["imagesize"].ToString());
                        photospacehf.Value = a.ToString();
                    }
                else
                {
                    photospacehf.Value = a.ToString();
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
        {
            string s1 = "select videosize from videodetails";
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
                Int64 a = 0;
                if (dt.Rows.Count > 0)
                    foreach (DataRow dr in dt.Rows)
                    {
                        a += Int64.Parse(dr["videosize"].ToString());
                        videospacehf.Value = a.ToString();
                    }
                else
                {
                    videospacehf.Value = a.ToString();
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
        long lBytes = (Convert.ToInt64(albumsspacehf.Value) + Convert.ToInt64(explorespacehf.Value) + Convert.ToInt64(photospacehf.Value) + Convert.ToInt64(videospacehf.Value));
        ConvertBytes(lBytes);
        displayspace2.Text = displayspace1.Text;

    }
    public string ConvertBytes(long lBytes)
    {
        string sSize = string.Empty;
        displayspace1.Text = "0";

        if (lBytes >= 1073741824)
        {
            Int64 a = lBytes;
            Int64 b = 1073741824;
            double div = (double)a / b;
            displayspace1.Text = String.Format("{0:0.00}", div) + " GB";
        }
        else if (lBytes >= 1048576)
            displayspace1.Text = String.Format("{0:D}", lBytes / 1048576) + " MB";
        else if (lBytes >= 1024)
            displayspace1.Text = String.Format("{0:##.##}", lBytes / 1024) + " KB";
        else if (lBytes > 0 && lBytes < 1024)
            displayspace1.Text = lBytes.ToString() + " bytes";

        return displayspace1.Text;
    }
    public void customerCount()
    {
        string s1 = "select id from customerdetails";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd = new SqlCommand(s1, con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            customerlbl.Text = "" + ds.Tables[0].Rows.Count.ToString();


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
            Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='admin-dashboard';}</script>");

        }
        finally
        {
            con.Close();

        }
    }
    public void userCount()
    {
        string s1 = "select * from loginusers";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd = new SqlCommand(s1, con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            userslbl.Text = "" + ds.Tables[0].Rows.Count.ToString();
            

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
    public void companyCount()
    {
        string s1 = "select id from companydetails";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd = new SqlCommand(s1, con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            companylbl.Text = "" + ds.Tables[0].Rows.Count.ToString();


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
    
    protected void updateinfobtn_Click(object sender, EventArgs e)
    {
        string u1 = Session["au"].ToString();
        string s1 = "update admin set fullname='" + editcompanynametb.Text + "', email='" + editemailtb.Text + "',password='" + editpasswordtb.Text + "',phone='"+editphonetb.Text+"', smsapikey='"+smsapikeytb.Text+"', smsuserid='"+smsuseridtb.Text+"', smssenderid='"+smssenderidtb.Text+"' where email='"+u1+"'";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd = new SqlCommand(s1, con);
            con.Open();
            cmd.ExecuteNonQuery();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("admin-login");
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
   
}