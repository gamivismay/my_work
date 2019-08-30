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
            string extension1 = ".jpg";
            string photoeventcoverimg = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + companyid + "\\" + customerid + "\\" + "photos" + "\\" + eventname + "\\" + "cover";
            Directory.CreateDirectory(context.Server.MapPath(photoeventcoverimg));
            string filename = postedFile.FileName;
            string originalname = Path.GetFileNameWithoutExtension(postedFile.FileName);
            long size = postedFile.ContentLength;
            string type = postedFile.ContentType;
            string ext = Path.GetExtension(postedFile.FileName);
            string SaveAsImage = System.IO.Path.Combine(context.Server.MapPath(photoeventcoverimg + "/" + customerid + eventname + extension1));
            postedFile.SaveAs(SaveAsImage);
            string finalimagename = customerid + eventname;
            string s1 = "insert into photodetails values('" + companyid + "','" + customerid + "','" + "cover" + "','" + eventname + "','"+originalname+"','" + finalimagename + "','" + size + "','" + ext + "','" + "0" + "','" + "0" + "')";
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

            }
            finally
            {
                con.Close();

            }
            context.Response.Write(photoeventcoverimg + "/" + filename);
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