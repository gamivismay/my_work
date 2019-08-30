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

public partial class admin_order_history : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["au"] == null || Session["ap"] == null)
        {
            Response.Redirect("admin-login");
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
            Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later. If still problem persist than contact admin');if(alert){ window.location='admin-dashboard';}</script>");

        }

        Panel1.Visible = false;
    }
    public void bindUserDetails()
    {
        string u1 = Session["au"].ToString();
        string p1 = Session["ap"].ToString();
        string s1 = "select * from orders order by id desc";
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
                    DropDownList1.SelectedValue = "" + dr["orderstatus"].ToString(); 
                    edittotalamountlbl.Text = "" + dr["totalamount"].ToString();
                    editdatelbl.Text = "" + dr["date"].ToString();

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
                Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='admin-order-history';}</script>");

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
            Page.RegisterStartupScript("UserMsg", "<script>alert('Updated..!!');if(alert){ window.location='admin-order-history';}</script>");

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

                string orderimgPath = System.Configuration.ConfigurationManager.AppSettings["userDataPath1"] + editemailidlbl.Text + "\\" + "order" + "\\" + editorderidlbl.Text;
                string path = Server.MapPath(orderimgPath);
                DirectoryInfo dir = new DirectoryInfo(MapPath(orderimgPath));
                FileInfo[] file = dir.GetFiles();
                foreach (FileInfo image in file)
                {
                    if (image.Exists)
                    {
                        string orderimgPath1 = System.Configuration.ConfigurationManager.AppSettings["userDataPath1"] + editemailidlbl.Text + "\\" + "order" + "\\" + editorderidlbl.Text + "\\" + image;
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
    public void removedirectories1(string strng1)
    {
        foreach (string file in Directory.GetFiles(strng1))
        {
            File.Delete(file);
        }
        foreach (string subfolder in Directory.GetDirectories(strng1))
        {
            removedirectories(subfolder);
        }
        Directory.Delete(strng1);

    }

    protected void deletebtn_Click(object sender, EventArgs e)
    {

        try
        {

            string companyPath = System.Configuration.ConfigurationManager.AppSettings["userDataPath1"] + editemailidlbl.Text + "\\" + "order" + "\\" + editorderidlbl.Text;
            string strng = Server.MapPath(companyPath);

            try
            {

                if (Directory.Exists(strng))
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
                string dltact = "delete from orders where orderid='" + editorderidlbl.Text + "'";
                SqlConnection conact = new SqlConnection();
                conact.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                try
                {
                    SqlCommand cmdact = new SqlCommand(dltact, conact);
                    conact.Open();
                    cmdact.ExecuteNonQuery();

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

        bindUserDetails();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton l = (LinkButton)e.Row.FindControl("delete");
            l.Attributes.Add("onclick", "javascript:return " +
    "confirm('Are you sure you want to delete this record')");
        }
    }
}