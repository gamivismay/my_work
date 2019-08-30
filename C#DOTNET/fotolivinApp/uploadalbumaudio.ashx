<%@ WebHandler Language="C#" Class="Upload" %>

using System;
using System.Web;
using System.IO;
using System.Web.SessionState;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;

public class Upload : IHttpHandler
{
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Expires = -1;
        try
        {
            HttpPostedFile postedFile = context.Request.Files["Filedata"];
            string companyid = context.Request.QueryString["coid"];
            string customerid = context.Request.QueryString["customerid"];
            string eventname = context.Request.QueryString["eventname"];
            string albumid = context.Request.QueryString["albumid"];

            string eventnamepath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + companyid + "\\" + customerid + "\\" + "albums" + "\\" + eventname;
            Directory.CreateDirectory(context.Server.MapPath(eventnamepath));
            string albumidpath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + companyid + "\\" + customerid + "\\" + "albums" + "\\" + eventname + "\\" + albumid;
            Directory.CreateDirectory(context.Server.MapPath(albumidpath));
            string albumaudiopath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + companyid + "\\" + customerid + "\\" + "albums" + "\\" + eventname + "\\" + albumid + "\\" + "audio";
            Directory.CreateDirectory(context.Server.MapPath(albumaudiopath));
           
            
            string filename = postedFile.FileName;
            string ext = Path.GetExtension(postedFile.FileName);
            string size = postedFile.ContentLength.ToString();


            string SaveAsAudio = System.IO.Path.Combine(context.Server.MapPath(albumaudiopath + "/" + customerid + albumid + ext));
            postedFile.SaveAs(SaveAsAudio);


            string audioname = customerid + albumid;
           
            context.Response.Write(albumid + "/" + filename);
            context.Response.StatusCode = 200;
           
        }
        catch (Exception ex)
        {
            context.Response.Write("Error: " + ex.Message);
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
    
}