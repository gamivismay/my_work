using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using Ionic.Zip;

public partial class company_offer : System.Web.UI.Page
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
                displayEvents();
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
            Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later. If still problem persist than contact admin');if(alert){ window.location='company-offer';}</script>");

        }
    }
    protected void addbtn_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {

            int digit1 = Convert.ToInt32("10");
            string allowedChars = "";
            allowedChars = "1,2,3,4,5,6,7,8,9,0,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            char[] sep = { ',' };
            string[] arr = allowedChars.Split(sep);
            string preproductid = "";
            string temp = "";
            Random rand = new Random();
            for (int i = 0; i < Convert.ToInt32(digit1); i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                preproductid += temp;
            }
            string adid1 = preproductid;
            string companyid = Session["coid"].ToString();
            string adid = companyid + adid1;
            DateTime datetime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));

            string adpath = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + companyid + "\\" + "addata" + "\\" + adid;
            Directory.CreateDirectory(Server.MapPath(adpath));

            string adimagepath = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + companyid + "\\" + "addata" + "\\" + adid + "\\";

            string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string fileext = Path.GetExtension(FileUpload1.PostedFile.FileName);
            if (fileext == ".jpg" || fileext == ".JPG" || fileext == ".jpeg" || fileext == ".JPEG")
            {
            FileUpload1.PostedFile.SaveAs(Server.MapPath(adimagepath) + adid + fileext);
            string insert = "insert into addetails values('" + companyid + "','" + adid + "','" + adnametb.Text + "','" + addetailtb.Text + "','" + datetime + "')";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            try
            {
                SqlCommand cmd = new SqlCommand(insert, con);
                con.Open();
                cmd.ExecuteNonQuery();
                Page.RegisterStartupScript("UserMsg", "<script>alert('Ad added..!');if(alert){ window.location='company-offer';}</script>");

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
                Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='company-offer';}</script>");

            }
            finally
            {
                con.Close();

            }

            }
            else
            {
                Page.RegisterStartupScript("UserMsg", "<script>alert('Image file not supported..! only jpg file format is supported..!');if(alert){ window.location='company-offer';}</script>");

            }
        }
        else
        {
            Page.RegisterStartupScript("UserMsg", "<script>alert('Please upload a ad image..!');if(alert){ window.location='company-offer';}</script>");

        }
    }

    public void displayEvents()
    {
        string companyid = Session["ccoid"].ToString();
        string adPath1;
        string adNamePath1;
        string adidPath1;
        string addetailPath1;
        {
            string s1 = "select adid, adname, addetail from addetails where companyid='" + companyid + "' order by id desc";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            try
            {
                SqlCommand cmd = new SqlCommand(s1, con);
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                da.Fill(dt);
                dt1.Columns.Add("adNamePath1");
                dt1.Columns.Add("adPath1");
                dt1.Columns.Add("adidPath1");
                dt1.Columns.Add("addetailPath1");
                foreach (DataRow dr in dt.Rows)
                {
                    string adname = "" + dr["adname"].ToString();
                    string addetail = "" + dr["addetail"].ToString();

                    string adid = "" + dr["adid"].ToString();

                    string adPath = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + companyid + "\\" + "addata" + "\\" + adid;


                    DirectoryInfo dir = new DirectoryInfo(MapPath(adPath));
                    FileInfo[] file = dir.GetFiles();
                    foreach (FileInfo image in file)
                    {
                        if (image.Exists)
                        {

                            adPath1 = adPath + "\\" + image;
                            adNamePath1 = adname;
                            adidPath1 = adid;
                            addetailPath1 = addetail;
                            adidPath1 = adid;
                            dt1.Rows.Add(adNamePath1, adPath1, adidPath1, addetailPath1);

                        }
                    }

                }
                Repeater1.DataSource = dt1;
                Repeater1.DataBind();
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

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            string coid1 = Session["ccoid"].ToString();

            string adid = e.CommandArgument.ToString();

            try
            {

                string exploreImage = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + coid1 + "\\" + "addata" + "\\" + adid;
                string strng = Server.MapPath(exploreImage);
                try
                {
                    removedirectories(strng);
                }
                catch (Exception ex)
                {
                    Exception ex22 = ex;
                    string errorMessage = string.Empty;
                    while (ex22 != null)
                    {
                        errorMessage += ex22.ToString();
                        ex22 = ex22.InnerException;
                    }
                }
                try
                {
                    string dltact = "delete from addetails where adid='" + adid + "' AND companyid='" + coid1 + "'";
                    SqlConnection conact = new SqlConnection();
                    conact.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    try
                    {
                        SqlCommand cmdact = new SqlCommand(dltact, conact);
                        conact.Open();
                        cmdact.ExecuteNonQuery();
                        displayEvents();
                        Page.RegisterStartupScript("UserMsg", "<script>alert('Ad deleted..!');if(alert){ window.location='company-offer';}</script>");

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        conact.Close();
                    }
                }
                catch (Exception ex)
                {
                    Exception ex22 = ex;
                    string errorMessage = string.Empty;
                    while (ex22 != null)
                    {
                        errorMessage += ex22.ToString();
                        ex22 = ex22.InnerException;
                    }
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

            }
        }
    }

    protected void downloadsample_Click(object sender, System.EventArgs e)
    {
        using (ZipFile zip = new ZipFile())
        {
            zip.AlternateEncodingUsage = ZipOption.AsNecessary;
            //zip.AddDirectoryByName("Files");

            try
            {

                string orderimgPath = "~/adsampleimages";
                string path = Server.MapPath(orderimgPath);
                DirectoryInfo dir = new DirectoryInfo(MapPath(orderimgPath));
                FileInfo[] file = dir.GetFiles();
                foreach (FileInfo image in file)
                {

                    if (image.Exists)
                    {
                        string orderimgPath1 = orderimgPath + "\\" + image;
                        string path1 = Server.MapPath(orderimgPath1);
                        if (File.Exists(path1))
                        {

                            zip.AddFile(path1, "adsample");
                            Response.BufferOutput = false;

                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }



            string zipName = String.Format("adsample" + ".zip");
            Response.ContentType = "application/zip";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + zipName);
            zip.Save(Response.OutputStream);
            Response.End();


        }
    }
}