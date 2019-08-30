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

public partial class company_sms : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["cu"] == null || Session["cp"] == null || Session["ccoid"] == null)
        {
            Response.Redirect("company-login");
        }
    }
     protected void sendsmsbtn_Click(object sender, EventArgs e)
    {
        string u1 = Session["cu"].ToString();
        string p1 = Session["cp"].ToString();
        string coid1 = Session["ccoid"].ToString();
        string urlfinal = "sms";

        if (numbertb.Text.Length > 0 && messagetb.Text.Length > 0)
        {
            WebClient wc = new WebClient();
            byte[] datasize = null;
            try
            {
                datasize = wc.DownloadData("http://www.google.com");
            }
            catch (Exception ex)
            {
                Page.RegisterStartupScript("UserMsg", "<script>alert('No internet connection. Try again later');if(alert){ window.location='company-sms';}</script>");
                numbertb.Text = "";
                messagetb.Text = "";
            }
            if (datasize != null && datasize.Length > 0)
            {
                if (numbertb.Text.Length > 0)
                {


                    try
                    {
                        string slct = "select smsuserid, smsapikey, smssenderid from companydetails where companyid='"+coid1+"'";
                        SqlConnection conslct = new SqlConnection();
                        conslct.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                        try
                        {
                            SqlCommand cmd2 = new SqlCommand(slct, conslct);
                            conslct.Open();
                            cmd2.ExecuteNonQuery();
                            SqlDataAdapter da = new SqlDataAdapter(cmd2);
                            SqlDataReader dr = cmd2.ExecuteReader();
                            while (dr.Read())
                            {

                                string smsuserid = "" + dr["smsuserid"].ToString();
                                string smsapikey = "" + dr["smsapikey"].ToString();
                                string smssenderid = "" + dr["smssenderid"].ToString();

                                string sUserID = smsuserid;
                                string sApikey = smsapikey;
                                string sNumber = numbertb.Text;
                                string sSenderid = smssenderid;
                                string sMessage = messagetb.Text;
                                int length = messagetb.Text.Length;
                                string sType = "txt";
                                string num = numbertb.Text;
                                string[] multinum = num.Split(',');
                               
                                    foreach (string multinums in multinum)
                                    {
                                        string sURL = "http://smshorizon.co.in/api/sendsms.php?user=" + sUserID + "&apikey=" + sApikey + "&mobile=" + multinums + "&senderid=" + sSenderid + "&message=" + sMessage + "&type=" + sType + "";
                                        string sResponse = GetResponse(sURL);

                                        string report1 = "http://smshorizon.co.in/api/status.php?user=" + sUserID + "&apikey=" + sApikey + "&msgid=" + sResponse + "";
                                        string status = GetResponse1(report1);

                                    
                                }
                              
                                Page.RegisterStartupScript("UserMsg", "<script>alert('Your SMS has been sent.');if(alert){ window.location=urlfinal;}</script>");
                                numbertb.Text = "";
                                messagetb.Text = "";
                            }
                        }
                        catch (Exception ex)
                        {
                            Page.RegisterStartupScript("UserMsg", "<script>alert('No internet connection. Try again later');if(alert){ window.location=urlfinal;}</script>");
               
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
                        Page.RegisterStartupScript("UserMsg", "<script>alert('Sending Failed. Check Your internet connection. Try again later or contact your operator');if(alert){ window.location=urlfinal;}</script>");
                        
                        numbertb.Text = "";
                        messagetb.Text = "";
                    }

                }
                else
                {
                    Page.RegisterStartupScript("UserMsg", "<script>alert('Phone Number not valid. Try again later or contact your operator');if(alert){ window.location=urlfinal;}</script>");
                    numbertb.Text = "";
                    messagetb.Text = "";
                }
            }
            else
            {
                Page.RegisterStartupScript("UserMsg", "<script>alert('No internet connection. Try again later');if(alert){ window.location=urlfinal;}</script>");
                numbertb.Text = "";
                messagetb.Text = "";
            }
            
        }
        else
        {
            Page.RegisterStartupScript("UserMsg", "<script>alert('Phone Number not valid. Try again later');if(alert){ window.location=urlfinal;}</script>");
            numbertb.Text = "";
            messagetb.Text = "";
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
 
}