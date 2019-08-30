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

public partial class company_dashboard : System.Web.UI.Page
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
                companyDetails();
                customerCount();
                userCount();
                viewsDetails();
                likesDetails();
                storageDetails();
                smsDetails();
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
            Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later. If still problem persist than contact admin');if(alert){ window.location='company-login';}</script>");

        }

    }
     public void companyDetails()
    {
        string u1 = Session["cu"].ToString();
        string p1 = Session["cp"].ToString();
        string coid1 = Session["ccoid"].ToString();
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
            Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='company-login';}</script>");

        }
        finally
        {
            con.Close();

        }
    }
    public void viewsDetails()
    {
        string u1 = Session["cu"].ToString();
        string p1 = Session["cp"].ToString();
        string coid1 = Session["ccoid"].ToString();
        {
            string s1 = "select views from albumdetails where companyid='" + coid1 + "' AND category='"+"cover"+"'";
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
                Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='company-login';}</script>");

            }
            finally
            {
                con.Close();

            }
        }
        {
            string s1 = "select views from exploredetails where companyid='" + coid1 + "'";
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
                Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='company-login';}</script>");

            }
            finally
            {
                con.Close();

            }
        }
        {
            string s1 = "select views from photodetails where companyid='" + coid1 + "'";
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
                Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='company-login';}</script>");

            }
            finally
            {
                con.Close();

            }
        }
        {
            string s1 = "select views from videodetails where companyid='" + coid1 + "'";
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
                Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='company-login';}</script>");

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
        string u1 = Session["cu"].ToString();
        string p1 = Session["cp"].ToString();
        string coid1 = Session["ccoid"].ToString();
        {
            string s1 = "select likes from albumdetails where companyid='" + coid1 + "' AND category='"+"cover"+"'";
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
                Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='company-login';}</script>");

            }
            finally
            {
                con.Close();

            }
        }
        {
            string s1 = "select likes from exploredetails where companyid='" + coid1 + "'";
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
                Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='company-login';}</script>");

            }
            finally
            {
                con.Close();

            }
        }
        {
            string s1 = "select likes from photodetails where companyid='" + coid1 + "'";
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
                Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='company-login';}</script>");

            }
            finally
            {
                con.Close();

            }
        }
        {
            string s1 = "select likes from videodetails where companyid='" + coid1 + "'";
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
                Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='company-login';}</script>");

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
        string u1 = Session["cu"].ToString();
        string p1 = Session["cp"].ToString();
        string coid1 = Session["ccoid"].ToString();
        {
            string s1 = "select filesize from albumdetails where companyid='" + coid1 + "'";
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
                Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='company-login';}</script>");

            }
            finally
            {
                con.Close();

            }
        }
        {
            string s1 = "select filesize from exploredetails where companyid='" + coid1 + "'";
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
                Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='company-login';}</script>");

            }
            finally
            {
                con.Close();

            }
        }
        {
            string s1 = "select imagesize from photodetails where companyid='" + coid1 + "'";
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
                Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='company-login';}</script>");

            }
            finally
            {
                con.Close();

            }
        }
        {
            string s1 = "select videosize from videodetails where companyid='" + coid1 + "'";
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
                Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='company-login';}</script>");

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
        string u1 = Session["cu"].ToString();
        string p1 = Session["cp"].ToString();
        string coid1 = Session["ccoid"].ToString();
        string s1 = "select id from customerdetails where companyid='" + coid1 + "'";
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
            displaycustomers1.Text = "" + ds.Tables[0].Rows.Count.ToString();
            displaycustomers2.Text = "" + ds.Tables[0].Rows.Count.ToString();
           
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
            Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='company-login';}</script>");

        }
        finally
        {
            con.Close();

        }
    }
    public void userCount()
    {
        string u1 = Session["cu"].ToString();
        string p1 = Session["cp"].ToString();
        string coid1 = Session["ccoid"].ToString();
        string s1 = "select id from loginusers where companyid='" + coid1 + "'";
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
            displayfollowers1.Text = "" + ds.Tables[0].Rows.Count.ToString();
            displayfollowers2.Text = "" + ds.Tables[0].Rows.Count.ToString();
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
            Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='company-login';}</script>");

        }
        finally
        {
            con.Close();

        }
    }
    public static string GetResponse(string sURL)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL); request.MaximumAutomaticRedirections = 4;
        request.Credentials = CredentialCache.DefaultCredentials;
        try
        {
            HttpWebResponse response = (HttpWebResponse)request.GetResponse(); Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8); string sResponse = readStream.ReadToEnd();
            response.Close();
            readStream.Close();
            return sResponse;
        }
        catch
        {
            return "";
        }
    }
    public void smsDetails()
    {
        string u1 = Session["cu"].ToString();
        string p1 = Session["cp"].ToString();
        string coid1 = Session["ccoid"].ToString();
        {
            string s1 = "select smscredit, smsapikey, smsuserid from companydetails where companyid='" + coid1 + "'";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            try
            {
                SqlCommand cmd1 = new SqlCommand(s1, con);
                con.Open();
                cmd1.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                dr1.Read();
                string credit = "" + dr1["smscredit"].ToString();
                string user = "" + dr1["smsuserid"].ToString();
                string apikey = "" + dr1["smsapikey"].ToString();
                       string url = "http://smshorizon.co.in/api/balance.php?user=" + user + "&apikey=" + apikey;
                       remainingsmslbl.Text = GetResponse(url);
                        char[] split ={':'}; 
                       string rsms = remainingsmslbl.Text;
                       string[] balance = rsms.Split(split);
                       sentsmslbl.Text = (Convert.ToInt32(credit) - Convert.ToInt32(balance[1])).ToString();
                       totalsmslbl.Text = credit;
                       dr1.Close();
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
                Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='company-login';}</script>");

            }
            finally
            {
                con.Close();

            }
        }
    }
  
    public void displayProfileImage()
    {
        string companyid = Session["ccoid"].ToString();

        string companyProfImgPath = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + companyid + "\\" + "profileimage"; ;
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
        string companyid = Session["ccoid"].ToString();

        string companyCoverImgPath = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + companyid + "\\" + "coverimage";
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

    
}