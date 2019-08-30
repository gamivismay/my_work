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
           
            string filename = postedFile.FileName;
            string ext = Path.GetExtension(postedFile.FileName);
            string originalname = Path.GetFileNameWithoutExtension(postedFile.FileName);
            long size = postedFile.ContentLength;
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

            string SaveAsImage = System.IO.Path.Combine(context.Server.MapPath(albumidpath + "/" + customerid + eventname + imageName + originalname + ext));
            postedFile.SaveAs(SaveAsImage);

            string finalimagename = customerid + eventname + imageName + originalname;
            string s1 = "insert into albumdetails values('"+companyid+"','"+customerid+"','"+ "albums" +"','"+eventname+"','"+albumid+"','"+originalname+"','"+finalimagename+"','"+size+"','"+ext+"','"+ "0" +"','"+ "0" +"')";
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