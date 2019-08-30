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
            string eventname = context.Request.QueryString["eventname"];
            string extension1 = ".jpg";
            string companyProfileImage = System.Configuration.ConfigurationManager.AppSettings["companyDataPath"] + companyid + "\\" + "explore" + "\\" + "photo";
            string filename = postedFile.FileName;
            long size = postedFile.ContentLength;
            string type = postedFile.ContentType;
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
            string SaveAsImage = System.IO.Path.Combine(context.Server.MapPath(companyProfileImage + "/" + companyid + eventname + imageName + filename + ext));
            postedFile.SaveAs(SaveAsImage);
            string finalimagename = companyid + eventname + imageName;
            string s1 = "insert into exploredetails values('" + companyid + "','" + "photo" + "','" + eventname + "','" + finalimagename + "','" + size + "','" + ext + "','" + "0" + "','" + "0" + "')";
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