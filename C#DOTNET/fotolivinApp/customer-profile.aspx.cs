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

public partial class customer_profile : System.Web.UI.Page
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
                viewsDetails();
                likesDetails();
                storageDetails();
                displayProfileImage();
                displayCoverImage();
                userCount();
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
            Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later. If still problem persist than contact admin');if(alert){ window.location='registered-customers';}</script>");

        }
    }
    public void customerDetails()
    {
        string u1 = Session["u"].ToString();
        string p1 = Session["p"].ToString();
        string coid1 = Session["coid"].ToString();
        string cid1 = Session["cid"].ToString();
        string s1 = "select * from customerdetails where customerid='" + cid1 + "'";
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
                editcompanyidlbl.Text = "" + dr["companyid"].ToString();
                editcustomeridlbl.Text = "" + dr["customerid"].ToString();
                editcustomernametb.Text = "" + dr["customername"].ToString();
                editsecondnametb.Text = "" + dr["accountname"].ToString();
                editcustomeremailtb.Text = "" + dr["customeremail"].ToString();
                editcustomerphonetb.Text = "" + dr["customerphone"].ToString();
                editcustomercitytb.Text = "" + dr["customercity"].ToString();
                editcustomerstatetb.Text = "" + dr["customerstate"].ToString();
                editcustomercountrytb.Text = "" + dr["customercountry"].ToString();
                editdatelbl.Text = "" + dr["date"].ToString();
                displaycustomerdatelbl.Text = "" + dr["date"].ToString();
                displaycustomeridlbl.Text = "" + dr["customerid"].ToString();
                displaycustomernamelbl.Text = "" + dr["customername"].ToString();
                displaycustomerphonelbl.Text = "" + dr["customerphone"].ToString();
                smscustomername1.Text = "" + dr["customername"].ToString();
                smscustomerid1.Text = "" + dr["customerid"].ToString();
                smsusername1.Text = "" + dr["customeremail"].ToString(); 
                smspassword1.Text = "" + dr["customerphone"].ToString(); 
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
            Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='registered-customers';}</script>");

        }
        finally
        {
            con.Close();

        }
    }
    public void userCount()
    {
        string coid1 = Session["coid"].ToString();
        string cid1 = Session["cid"].ToString();
        string s1 = "select id from loginusers where customerid='" + cid1 + "' AND companyid='"+coid1+"'";
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
            displaycustomeruserlbl1.Text = "" + ds.Tables[0].Rows.Count.ToString();
            displaycustomeruserlbl2.Text = "" + ds.Tables[0].Rows.Count.ToString();
            displaycustomeruserlbl.Text = "" + ds.Tables[0].Rows.Count.ToString();
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
            Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='registered-customers';}</script>");

        }
        finally
        {
            con.Close();

        }
    }
    public void viewsDetails()
    {
        string u1 = Session["u"].ToString();
        string p1 = Session["p"].ToString();
        string coid1 = Session["coid"].ToString();
        string cid1 = Session["cid"].ToString();
        
        {
            string s1 = "select views from albumdetails where customerid='" + cid1 + "' AND category='"+"cover"+"'";
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
                Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='registered-customers';}</script>");

            }
            finally
            {
                con.Close();

            }
        }
        {
            string s1 = "select views from photodetails where customerid='" + cid1 + "'";
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
                Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='registered-customers';}</script>");

            }
            finally
            {
                con.Close();

            }
        }
        {
            string s1 = "select views from videodetails where customerid='" + cid1 + "'";
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
                Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='registered-customers';}</script>");

            }
            finally
            {
                con.Close();

            }
        }
        displaycustomerviewlbl1.Text = (Convert.ToInt32(albumsviewhf.Value) + Convert.ToInt32(photoviewhf.Value) + Convert.ToInt32(videoviewhf.Value)).ToString();
        displaycustomerviewlbl2.Text = (Convert.ToInt32(albumsviewhf.Value) + Convert.ToInt32(photoviewhf.Value) + Convert.ToInt32(videoviewhf.Value)).ToString();
    }
    public void likesDetails()
    {
        string u1 = Session["u"].ToString();
        string p1 = Session["p"].ToString();
        string coid1 = Session["coid"].ToString();
        string cid1 = Session["cid"].ToString();
        
        {
            string s1 = "select likes from albumdetails where customerid='" + cid1 + "' AND category='"+"cover"+"'";
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
                Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='registered-customers';}</script>");

            }
            finally
            {
                con.Close();

            }
        }
       
        {
            string s1 = "select likes from photodetails where customerid='" + cid1 + "'";
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
                Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='registered-customers';}</script>");

            }
            finally
            {
                con.Close();

            }
        }
        {
            string s1 = "select likes from videodetails where customerid='" + cid1 + "'";
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
                Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='registered-customers';}</script>");

            }
            finally
            {
                con.Close();

            }
        }
        displaycustomerlikelbl1.Text = (Convert.ToInt32(albumslikehf.Value) + Convert.ToInt32(photolikehf.Value) + Convert.ToInt32(videolikehf.Value)).ToString();
        displaycustomerlikelbl2.Text = (Convert.ToInt32(albumslikehf.Value) + Convert.ToInt32(photolikehf.Value) + Convert.ToInt32(videolikehf.Value)).ToString();

    }
    public void storageDetails()
    {
        string u1 = Session["u"].ToString();
        string p1 = Session["p"].ToString();
        string coid1 = Session["coid"].ToString();
        string cid1 = Session["cid"].ToString();
        
        {
            string s1 = "select filesize from albumdetails where customerid='" + cid1 + "'";
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
                Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='registered-customers';}</script>");

            }
            finally
            {
                con.Close();

            }
        }
        
        {
            string s1 = "select imagesize from photodetails where customerid='" + cid1 + "'";
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
                Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='registered-customers';}</script>");

            }
            finally
            {
                con.Close();

            }
        }
        {
            string s1 = "select videosize from videodetails where customerid='" + cid1 + "'";
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
                Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='registered-customers';}</script>");

            }
            finally
            {
                con.Close();

            }
        }
        long lBytes = (Convert.ToInt64(albumsspacehf.Value) + Convert.ToInt64(photospacehf.Value) + Convert.ToInt64(videospacehf.Value));
        ConvertBytes(lBytes);
        displaycustomerspacelbl2.Text = displaycustomerspacelbl1.Text;

    }
    public string ConvertBytes(long lBytes)
    {
        string sSize = string.Empty;
        displaycustomerspacelbl1.Text = "0";
        if (lBytes >= 1073741824)
        {
            Int64 a = lBytes;
            Int64 b = 1073741824;
            double div = (double)a / b;
            displaycustomerspacelbl1.Text = String.Format("{0:0.00}", div) + " GB";
        }
        else if (lBytes >= 1048576)
        {
            displaycustomerspacelbl1.Text = String.Format("{0:D}", lBytes / 1048576) + " MB";
        }
        else if (lBytes >= 1024)
        {
            displaycustomerspacelbl1.Text = String.Format("{0:##.##}", lBytes / 1024) + " KB";
        }
        else if (lBytes > 0 && lBytes < 1024)
        {
            displaycustomerspacelbl1.Text = lBytes.ToString() + " bytes";
        }
        return displaycustomerspacelbl1.Text;
    }
    public void displayProfileImage()
    {
        string customerProfImgPath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + editcompanyidlbl.Text + "\\" + editcustomeridlbl.Text + "\\" + "profileimage";
        string customerProfImgPath1;
        DirectoryInfo dir = new DirectoryInfo(MapPath(customerProfImgPath));
        FileInfo[] file = dir.GetFiles();
        DataTable dt = new DataTable();
        dt.Columns.Add("customerProfImgPath1");
        foreach (FileInfo image in file)
        {
            if (image.Exists)
            {
                if (image.Extension.ToLower() == ".jpg" || image.Extension.ToLower() == ".jpeg")
                {
                    customerProfImgPath1 = customerProfImgPath + "\\" + editcustomeridlbl.Text + "profile" + ".jpg";

                    dt.Rows.Add(customerProfImgPath1);
                }

            }

        }

        Repeater1.DataSource = dt;
        Repeater1.DataBind();
    }
    public void displayCoverImage()
    {
        string customerCoverImgPath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + editcompanyidlbl.Text + "\\" + editcustomeridlbl.Text + "\\" + "coverimage";
        string customerCoverImgPath1;
        DirectoryInfo dir = new DirectoryInfo(MapPath(customerCoverImgPath));
        FileInfo[] file = dir.GetFiles();
        DataTable dt = new DataTable();
        dt.Columns.Add("customerCoverImgPath1");
        foreach (FileInfo image in file)
        {
            if (image.Exists)
            {
                if (image.Extension.ToLower() == ".jpg" || image.Extension.ToLower() == ".jpeg")
                {
                    customerCoverImgPath1 = customerCoverImgPath + "\\" + editcustomeridlbl.Text + "cover" + ".jpg";

                    dt.Rows.Add(customerCoverImgPath1);
                }

            }

        }

        Repeater2.DataSource = dt;
        Repeater2.DataBind();
    }
    protected void updateinfobtn_Click(object sender, EventArgs e)
    {
        string s1 = "update customerdetails set customername='" + editcustomernametb.Text + "', accountname='" + editsecondnametb.Text + "',customeremail='" + editcustomeremailtb.Text + "',customerphone='" + editcustomerphonetb.Text + "',customercity='" + editcustomercitytb.Text + "',customerstate='" + editcustomerstatetb.Text + "',customercountry='" + editcustomercountrytb.Text + "' where customerid='" + editcustomeridlbl.Text + "'";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd = new SqlCommand(s1, con);
            con.Open();
            cmd.ExecuteNonQuery();
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
        finally
        {
            con.Close();

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
    protected void sendsmsbtn_Click(object sender, EventArgs e)
    {

        string url = "customer-profile";
                try
                {
                    string slct = "select companyname, smsuserid, smsapikey, smssenderid from companydetails where companyid='"+editcompanyidlbl.Text+"'";
                    SqlConnection conslct = new SqlConnection();
                    conslct.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    try
                    {
                        SqlCommand cmd = new SqlCommand(slct, conslct);
                        conslct.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            string cname = "" + dr["companyname"].ToString();
                            string smsuserid = "" + dr["smsuserid"].ToString();
                            string smsapikey = "" + dr["smsapikey"].ToString();
                            string smssenderid = "" + dr["smssenderid"].ToString();

                            string sUserID = smsuserid;
                            string sApikey = smsapikey;
                            string sNumber = displaycustomerphonelbl.Text;
                            string sSenderid = smssenderid;
                            string sMessage = "Dear" + " " + editcustomernametb.Text + ", Your fotolivin app account's username is" + " " + editcustomeremailtb.Text + " and your password is" + " " + editcustomerphonetb.Text + " (Your username and password are for your personal use only, do not share it to anyone). Your customerid is " + editcustomeridlbl.Text + ". Share your customerid only to invite friends and family, enjoy sharing with all...!! Download fotolivin app from http://fotolivin.com/app ";
                            string sType = "txt";

                            DateTime datetime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
                            string sURL = "http://smshorizon.co.in/api/sendsms.php?user=" + sUserID + "&apikey=" + sApikey + "&mobile=" + sNumber + "&senderid=" + sSenderid + "&message=" + sMessage + "&type=" + sType + "";
                            string sResponse = GetResponse(sURL);

                            string report1 = "http://smshorizon.co.in/api/status.php?user=" + sUserID + "&apikey=" + sApikey + "&msgid=" + sResponse + "";
                            string status = GetResponse1(report1);
                            }
                        Page.RegisterStartupScript("UserMsg", "<script>alert('Your SMS has been sent.');if(alert){ window.location=url;}</script>");
                                
                    }
                    catch (Exception ex)
                    {
                        Page.RegisterStartupScript("UserMsg", "<script>alert('Your SMS has not been sent. Please try again later');if(alert){ window.location=url;}</script>");
                   
                    }
                    finally
                    {
                        conslct.Close();
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
                    Page.RegisterStartupScript("UserMsg", "<script>alert('Your SMS has not been sent. Please try again later');if(alert){ window.location=url;}</script>");
                   

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
    public static string GetResponse1(string report1)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(report1); request.MaximumAutomaticRedirections = 4;
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

    protected void refresh_Click(object sender, EventArgs e)
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
}