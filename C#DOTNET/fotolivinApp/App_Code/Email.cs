using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

/// <summary>
/// Summary description for Email
/// </summary>
public class EmailClass
{
    public bool a;
    public EmailClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void SendMail(string msg, string to, string subject)
    {
        try
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(to);
            mail.From = new MailAddress("info@fotolivin.com");
            mail.Subject = subject;

            string Body = null;
            Body = msg;
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "mail.fotolivin.com";
            smtp.Credentials = new System.Net.NetworkCredential("info@fotolivin.com", "Info_fotolivin04");
            smtp.Port = 25;
            smtp.EnableSsl = false;
            smtp.UseDefaultCredentials = false;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(mail);
            a = true;
        }
        catch (Exception ex)
        {
            ex.ToString();
            a = false;
        }


    }


}







