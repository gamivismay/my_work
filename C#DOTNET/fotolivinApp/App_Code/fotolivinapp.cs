using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI;
using System.Web.Script;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.IO;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Mail;
using System.Net;
using System.Xml;

/// <summary>
/// Summary description for app
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class app : System.Web.Services.WebService
{
    public bool a;
    static string base64String = null;

    public app()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    private XmlElement Serialize(object obj)
    {
        XmlElement serializedXmlElement = null;

        try
        {
            System.IO.MemoryStream memoryStream = new MemoryStream();
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(obj.GetType());
            xmlSerializer.Serialize(memoryStream, obj);
            memoryStream.Position = 0;

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(memoryStream);
            serializedXmlElement = xmlDocument.DocumentElement;
        }
        catch (Exception e)
        {
            //logging statements. You must log exception for review
        }

        return serializedXmlElement;
    }
    private void SendEMail(MailMessage mail)
    {
        SmtpClient client = new SmtpClient();
        client.Host = "mail.fotolivin.com";
        client.Port = 25;
        client.EnableSsl = false;
        client.UseDefaultCredentials = false;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.Credentials = new System.Net.NetworkCredential("info@fotolivin.com", "Info_fotolivin04");
        try
        {
            client.Send(mail);
        }
        catch (Exception ex)
        {

            throw ex;
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
    //public static string GetResponse1(string report1)
    //{
    //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(report1); request.MaximumAutomaticRedirections = 4;
    //    request.Credentials = CredentialCache.DefaultCredentials;
    //    try
    //    {
    //        HttpWebResponse response = (HttpWebResponse)request.GetResponse(); Stream receiveStream = response.GetResponseStream();
    //        StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8); string sResponse = readStream.ReadToEnd();
    //        response.Close();
    //        readStream.Close();
    //        return sResponse;
    //    }
    //    catch
    //    {
    //        return "";
    //    }
    //}
    //public static string GetResponse2(string sURL)
    //{
    //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL); request.MaximumAutomaticRedirections = 4;
    //    request.Credentials = CredentialCache.DefaultCredentials;
    //    try
    //    {
    //        HttpWebResponse response = (HttpWebResponse)request.GetResponse(); Stream receiveStream = response.GetResponseStream();
    //        StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8); string sResponse = readStream.ReadToEnd();
    //        response.Close();
    //        readStream.Close();
    //        return sResponse;
    //    }
    //    catch
    //    {
    //        return "";
    //    }
    //}
    public static string GetResponseorder(string sURLorder)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURLorder); request.MaximumAutomaticRedirections = 4;
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

    //portfolio api starts

    [WebMethod]
    public XmlElement signup(string accountname, string username, string password, string email, string birthdate, string phone, string devicetype, string devicetoken)
    {

        string address1 = "";
        string city1 = "";
        string state1 = "";
        string pincode1 = "";
        string companyid = "";
        string customerid = "";
        string loginstatus = "0";
        string userstatus = "0";
        DateTime date = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time")); ;

        string slct2 = "select emailid from loginusers where emailid='" + email + "'";
        SqlConnection con2 = new SqlConnection();
        con2.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd2 = new SqlCommand(slct2, con2);
            con2.Open();
            cmd2.ExecuteNonQuery();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable("Status");
                dt.Columns.Add(new DataColumn("message", typeof(string)));
                dt.Columns.Add(new DataColumn("valid", typeof(string)));
                DataRow dr = dt.NewRow();
                DataSet ds4 = new DataSet();
                dr["message"] = "user already exists..!!";
                dr["valid"] = "0";
                dt.Rows.Add(dr);
                ds4.Tables.Add(dt);
                XmlDataDocument xmldata = new XmlDataDocument(ds4);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;

            }

            else
            {
                string userpath = System.Configuration.ConfigurationManager.AppSettings["userDataPath"] + email;
                Directory.CreateDirectory(Server.MapPath(userpath));
                string orderpath = System.Configuration.ConfigurationManager.AppSettings["userDataPath"] + email + "\\" + "order";
                Directory.CreateDirectory(Server.MapPath(orderpath));
                string insert = "insert into loginusers values('" + username + "', '" + email + "','" + password + "','" + phone + "','" + address1 + "','" + city1 + "','" + state1 + "','" + pincode1 + "','" + birthdate + "','" + companyid + "', '" + customerid + "', '" + accountname + "', '" + devicetype + "','" + devicetoken + "','" + loginstatus + "','" + userstatus + "','" + date + "')";
                SqlConnection con1 = new SqlConnection();
                con1.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                try
                {
                    SqlCommand cmd1 = new SqlCommand(insert, con1);
                    con1.Open();
                    cmd1.ExecuteNonQuery();
                    DataTable dt = new DataTable("Status");
                    DataSet ds3 = new DataSet();
                    dt.Columns.Add(new DataColumn("message", typeof(string)));
                    dt.Columns.Add(new DataColumn("valid", typeof(string)));
                    DataRow dr = dt.NewRow();
                    dr["message"] = "Account created successfully..!!";
                    dr["valid"] = "1";
                    dt.Rows.Add(dr);
                    ds3.Tables.Add(dt);
                    XmlDataDocument xmldata = new XmlDataDocument(ds3);
                    XmlElement xmlElement = xmldata.DocumentElement;
                    return xmlElement;
                }
                catch (Exception ex)
                {
                    DataTable dterror = new DataTable("errorStatus");
                    dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
                    dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
                    DataRow drerror = dterror.NewRow();
                    DataSet dserror = new DataSet();
                    drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
                    drerror["errorValid"] = "0";
                    dterror.Rows.Add(drerror);
                    dserror.Tables.Add(dterror);
                    XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
                    XmlElement xmlElementerror = xmldataerror.DocumentElement;
                    return xmlElementerror;

                }
                finally
                {
                    con1.Close();
                }

            }
        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;

        }
        finally
        {
            con2.Close();
        }

    }
    [WebMethod]
    public XmlElement login(string emailid, string password, string devicetype, string devicetoken)
    {
        string loginstatus = "1";
        string slct2 = "select username, emailid, password, phone, address, birthdate, loginstatus, userstatus from loginusers where emailid='" + emailid + "' AND password='" + password + "'";
        string update = "update loginusers set devicetype='" + devicetype + "', devicetoken='" + devicetoken + "', loginstatus='" + loginstatus + "' where emailid='" + emailid + "'";
        SqlConnection con2 = new SqlConnection();
        con2.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd2 = new SqlCommand(slct2, con2);
            con2.Open();
            cmd2.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                DataTable dt = new DataTable("Status");
                dt.Columns.Add(new DataColumn("message", typeof(string)));
                dt.Columns.Add(new DataColumn("valid", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["message"] = "no data found";
                dr["valid"] = "0";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);
                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            else
            {
                DataSet ds1 = new DataSet();
                using (SqlCommand cmd = new SqlCommand(slct2, con2))
                {
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                    da1.Fill(ds1);
                }
                using (SqlCommand cmd1 = new SqlCommand(update, con2))
                {
                    cmd1.ExecuteNonQuery();
                    

                }
                DataTable dt = new DataTable("Status");
                dt.Columns.Add(new DataColumn("message", typeof(string)));
                dt.Columns.Add(new DataColumn("valid", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["message"] = "Logged in..!!";
                dr["valid"] = "1";
                dt.Rows.Add(dr);
                ds1.Tables.Add(dt);
                XmlDataDocument xmldata = new XmlDataDocument(ds1);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;

        }
        finally
        {
            con2.Close();
        }


    }
    [WebMethod]
    public XmlElement googleLogin(string emailid, string devicetype, string devicetoken)
    {

        string slct2 = "select username, emailid, password, phone, address, birthdate, loginstatus, userstatus from loginusers where emailid='" + emailid + "'";
        string update = "update loginusers set devicetype='" + devicetype + "', devicetoken='" + devicetoken + "', loginstatus='" + "1" + "' where emailid='" + emailid + "'";
        SqlConnection con2 = new SqlConnection();
        con2.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd2 = new SqlCommand(slct2, con2);
            con2.Open();
            cmd2.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                DataTable dt = new DataTable("Status");
                dt.Columns.Add(new DataColumn("message", typeof(string)));
                dt.Columns.Add(new DataColumn("valid", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["message"] = "no data found";
                dr["valid"] = "0";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);
                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            else
            {
                DataSet ds1 = new DataSet();
                using (SqlCommand cmd = new SqlCommand(update, con2))
                {
                    cmd.ExecuteNonQuery();

                    using (SqlCommand cmd1 = new SqlCommand(slct2, con2))
                    {
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                        da1.Fill(ds1);

                    }
                }
                DataTable dt = new DataTable("Status");
                dt.Columns.Add(new DataColumn("message", typeof(string)));
                dt.Columns.Add(new DataColumn("valid", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["message"] = "Logged in with google..!!";
                dr["valid"] = "1";
                dt.Rows.Add(dr);
                ds1.Tables.Add(dt);
                XmlDataDocument xmldata = new XmlDataDocument(ds1);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;

        }
        finally
        {
            con2.Close();
        }


    }
    [WebMethod]
    public XmlElement forgotPassword(string emailid)
    {

        string slct2 = "select emailid, password from loginusers where emailid='" + emailid + "'";
        SqlConnection con2 = new SqlConnection();
        con2.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd2 = new SqlCommand(slct2, con2);
            con2.Open();
            cmd2.ExecuteNonQuery();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            if (ds2.Tables[0].Rows.Count == 0)
            {
                DataTable dt = new DataTable("Status");
                dt.Columns.Add(new DataColumn("message", typeof(string)));
                dt.Columns.Add(new DataColumn("valid", typeof(string)));
                DataRow dr = dt.NewRow();
                DataSet ds4 = new DataSet();
                dr["message"] = "user doesnot exists..!!";
                dr["valid"] = "0";
                dt.Rows.Add(dr);
                ds4.Tables.Add(dt);
                XmlDataDocument xmldata = new XmlDataDocument(ds4);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;

            }
            else
            {

                string pswrd = ds2.Tables[0].Rows[0]["password"].ToString();
                string email = ds2.Tables[0].Rows[0]["emailid"].ToString();
                MailMessage mail = new MailMessage();
                string from, to, bcc, cc, subject, body;
                from = "info@fotolivin.com";   //Email Address of Sender
                to = emailid;   //Email Address of Receiver
                bcc = "";
                cc = "";
                subject = "This mail is from client.";
                StringBuilder sb = new StringBuilder();
                sb.Append("Hello Sir,<br/>");
                sb.Append("Your password from email id" + " " + email + " is " + pswrd + ".");
                sb.Append("<br/>");
                sb.Append("<br/>");
                sb.Append("you can also change your password from edit profile after logging to your account.");
                sb.Append("<br/>");
                sb.Append("<br/>");
                sb.Append("Please don't share your credential with anyone.");
                sb.Append("<br/>");
                sb.Append("<br/>");
                sb.Append("For any query please contact company.");
                sb.Append("<br/>");
                sb.Append("<br/>");
                sb.Append("Thanking you<br/>");


                body = sb.ToString();
                mail.From = new MailAddress(from);
                mail.To.Add(new MailAddress(to));

                if (!string.IsNullOrEmpty(bcc))
                {
                    mail.Bcc.Add(new MailAddress(bcc));
                }
                if (!string.IsNullOrEmpty(cc))
                {
                    mail.CC.Add(new MailAddress(cc));
                }

                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                SendEMail(mail);

                DataTable dt = new DataTable("Status");
                DataSet ds3 = new DataSet();
                dt.Columns.Add(new DataColumn("message", typeof(string)));
                dt.Columns.Add(new DataColumn("valid", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["message"] = "password sent to emailid successfully..!!";
                dr["valid"] = "1";
                dt.Rows.Add(dr);
                ds3.Tables.Add(dt);
                XmlDataDocument xmldata = new XmlDataDocument(ds3);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;
        }
        finally
        {
            con2.Close();
        }

    }
    [WebMethod]
    public XmlElement loginUserDetails(string customerid)
    {

        string slct2 = "select username, emailid, password, phone, address, birthdate, loginstatus, userstatus from loginusers where customerid='" + customerid + "'";
        SqlConnection con2 = new SqlConnection();
        con2.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd2 = new SqlCommand(slct2, con2);
            con2.Open();
            cmd2.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                DataTable dt = new DataTable("Status");
                dt.Columns.Add(new DataColumn("message", typeof(string)));
                dt.Columns.Add(new DataColumn("valid", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["message"] = "no data found";
                dr["valid"] = "0";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);
                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            else
            {
                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;

        }
        finally
        {
            con2.Close();
        }


    }
    [WebMethod]
    public XmlElement editUserDetails(string emailid, string username, string password, string phone, string address, string birthdate)
    {

        string slct2 = "select emailid from loginusers where emailid='" + emailid + "'";
        string update = "update loginusers set username='" + username + "', password='" + password + "', phone='" + phone + "', address='" + address + "', birthdate ='" + birthdate + "' where emailid='" + emailid + "'";
        string slctall = "select username, emailid, password, phone, address, birthdate from loginusers where emailid='" + emailid + "'";
        SqlConnection con2 = new SqlConnection();
        con2.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        con2.Open();
        try
        {
            SqlCommand cmd2 = new SqlCommand(slct2, con2);
            cmd2.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                DataTable dt = new DataTable("Status");
                dt.Columns.Add(new DataColumn("message", typeof(string)));
                dt.Columns.Add(new DataColumn("valid", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["message"] = "no data found";
                dr["valid"] = "0";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);
                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            else
            {
                try
                {
                    DataSet ds1 = new DataSet();
                    using (SqlCommand cmd = new SqlCommand(update, con2))
                    {

                        cmd.ExecuteNonQuery();
                        using (SqlCommand cmd1 = new SqlCommand(slctall, con2))
                        {
                            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                            DataTable dt = new DataTable("Status");
                            dt.Columns.Add(new DataColumn("message", typeof(string)));
                            dt.Columns.Add(new DataColumn("valid", typeof(string)));
                            DataRow dr = dt.NewRow();
                            dr["message"] = "Users details updated..!!";
                            dr["valid"] = "1";
                            dt.Rows.Add(dr);
                            ds1.Tables.Add(dt);
                            da1.Fill(ds1);
                        }
                    }
                    XmlDataDocument xmldata = new XmlDataDocument(ds1);
                    XmlElement xmlElement = xmldata.DocumentElement;
                    return xmlElement;
                }
                catch (Exception ex)
                {
                    DataTable dterror = new DataTable("errorStatus");
                    dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
                    dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
                    DataRow drerror = dterror.NewRow();
                    DataSet dserror = new DataSet();
                    drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
                    drerror["errorValid"] = "0";
                    dterror.Rows.Add(drerror);
                    dserror.Tables.Add(dterror);
                    XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
                    XmlElement xmlElementerror = xmldataerror.DocumentElement;
                    return xmlElementerror;

                }

            }
        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;

        }
        finally
        {
            con2.Close();
        }


    }
    [WebMethod]
    public XmlElement logoutUserAccount(string emailid)
    {
        string customerid = "";
        string companyid = "";
        string devicetoken = "";
        string devicetype = "";
        string loginstatus = "0";

        string update = "update loginusers set companyid='" + companyid + "', customerid='" + customerid + "', devicetype='" + devicetype + "', devicetoken='" + devicetoken + "', loginstatus='" + loginstatus + "' where emailid='" + emailid + "'";
        SqlConnection con2 = new SqlConnection();
        con2.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd2 = new SqlCommand(update, con2);
            con2.Open();
            cmd2.ExecuteNonQuery();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("Status");
            dt.Columns.Add(new DataColumn("message", typeof(string)));
            dt.Columns.Add(new DataColumn("valid", typeof(string)));
            DataRow dr = dt.NewRow();
            dr["message"] = "Logged out..!!";
            dr["valid"] = "1";
            dt.Rows.Add(dr);
            ds.Tables.Add(dt);
            XmlDataDocument xmldata = new XmlDataDocument(ds);
            XmlElement xmlElement = xmldata.DocumentElement;
            return xmlElement;

        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;
        }
        finally
        {
            con2.Close();
        }


    }
    [WebMethod]
    public XmlElement deleteUserAccount(string emailid)
    {
        string userPath = System.Configuration.ConfigurationManager.AppSettings["userDataPath"] + emailid;
        string strng = Server.MapPath(userPath);
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
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;
        }
        string delete = "delete from loginusers where emailid='" + emailid + "'; delete from orders where emailid='" + emailid + "'";
        SqlConnection con2 = new SqlConnection();
        con2.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd2 = new SqlCommand(delete, con2);
            con2.Open();
            cmd2.ExecuteNonQuery();
            DataTable dt = new DataTable("Status");
            dt.Columns.Add(new DataColumn("message", typeof(string)));
            dt.Columns.Add(new DataColumn("valid", typeof(string)));
            DataRow dr = dt.NewRow();
            DataSet ds4 = new DataSet();
            dr["message"] = "Account deleted..!!";
            dr["valid"] = "1";
            dt.Rows.Add(dr);
            ds4.Tables.Add(dt);
            XmlDataDocument xmldata = new XmlDataDocument(ds4);
            XmlElement xmlElement = xmldata.DocumentElement;
            return xmlElement;
        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;

        }
        finally
        {
            con2.Close();
        }


    }

    [WebMethod]
    public XmlElement userAccount(string customerid, string emailid)
    {

        string slct2 = "select companyid, customerid from customerdetails where customerid='" + customerid + "'";
        string slctall = "select companyid, customerid, customername, accountname from customerdetails where customerid='" + customerid + "'";

        string slct3 = "select views, likes from albumdetails where customerid='" + customerid + "' AND category='" + "cover" + "'";
        string slct4 = "select views, likes from photodetails where customerid='" + customerid + "'";
        string slct5 = "select views, likes from videodetails where customerid='" + customerid + "'";
        string slct6 = "select customerid from loginusers where customerid='" + customerid + "'";

        SqlConnection con2 = new SqlConnection();
        con2.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        con2.Open();
        try
        {
            DataTable dtnew = new DataTable("totalstats");
            DataRow drnew = dtnew.NewRow();
            SqlCommand cmd2 = new SqlCommand(slct2, con2);
            cmd2.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                DataTable dt = new DataTable("Status");
                dt.Columns.Add(new DataColumn("message", typeof(string)));
                dt.Columns.Add(new DataColumn("valid", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["message"] = "no data found";
                dr["valid"] = "0";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);
                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            else
            {

                DataSet ds1 = new DataSet();
                DataSet dstemp = new DataSet();
                SqlDataReader dr = cmd2.ExecuteReader();
                dr.Read();
                string companyid = "" + dr["companyid"].ToString();
                string slct7 = "select companyname from companydetails where companyid='" + companyid + "'";
                string update = "update loginusers set companyid='" + companyid + "', customerid='" + customerid + "' where emailid='" + emailid + "'";
                dr.Close();
                try
                {

                    using (SqlCommand cmd = new SqlCommand(update, con2))
                    {
                        cmd.ExecuteNonQuery();

                        using (SqlCommand cmd1 = new SqlCommand(slctall, con2))
                        {
                            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                            da1.Fill(ds1);

                        }

                        using (SqlCommand cmd1 = new SqlCommand(slct3, con2))
                        {

                            cmd1.ExecuteNonQuery();
                            SqlDataAdapter da3 = new SqlDataAdapter(cmd1);
                            DataTable dt = new DataTable();
                            da3.Fill(dt);

                            DataTable dt1 = new DataTable("albumstats");


                            dt1.Columns.Add(new DataColumn("message1", typeof(string)));
                            dt1.Columns.Add(new DataColumn("views1", typeof(string)));
                            dt1.Columns.Add(new DataColumn("likes1", typeof(string)));
                            int a = 0;
                            int b = 0;
                            DataRow dr3 = dt1.NewRow();
                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataRow dr1 in dt.Rows)
                                {
                                    dr3["message1"] = "Total views and likes statistics..!!";
                                    a += Int32.Parse(dr1["views"].ToString());
                                    dr3["views1"] = a.ToString();
                                    b += Int32.Parse(dr1["likes"].ToString());
                                    dr3["likes1"] = b.ToString();

                                }
                            }
                            else
                            {
                                dr3["message1"] = "Total views and likes statistics..!!";
                                dr3["views1"] = "0";
                                dr3["likes1"] = "0";
                            }

                            dt1.Rows.Add(dr3);

                            dstemp.Tables.Add(dt1);

                        }
                        using (SqlCommand cmd1 = new SqlCommand(slct4, con2))
                        {
                            cmd1.ExecuteNonQuery();
                            SqlDataAdapter da3 = new SqlDataAdapter(cmd1);
                            DataTable dt = new DataTable();
                            da3.Fill(dt);

                            DataTable dt1 = new DataTable("photostats");


                            dt1.Columns.Add(new DataColumn("message2", typeof(string)));
                            dt1.Columns.Add(new DataColumn("views2", typeof(string)));
                            dt1.Columns.Add(new DataColumn("likes2", typeof(string)));
                            int a = 0;
                            int b = 0;
                            DataRow dr3 = dt1.NewRow();
                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataRow dr1 in dt.Rows)
                                {
                                    dr3["message2"] = "Total views and likes statistics..!!";
                                    a += Int32.Parse(dr1["views"].ToString());
                                    dr3["views2"] = a.ToString();
                                    b += Int32.Parse(dr1["likes"].ToString());
                                    dr3["likes2"] = b.ToString();

                                }
                            }
                            else
                            {
                                dr3["message2"] = "Total views and likes statistics..!!";
                                dr3["views2"] = "0";
                                dr3["likes2"] = "0";
                            }
                            dt1.Rows.Add(dr3);

                            dstemp.Tables.Add(dt1);

                        }
                        using (SqlCommand cmd1 = new SqlCommand(slct5, con2))
                        {
                            cmd1.ExecuteNonQuery();
                            SqlDataAdapter da3 = new SqlDataAdapter(cmd1);
                            DataTable dt = new DataTable();
                            da3.Fill(dt);

                            DataTable dt1 = new DataTable("videostats");


                            dt1.Columns.Add(new DataColumn("message3", typeof(string)));
                            dt1.Columns.Add(new DataColumn("views3", typeof(string)));
                            dt1.Columns.Add(new DataColumn("likes3", typeof(string)));
                            int a = 0;
                            int b = 0;
                            DataRow dr3 = dt1.NewRow();
                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataRow dr1 in dt.Rows)
                                {
                                    dr3["message3"] = "Total views and likes statistics..!!";
                                    a += Int32.Parse(dr1["views"].ToString());
                                    dr3["views3"] = a.ToString();
                                    b += Int32.Parse(dr1["likes"].ToString());
                                    dr3["likes3"] = b.ToString();

                                }
                            }
                            else
                            {
                                dr3["message3"] = "Total views and likes statistics..!!";
                                dr3["views3"] = "0";
                                dr3["likes3"] = "0";
                            }
                            dt1.Rows.Add(dr3);

                            dstemp.Tables.Add(dt1);

                        }
                        using (SqlCommand cmd1 = new SqlCommand(slct6, con2))
                        {

                            cmd1.ExecuteNonQuery();
                            SqlDataAdapter da3 = new SqlDataAdapter(cmd1);
                            DataTable dt = new DataTable();
                            da3.Fill(dt);

                            DataTable dt1 = new DataTable("customeruserstats");
                            dt1.Columns.Add(new DataColumn("message4", typeof(string)));
                            dt1.Columns.Add(new DataColumn("customerusers", typeof(string)));
                            DataRow dr3 = dt1.NewRow();

                            dr3["message4"] = "Total companycustomers statistics..!!";
                            dr3["customerusers"] = "" + dt.Rows.Count.ToString();



                            dt1.Rows.Add(dr3);

                            dstemp.Tables.Add(dt1);
                        }
                        using (SqlCommand cmd1 = new SqlCommand(slct7, con2))
                        {
                            cmd1.ExecuteNonQuery();
                            SqlDataAdapter da3 = new SqlDataAdapter(cmd1);
                            DataTable dt = new DataTable();
                            da3.Fill(dt);
                            dstemp.Tables.Add(dt);
                        }
                    }


                }
                catch (Exception ex)
                {
                    DataTable dterror = new DataTable("errorStatus");
                    dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
                    dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
                    DataRow drerror = dterror.NewRow();
                    DataSet dserror = new DataSet();
                    drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
                    drerror["errorValid"] = "0";
                    dterror.Rows.Add(drerror);
                    dserror.Tables.Add(dterror);
                    XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
                    XmlElement xmlElementerror = xmldataerror.DocumentElement;
                    return xmlElementerror;

                }
                dtnew.Columns.Add(new DataColumn("totalviews", typeof(string)));
                dtnew.Columns.Add(new DataColumn("totallikes", typeof(string)));
                dtnew.Columns.Add(new DataColumn("totalcustomerusers", typeof(string)));
                dtnew.Columns.Add(new DataColumn("companyname", typeof(string)));
                drnew["totalviews"] = (Convert.ToInt32(dstemp.Tables[0].Rows[0]["views1"]) + Convert.ToInt32(dstemp.Tables[1].Rows[0]["views2"]) + Convert.ToInt32(dstemp.Tables[2].Rows[0]["views3"])).ToString();
                drnew["totallikes"] = (Convert.ToInt32(dstemp.Tables[0].Rows[0]["likes1"]) + Convert.ToInt32(dstemp.Tables[1].Rows[0]["likes2"]) + Convert.ToInt32(dstemp.Tables[2].Rows[0]["likes3"])).ToString();
                drnew["totalcustomerusers"] = "" + dstemp.Tables[3].Rows[0]["customerusers"].ToString();
                drnew["companyname"] = "" + dstemp.Tables[4].Rows[0]["companyname"].ToString();
                dtnew.Rows.Add(drnew);
                ds1.Tables.Add(dtnew);

                XmlDataDocument xmldata = new XmlDataDocument(ds1);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;

            }
        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;

        }
        finally
        {
            con2.Close();
        }


    }
    [WebMethod]
    public XmlElement homeDetails(string customerid, string companyid)
    {

        string slctall = "select accountname from customerdetails where customerid='" + customerid + "'";

        string slct3 = "select views, likes from albumdetails where customerid='" + customerid + "' AND category='" + "cover" + "'";
        string slct4 = "select views, likes from photodetails where customerid='" + customerid + "'";
        string slct5 = "select views, likes from videodetails where customerid='" + customerid + "'";
        string slct6 = "select customerid from loginusers where customerid='" + customerid + "'";
        string slct7 = "select fblink, websitelink, companyname from companydetails where companyid='" + companyid + "'";

        SqlConnection con2 = new SqlConnection();
        con2.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        con2.Open();
        try
        {
            DataTable dtnew = new DataTable("totalstats");
            DataRow drnew = dtnew.NewRow();


            DataSet ds1 = new DataSet();
            DataSet dstemp = new DataSet();

            try
            {



                using (SqlCommand cmd1 = new SqlCommand(slctall, con2))
                {
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    da1.Fill(ds1);

                }
                using (SqlCommand cmd1 = new SqlCommand(slct7, con2))
                {
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd1);
                    da2.Fill(ds1);

                }
                using (SqlCommand cmd1 = new SqlCommand(slct3, con2))
                {

                    cmd1.ExecuteNonQuery();
                    SqlDataAdapter da3 = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da3.Fill(dt);

                    DataTable dt1 = new DataTable("albumstats");


                    dt1.Columns.Add(new DataColumn("message1", typeof(string)));
                    dt1.Columns.Add(new DataColumn("views1", typeof(string)));
                    dt1.Columns.Add(new DataColumn("likes1", typeof(string)));
                    int a = 0;
                    int b = 0;
                    DataRow dr3 = dt1.NewRow();
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr1 in dt.Rows)
                        {
                            dr3["message1"] = "Total views and likes statistics..!!";
                            a += Int32.Parse(dr1["views"].ToString());
                            dr3["views1"] = a.ToString();
                            b += Int32.Parse(dr1["likes"].ToString());
                            dr3["likes1"] = b.ToString();

                        }
                    }
                    else
                    {
                        dr3["message1"] = "Total views and likes statistics..!!";
                        dr3["views1"] = "0";
                        dr3["likes1"] = "0";
                    }

                    dt1.Rows.Add(dr3);

                    dstemp.Tables.Add(dt1);

                }
                using (SqlCommand cmd1 = new SqlCommand(slct4, con2))
                {
                    cmd1.ExecuteNonQuery();
                    SqlDataAdapter da3 = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da3.Fill(dt);

                    DataTable dt1 = new DataTable("photostats");


                    dt1.Columns.Add(new DataColumn("message2", typeof(string)));
                    dt1.Columns.Add(new DataColumn("views2", typeof(string)));
                    dt1.Columns.Add(new DataColumn("likes2", typeof(string)));
                    int a = 0;
                    int b = 0;
                    DataRow dr3 = dt1.NewRow();
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr1 in dt.Rows)
                        {
                            dr3["message2"] = "Total views and likes statistics..!!";
                            a += Int32.Parse(dr1["views"].ToString());
                            dr3["views2"] = a.ToString();
                            b += Int32.Parse(dr1["likes"].ToString());
                            dr3["likes2"] = b.ToString();

                        }
                    }
                    else
                    {
                        dr3["message2"] = "Total views and likes statistics..!!";
                        dr3["views2"] = "0";
                        dr3["likes2"] = "0";
                    }
                    dt1.Rows.Add(dr3);

                    dstemp.Tables.Add(dt1);

                }
                using (SqlCommand cmd1 = new SqlCommand(slct5, con2))
                {
                    cmd1.ExecuteNonQuery();
                    SqlDataAdapter da3 = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da3.Fill(dt);

                    DataTable dt1 = new DataTable("videostats");


                    dt1.Columns.Add(new DataColumn("message3", typeof(string)));
                    dt1.Columns.Add(new DataColumn("views3", typeof(string)));
                    dt1.Columns.Add(new DataColumn("likes3", typeof(string)));
                    int a = 0;
                    int b = 0;
                    DataRow dr3 = dt1.NewRow();
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr1 in dt.Rows)
                        {
                            dr3["message3"] = "Total views and likes statistics..!!";
                            a += Int32.Parse(dr1["views"].ToString());
                            dr3["views3"] = a.ToString();
                            b += Int32.Parse(dr1["likes"].ToString());
                            dr3["likes3"] = b.ToString();

                        }
                    }
                    else
                    {
                        dr3["message3"] = "Total views and likes statistics..!!";
                        dr3["views3"] = "0";
                        dr3["likes3"] = "0";
                    }
                    dt1.Rows.Add(dr3);

                    dstemp.Tables.Add(dt1);

                }
                using (SqlCommand cmd1 = new SqlCommand(slct6, con2))
                {

                    cmd1.ExecuteNonQuery();
                    SqlDataAdapter da3 = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da3.Fill(dt);

                    DataTable dt1 = new DataTable("customeruserstats");
                    dt1.Columns.Add(new DataColumn("message4", typeof(string)));
                    dt1.Columns.Add(new DataColumn("customerusers", typeof(string)));
                    DataRow dr3 = dt1.NewRow();

                    dr3["message4"] = "Total companycustomers statistics..!!";
                    dr3["customerusers"] = "" + dt.Rows.Count.ToString();



                    dt1.Rows.Add(dr3);

                    dstemp.Tables.Add(dt1);
                }

                

            }
            catch (Exception ex)
            {
                DataTable dterror = new DataTable("errorStatus");
                dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
                dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
                DataRow drerror = dterror.NewRow();
                DataSet dserror = new DataSet();
                drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
                drerror["errorValid"] = "0";
                dterror.Rows.Add(drerror);
                dserror.Tables.Add(dterror);
                XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
                XmlElement xmlElementerror = xmldataerror.DocumentElement;
                return xmlElementerror;

            }
            dtnew.Columns.Add(new DataColumn("totalviews", typeof(string)));
            dtnew.Columns.Add(new DataColumn("totallikes", typeof(string)));
            dtnew.Columns.Add(new DataColumn("totalcustomerusers", typeof(string)));
            drnew["totalviews"] = (Convert.ToInt32(dstemp.Tables[0].Rows[0]["views1"]) + Convert.ToInt32(dstemp.Tables[1].Rows[0]["views2"]) + Convert.ToInt32(dstemp.Tables[2].Rows[0]["views3"])).ToString();
            drnew["totallikes"] = (Convert.ToInt32(dstemp.Tables[0].Rows[0]["likes1"]) + Convert.ToInt32(dstemp.Tables[1].Rows[0]["likes2"]) + Convert.ToInt32(dstemp.Tables[2].Rows[0]["likes3"])).ToString();
            drnew["totalcustomerusers"] = "" + dstemp.Tables[3].Rows[0]["customerusers"].ToString();
            dtnew.Rows.Add(drnew);
            ds1.Tables.Add(dtnew);

            XmlDataDocument xmldata = new XmlDataDocument(ds1);
            XmlElement xmlElement = xmldata.DocumentElement;
            return xmlElement;


        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;

        }
        finally
        {
            con2.Close();
        }


    }
    //[WebMethod]
    //public XmlElement ownerAccount(string secureid, string emailid, string date)
    //{

    //    string slct2 = "select companyid, customerid from customerdetails where secureid='" + secureid + "'";

    //    SqlConnection con2 = new SqlConnection();
    //    con2.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    //    con2.Open();
    //    try
    //    {
    //        DataTable dtnew = new DataTable("totalstats");
    //        DataRow drnew = dtnew.NewRow();
    //        SqlCommand cmd2 = new SqlCommand(slct2, con2);
    //        cmd2.ExecuteNonQuery();
    //        SqlDataAdapter da = new SqlDataAdapter(cmd2);
    //        DataSet ds = new DataSet();
    //        da.Fill(ds);
    //        if (ds.Tables[0].Rows.Count == 0)
    //        {
    //            DataTable dt = new DataTable("Status");
    //            dt.Columns.Add(new DataColumn("message", typeof(string)));
    //            dt.Columns.Add(new DataColumn("valid", typeof(string)));
    //            DataRow dr = dt.NewRow();
    //            dr["message"] = "no data found";
    //            dr["valid"] = "0";
    //            dt.Rows.Add(dr);
    //            ds.Tables.Add(dt);
    //            XmlDataDocument xmldata = new XmlDataDocument(ds);
    //            XmlElement xmlElement = xmldata.DocumentElement;
    //            return xmlElement;
    //        }
    //        else
    //        {

    //            DataSet ds1 = new DataSet();
    //            DataSet dstemp = new DataSet();
    //            SqlDataReader dr = cmd2.ExecuteReader();
    //            dr.Read();
    //            string companyid = "" + dr["companyid"].ToString();
    //            string customerid = "" + dr["customerid"].ToString();

    //            string slctall = "select companyid, customerid, secureid, galleryid, customername, secondname, events, giftstatus from customerdetails where customerid='" + customerid + "'";
    //            string slct3 = "select views, likes from albumdetails where customerid='" + customerid + "' AND category='" + "cover" + "'";
    //            string slct4 = "select views, likes from photodetails where customerid='" + customerid + "'";
    //            string slct5 = "select views, likes from videodetails where customerid='" + customerid + "'";
    //            string slct6 = "select customerid from loginusers where customerid='" + customerid + "'";
    //            string slct7 = "select companyname from companydetails where companyid='" + companyid + "'";
    //            string update = "update loginusers set companyid='" + companyid + "', customerid='" + customerid + "', date='" + date + "' where emailid='" + emailid + "'";
    //            dr.Close();
    //            try
    //            {

    //                using (SqlCommand cmd = new SqlCommand(update, con2))
    //                {
    //                    cmd.ExecuteNonQuery();

    //                    using (SqlCommand cmd1 = new SqlCommand(slctall, con2))
    //                    {
    //                        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
    //                        da1.Fill(ds1);

    //                    }

    //                    using (SqlCommand cmd1 = new SqlCommand(slct3, con2))
    //                    {

    //                        cmd1.ExecuteNonQuery();
    //                        SqlDataAdapter da3 = new SqlDataAdapter(cmd1);
    //                        DataTable dt = new DataTable();
    //                        da3.Fill(dt);

    //                        DataTable dt1 = new DataTable("albumstats");


    //                        dt1.Columns.Add(new DataColumn("message1", typeof(string)));
    //                        dt1.Columns.Add(new DataColumn("views1", typeof(string)));
    //                        dt1.Columns.Add(new DataColumn("likes1", typeof(string)));
    //                        int a = 0;
    //                        int b = 0;
    //                        DataRow dr3 = dt1.NewRow();
    //                        if (dt.Rows.Count > 0)
    //                        {
    //                            foreach (DataRow dr1 in dt.Rows)
    //                            {
    //                                dr3["message1"] = "Total views and likes statistics..!!";
    //                                a += Int32.Parse(dr1["views"].ToString());
    //                                dr3["views1"] = a.ToString();
    //                                b += Int32.Parse(dr1["likes"].ToString());
    //                                dr3["likes1"] = b.ToString();

    //                            }
    //                        }

    //                        dt1.Rows.Add(dr3);

    //                        dstemp.Tables.Add(dt1);

    //                    }
    //                    using (SqlCommand cmd1 = new SqlCommand(slct4, con2))
    //                    {
    //                        cmd1.ExecuteNonQuery();
    //                        SqlDataAdapter da3 = new SqlDataAdapter(cmd1);
    //                        DataTable dt = new DataTable();
    //                        da3.Fill(dt);

    //                        DataTable dt1 = new DataTable("photostats");


    //                        dt1.Columns.Add(new DataColumn("message2", typeof(string)));
    //                        dt1.Columns.Add(new DataColumn("views2", typeof(string)));
    //                        dt1.Columns.Add(new DataColumn("likes2", typeof(string)));
    //                        int a = 0;
    //                        int b = 0;
    //                        DataRow dr3 = dt1.NewRow();
    //                        if (dt.Rows.Count > 0)
    //                        {
    //                            foreach (DataRow dr1 in dt.Rows)
    //                            {
    //                                dr3["message2"] = "Total views and likes statistics..!!";
    //                                a += Int32.Parse(dr1["views"].ToString());
    //                                dr3["views2"] = a.ToString();
    //                                b += Int32.Parse(dr1["likes"].ToString());
    //                                dr3["likes2"] = b.ToString();

    //                            }
    //                        }

    //                        dt1.Rows.Add(dr3);

    //                        dstemp.Tables.Add(dt1);

    //                    }
    //                    using (SqlCommand cmd1 = new SqlCommand(slct5, con2))
    //                    {
    //                        cmd1.ExecuteNonQuery();
    //                        SqlDataAdapter da3 = new SqlDataAdapter(cmd1);
    //                        DataTable dt = new DataTable();
    //                        da3.Fill(dt);

    //                        DataTable dt1 = new DataTable("videostats");


    //                        dt1.Columns.Add(new DataColumn("message3", typeof(string)));
    //                        dt1.Columns.Add(new DataColumn("views3", typeof(string)));
    //                        dt1.Columns.Add(new DataColumn("likes3", typeof(string)));
    //                        int a = 0;
    //                        int b = 0;
    //                        DataRow dr3 = dt1.NewRow();
    //                        if (dt.Rows.Count > 0)
    //                        {
    //                            foreach (DataRow dr1 in dt.Rows)
    //                            {
    //                                dr3["message3"] = "Total views and likes statistics..!!";
    //                                a += Int32.Parse(dr1["views"].ToString());
    //                                dr3["views3"] = a.ToString();
    //                                b += Int32.Parse(dr1["likes"].ToString());
    //                                dr3["likes3"] = b.ToString();

    //                            }
    //                        }

    //                        dt1.Rows.Add(dr3);

    //                        dstemp.Tables.Add(dt1);

    //                    }
    //                    using (SqlCommand cmd1 = new SqlCommand(slct6, con2))
    //                    {

    //                        cmd1.ExecuteNonQuery();
    //                        SqlDataAdapter da3 = new SqlDataAdapter(cmd1);
    //                        DataTable dt = new DataTable();
    //                        da3.Fill(dt);

    //                        DataTable dt1 = new DataTable("customeruserstats");
    //                        dt1.Columns.Add(new DataColumn("message4", typeof(string)));
    //                        dt1.Columns.Add(new DataColumn("customerusers", typeof(string)));
    //                        DataRow dr3 = dt1.NewRow();

    //                        dr3["message4"] = "Total companycustomers statistics..!!";
    //                        dr3["customerusers"] = "" + dt.Rows.Count.ToString();



    //                        dt1.Rows.Add(dr3);

    //                        dstemp.Tables.Add(dt1);
    //                    }
    //                    using (SqlCommand cmd1 = new SqlCommand(slct7, con2))
    //                    {
    //                        cmd1.ExecuteNonQuery();
    //                        SqlDataAdapter da3 = new SqlDataAdapter(cmd1);
    //                        DataTable dt = new DataTable();
    //                        da3.Fill(dt);
    //                        dstemp.Tables.Add(dt);
    //                    }
    //                }


    //            }
    //            catch (Exception ex)
    //            {
    //                throw ex;

    //            }
    //            dtnew.Columns.Add(new DataColumn("totalviews", typeof(string)));
    //            dtnew.Columns.Add(new DataColumn("totallikes", typeof(string)));
    //            dtnew.Columns.Add(new DataColumn("totalcustomerusers", typeof(string)));
    //            dtnew.Columns.Add(new DataColumn("companyname", typeof(string)));
    //            drnew["totalviews"] = (Convert.ToInt32(dstemp.Tables[0].Rows[0]["views1"]) + Convert.ToInt32(dstemp.Tables[1].Rows[0]["views2"]) + Convert.ToInt32(dstemp.Tables[2].Rows[0]["views3"])).ToString();
    //            drnew["totallikes"] = (Convert.ToInt32(dstemp.Tables[0].Rows[0]["likes1"]) + Convert.ToInt32(dstemp.Tables[1].Rows[0]["likes2"]) + Convert.ToInt32(dstemp.Tables[2].Rows[0]["likes3"])).ToString();
    //            drnew["totalcustomerusers"] = "" + dstemp.Tables[3].Rows[0]["customerusers"].ToString();
    //            drnew["companyname"] = "" + dstemp.Tables[4].Rows[0]["companyname"].ToString();
    //            dtnew.Rows.Add(drnew);
    //            ds1.Tables.Add(dtnew);

    //            XmlDataDocument xmldata = new XmlDataDocument(ds1);
    //            XmlElement xmlElement = xmldata.DocumentElement;
    //            return xmlElement;

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;

    //    }
    //    finally
    //    {
    //        con2.Close();
    //    }


    //}
    [WebMethod]
    public XmlElement companyDetails(string companyid)
    {

        string slct1 = "select fullname, companyname, address, email, phone, about, achievement, fblink, instagramlink, googlepluslink, twitterlink, youtubelink, websitelink from companydetails where companyid='" + companyid + "'";
        SqlConnection con1 = new SqlConnection();
        con1.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd1 = new SqlCommand(slct1, con1);
            con1.Open();
            cmd1.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                DataTable dt = new DataTable("Status");
                dt.Columns.Add(new DataColumn("message", typeof(string)));
                dt.Columns.Add(new DataColumn("valid", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["message"] = "no data found";
                dr["valid"] = "0";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);
                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            else
            {
                string s2 = "select companyid from loginusers where companyid='" + companyid + "'";
                SqlConnection con2 = new SqlConnection();
                con2.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                SqlCommand cmd2 = new SqlCommand(s2, con2);
                con2.Open();
                cmd2.ExecuteNonQuery();
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                DataTable dt2 = new DataTable();
                dt2.Columns.Add(new DataColumn("followers", typeof(string)));
                DataRow dr2 = dt2.NewRow();
                dr2["followers"] = "" + ds2.Tables[0].Rows.Count.ToString();
                dt2.Rows.Add(dr2);
                ds.Tables.Add(dt2);
                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;
        }
        finally
        {
            con1.Close();
        }


    }
    [WebMethod]
    public XmlElement exploreDetails(string companyid)
    {

        string slct3 = "select id, event, category, filename, filewidth, fileheight, fileextension, location,sale, imageprice, views, likes, date from exploreDetails where companyid='" + companyid + "' order by id desc";
        SqlConnection con3 = new SqlConnection();
        con3.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd3 = new SqlCommand(slct3, con3);
            con3.Open();
            cmd3.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd3);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                DataTable dt = new DataTable("Status");
                dt.Columns.Add(new DataColumn("message", typeof(string)));
                dt.Columns.Add(new DataColumn("valid", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["message"] = "no data found";
                dr["valid"] = "0";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);
                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            else
            {
                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;

        }
        finally
        {
            con3.Close();
        }


    }
    [WebMethod]
    public XmlElement exploreDetailsAndroid(string companyid, string lastid)
    {

        string slct3 = "select top 20 id, event, category, filename, filewidth, fileheight, fileextension, location,sale, imageprice, views, likes, date from exploreDetails where companyid='" + companyid + "' AND id < '" + lastid + "' order by id desc ";
        SqlConnection con3 = new SqlConnection();
        con3.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd3 = new SqlCommand(slct3, con3);
            con3.Open();
            cmd3.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd3);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                DataTable dt = new DataTable("Status");
                dt.Columns.Add(new DataColumn("message", typeof(string)));
                dt.Columns.Add(new DataColumn("valid", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["message"] = "no data found";
                dr["valid"] = "0";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);
                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            else
            {
                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;

        }
        finally
        {
            con3.Close();
        }


    }
    //[WebMethod]
    //public XmlElement exploreTrendingDetails(string companyid)
    //{

    //    string slct3 = "select event, category, filename, filewidth, fileheight, fileextension, location,sale, imageprice, views, likes from exploreDetails where companyid='" + companyid + "' order by views desc, date desc";
    //    SqlConnection con3 = new SqlConnection();
    //    con3.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    //    try
    //    {
    //        SqlCommand cmd3 = new SqlCommand(slct3, con3);
    //        con3.Open();
    //        cmd3.ExecuteNonQuery();
    //        SqlDataAdapter da = new SqlDataAdapter(cmd3);
    //        DataSet ds = new DataSet();
    //        da.Fill(ds);
    //        if (ds.Tables[0].Rows.Count == 0)
    //        {
    //            DataTable dt = new DataTable("Status");
    //            dt.Columns.Add(new DataColumn("message", typeof(string)));
    //            dt.Columns.Add(new DataColumn("valid", typeof(string)));
    //            DataRow dr = dt.NewRow();
    //            dr["message"] = "no data found";
    //            dr["valid"] = "0";
    //            dt.Rows.Add(dr);
    //            ds.Tables.Add(dt);
    //            XmlDataDocument xmldata = new XmlDataDocument(ds);
    //            XmlElement xmlElement = xmldata.DocumentElement;
    //            return xmlElement;
    //        }
    //        else
    //        {
    //            XmlDataDocument xmldata = new XmlDataDocument(ds);
    //            XmlElement xmlElement = xmldata.DocumentElement;
    //            return xmlElement;
    //        }
    //    }
        //catch (Exception ex)
        //{
        //    throw ex;

        //}
    //    finally
    //    {
    //        con3.Close();
    //    }


    //}
    //un comment if needed. to get individual image details
    //[WebMethod]
    //public XmlElement exploreImageDetails(string filename)
    //{

    //    string slct3 = "select event, location,sale, imageprice, discountrate, discountprice, views, likes from exploreDetails where filename='" + filename + "'";
    //    SqlConnection con3 = new SqlConnection();
    //    con3.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    //    try
    //    {
    //        SqlCommand cmd3 = new SqlCommand(slct3, con3);
    //        con3.Open();
    //        cmd3.ExecuteNonQuery();
    //        SqlDataAdapter da = new SqlDataAdapter(cmd3);
    //        DataSet ds = new DataSet();
    //        da.Fill(ds);
    //        if (ds.Tables[0].Rows.Count == 0)
    //        {
    //            DataTable dt = new DataTable("Status");
    //            dt.Columns.Add(new DataColumn("message", typeof(string)));
    //            DataRow dr = dt.NewRow();
    //            dr["message"] = "no data found";
    //            dt.Rows.Add(dr);
    //            ds.Tables.Add(dt);
    //            XmlDataDocument xmldata = new XmlDataDocument(ds);
    //            XmlElement xmlElement = xmldata.DocumentElement;
    //            return xmlElement;
    //        }
    //        else
    //        {
    //            XmlDataDocument xmldata = new XmlDataDocument(ds);
    //            XmlElement xmlElement = xmldata.DocumentElement;
    //            return xmlElement;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;

    //    }
    //    finally
    //    {
    //        con3.Close();
    //    }


    //}
    [WebMethod]
    public XmlElement exploreViews(string companyid, string filename, string views)
    {
        string update = "update exploredetails set views='" + views + "' where companyid='" + companyid + "' AND filename='" + filename + "'";
        string slct = "select views from exploredetails where filename='" + filename + "'";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        con.Open();
        try
        {
            DataSet ds = new DataSet();
            using (SqlCommand cmd = new SqlCommand(update, con))
            {
                cmd.ExecuteNonQuery();
                using (SqlCommand cmd1 = new SqlCommand(slct, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    da.Fill(ds);
                    DataTable dt = new DataTable("Status");
                    dt.Columns.Add(new DataColumn("message", typeof(string)));
                    dt.Columns.Add(new DataColumn("valid", typeof(string)));
                    DataRow dr = dt.NewRow();
                    dr["message"] = "viewed";
                    dr["valid"] = "1";
                    dt.Rows.Add(dr);
                    ds.Tables.Add(dt);
                }
            }
            XmlDataDocument xmldata = new XmlDataDocument(ds);
            XmlElement xmlElement = xmldata.DocumentElement;
            return xmlElement;
        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;

        }
        finally
        {
            con.Close();
        }

    }
    [WebMethod]
    public XmlElement exploreLikes(string companyid, string filename, string likes)
    {
        string update = "update exploredetails set likes='" + likes + "' where companyid='" + companyid + "' AND filename='" + filename + "'";
        string slct = "select views from exploredetails where filename='" + filename + "'";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        con.Open();
        try
        {
            DataSet ds = new DataSet();
            using (SqlCommand cmd = new SqlCommand(update, con))
            {
                cmd.ExecuteNonQuery();
                using (SqlCommand cmd1 = new SqlCommand(slct, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    da.Fill(ds);
                    DataTable dt = new DataTable("Status");
                    dt.Columns.Add(new DataColumn("message", typeof(string)));
                    dt.Columns.Add(new DataColumn("valid", typeof(string)));
                    DataRow dr = dt.NewRow();
                    dr["message"] = "liked";
                    dr["valid"] = "1";
                    dt.Rows.Add(dr);
                    ds.Tables.Add(dt);
                }
            }
            XmlDataDocument xmldata = new XmlDataDocument(ds);
            XmlElement xmlElement = xmldata.DocumentElement;
            return xmlElement;
        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;
        }
        finally
        {
            con.Close();
        }

    }
    [WebMethod]
    public XmlElement serviceDetails(string companyid)
    {

        string slct3 = "select DISTINCT servicename, startingcost, paymentterms, travelcost from service where companyid='" + companyid + "'";
        SqlConnection con3 = new SqlConnection();
        con3.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd3 = new SqlCommand(slct3, con3);
            con3.Open();
            cmd3.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd3);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                DataTable dt = new DataTable("Status");
                dt.Columns.Add(new DataColumn("message", typeof(string)));
                dt.Columns.Add(new DataColumn("valid", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["message"] = "no data found";
                dr["valid"] = "0";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);
                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            else
            {

                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;

        }
        finally
        {
            con3.Close();
        }


    }
    [WebMethod]
    public XmlElement serviceImages(string companyid, string servicename)
    {

        try
        {

            DataSet ds = new DataSet();
            string exploreImage = System.Configuration.ConfigurationManager.AppSettings["companyDataPath"] + companyid + "\\" + "service" + "\\" + servicename;
            string exploreImage1;
            DirectoryInfo dir = new DirectoryInfo(Server.MapPath(exploreImage));
            FileInfo[] file = dir.GetFiles();
            if (file.Length == 0)
            {
                DataTable dt = new DataTable("Status");
                dt.Columns.Add(new DataColumn("message", typeof(string)));
                dt.Columns.Add(new DataColumn("valid", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["message"] = "no data found";
                dr["valid"] = "0";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);
                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            else
            {

                DataTable dt = new DataTable("Table");
                dt.Columns.Add("exploreImage1");
                foreach (FileInfo image in file)
                {
                    if (image.Exists)
                    {
                        exploreImage1 = image.Name;
                        dt.Rows.Add(exploreImage1);

                    }
                }
                ds.Tables.Add(dt);
                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;

        }



    }
    [WebMethod]
    public XmlElement booking(string companyid, string customername, string customernumber, string servicename)
    {

        
        SqlConnection con2 = new SqlConnection();
        con2.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            con2.Open();
            DataSet ds2 = new DataSet();
                string slctsms = "select companyname,smsapikey, smsuserid, smssenderid, phone, email from companydetails where companyid='" + companyid + "'";

                try
                {

                    SqlCommand cmdsms = new SqlCommand(slctsms, con2);
                    cmdsms.ExecuteNonQuery();
                    SqlDataReader drsms = cmdsms.ExecuteReader();
                    drsms.Read();
                    string sApikey = "" + drsms["smsapikey"].ToString();
                    string sUserID = "" + drsms["smsuserid"].ToString();
                    string sSenderid = "" + drsms["smssenderid"].ToString();
                    string companyphone = "" + drsms["phone"].ToString();
                    string companyname = "" + drsms["companyname"].ToString();
                    string companyemail = "" + drsms["email"].ToString();
                    string sType = "txt";
                    string sMessage = "Hello" + " " + companyname + ", Your customer has sent an enquiry via app. Service name is " + " " + servicename + ". Please contact your customer to confirm work. Customer's name is " + customername +  ", and number is "+ customernumber + ". For more assistance, feel free to contact fotolivin.";
                    string sURL = "http://smshorizon.co.in/api/sendsms.php?user=" + sUserID + "&apikey=" + sApikey + "&mobile=" + companyphone + "&senderid=" + sSenderid + "&message=" + sMessage + "&type=" + sType + "";
                    string sResponse = GetResponse(sURL);
                    MailMessage mail = new MailMessage();
                    string from, to, bcc, cc, subject, body;
                    from = "info@fotolivin.com";   //Email Address of Sender
                    to = companyemail;   //Email Address of Receiver
                    bcc = "";
                    cc = "";
                    subject = "This mail is from client.";
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Hello Sir,<br/>");
                    sb.Append("Your customer has sent an enquiry via app. Service name is " + " " + servicename + ". Please contact your customer to confirm work. Customer's name is " + customername + ", and number is " + customernumber + ".");
                    sb.Append("<br/>");
                    sb.Append("<br/>");
                    sb.Append("For any query please contact company.");
                    sb.Append("<br/>");
                    sb.Append("<br/>");
                    sb.Append("Thanking you<br/>");


                    body = sb.ToString();
                    mail.From = new MailAddress(from);
                    mail.To.Add(new MailAddress(to));

                    if (!string.IsNullOrEmpty(bcc))
                    {
                        mail.Bcc.Add(new MailAddress(bcc));
                    }
                    if (!string.IsNullOrEmpty(cc))
                    {
                        mail.CC.Add(new MailAddress(cc));
                    }

                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;

                    SendEMail(mail);
                    drsms.Close();
                    DataTable dt = new DataTable("Status");
                    DataSet ds3 = new DataSet();
                    dt.Columns.Add(new DataColumn("message", typeof(string)));
                    dt.Columns.Add(new DataColumn("valid", typeof(string)));
                    DataRow dr = dt.NewRow();
                    dr["message"] = "Booking successful..!!";
                    dr["valid"] = "1";
                    dt.Rows.Add(dr);
                    ds3.Tables.Add(dt);
                    XmlDataDocument xmldata = new XmlDataDocument(ds3);
                    XmlElement xmlElement = xmldata.DocumentElement;
                    return xmlElement;
                }
                catch (Exception ex)
                {
                    DataTable dterror = new DataTable("errorStatus");
                    dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
                    dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
                    DataRow drerror = dterror.NewRow();
                    DataSet dserror = new DataSet();
                    drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
                    drerror["errorValid"] = "0";
                    dterror.Rows.Add(drerror);
                    dserror.Tables.Add(dterror);
                    XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
                    XmlElement xmlElementerror = xmldataerror.DocumentElement;
                    return xmlElementerror;
                }


        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;

        }
        finally
        {
            con2.Close();
        }

    }
    [WebMethod]
    public XmlElement adDetails(string companyid)
    {

        string slct3 = "select adid, adname, addetail from addetails where companyid='" + companyid + "' order by id desc";
        SqlConnection con3 = new SqlConnection();
        con3.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd3 = new SqlCommand(slct3, con3);
            con3.Open();
            cmd3.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd3);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                DataTable dt = new DataTable("Status");
                dt.Columns.Add(new DataColumn("message", typeof(string)));
                dt.Columns.Add(new DataColumn("valid", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["message"] = "no data found";
                dr["valid"] = "0";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);
                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            else
            {
                SqlDataReader drnew = cmd3.ExecuteReader();
                drnew.Read();
                string adid = "" + drnew["adid"].ToString();
               // DataSet ds = new DataSet();
                string adImage = System.Configuration.ConfigurationManager.AppSettings["companyDataPath"] + companyid + "\\" + "addata";
                string adImage1;
                DirectoryInfo dir = new DirectoryInfo(Server.MapPath(adImage));
                FileInfo[] file = dir.GetFiles();
                DataTable dt = new DataTable("imagename");
                dt.Columns.Add("adImage1");
                foreach (FileInfo image in file)
                {
                    if (image.Exists)
                    {
                        adImage1 = image.Name;
                        dt.Rows.Add(adImage1);

                    }
                }
                ds.Tables.Add(dt);
                drnew.Close();
                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;

        }
        finally
        {
            con3.Close();
        }


    }
   


    [WebMethod]
    public XmlElement photoEventCover(string customerid, string companyid)
    {


        string slct4 = "select category, event, imagename, imageextension from photoDetails where customerid='" + customerid + "' AND companyid='" + companyid + "' AND category='" + "cover" + "'";
        SqlConnection con4 = new SqlConnection();
        con4.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd4 = new SqlCommand(slct4, con4);
            con4.Open();
            cmd4.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd4);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                DataTable dt = new DataTable("Status");
                dt.Columns.Add(new DataColumn("message", typeof(string)));
                dt.Columns.Add(new DataColumn("valid", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["message"] = "no data found";
                dr["valid"] = "0";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);
                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            else
            {
                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;

        }
        finally
        {
            con4.Close();
        }


    }
    [WebMethod]
    public XmlElement photoEventImages(string customerid, string companyid, string eventname)
    {


        string slct4 = "select category, event, imagename, imageextension, views, likes from photoDetails where customerid='" + customerid + "' AND companyid='" + companyid + "' AND event='" + eventname + "' AND category='" + "photos" + "' ";
        SqlConnection con4 = new SqlConnection();
        con4.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd4 = new SqlCommand(slct4, con4);
            con4.Open();
            cmd4.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd4);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                DataTable dt = new DataTable("Status");
                dt.Columns.Add(new DataColumn("message", typeof(string)));
                dt.Columns.Add(new DataColumn("valid", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["message"] = "no data found";
                dr["valid"] = "0";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);
                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            else
            {
                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;

        }
        finally
        {
            con4.Close();
        }


    }
    [WebMethod]
    public XmlElement photoEventImagesAndroid(string customerid, string companyid, string eventname, string lastid)
    {


        string slct4 = "select top 20 id, category, event, imagename, imageextension, views, likes from photoDetails where customerid='" + customerid + "' AND companyid='" + companyid + "' AND event='" + eventname + "' AND category='" + "photos" + "' AND id > '" + lastid + "' ";
        SqlConnection con4 = new SqlConnection();
        con4.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd4 = new SqlCommand(slct4, con4);
            con4.Open();
            cmd4.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd4);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                DataTable dt = new DataTable("Status");
                dt.Columns.Add(new DataColumn("message", typeof(string)));
                dt.Columns.Add(new DataColumn("valid", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["message"] = "no data found";
                dr["valid"] = "0";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);
                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            else
            {
                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;

        }
        finally
        {
            con4.Close();
        }


    }
    [WebMethod]
    public XmlElement photoViews(string customerid, string imagename, string views)
    {
        string update = "update photodetails set views='" + views + "' where customerid='" + customerid + "' AND imagename='" + imagename + "'";
        string slct = "select views from photodetails where customerid='" + customerid + "' AND imagename='" + imagename + "'";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        con.Open();
        try
        {
            DataSet ds = new DataSet();
            using (SqlCommand cmd = new SqlCommand(update, con))
            {
                cmd.ExecuteNonQuery();
                using (SqlCommand cmd1 = new SqlCommand(slct, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    da.Fill(ds);
                    DataTable dt = new DataTable("Status");
                    dt.Columns.Add(new DataColumn("message", typeof(string)));
                    dt.Columns.Add(new DataColumn("valid", typeof(string)));
                    DataRow dr = dt.NewRow();
                    dr["message"] = "viewed";
                    dr["valid"] = "1";
                    dt.Rows.Add(dr);
                    ds.Tables.Add(dt);
                }
            }
            XmlDataDocument xmldata = new XmlDataDocument(ds);
            XmlElement xmlElement = xmldata.DocumentElement;
            return xmlElement;
        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;
        }
        finally
        {
            con.Close();
        }

    }
    [WebMethod]
    public XmlElement photoLikes(string customerid, string imagename, string likes)
    {
        string update = "update photodetails set likes='" + likes + "' where customerid='" + customerid + "' AND imagename='" + imagename + "'";
        string slct = "select likes from photodetails where customerid='" + customerid + "' AND imagename='" + imagename + "'";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        con.Open();
        try
        {
            DataSet ds = new DataSet();
            using (SqlCommand cmd = new SqlCommand(update, con))
            {

                cmd.ExecuteNonQuery();
                using (SqlCommand cmd1 = new SqlCommand(slct, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    da.Fill(ds);
                    DataTable dt = new DataTable("Status");
                    dt.Columns.Add(new DataColumn("message", typeof(string)));
                    dt.Columns.Add(new DataColumn("valid", typeof(string)));
                    DataRow dr = dt.NewRow();
                    dr["message"] = "liked";
                    dr["valid"] = "1";
                    dt.Rows.Add(dr);
                    ds.Tables.Add(dt);
                }
            }
            XmlDataDocument xmldata = new XmlDataDocument(ds);
            XmlElement xmlElement = xmldata.DocumentElement;
            return xmlElement;
        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;
        }
        finally
        {
            con.Close();
        }

    }

    [WebMethod]
    public XmlElement videoDetails(string customerid, string companyid)
    {


        string slct5 = "select event, videoname, videoextension, views, likes from videoDetails where customerid='" + customerid + "' AND companyid='" + companyid + "'";
        SqlConnection con5 = new SqlConnection();
        con5.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd5 = new SqlCommand(slct5, con5);
            con5.Open();
            cmd5.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd5);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                DataTable dt = new DataTable("Status");
                dt.Columns.Add(new DataColumn("message", typeof(string)));
                dt.Columns.Add(new DataColumn("valid", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["message"] = "no data found";
                dr["valid"] = "0";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);
                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            else
            {
                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;
        }
        finally
        {
            con5.Close();
        }


    }
    [WebMethod]
    public XmlElement videoViews(string customerid, string videoname, string views)
    {
        string update = "update videodetails set views='" + views + "' where customerid='" + customerid + "' AND videoname='" + videoname + "'";
        string slct = "select views from videodetails where customerid='" + customerid + "' AND videoname='" + videoname + "'";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        con.Open();
        try
        {
            DataSet ds = new DataSet();
            using (SqlCommand cmd = new SqlCommand(update, con))
            {

                cmd.ExecuteNonQuery();
                using (SqlCommand cmd1 = new SqlCommand(slct, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    da.Fill(ds);
                    DataTable dt = new DataTable("Status");
                    dt.Columns.Add(new DataColumn("message", typeof(string)));
                    dt.Columns.Add(new DataColumn("valid", typeof(string)));
                    DataRow dr = dt.NewRow();
                    dr["message"] = "viewed";
                    dr["valid"] = "1";
                    dt.Rows.Add(dr);
                    ds.Tables.Add(dt);
                }
            }
            XmlDataDocument xmldata = new XmlDataDocument(ds);
            XmlElement xmlElement = xmldata.DocumentElement;
            return xmlElement;
        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;
        }
        finally
        {
            con.Close();
        }

    }
    [WebMethod]
    public XmlElement videoLikes(string customerid, string videoname, string likes)
    {
        string update = "update videodetails set likes='" + likes + "' where customerid='" + customerid + "' AND videoname='" + videoname + "'";
        string slct = "select likes from videodetails where customerid='" + customerid + "' AND videoname='" + videoname + "'";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        con.Open();
        try
        {

            DataSet ds = new DataSet();
            using (SqlCommand cmd = new SqlCommand(update, con))
            {

                cmd.ExecuteNonQuery();
                using (SqlCommand cmd1 = new SqlCommand(slct, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    da.Fill(ds);
                    DataTable dt = new DataTable("Status");
                    dt.Columns.Add(new DataColumn("message", typeof(string)));
                    dt.Columns.Add(new DataColumn("valid", typeof(string)));
                    DataRow dr = dt.NewRow();
                    dr["message"] = "liked";
                    dr["valid"] = "1";
                    dt.Rows.Add(dr);
                    ds.Tables.Add(dt);
                }
            }
            XmlDataDocument xmldata = new XmlDataDocument(ds);
            XmlElement xmlElement = xmldata.DocumentElement;
            return xmlElement;
        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;
        }
        finally
        {
            con.Close();
        }

    }

    [WebMethod]
    public XmlElement albumEventCover(string customerid, string companyid)
    {

        string slct6 = "select category, event, albumid, filename, fileextension, views, likes from albumDetails where customerid='" + customerid + "' AND companyid='" + companyid + "' AND category='" + "cover" + "'";
        SqlConnection con6 = new SqlConnection();
        con6.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd6 = new SqlCommand(slct6, con6);
            con6.Open();
            cmd6.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd6);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                DataTable dt = new DataTable("Status");
                dt.Columns.Add(new DataColumn("message", typeof(string)));
                dt.Columns.Add(new DataColumn("valid", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["message"] = "no data found";
                dr["valid"] = "0";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);
                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            else
            {
                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;
        }
        finally
        {
            con6.Close();
        }
    }
    [WebMethod]
    public XmlElement albumEventImages(string customerid, string companyid, string albumid)
    {

        string slct6 = "select category, event, albumid, filename, fileextension from albumDetails where customerid='" + customerid + "' AND companyid='" + companyid + "' AND category='" + "albums" + "' AND albumid='" + albumid + "' order by originalname asc";
        SqlConnection con6 = new SqlConnection();
        con6.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd6 = new SqlCommand(slct6, con6);
            con6.Open();
            cmd6.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd6);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                DataTable dt = new DataTable("Status");
                dt.Columns.Add(new DataColumn("message", typeof(string)));
                dt.Columns.Add(new DataColumn("valid", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["message"] = "no data found";
                dr["valid"] = "0";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);
                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            else
            {
                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;
        }
        finally
        {
            con6.Close();
        }
    }
    [WebMethod]
    public XmlElement albumsViews(string customerid, string albumid, string views)
    {
        string update = "update albumdetails set views='" + views + "' where customerid='" + customerid + "' AND albumid='" + albumid + "' AND category='" + "cover" + "'";
        string slct = "select views from albumdetails where customerid='" + customerid + "' AND albumid='" + albumid + "' AND category='" + "cover" + "'";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        con.Open();
        try
        {

            DataSet ds = new DataSet();
            using (SqlCommand cmd = new SqlCommand(update, con))
            {

                cmd.ExecuteNonQuery();
                using (SqlCommand cmd1 = new SqlCommand(slct, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    da.Fill(ds);
                    DataTable dt = new DataTable("Status");
                    dt.Columns.Add(new DataColumn("message", typeof(string)));
                    dt.Columns.Add(new DataColumn("valid", typeof(string)));
                    DataRow dr = dt.NewRow();
                    dr["message"] = "viewed";
                    dr["valid"] = "1";
                    dt.Rows.Add(dr);
                    ds.Tables.Add(dt);
                }
            }
            XmlDataDocument xmldata = new XmlDataDocument(ds);
            XmlElement xmlElement = xmldata.DocumentElement;
            return xmlElement;
        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;
        }
        finally
        {
            con.Close();
        }

    }
    [WebMethod]
    public XmlElement albumsLikes(string customerid, string albumid, string likes)
    {
        string update = "update albumdetails set likes='" + likes + "' where customerid='" + customerid + "' AND albumid='" + albumid + "' AND category='" + "cover" + "'";
        string slct = "select likes from albumdetails where customerid='" + customerid + "' AND albumid='" + albumid + "' AND category='" + "cover" + "'";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        con.Open();
        try
        {
            DataSet ds = new DataSet();
            using (SqlCommand cmd = new SqlCommand(update, con))
            {

                cmd.ExecuteNonQuery();
                using (SqlCommand cmd1 = new SqlCommand(slct, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    da.Fill(ds);
                    DataTable dt = new DataTable("Status");
                    dt.Columns.Add(new DataColumn("message", typeof(string)));
                    dt.Columns.Add(new DataColumn("valid", typeof(string)));
                    DataRow dr = dt.NewRow();
                    dr["message"] = "liked";
                    dr["valid"] = "1";
                    dt.Rows.Add(dr);
                    ds.Tables.Add(dt);
                }
            }
            XmlDataDocument xmldata = new XmlDataDocument(ds);
            XmlElement xmlElement = xmldata.DocumentElement;
            return xmlElement;
        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;
        }
        finally
        {
            con.Close();
        }

    }


    //portfolio api ends

    //order api starts
    
    public System.Drawing.Image Base64ToImage(string imagestring)
    {
        byte[] imageBytes = Convert.FromBase64String(imagestring);
        MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
        ms.Write(imageBytes, 0, imageBytes.Length);
        System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
        return image;
    }
    [WebMethod]
    public XmlElement orderRegister(string companyid, string customerid, string username, string email, string phone, string address, string productid, string productname, string productsize, string productprice, string imageprice, string totalamount, string imagestring)
    {

        DateTime date = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time")); ;

        int digit1 = Convert.ToInt32("8");
        string allowedChars = "";
        allowedChars = "1,2,3,4,5,6,7,8,9,0,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
        char[] sep = { ',' };
        string[] arr = allowedChars.Split(sep);
        string preorderid = "";
        string temp = "";
        Random rand = new Random();
        for (int i = 0; i < Convert.ToInt32(digit1); i++)
        {
            temp = arr[rand.Next(0, arr.Length)];
            preorderid += temp;

        }

        string orderid = preorderid;
        string slct2 = "select orderid from orders where orderid='" + orderid + "'";
        SqlConnection con2 = new SqlConnection();
        con2.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd2 = new SqlCommand(slct2, con2);
            con2.Open();
            cmd2.ExecuteNonQuery();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable("Status");
                dt.Columns.Add(new DataColumn("message", typeof(string)));
                dt.Columns.Add(new DataColumn("valid", typeof(string)));
                DataRow dr = dt.NewRow();
                DataSet ds4 = new DataSet();
                dr["message"] = "It seems there is a problem registering your order..!! Please try again..!!";
                dr["valid"] = "0";
                dt.Rows.Add(dr);
                ds4.Tables.Add(dt);
                XmlDataDocument xmldata = new XmlDataDocument(ds4);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;

            }
            else
            {
                string insert = "insert into orders values('" + companyid + "','" + customerid + "','" + username + "', '" + email + "','" + phone + "','" + address + "','" + orderid + "','" + productid + "','"+productname+"','"+productsize+"','"+productprice+"', '" + imageprice + "', '" + "pending" + "', '" + totalamount + "', '" + date + "')";
                string slctsms = "select companyname,smsapikey, smsuserid, smssenderid, phone, email from companydetails where companyid='" + companyid + "'";

                try
                {
                    string orderidpath = System.Configuration.ConfigurationManager.AppSettings["userDataPath"] + email + "\\" + "order" + "\\" + orderid;
                    Directory.CreateDirectory(Server.MapPath(orderidpath));

                    string orderPath = System.Configuration.ConfigurationManager.AppSettings["userDataPath"] + email + "\\" + "order" + "\\" + orderid + "\\" + orderid + ".jpg";
                    Base64ToImage(imagestring).Save(Server.MapPath(orderPath));

                    SqlCommand cmd1 = new SqlCommand(insert, con2);
                    cmd1.ExecuteNonQuery();
                    SqlCommand cmdsms = new SqlCommand(slctsms, con2);
                    cmdsms.ExecuteNonQuery();
                    SqlDataReader drsms = cmdsms.ExecuteReader();
                    drsms.Read();
                    string sApikey = "" + drsms["smsapikey"].ToString();
                    string sUserID = "" + drsms["smsuserid"].ToString();
                    string sSenderid = "" + drsms["smssenderid"].ToString();
                    string companyphone = "" + drsms["phone"].ToString();
                    string companyname = "" + drsms["companyname"].ToString();
                    string companyemail = "" + drsms["email"].ToString();
                    string sType = "txt";
                    string sMessage = "Hello" + " " + companyname + ", Your customer has registered an order via app. Orderid is " + " " + orderid + ". Please check details of order in your account. For more assistance, feel free to contact fotolivin.";
                    string sURL = "http://smshorizon.co.in/api/sendsms.php?user=" + sUserID + "&apikey=" + sApikey + "&mobile=" + companyphone + "&senderid=" + sSenderid + "&message=" + sMessage + "&type=" + sType + "";
                    string sResponse = GetResponse(sURL);
                    
                    string sMessageorder = "Hello" + " " + username + ", Your order has been registered to " + companyname + ". Your orderid is " + orderid + ". Check details of order in your order history. For more assistance, feel free to contact " + companyname + ", " + companyphone + ".";
                    string sURLorder = "http://smshorizon.co.in/api/sendsms.php?user=" + sUserID + "&apikey=" + sApikey + "&mobile=" + phone + "&senderid=" + sSenderid + "&message=" + sMessageorder + "&type=" + sType + "";
                    string sResponseorder = GetResponseorder(sURLorder);

                    MailMessage mail = new MailMessage();
                    string from, to, bcc, cc, subject, body;
                    from = "info@fotolivin.com";   //Email Address of Sender
                    to = companyemail;   //Email Address of Receiver
                    bcc = "";
                    cc = "";
                    subject = "This mail is from client.";
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Hello Sir,<br/>");
                    sb.Append("Your customer has registered an order via app. Orderid is  " + " " + orderid + ". Please check details of order in your account. For more assistance, feel free to contact fotolivin.");
                    sb.Append("<br/>");
                    sb.Append("<br/>");
                    sb.Append("For any query please contact company.");
                    sb.Append("<br/>");
                    sb.Append("<br/>");
                    sb.Append("Thanking you<br/>");


                    body = sb.ToString();
                    mail.From = new MailAddress(from);
                    mail.To.Add(new MailAddress(to));

                    if (!string.IsNullOrEmpty(bcc))
                    {
                        mail.Bcc.Add(new MailAddress(bcc));
                    }
                    if (!string.IsNullOrEmpty(cc))
                    {
                        mail.CC.Add(new MailAddress(cc));
                    }

                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;

                    SendEMail(mail);

                    drsms.Close();
                    DataTable dt = new DataTable("Status");
                    DataSet ds3 = new DataSet();
                    dt.Columns.Add(new DataColumn("message", typeof(string)));
                    dt.Columns.Add(new DataColumn("valid", typeof(string)));
                    DataRow dr = dt.NewRow();
                    dr["message"] = "Order placed successfully..!!";
                    dr["valid"] = "1";
                    dt.Rows.Add(dr);
                    ds3.Tables.Add(dt);
                    XmlDataDocument xmldata = new XmlDataDocument(ds3);
                    XmlElement xmlElement = xmldata.DocumentElement;
                    return xmlElement;
                }
                catch (Exception ex)
                {
                    cancelOrder(orderid, email);
                    DataTable dterror = new DataTable("errorStatus");
                    dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
                    dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
                    DataRow drerror = dterror.NewRow();
                    DataSet dserror = new DataSet();
                    drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
                    drerror["errorValid"] = "0";
                    dterror.Rows.Add(drerror);
                    dserror.Tables.Add(dterror);
                    XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
                    XmlElement xmlElementerror = xmldataerror.DocumentElement;
                    return xmlElementerror;
                }


            }
        }
        catch (Exception ex)
        {
            cancelOrder(orderid, email);
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;

        }
        finally
        {
            con2.Close();
        }

    }
    [WebMethod]
    public XmlElement uploadImage(string imagestring)
    {

        int digit1 = Convert.ToInt32("8");
        string allowedChars = "";
        allowedChars = "1,2,3,4,5,6,7,8,9,0";
        char[] sep = { ',' };
        string[] arr = allowedChars.Split(sep);
        string preorderid = "";
        string temp = "";
        Random rand = new Random();
        for (int i = 0; i < Convert.ToInt32(digit1); i++)
        {
            temp = arr[rand.Next(0, arr.Length)];
            preorderid += temp;

        }

        string orderid = preorderid;
        
               
                try
                {
                    
                    string orderPath = System.Configuration.ConfigurationManager.AppSettings["userDataPath"] + orderid + ".jpg";
                    Base64ToImage(imagestring).Save(Server.MapPath(orderPath));

                    DataTable dt = new DataTable("Status");
                    DataSet ds3 = new DataSet();
                    dt.Columns.Add(new DataColumn("message", typeof(string)));
                    dt.Columns.Add(new DataColumn("valid", typeof(string)));
                    DataRow dr = dt.NewRow();
                    dr["message"] = "Order placed successfully..!!";
                    dr["valid"] = "1";
                    dt.Rows.Add(dr);
                    ds3.Tables.Add(dt);
                    XmlDataDocument xmldata = new XmlDataDocument(ds3);
                    XmlElement xmlElement = xmldata.DocumentElement;
                    return xmlElement;
                }
                catch (Exception ex)
                {
                    
                    DataTable dterror = new DataTable("errorStatus");
                    dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
                    dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
                    DataRow drerror = dterror.NewRow();
                    DataSet dserror = new DataSet();
                    drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
                    drerror["errorValid"] = "0";
                    dterror.Rows.Add(drerror);
                    dserror.Tables.Add(dterror);
                    XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
                    XmlElement xmlElementerror = xmldataerror.DocumentElement;
                    return xmlElementerror;
                }


            
       

    }
   
    [WebMethod]
    public XmlElement cancelOrder(string orderid, string email)
    {
        string orderPath = System.Configuration.ConfigurationManager.AppSettings["userDataPath"] + email + "\\" + "order" + "\\" + orderid;
        string strng = Server.MapPath(orderPath);
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
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;
        }
        string delete = "delete from orders where orderid='" + orderid + "'";
        SqlConnection con2 = new SqlConnection();
        con2.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd2 = new SqlCommand(delete, con2);
            con2.Open();
            cmd2.ExecuteNonQuery();
            DataTable dt = new DataTable("Status");
            dt.Columns.Add(new DataColumn("message", typeof(string)));
            dt.Columns.Add(new DataColumn("valid", typeof(string)));
            DataRow dr = dt.NewRow();
            DataSet ds4 = new DataSet();
            dr["message"] = "Order canceled..!!";
            dr["valid"] = "1";
            dt.Rows.Add(dr);
            ds4.Tables.Add(dt);
            XmlDataDocument xmldata = new XmlDataDocument(ds4);
            XmlElement xmlElement = xmldata.DocumentElement;
            return xmlElement;
        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;
        }
        finally
        {
            con2.Close();
        }


    }
    [WebMethod]
    public XmlElement orderHistory(string emailid, string companyid)
    {

        string slct2 = "select productid, productname, productsize,orderstatus,totalamount, date from orders where emailid='" + emailid + "' AND companyid='"+companyid+"' order by id desc";
        SqlConnection con2 = new SqlConnection();
        con2.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd2 = new SqlCommand(slct2, con2);
            con2.Open();
            cmd2.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                DataTable dt = new DataTable("Status");
                dt.Columns.Add(new DataColumn("message", typeof(string)));
                dt.Columns.Add(new DataColumn("valid", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["message"] = "no data found";
                dr["valid"] = "0";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);
                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            else
            {
                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;
        }
        finally
        {
            con2.Close();
        }


    }
    // uncomment if needed. to get order details individually
    //[WebMethod]
    //public XmlElement orderDetails(string orderid)
    //{

    //    string slct2 = "select * from orders where orderid='" + orderid + "'";
    //    SqlConnection con2 = new SqlConnection();
    //    con2.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    //    try
    //    {
    //        SqlCommand cmd2 = new SqlCommand(slct2, con2);
    //        con2.Open();
    //        cmd2.ExecuteNonQuery();
    //        SqlDataAdapter da = new SqlDataAdapter(cmd2);
    //        DataSet ds = new DataSet();
    //        da.Fill(ds);
    //        if (ds.Tables[0].Rows.Count == 0)
    //        {
    //            DataTable dt = new DataTable("Status");
    //            dt.Columns.Add(new DataColumn("message", typeof(string)));
    //            DataRow dr = dt.NewRow();
    //            dr["message"] = "no data found";
    //            dt.Rows.Add(dr);
    //            ds.Tables.Add(dt);
    //            XmlDataDocument xmldata = new XmlDataDocument(ds);
    //            XmlElement xmlElement = xmldata.DocumentElement;
    //            return xmlElement;
    //        }
    //        else
    //        {
    //            XmlDataDocument xmldata = new XmlDataDocument(ds);
    //            XmlElement xmlElement = xmldata.DocumentElement;
    //            return xmlElement;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;

    //    }
    //    finally
    //    {
    //        con2.Close();
    //    }


    //}
    [WebMethod]
    public XmlElement productDisplay(string companyid)
    {

        string slct2 = "select productid, productname, productsize, productprice from products where companyid='" + companyid + "' order by id desc";
        SqlConnection con2 = new SqlConnection();
        con2.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd2 = new SqlCommand(slct2, con2);
            con2.Open();
            cmd2.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                DataTable dt = new DataTable("Status");
                dt.Columns.Add(new DataColumn("message", typeof(string)));
                dt.Columns.Add(new DataColumn("valid", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["message"] = "no data found";
                dr["valid"] = "0";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);
                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            else
            {
                XmlDataDocument xmldata = new XmlDataDocument(ds);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;
        }
        finally
        {
            con2.Close();
        }


    }
    // uncomment if needed. to get product details individually
    //[WebMethod]
    //public XmlElement productDetails(string productid)
    //{

    //    string slct2 = "select * from products where productid='" + productid + "'";
    //    SqlConnection con2 = new SqlConnection();
    //    con2.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    //    try
    //    {
    //        SqlCommand cmd2 = new SqlCommand(slct2, con2);
    //        con2.Open();
    //        cmd2.ExecuteNonQuery();
    //        SqlDataAdapter da = new SqlDataAdapter(cmd2);
    //        DataSet ds = new DataSet();
    //        da.Fill(ds);
    //        if (ds.Tables[0].Rows.Count == 0)
    //        {
    //            DataTable dt = new DataTable("Status");
    //            dt.Columns.Add(new DataColumn("message", typeof(string)));
    //            DataRow dr = dt.NewRow();
    //            dr["message"] = "no data found";
    //            dt.Rows.Add(dr);
    //            ds.Tables.Add(dt);
    //            XmlDataDocument xmldata = new XmlDataDocument(ds);
    //            XmlElement xmlElement = xmldata.DocumentElement;
    //            return xmlElement;
    //        }
    //        else
    //        {
    //            XmlDataDocument xmldata = new XmlDataDocument(ds);
    //            XmlElement xmlElement = xmldata.DocumentElement;
    //            return xmlElement;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;

    //    }
    //    finally
    //    {
    //        con2.Close();
    //    }


    //}

    //order api ends



    //dashboard api starts

    //[WebMethod]
    //public XmlElement companyLogin(string emailid, string password, string devicetype, string devicetoken)
    //{
    //    string slct2 = "select fullname, companyname, address, email, phone, city, state, country, about, service, achievement, smscredit, companyid, password from companydetails where email='" + emailid + "' AND password='" + password + "'";
    //    SqlConnection con2 = new SqlConnection();
    //    con2.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    //    try
    //    {
    //        SqlCommand cmd2 = new SqlCommand(slct2, con2);
    //        con2.Open();
    //        cmd2.ExecuteNonQuery();
    //        SqlDataAdapter da = new SqlDataAdapter(cmd2);
    //        DataSet ds = new DataSet();
    //        da.Fill(ds);
    //        if (ds.Tables[0].Rows.Count == 0)
    //        {
    //            DataTable dt = new DataTable("Status");
    //            dt.Columns.Add(new DataColumn("message", typeof(string)));
    //            DataRow dr = dt.NewRow();
    //            dr["message"] = "no data found";
    //            dt.Rows.Add(dr);
    //            ds.Tables.Add(dt);
    //            XmlDataDocument xmldata = new XmlDataDocument(ds);
    //            XmlElement xmlElement = xmldata.DocumentElement;
    //            return xmlElement;
    //        }
    //        else
    //        {
    //            string update = "update companydetails set devicetype='" + devicetype + "', devicetoken='" + devicetoken + "' where email='" + emailid + "' AND password='" + password + "'";
    //            SqlConnection con = new SqlConnection();
    //            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    //            try
    //            {
    //                SqlCommand cmd = new SqlCommand(update, con);
    //                con.Open();
    //                cmd.ExecuteNonQuery();
    //                XmlDataDocument xmldata = new XmlDataDocument(ds);
    //                XmlElement xmlElement = xmldata.DocumentElement;
    //                return xmlElement;
    //            }
    //            catch (Exception ex)
    //            {
    //                throw ex;

    //            }
    //            finally
    //            {

    //                con.Close();
    //            }

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;

    //    }
    //    finally
    //    {
    //        con2.Close();
    //    }


    //}
    //[WebMethod]
    //public XmlElement editCompanyDetails(string companyid, string fullname, string companyname, string address, string emailid, string phone, string city, string state, string country, string about, string service, string achievement, string password)
    //{

    //    string slct2 = "select companyid from companydetails where companyid='" + companyid + "'";
    //    string update = "update companydetails set fullname='" + fullname + "', companyname='" + companyname + "',address='" + address + "',email='" + emailid + "',phone='" + phone + "',city='" + city + "',state='" + state + "',country='" + country + "',about='" + about + "',service='" + service + "',achievement='" + achievement + "', password='" + password + "' where companyid='" + companyid + "'";
    //    string slctall = "select * from companydetails where companyid='" + companyid + "'";

    //    SqlConnection con2 = new SqlConnection();
    //    con2.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    //    con2.Open();
    //    try
    //    {
    //        SqlCommand cmd2 = new SqlCommand(slct2, con2);
    //        cmd2.ExecuteNonQuery();
    //        SqlDataAdapter da = new SqlDataAdapter(cmd2);
    //        DataSet ds = new DataSet();
    //        da.Fill(ds);
    //        if (ds.Tables[0].Rows.Count == 0)
    //        {
    //            DataTable dt = new DataTable("Status");
    //            dt.Columns.Add(new DataColumn("message", typeof(string)));
    //            DataRow dr = dt.NewRow();
    //            dr["message"] = "no data found";
    //            dt.Rows.Add(dr);
    //            ds.Tables.Add(dt);
    //            XmlDataDocument xmldata = new XmlDataDocument(ds);
    //            XmlElement xmlElement = xmldata.DocumentElement;
    //            return xmlElement;
    //        }
    //        else
    //        {
    //            try
    //            {

    //                using (SqlCommand cmd = new SqlCommand(update, con2))
    //                {
    //                    DataSet ds1 = new DataSet();
    //                    cmd.ExecuteNonQuery();

    //                    using(SqlCommand cmd1 = new SqlCommand(slctall,con2))
    //                    {
    //                        cmd1.ExecuteNonQuery();
    //                        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
    //                        DataTable dt = new DataTable("Status");
    //                        dt.Columns.Add(new DataColumn("message", typeof(string)));
    //                        DataRow dr = dt.NewRow();
    //                        dr["message"] = "Company details updated..!!";
    //                        dt.Rows.Add(dr);
    //                        ds1.Tables.Add(dt);
    //                        da1.Fill(ds1);
    //                    }
    //                    XmlDataDocument xmldata = new XmlDataDocument(ds1);
    //                    XmlElement xmlElement = xmldata.DocumentElement;
    //                    return xmlElement;
    //                }

    //            }
    //            catch (Exception ex)
    //            {
    //                throw ex;

    //            }

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;

    //    }
    //    finally
    //    {
    //        con2.Close();
    //    }


    //}
    //[WebMethod]
    //public int deleteCustomerAccount(string customerid, string galleryid, string companyid)
    //{
    //    string customerPath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + companyid + "\\" + galleryid;
    //    string strng = Server.MapPath(customerPath);
    //    try
    //    {

    //        if (Directory.Exists(strng))
    //        {
    //            foreach (string file in Directory.GetFiles(strng))
    //            {
    //                File.Delete(file);
    //            }
    //            foreach (string subfolder in Directory.GetDirectories(strng))
    //            {
    //                removedirectories(subfolder);
    //            }
    //            Directory.Delete(strng);

    //        }


    //    }
    //    catch (Exception ex)
    //    {
    //        Exception ex22 = ex;
    //        string errorMessage = string.Empty;
    //        while (ex22 != null)
    //        {
    //            errorMessage += ex22.ToString();
    //            ex22 = ex22.InnerException;
    //        }
    //    }
    //    string delete = "delete from customerdetails where customerid='" + customerid + "'; delete from albumdetails where customerid='" + customerid + "'; delete from photodetails where customerid='" + customerid + "'; delete from videodetails where customerid='" + customerid + "'; delete from loginusers where customerid='" + customerid + "'; delete from orders where customerid='" + customerid + "'";
    //    SqlConnection con2 = new SqlConnection();
    //    con2.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    //    try
    //    {
    //        SqlCommand cmd2 = new SqlCommand(delete, con2);
    //        con2.Open();
    //        int row = cmd2.ExecuteNonQuery();
    //        return row;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;

    //    }
    //    finally
    //    {
    //        con2.Close();
    //    }


    //}
    //[WebMethod]
    //public XmlElement userProfileDetails(string emailid)
    //{

    //    string slct2 = "select username, emailid, password, phone, address, city, state, pincode, birthdate, date from loginusers where emailid='" + emailid + "'";
    //    SqlConnection con2 = new SqlConnection();
    //    con2.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    //    try
    //    {
    //        SqlCommand cmd2 = new SqlCommand(slct2, con2);
    //        con2.Open();
    //        cmd2.ExecuteNonQuery();
    //        SqlDataAdapter da = new SqlDataAdapter(cmd2);
    //        DataSet ds = new DataSet();
    //        da.Fill(ds);
    //        if (ds.Tables[0].Rows.Count == 0)
    //        {
    //            DataTable dt = new DataTable("Status");
    //            dt.Columns.Add(new DataColumn("message", typeof(string)));
    //            DataRow dr = dt.NewRow();
    //            dr["message"] = "no data found";
    //            dt.Rows.Add(dr);
    //            ds.Tables.Add(dt);
    //            XmlDataDocument xmldata = new XmlDataDocument(ds);
    //            XmlElement xmlElement = xmldata.DocumentElement;
    //            return xmlElement;
    //        }
    //        else
    //        {

    //            XmlDataDocument xmldata = new XmlDataDocument(ds);
    //            XmlElement xmlElement = xmldata.DocumentElement;
    //            return xmlElement;

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;

    //    }
    //    finally
    //    {
    //        con2.Close();
    //    }


    //}
    //[WebMethod]
    //public XmlElement editExploreDetails(string companyid, string filename, string eventname, string location, string sale, string imageprice, string discountrate, string discountprice, string filesize, string filewidth, string fileheight, string fileextension )
    //{

    //    string slct2 = "select filename, companyid from exploredetails where companyid='" + companyid + "' AND filename='" + filename + "'";
    //    string update = "update exploredetails set event='" + eventname + "',filesize='"+filesize+"',filewidth='"+filewidth+"',fileheight='"+fileheight+"',fileextension='"+fileextension+"', location='" + location + "',sale='"+sale+"', imageprice='" + imageprice + "', discountrate='" + discountrate + "', discountprice ='" + discountprice + "' where filename='" + filename + "'";
    //    string slctall = "select event, filename, filesize, filewidth, fileheight, fileextension, location, sale, imageprice, discountrate, discountprice from exploredetails where companyid='" + companyid + "' AND filename='" + filename + "'";
    //    SqlConnection con2 = new SqlConnection();
    //    con2.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    //    con2.Open();
    //    try
    //    {
    //        SqlCommand cmd2 = new SqlCommand(slct2, con2);
    //        cmd2.ExecuteNonQuery();
    //        SqlDataAdapter da = new SqlDataAdapter(cmd2);
    //        DataSet ds = new DataSet();
    //        da.Fill(ds);
    //        if (ds.Tables[0].Rows.Count == 0)
    //        {
    //            DataTable dt = new DataTable("Status");
    //            dt.Columns.Add(new DataColumn("message", typeof(string)));
    //            DataRow dr = dt.NewRow();
    //            dr["message"] = "no data found";
    //            dt.Rows.Add(dr);
    //            ds.Tables.Add(dt);
    //            XmlDataDocument xmldata = new XmlDataDocument(ds);
    //            XmlElement xmlElement = xmldata.DocumentElement;
    //            return xmlElement;
    //        }
    //        else
    //        {
    //            try
    //            {
    //                DataSet ds1 = new DataSet();
    //                using (SqlCommand cmd = new SqlCommand(update, con2))
    //                {

    //                    cmd.ExecuteNonQuery();
    //                    using(SqlCommand cmd1 = new SqlCommand(slctall, con2))
    //                    {
    //                    cmd1.ExecuteNonQuery();
    //                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
    //                    DataTable dt = new DataTable("Status");
    //                    dt.Columns.Add(new DataColumn("message", typeof(string)));
    //                    DataRow dr = dt.NewRow();
    //                    dr["message"] = "Explore image details updated..!!";
    //                    dt.Rows.Add(dr);
    //                    ds1.Tables.Add(dt);
    //                    da1.Fill(ds1);
    //                    }
    //                }
    //                XmlDataDocument xmldata = new XmlDataDocument(ds1);
    //                XmlElement xmlElement = xmldata.DocumentElement;
    //                return xmlElement;
    //            }
    //            catch (Exception ex)
    //            {
    //                throw ex;

    //            }

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;

    //    }
    //    finally
    //    {
    //        con2.Close();
    //    }


    //}
    //[WebMethod]
    //public XmlElement addExploreImage(string companyid, string eventname, string filename, string filesize, string filewidth, string fileheight, string fileextension, string location,string sale, string imageprice, string discountrate, string discountprice, string date)
    //{

    //    string slct2 = "select filename from exploredetails where filename='" + filename + "'";
    //    SqlConnection con2 = new SqlConnection();
    //    con2.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    //    try
    //    {
    //        SqlCommand cmd2 = new SqlCommand(slct2, con2);
    //        con2.Open();
    //        cmd2.ExecuteNonQuery();
    //        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
    //        DataSet ds2 = new DataSet();
    //        da2.Fill(ds2);
    //        if (ds2.Tables[0].Rows.Count > 0)
    //        {
    //            DataTable dt = new DataTable("Status");
    //            dt.Columns.Add(new DataColumn("message", typeof(string)));
    //            DataRow dr = dt.NewRow();
    //            DataSet ds4 = new DataSet();
    //            dr["message"] = "filename already exists..!!";
    //            dt.Rows.Add(dr);
    //            ds4.Tables.Add(dt);
    //            XmlDataDocument xmldata = new XmlDataDocument(ds4);
    //            XmlElement xmlElement = xmldata.DocumentElement;
    //            return xmlElement;

    //        }

    //        else
    //        {
    //            string insert = "insert into exploredetails values('" + companyid + "', '" + "photo" + "','" + eventname + "','" + filename + "','" + filesize + "','" + filewidth + "','" + fileheight + "','" + fileextension + "','" + location + "','"+sale+"','" + imageprice + "', '" + discountrate + "', '" + discountprice + "',  '" + "0" + "', '" + "0" + "','" + date + "')";
    //            SqlConnection con1 = new SqlConnection();
    //            con1.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    //            try
    //            {
    //                SqlCommand cmd1 = new SqlCommand(insert, con1);
    //                con1.Open();
    //                cmd1.ExecuteNonQuery();
    //                DataTable dt = new DataTable("Status");
    //                DataSet ds3 = new DataSet();
    //                dt.Columns.Add(new DataColumn("message", typeof(string)));
    //                DataRow dr = dt.NewRow();
    //                dr["message"] = "Explore Image uploaded successfully..!!";
    //                dt.Rows.Add(dr);
    //                ds3.Tables.Add(dt);
    //                XmlDataDocument xmldata = new XmlDataDocument(ds3);
    //                XmlElement xmlElement = xmldata.DocumentElement;
    //                return xmlElement;
    //            }
    //            catch (Exception ex)
    //            {
    //                throw ex;

    //            }
    //            finally
    //            {
    //                con1.Close();
    //            }

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;

    //    }
    //    finally
    //    {
    //        con2.Close();
    //    }

    //}
    //[WebMethod]
    //public int deleteExploreImage(string companyid, string filename, string fileextension)
    //{
    //    string exploreimagePath = System.Configuration.ConfigurationManager.AppSettings["companyDataPath"] + companyid + "\\" + "explore" + "\\" + "photo" + "\\" + filename + fileextension;
    //    string strng = Server.MapPath(exploreimagePath);
    //    try
    //    {


    //        File.Delete(strng);




    //    }
    //    catch (Exception ex)
    //    {
    //        Exception ex22 = ex;
    //        string errorMessage = string.Empty;
    //        while (ex22 != null)
    //        {
    //            errorMessage += ex22.ToString();
    //            ex22 = ex22.InnerException;
    //        }
    //    }
    //    string delete = "delete from exploredetails where filename='" + filename + "'";
    //    SqlConnection con2 = new SqlConnection();
    //    con2.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    //    try
    //    {
    //        SqlCommand cmd2 = new SqlCommand(delete, con2);
    //        con2.Open();
    //        int row = cmd2.ExecuteNonQuery();
    //        return row;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;

    //    }
    //    finally
    //    {
    //        con2.Close();
    //    }


    //}
    //[WebMethod]
    //public int sendSms(string numbers, string message, string companyid)
    //{

    //    string slct = "select smsuserid, smsapikey, smssenderid from companydetails where companyid='" + companyid + "'";
    //    SqlConnection conslct = new SqlConnection();
    //    conslct.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    //    try
    //    {
    //        SqlCommand cmd2 = new SqlCommand(slct, conslct);
    //        conslct.Open();
    //        int row = cmd2.ExecuteNonQuery();
    //        SqlDataAdapter da = new SqlDataAdapter(cmd2);
    //        SqlDataReader dr = cmd2.ExecuteReader();
    //        while (dr.Read())
    //        {

    //            string smsuserid = "" + dr["smsuserid"].ToString();
    //            string smsapikey = "" + dr["smsapikey"].ToString();
    //            string smssenderid = "" + dr["smssenderid"].ToString();

    //            string sUserID = smsuserid;
    //            string sApikey = smsapikey;
    //            string sNumber = numbers;
    //            string sSenderid = smssenderid;
    //            string sMessage = message;

    //            string sType = "txt";
    //            string num = numbers;
    //            string[] multinum = num.Split(',');
    //            foreach (string multinums in multinum)
    //            {
    //                string sURL = "http://smshorizon.co.in/api/sendsms.php?user=" + sUserID + "&apikey=" + sApikey + "&mobile=" + multinums + "&senderid=" + sSenderid + "&message=" + sMessage + "&type=" + sType + "";
    //                string sResponse = GetResponse(sURL);

    //                string report1 = "http://smshorizon.co.in/api/status.php?user=" + sUserID + "&apikey=" + sApikey + "&msgid=" + sResponse + "";
    //                string status = GetResponse1(report1);
    //            }

    //        }
    //        dr.Close();

    //        return row;

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;

    //    }
    //    finally
    //    {

    //        conslct.Close();
    //    }

    //}
    //[WebMethod]
    //public XmlElement allStatsDashboard(string companyid)
    //{
    //    string slct1 = "select views, likes from albumdetails where companyid='" + companyid + "' AND category='" + "cover" + "'";
    //    string slct2 = "select views, likes from exploredetails where companyid='" + companyid + "'";
    //    string slct3 = "select views, likes from photodetails where companyid='" + companyid + "'";
    //    string slct4 = "select views, likes from videodetails where companyid='" + companyid + "'";
    //    string slct5 = "select companyid from loginusers where companyid='" + companyid + "'";
    //    string slct6 = "select companyid from customerdetails where companyid='" + companyid + "'";
    //    SqlConnection con2 = new SqlConnection();
    //    con2.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    //    con2.Open();
    //    try
    //    {
    //        DataSet ds = new DataSet();
    //        DataTable dt2 = new DataTable("totalstats");
    //        DataRow dr2 = dt2.NewRow();
    //        using (SqlCommand cmd2 = new SqlCommand(slct1, con2))
    //        {



    //            cmd2.ExecuteNonQuery();
    //            SqlDataAdapter da = new SqlDataAdapter(cmd2);
    //            DataTable dt = new DataTable();
    //            da.Fill(dt);

    //            DataTable dt1 = new DataTable("albumstats");


    //            dt1.Columns.Add(new DataColumn("message1", typeof(string)));
    //            dt1.Columns.Add(new DataColumn("views1", typeof(string)));
    //            dt1.Columns.Add(new DataColumn("likes1", typeof(string)));
    //            int a = 0;
    //            int b = 0;
    //            DataRow dr = dt1.NewRow();
    //            if (dt.Rows.Count > 0)
    //            {
    //                foreach (DataRow dr1 in dt.Rows)
    //                {
    //                    dr["message1"] = "Total views and likes statistics..!!";
    //                    a += Int32.Parse(dr1["views"].ToString());
    //                    dr["views1"] = a.ToString();
    //                    b += Int32.Parse(dr1["likes"].ToString());
    //                    dr["likes1"] = b.ToString();

    //                }
    //            }

    //            dt1.Rows.Add(dr);

    //            ds.Tables.Add(dt1);


    //        }
    //        using (SqlCommand cmd2 = new SqlCommand(slct2, con2))
    //        {



    //            cmd2.ExecuteNonQuery();
    //            SqlDataAdapter da = new SqlDataAdapter(cmd2);
    //            DataTable dt = new DataTable();
    //            da.Fill(dt);


    //            DataTable dt1 = new DataTable("explorestats");
    //            dt1.Columns.Add(new DataColumn("message2", typeof(string)));
    //            dt1.Columns.Add(new DataColumn("views2", typeof(string)));
    //            dt1.Columns.Add(new DataColumn("likes2", typeof(string)));
    //            int a = 0;
    //            int b = 0;
    //            DataRow dr = dt1.NewRow();
    //            if (dt.Rows.Count > 0)
    //            {
    //                foreach (DataRow dr1 in dt.Rows)
    //                {
    //                    dr["message2"] = "Total views and likes statistics..!!";
    //                    a += Int32.Parse(dr1["views"].ToString());
    //                    dr["views2"] = a.ToString();
    //                    b += Int32.Parse(dr1["likes"].ToString());
    //                    dr["likes2"] = b.ToString();

    //                }
    //            }

    //            dt1.Rows.Add(dr);

    //            ds.Tables.Add(dt1);


    //        }
    //        using (SqlCommand cmd2 = new SqlCommand(slct3, con2))
    //        {



    //            cmd2.ExecuteNonQuery();
    //            SqlDataAdapter da = new SqlDataAdapter(cmd2);
    //            DataTable dt = new DataTable();
    //            da.Fill(dt);

    //            DataTable dt1 = new DataTable("photostats");

    //            dt1.Columns.Add(new DataColumn("message3", typeof(string)));
    //            dt1.Columns.Add(new DataColumn("views3", typeof(string)));
    //            dt1.Columns.Add(new DataColumn("likes3", typeof(string)));
    //            int a = 0;
    //            int b = 0;
    //            DataRow dr = dt1.NewRow();
    //            if (dt.Rows.Count > 0)
    //            {
    //                foreach (DataRow dr1 in dt.Rows)
    //                {
    //                    dr["message3"] = "Total views and likes statistics..!!";
    //                    a += Int32.Parse(dr1["views"].ToString());
    //                    dr["views3"] = a.ToString();
    //                    b += Int32.Parse(dr1["likes"].ToString());
    //                    dr["likes3"] = b.ToString();

    //                }
    //            }

    //            dt1.Rows.Add(dr);

    //            ds.Tables.Add(dt1);


    //        }
    //        using (SqlCommand cmd2 = new SqlCommand(slct4, con2))
    //        {



    //            cmd2.ExecuteNonQuery();
    //            SqlDataAdapter da = new SqlDataAdapter(cmd2);
    //            DataTable dt = new DataTable();
    //            da.Fill(dt);

    //            DataTable dt1 = new DataTable("videostats");

    //            dt1.Columns.Add(new DataColumn("message4", typeof(string)));
    //            dt1.Columns.Add(new DataColumn("views4", typeof(string)));
    //            dt1.Columns.Add(new DataColumn("likes4", typeof(string)));
    //            int a = 0;
    //            int b = 0;
    //            DataRow dr = dt1.NewRow();
    //            if (dt.Rows.Count > 0)
    //            {
    //                foreach (DataRow dr1 in dt.Rows)
    //                {
    //                    dr["message4"] = "Total views and likes statistics..!!";
    //                    a += Int32.Parse(dr1["views"].ToString());
    //                    dr["views4"] = a.ToString();
    //                    b += Int32.Parse(dr1["likes"].ToString());
    //                    dr["likes4"] = b.ToString();

    //                }
    //            }

    //            dt1.Rows.Add(dr);

    //            ds.Tables.Add(dt1);


    //        }
    //        using (SqlCommand cmd2 = new SqlCommand(slct5, con2))
    //        {



    //            cmd2.ExecuteNonQuery();
    //            SqlDataAdapter da = new SqlDataAdapter(cmd2);
    //            DataTable dt = new DataTable();
    //            da.Fill(dt);

    //            DataTable dt1 = new DataTable("companyuserstats");
    //            dt1.Columns.Add(new DataColumn("message5", typeof(string)));
    //            dt1.Columns.Add(new DataColumn("companyusers", typeof(string)));
    //            DataRow dr = dt1.NewRow();

    //            dr["message5"] = "Total companyusers statistics..!!";
    //            dr["companyusers"] = "" + dt.Rows.Count.ToString();



    //            dt1.Rows.Add(dr);

    //            ds.Tables.Add(dt1);


    //        }
    //        using (SqlCommand cmd2 = new SqlCommand(slct6, con2))
    //        {



    //            cmd2.ExecuteNonQuery();
    //            SqlDataAdapter da = new SqlDataAdapter(cmd2);
    //            DataTable dt = new DataTable();
    //            da.Fill(dt);

    //            DataTable dt1 = new DataTable("companycustomerstats");
    //            dt1.Columns.Add(new DataColumn("message6", typeof(string)));
    //            dt1.Columns.Add(new DataColumn("companycustomers", typeof(string)));
    //            DataRow dr = dt1.NewRow();

    //            dr["message6"] = "Total companycustomers statistics..!!";
    //            dr["companycustomers"] = "" + dt.Rows.Count.ToString();



    //            dt1.Rows.Add(dr);

    //            ds.Tables.Add(dt1);


    //        }
    //        dt2.Columns.Add(new DataColumn("totalviews", typeof(string)));
    //        dt2.Columns.Add(new DataColumn("totallikes", typeof(string)));
    //        dt2.Columns.Add(new DataColumn("totalcompanyusers", typeof(string)));
    //        dt2.Columns.Add(new DataColumn("totalcompanycustomers", typeof(string)));
    //        dr2["totalviews"] = (Convert.ToInt32(ds.Tables[0].Rows[0]["views1"]) + Convert.ToInt32(ds.Tables[1].Rows[0]["views2"]) + Convert.ToInt32(ds.Tables[2].Rows[0]["views3"]) + Convert.ToInt32(ds.Tables[3].Rows[0]["views4"])).ToString();
    //        dr2["totallikes"] = (Convert.ToInt32(ds.Tables[0].Rows[0]["likes1"]) + Convert.ToInt32(ds.Tables[1].Rows[0]["likes2"]) + Convert.ToInt32(ds.Tables[2].Rows[0]["likes3"]) + Convert.ToInt32(ds.Tables[3].Rows[0]["likes4"])).ToString();
    //        dr2["totalcompanyusers"] = "" + ds.Tables[4].Rows[0]["companyusers"].ToString();
    //        dr2["totalcompanycustomers"] = "" + ds.Tables[5].Rows[0]["companycustomers"].ToString();
    //        dt2.Rows.Add(dr2);
    //        ds.Tables.Add(dt2);
    //        XmlDataDocument xmldata = new XmlDataDocument(ds);
    //        XmlElement xmlElement = xmldata.DocumentElement;
    //        return xmlElement;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;

    //    }
    //    finally
    //    {
    //        con2.Close();
    //    }

    //}

    //[WebMethod]
    //public XmlElement smsStats(string companyid)
    //{
    //    {
    //        string s1 = "select smscredit, smsapikey, smsuserid from companydetails where companyid='" + companyid + "'";
    //        SqlConnection con = new SqlConnection();
    //        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    //        try
    //        {
    //            SqlCommand cmd1 = new SqlCommand(s1, con);
    //            con.Open();
    //            cmd1.ExecuteNonQuery();
    //            SqlDataAdapter da = new SqlDataAdapter(cmd1);
    //            DataTable dt = new DataTable();
    //            da.Fill(dt);
    //            SqlDataReader dr1 = cmd1.ExecuteReader();
    //            dr1.Read();
    //            string credit = "" + dr1["smscredit"].ToString();
    //            string user = "" + dr1["smsuserid"].ToString();
    //            string apikey = "" + dr1["smsapikey"].ToString();
    //            string url = "http://smshorizon.co.in/api/balance.php?user=" + user + "&apikey=" + apikey;
    //            char[] split = { ':' };
    //            string rsms = GetResponse2(url);
    //            string[] balance = rsms.Split(split);
    //            string sentsms = (Convert.ToInt32(credit) - Convert.ToInt32(balance[1])).ToString();
    //            string bal = balance[1].ToString();
    //            DataTable dt2 = new DataTable("sms_stats");
    //            DataRow dr2 = dt2.NewRow();
    //            DataSet ds2 = new DataSet();
    //            dt2.Columns.Add(new DataColumn("credit", typeof(string)));
    //            dt2.Columns.Add(new DataColumn("balance", typeof(string)));
    //            dt2.Columns.Add(new DataColumn("sent", typeof(string)));
    //            dr2["credit"] = credit;
    //            dr2["balance"] = bal;
    //            dr2["sent"] = sentsms;
    //            dr1.Close();
    //            dt2.Rows.Add(dr2);
    //            ds2.Tables.Add(dt2);
    //            XmlDataDocument xmldata = new XmlDataDocument(ds2);
    //            XmlElement xmlElement = xmldata.DocumentElement;
    //            return xmlElement;
    //        }

    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //        finally
    //        {
    //            con.Close();

    //        }
    //    }
    //}

    //dashboard api ends
    [WebMethod]
    public XmlElement sendVerificationNumber(string phonenumber, string devicetoken, string email)
    {
        string slct2 = "select emailid from loginusers where emailid='" + email + "'";
        SqlConnection con2 = new SqlConnection();
        con2.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd2 = new SqlCommand(slct2, con2);
            con2.Open();
            cmd2.ExecuteNonQuery();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable("Status");
                dt.Columns.Add(new DataColumn("message", typeof(string)));
                dt.Columns.Add(new DataColumn("valid", typeof(string)));
                DataRow dr = dt.NewRow();
                DataSet ds4 = new DataSet();
                dr["message"] = "user already exists..!!";
                dr["valid"] = "0";
                dt.Rows.Add(dr);
                ds4.Tables.Add(dt);
                XmlDataDocument xmldata = new XmlDataDocument(ds4);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;

            }

            else
            {
                int digit1 = Convert.ToInt32("4");
                string allowedChars = "";
                allowedChars = "1,2,3,4,5,6,7,8,9,0";
                char[] sep = { ',' };
                string[] arr = allowedChars.Split(sep);
                string preorderid = "";
                string temp = "";
                Random rand = new Random();
                for (int i = 0; i < Convert.ToInt32(digit1); i++)
                {
                    temp = arr[rand.Next(0, arr.Length)];
                    preorderid += temp;

                }

                string orderid = preorderid;
                try
                {
                    string insert = "insert into verifynumber values('" + phonenumber + "','" + devicetoken + "','" + orderid + "')";
                    string slctsms = "select smsapikey, smsuserid, smssenderid from admin";

                    try
                    {
                        SqlCommand cmd1 = new SqlCommand(insert, con2);
                        cmd1.ExecuteNonQuery();
                        SqlCommand cmdsms = new SqlCommand(slctsms, con2);
                        cmdsms.ExecuteNonQuery();
                        SqlDataReader drsms = cmdsms.ExecuteReader();
                        drsms.Read();
                        string sApikey = "" + drsms["smsapikey"].ToString();
                        string sUserID = "" + drsms["smsuserid"].ToString();
                        string sSenderid = "" + drsms["smssenderid"].ToString();
                        string sType = "txt";
                        string sMessage = "Hello, your fotolivin verification number is " + " " + orderid + ". Please use it to verify your phone number in your account. For more assistance, feel free to contact company.";
                        string sURL = "http://smshorizon.co.in/api/sendsms.php?user=" + sUserID + "&apikey=" + sApikey + "&mobile=" + phonenumber + "&senderid=" + sSenderid + "&message=" + sMessage + "&type=" + sType + "";
                        string sResponse = GetResponse(sURL);
                        drsms.Close();
                        DataTable dt = new DataTable("Status");
                        DataSet ds3 = new DataSet();
                        dt.Columns.Add(new DataColumn("message", typeof(string)));
                        dt.Columns.Add(new DataColumn("valid", typeof(string)));
                        DataRow dr = dt.NewRow();
                        dr["message"] = "Verification number sent successfully..!!";
                        dr["valid"] = "1";
                        dt.Rows.Add(dr);
                        ds3.Tables.Add(dt);
                        XmlDataDocument xmldata = new XmlDataDocument(ds3);
                        XmlElement xmlElement = xmldata.DocumentElement;
                        return xmlElement;
                    }
                    catch (Exception ex)
                    {

                        DataTable dterror = new DataTable("errorStatus");
                        dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
                        dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
                        DataRow drerror = dterror.NewRow();
                        DataSet dserror = new DataSet();
                        drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
                        drerror["errorValid"] = "0";
                        dterror.Rows.Add(drerror);
                        dserror.Tables.Add(dterror);
                        XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
                        XmlElement xmlElementerror = xmldataerror.DocumentElement;
                        return xmlElementerror;
                    }



                }
                catch (Exception ex)
                {

                    DataTable dterror = new DataTable("errorStatus");
                    dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
                    dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
                    DataRow drerror = dterror.NewRow();
                    DataSet dserror = new DataSet();
                    drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
                    drerror["errorValid"] = "0";
                    dterror.Rows.Add(drerror);
                    dserror.Tables.Add(dterror);
                    XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
                    XmlElement xmlElementerror = xmldataerror.DocumentElement;
                    return xmlElementerror;

                }
                
            }
        }
        catch (Exception ex)
        {
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;

        }
        finally
        {
            con2.Close();
        }
        
    }
    [WebMethod]
    public XmlElement verifyNumber(string phonenumber, string devicetoken, string verificationnumber)
    {

        string slct2 = "select * from verifynumber where phonenumber='" + phonenumber + "' AND devicetoken='"+devicetoken+"' AND verificationnumber='"+verificationnumber+"'";
        SqlConnection con2 = new SqlConnection();
        con2.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd2 = new SqlCommand(slct2, con2);
            con2.Open();
            cmd2.ExecuteNonQuery();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                string delete = "delete from verifynumber where phonenumber='" + phonenumber + "' AND devicetoken='" + devicetoken + "'";

                try
                {
                    SqlCommand cmd1 = new SqlCommand(delete, con2);
                    cmd1.ExecuteNonQuery();
                    DataTable dt = new DataTable("Status");
                    DataSet ds3 = new DataSet();
                    dt.Columns.Add(new DataColumn("message", typeof(string)));
                    dt.Columns.Add(new DataColumn("valid", typeof(string)));
                    DataRow dr = dt.NewRow();
                    dr["message"] = "Verified..!!";
                    dr["valid"] = "1";
                    dt.Rows.Add(dr);
                    ds3.Tables.Add(dt);
                    XmlDataDocument xmldata = new XmlDataDocument(ds3);
                    XmlElement xmlElement = xmldata.DocumentElement;
                    return xmlElement;
                }
                catch (Exception ex)
                {

                    DataTable dterror = new DataTable("errorStatus");
                    dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
                    dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
                    DataRow drerror = dterror.NewRow();
                    DataSet dserror = new DataSet();
                    drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
                    drerror["errorValid"] = "0";
                    dterror.Rows.Add(drerror);
                    dserror.Tables.Add(dterror);
                    XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
                    XmlElement xmlElementerror = xmldataerror.DocumentElement;
                    return xmlElementerror;
                }
                
            }
            else
            {

                DataTable dt = new DataTable("Status");
                dt.Columns.Add(new DataColumn("message", typeof(string)));
                dt.Columns.Add(new DataColumn("valid", typeof(string)));
                DataRow dr = dt.NewRow();
                DataSet ds4 = new DataSet();
                dr["message"] = "Not verified..!! Please try again..!!";
                dr["valid"] = "0";
                dt.Rows.Add(dr);
                ds4.Tables.Add(dt);
                XmlDataDocument xmldata = new XmlDataDocument(ds4);
                XmlElement xmlElement = xmldata.DocumentElement;
                return xmlElement;


            }
        }
        catch (Exception ex)
        {
            
            DataTable dterror = new DataTable("errorStatus");
            dterror.Columns.Add(new DataColumn("errorMessage", typeof(string)));
            dterror.Columns.Add(new DataColumn("errorValid", typeof(string)));
            DataRow drerror = dterror.NewRow();
            DataSet dserror = new DataSet();
            drerror["errorMessage"] = "It seems there is a problem..!! Please try again later..!!";
            drerror["errorValid"] = "0";
            dterror.Rows.Add(drerror);
            dserror.Tables.Add(dterror);
            XmlDataDocument xmldataerror = new XmlDataDocument(dserror);
            XmlElement xmlElementerror = xmldataerror.DocumentElement;
            return xmlElementerror;

        }
        finally
        {
            con2.Close();
        }

    }

    


}










