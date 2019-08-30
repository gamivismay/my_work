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

public partial class company_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void signinbtn_Click(object sender, EventArgs e)
    {
        string s1 = "select email,password,companyid from companydetails where email='" + usernametb.Text + "' AND password='" + passwordtb.Text + "'";
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
            if (dt.Rows.Count > 0)
            {
                string id = "" + dt.Rows[0]["companyid"].ToString();
                Session["cu"] = usernametb.Text;
                Session["cp"] = passwordtb.Text;
                Session["ccoid"] = id;
                Response.Redirect("company-dashboard");

            }
            else
            {
                Page.RegisterStartupScript("UserMsg", "<script>alert('Wrong username or password');if(alert){ window.location='company-login';}</script>");

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
            Page.RegisterStartupScript("UserMsg", "<script>alert('Login Failed. Try again later');if(alert){ window.location='company-login';}</script>");

        }
        finally
        {
            con.Close();

        }
    }
    protected void submitbtn_Click(object sender, EventArgs e)
    {
        WebClient wc = new WebClient();
        byte[] datasize = null;
        try
        {
            datasize = wc.DownloadData("http://www.google.com");
        }
        catch (Exception ex)
        {
            Page.RegisterStartupScript("UserMsg", "<script>alert('No internet connection. Try again later');if(alert){ window.location='company-login';}</script>");

        }
        try
        {
             string slct2 = "select email, password from companydetails where email='" + emailtb.Text + "'";
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
                Page.RegisterStartupScript("UserMsg", "<script>alert('Email does not exist...!!');if(alert){ window.location='company-login';}</script>");

            }
            else
            {
                MailMessage mail = BuildMail();
                SendEMail(mail);
                Response.Redirect("company-confirm-email");
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
        finally
        {
            con2.Close();
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
    private MailMessage BuildMail()
    {
        int digit = Convert.ToInt32("8");
        string allowedChars = "";
        allowedChars = "1,2,3,4,5,6,7,8,9,0,A,B,C,D,E,F,G,H,I,J,K,L,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
        char[] sep = { ',' };
        string[] arr = allowedChars.Split(sep);
        string referString = "";
        string temp = "";
        Random rand = new Random();
        for (int i = 0; i < Convert.ToInt32(digit); i++)
        {
            temp = arr[rand.Next(0, arr.Length)];
            referString += temp;

        }
        string newpassword = referString;
        string s1 = "update companydetails set password='" + newpassword + "' where email='" + emailtb.Text + "'";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd = new SqlCommand(s1, con);
            con.Open();
            cmd.ExecuteNonQuery();

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
            Page.RegisterStartupScript("UserMsg", "<script>alert('Login Failed. Try again later');if(alert){ window.location='company-login';}</script>");

        }
        finally
        {
            con.Close();

        }

        string from, to, bcc, cc, subject, body;
        from = "info@fotolivin.com";   //Email Address of Sender
        to = emailtb.Text;   //Email Address of Receiver
        bcc = "";
        cc = "";
        subject = "This is auto-generated email. please do not reply to this mail.";

        StringBuilder sb = new StringBuilder();
        sb.Append("Hello Sir,<br/>");
        sb.Append("Your password has been changed. You can change this password from your account in company profile.");
        sb.Append("<br/>");
        sb.Append("Your account details are as below : ");
        sb.Append("<br/>");
        sb.Append("your email id is:" + " " + emailtb.Text);
        sb.Append("<br/>");
        sb.Append("your password id is:" + " " + newpassword);
        sb.Append("<br/>");
        sb.Append("Thanking you<br/>");


        body = sb.ToString();

        MailMessage mail = new MailMessage();
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

        return mail;

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
 
}