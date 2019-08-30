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
            string videoid = context.Request.QueryString["videoid"];
            string extension1 = ".mp4";
            string extension2 = ".jpg";
            string eventvideos = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + companyid + "\\" + customerid + "\\" + "videos" + "\\" + eventname;
            Directory.CreateDirectory(context.Server.MapPath(eventvideos));
            string eventvideosthumb = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + companyid + "\\" + customerid + "\\" + "videos" + "\\" + eventname + "\\" + "thumb";
            Directory.CreateDirectory(context.Server.MapPath(eventvideosthumb));
            string filename = postedFile.FileName;
            string originalname = Path.GetFileNameWithoutExtension(postedFile.FileName);
            long size = postedFile.ContentLength;
            string ext = Path.GetExtension(postedFile.FileName);
            int digit = Convert.ToInt32("5");
            string allowedChars = "";
            allowedChars = "1,2,3,4,5,6,7,8,9,0,A,B,C,D,E,F,G,H,I,J,K,L,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            char[] sep = { ',' };
            string[] arr = allowedChars.Split(sep);
            string preimagename = "";
            string temp = "";
            Random rand = new Random();
            for (int i = 0; i < Convert.ToInt32(digit); i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                preimagename += temp;

            }
            string imageName = preimagename;
            
            if (ext == ".mp4")
            {
                string SaveAsVideo = System.IO.Path.Combine(context.Server.MapPath(eventvideos + "/" + customerid + eventname + videoid + ext));
                postedFile.SaveAs(SaveAsVideo);
                string finalimagename = customerid + eventname + videoid ;
                string s1 = "insert into videodetails values('" + companyid + "','" + customerid + "','" + "videos" + "','" + eventname + "','"+originalname+"','" + finalimagename + "','" + size + "','" + ext + "','" + "0" + "','" + "0" + "')";
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
            }
            else if(ext==".jpg" || ext == ".jpeg" || ext==".JPG" || ext==".JPEG")
            {
                string SaveAsVideo = System.IO.Path.Combine(context.Server.MapPath(eventvideosthumb + "/" + customerid + eventname + videoid + ext));
                postedFile.SaveAs(SaveAsVideo);                
            }
            
            context.Response.Write(eventvideos + "/" + filename);
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