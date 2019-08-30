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

public partial class gallery_albums : System.Web.UI.Page
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
        
    }
     public void customerDetails()
    {
        string coid1 = Session["coid"].ToString();
        string cid1 = Session["cid"].ToString();
        customeridlbl.Text = cid1;
        companyidlbl.Text = coid1;
        gallerynamelbl.Text = Request.QueryString["gname"].ToString();
        
    }

    protected void backbtn_Click(object sender, EventArgs e)
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
    public void displayEvents()
    {
        eventnamelbl.Text = Request.QueryString["albumid"].ToString();
        string s = eventnamelbl.Text;
        string albumsPhotoPath1;
        string albumsPhotoNamePath1;
        string albumsPhotoONPath1;
        {
            string s1 = "select originalname, filename, fileextension from albumdetails where customerid='" + customeridlbl.Text + "' AND albumid='" + s + "' AND category='" + "albums" + "' order by originalname asc";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            try
            {
                SqlCommand cmd = new SqlCommand(s1, con);
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                da.Fill(dt);
                dt1.Columns.Add("albumsPhotoPath1");
                dt1.Columns.Add("albumsPhotoNamePath1");
                dt1.Columns.Add("albumsPhotoONPath1");

                foreach (DataRow dr in dt.Rows)
                {
                    string originalname = "" + dr["originalname"].ToString();
                    string photo = "" + dr["filename"].ToString();
                    string ext = "" + dr["fileextension"].ToString();

                    albumsPhotoONPath1 = originalname;


                    albumsPhotoPath1 = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + companyidlbl.Text + "\\" + customeridlbl.Text + "\\" + "albums" + "\\" + gallerynamelbl.Text + "\\" + s + "\\" + photo + ext;
                    albumsPhotoNamePath1 = HttpUtility.HtmlEncode(Path.GetFileNameWithoutExtension(albumsPhotoPath1));
                    dt1.Rows.Add(albumsPhotoPath1, albumsPhotoNamePath1, albumsPhotoONPath1);
                }
                Repeater1.DataSource = dt1;
                Repeater1.DataBind();
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
  
    protected void Refresh_Click(object sender, EventArgs e)
    {
        try
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            Response.Redirect(url);
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
    protected void photodelete_Click(object sender, ImageClickEventArgs e)
    {
        bool isdeleted;
        foreach (RepeaterItem item in Repeater1.Items)
        {
            isdeleted = ((CheckBox)item.FindControl("chck")).Checked;
            if (isdeleted)
            {
                try
                {
                    System.Web.UI.WebControls.Image i = (System.Web.UI.WebControls.Image)item.FindControl("Image1");
                    Label lbl = (Label)item.FindControl("filenamelbl");

                    string s = i.ImageUrl;
                    string path1 = Server.MapPath(s);

                    if (File.Exists(path1))
                    {

                        File.Delete(path1);

                    }
                    try
                    {
                        string[] split = lbl.Text.Split('.');
                        string filename = lbl.Text;
                        string dltact = "delete from albumdetails where filename='" + filename + "'";
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
                        string url = HttpContext.Current.Request.Url.AbsoluteUri;
                        Response.Redirect(url);
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
   
    
}