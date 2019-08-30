<%@ WebHandler Language="C#" Class="Upload" %>

using System;
using System.Web;
using System.IO;
using System.Web.SessionState;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

public class Upload : IHttpHandler
{
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Expires = -1;
        try
        {
            HttpPostedFile postedFile = context.Request.Files["Filedata"];
            string companyid = context.Request.QueryString["coid"];
            string extension1 = ".jpg";
            string companyProfileImage = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + companyid + "\\" + "profileimage";
            string filename = postedFile.FileName;
            string SaveAsImage = System.IO.Path.Combine(context.Server.MapPath(companyProfileImage + "/" + companyid + "profile" + extension1));
            postedFile.SaveAs(SaveAsImage);
            context.Response.Write(companyProfileImage + "/" + filename);
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