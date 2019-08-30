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
using Ionic.Zip;

public partial class order_history : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["u"] == null || Session["p"] == null || Session["coid"] == null || Session["oid"] == null)
        {
            Response.Redirect("login");
        }
        try
        {
            if (!IsPostBack)
            {
                bindUserDetails();
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
            Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later. If still problem persist than contact admin');if(alert){ window.location='dashboard';}</script>");

        }

        Panel1.Visible = false;
    }
    public void bindUserDetails()
    {
        string u1 = Session["u"].ToString();
        string p1 = Session["p"].ToString();
        string coid1 = Session["coid"].ToString();
        string s1 = "select * from orders where companyid='" + coid1 + "'  order by id desc";
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
            GridView1.DataSource = dt;
            GridView1.DataBind();

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
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
        bindUserDetails();


    }
    protected void viewdetails_Command(object sender, CommandEventArgs e)
    {
        Panel1.Visible = true;
        try
        {
            string a = Convert.ToString(e.CommandArgument);
            string s1 = "select * from orders where orderid='" + a + "'";
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
                    editcompanyidlbl.Text = "" + dr["companyid"].ToString();
                    editcustomeridlbl.Text = "" + dr["customerid"].ToString();
                    editusernamelbl.Text = "" + dr["username"].ToString();
                    editemailidlbl.Text = "" + dr["emailid"].ToString();
                    editphonelbl.Text = "" + dr["phone"].ToString();
                    editaddresslbl.Text = "" + dr["address"].ToString();
                    editorderidlbl.Text = "" + dr["orderid"].ToString();
                    editproductidlbl.Text = "" + dr["productid"].ToString();
                    editproductnamelbl.Text = "" + dr["productname"].ToString();
                    editproductsizelbl.Text = "" + dr["productsize"].ToString();
                    editproductpricelbl.Text = "" + dr["productprice"].ToString();
                    editimagepricelbl.Text = "" + dr["imageprice"].ToString();
                     edittotalamountlbl.Text = "" + dr["totalamount"].ToString();
                    editdatelbl.Text = "" + dr["date"].ToString();
                    DropDownList1.SelectedValue = "" + dr["orderstatus"].ToString(); 
                }
                //msgtexttb.Text = "Dear " + editusernamelbl.Text + ". your order is confirmed by the company. Total amount to be paid is " + edittotalamountlbl.Text + ". For more details please contact fotolivin support number.";
   
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
                Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='order-history';}</script>");

            }
            finally
            {
                con.Close();

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
   
    protected void updateinfobtn_Click(object sender, EventArgs e)
    {
        string s1 = "update orders set orderstatus='" + DropDownList1.Text + "' where orderid='" + editorderidlbl.Text + "'";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd = new SqlCommand(s1, con);
            con.Open();
            cmd.ExecuteNonQuery();
            Page.RegisterStartupScript("UserMsg", "<script>alert('Updated..!!');if(alert){ window.location='order-history';}</script>");

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


    protected void downloadimgbtn_Click(object sender, EventArgs e)
    {

        using (ZipFile zip = new ZipFile())
        {
            zip.AlternateEncodingUsage = ZipOption.AsNecessary;
            //zip.AddDirectoryByName("Files");

            try
            {

                string orderimgPath = System.Configuration.ConfigurationManager.AppSettings["userDataPath"] + editemailidlbl.Text + "\\" + "order" + "\\" + editorderidlbl.Text;
                string path = Server.MapPath(orderimgPath);
                DirectoryInfo dir = new DirectoryInfo(MapPath(orderimgPath));
                FileInfo[] file = dir.GetFiles();
                foreach (FileInfo image in file)
                {
                    if (image.Exists)
                    {
                        string orderimgPath1 = System.Configuration.ConfigurationManager.AppSettings["userDataPath"] + editemailidlbl.Text + "\\" + "order" + "\\" + editorderidlbl.Text + "\\" + image;
                        string path1 = Server.MapPath(orderimgPath1);
                        if (File.Exists(path1))
                        {

                            zip.AddFile(path1, editorderidlbl.Text.ToString());
                            Response.BufferOutput = false;

                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }



            string zipName = String.Format(editorderidlbl.Text + ".zip");
            Response.ContentType = "application/zip";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + zipName);
            zip.Save(Response.OutputStream);
            Response.End();


        }

    }
   
    //protected void sendsmsbtn_Click(object sender, EventArgs e)
    //{
    //    string u1 = Session["u"].ToString();
    //    string p1 = Session["p"].ToString();
    //    string coid1 = Session["coid"].ToString();


    //    if (editphonelbl.Text.Length > 0 && msgtexttb.Text.Length > 0)
    //    {
    //        WebClient wc = new WebClient();
    //        byte[] datasize = null;
    //        try
    //        {
    //            datasize = wc.DownloadData("http://www.google.com");
    //        }
    //        catch (Exception ex)
    //        {
    //            Page.RegisterStartupScript("UserMsg", "<script>alert('No internet connection. Try again later');if(alert){ window.location='order-history';}</script>");
              
    //            sendsmsbtn.Text = "Sms not sent. Send it again..??";

    //        }
    //        if (datasize != null && datasize.Length > 0)
    //        {
    //            if (editphonelbl.Text.Length > 0)
    //            {


    //                try
    //                {
    //                    string slct = "select smsuserid, smsapikey, smssenderid from companydetails where companyid='" + coid1 + "'";
    //                    SqlConnection conslct = new SqlConnection();
    //                    conslct.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    //                    try
    //                    {
    //                        SqlCommand cmd2 = new SqlCommand(slct, conslct);
    //                        conslct.Open();
    //                        cmd2.ExecuteNonQuery();
    //                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
    //                        SqlDataReader dr = cmd2.ExecuteReader();
    //                        while (dr.Read())
    //                        {

    //                            string smsuserid = "" + dr["smsuserid"].ToString();
    //                            string smsapikey = "" + dr["smsapikey"].ToString();
    //                            string smssenderid = "" + dr["smssenderid"].ToString();

    //                            string sUserID = smsuserid;
    //                            string sApikey = smsapikey;
    //                            string sNumber = editphonelbl.Text;
    //                            string sSenderid = smssenderid;
    //                            string sMessage = msgtexttb.Text;

    //                            string sType = "txt";


    //                            string sURL = "http://smshorizon.co.in/api/sendsms.php?user=" + sUserID + "&apikey=" + sApikey + "&mobile=" + sNumber + "&senderid=" + sSenderid + "&message=" + sMessage + "&type=" + sType + "";
    //                            string sResponse = GetResponse(sURL);

    //                            string report1 = "http://smshorizon.co.in/api/status.php?user=" + sUserID + "&apikey=" + sApikey + "&msgid=" + sResponse + "";
    //                            string status = GetResponse1(report1);
                               
    //                            sendsmsbtn.Text = "Sms sent. Send it again..??";
    //                            Page.RegisterStartupScript("UserMsg", "<script>alert('sms sent..!!');if(alert){ window.location='order-history';}</script>");

    //                        }
    //                    }
    //                    catch (Exception ex)
    //                    {
    //                        Page.RegisterStartupScript("UserMsg", "<script>alert('No internet connection. Try again later');if(alert){ window.location='order-history';}</script>");
                           
    //                        sendsmsbtn.Text = "Sms not sent. Send it again..??";
    //                    }
    //                    finally
    //                    {
    //                        conslct.Close();
    //                    }
    //                }
    //                catch (Exception ex)
    //                {
    //                    Exception ex2 = ex;
    //                    string errorMessage = string.Empty;
    //                    while (ex2 != null)
    //                    {
    //                        errorMessage += ex2.ToString();
    //                        ex2 = ex2.InnerException;
    //                    }
    //                    Page.RegisterStartupScript("UserMsg", "<script>alert('Sending Failed. Check Your internet connection. Try again later or contact your operator');if(alert){ window.location='order-history';}</script>");

                        
    //                    sendsmsbtn.Text = "Sms not sent. Send it again..??";
    //                }

    //            }
    //            else
    //            {
    //                Page.RegisterStartupScript("UserMsg", "<script>alert('Phone Number not valid. Try again later or contact your operator');if(alert){ window.location='order-history';}</script>");

    //            }
    //        }
    //        else
    //        {
    //            Page.RegisterStartupScript("UserMsg", "<script>alert('No internet connection. Try again later');if(alert){ window.location='order-history';}</script>");

    //        }

    //    }
    //    else
    //    {
    //        Page.RegisterStartupScript("UserMsg", "<script>alert('Phone Number not valid. Try again later');if(alert){ window.location='order-history';}</script>");

    //    }
    //}
    //public static string GetResponse(string sURL)
    //{
    //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL); request.MaximumAutomaticRedirections = 4;
    //    request.Credentials = CredentialCache.DefaultCredentials;
    //    try
    //    {
    //        HttpWebResponse response = (HttpWebResponse)request.GetResponse(); Stream receiveStream = response.GetResponseStream();
    //        StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8); string sResponse = readStream.ReadToEnd();
    //        response.Close();
    //        readStream.Close();
    //        return sResponse;
    //    }
    //    catch
    //    {
    //        return "";
    //    }
    //}
    //public static string GetResponse1(string report1)
    //{
    //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(report1); request.MaximumAutomaticRedirections = 4;
    //    request.Credentials = CredentialCache.DefaultCredentials;
    //    try
    //    {
    //        HttpWebResponse response = (HttpWebResponse)request.GetResponse(); Stream receiveStream = response.GetResponseStream();
    //        StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8); string sResponse = readStream.ReadToEnd();
    //        response.Close();
    //        readStream.Close();
    //        return sResponse;
    //    }
    //    catch
    //    {
    //        return "";
    //    }
    //}
}