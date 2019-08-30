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

public partial class company_contact_us : System.Web.UI.Page
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
            Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later. If still problem persist than contact admin');if(alert){ window.location='company-dashboard';}</script>");

        }

    }
     public void companyDetails()
    {
        string u1 = Session["cu"].ToString();
        string p1 = Session["cp"].ToString();
        string coid1 = Session["ccoid"].ToString();
        string s1 = "select fullname, companyname, email, phone from companydetails where companyid='" + coid1 + "'";
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
                fullnametb.Text = "" + dr["fullname"].ToString();
                companynametb.Text = "" + dr["companyname"].ToString();
                emailtb.Text = "" + dr["email"].ToString();
                phonetb.Text = "" + dr["phone"].ToString();
                
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
            Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='company-dashboard';}</script>");

        }
        finally
        {
            con.Close();

        }
    }

    protected void sendbtn_Click(object sender, EventArgs e)
    {
        MailMessage mail = BuildMail();
        SendEMail(mail);
        messagetb.Text = "";
        Response.Write("<script>alert('Sent successfully. Wait for our response..!')</script>");
        
    }
    private MailMessage BuildMail()
    {
        string from, to, bcc, cc, subject, body;
        from = "info@fotolivin.com";   //Email Address of Sender
        to = "fotolivin@gmail.com";   //Email Address of Receiver
        bcc = "";
        cc = "";
        subject = "This mail is from client.";

        StringBuilder sb = new StringBuilder();
        sb.Append("Hello Sir,<br/>");
        sb.Append(fullnametb.Text);
        sb.Append("<br/>");
        sb.Append(companynametb.Text);
        sb.Append("<br/>");
        sb.Append(emailtb.Text);
        sb.Append("<br/>");
        sb.Append(phonetb.Text);
        sb.Append("<br/>");
        sb.Append(messagetb.Text);
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

            throw ex;
        }
    }
 
}