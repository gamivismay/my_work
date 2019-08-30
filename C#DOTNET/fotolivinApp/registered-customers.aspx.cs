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

public partial class registered_customers : System.Web.UI.Page
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
                bindCustomerDetails();
               
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
    }
     public void bindCustomerDetails()
    {
        string u1 = Session["u"].ToString();
        string p1 = Session["p"].ToString();
        string coid1 = Session["coid"].ToString();
        string s1 = "select id, customerid, customername, accountname, customeremail, customerphone, date from customerdetails where companyid='"+coid1+"' order by id desc";
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
        bindCustomerDetails();


    }
   
    protected void viewdetails_Command(object sender, CommandEventArgs e)
    {
        try
        {
            string a = Convert.ToString(e.CommandArgument);
            Session["cid"] = a;
            Response.Redirect("customer-profile");
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
   
    protected void delete_Command(object sender, CommandEventArgs e)
    {
        string customerid = Convert.ToString(e.CommandArgument);
        string companyid = ((Label)Master.FindControl("companyidlbl")).Text;
        string s1 = "select customerid from customerdetails where customerid='" + customerid + "'";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd = new SqlCommand(s1, con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
        try
        {

            string eventsPath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath"] + companyid + "\\" + customerid;
            string strng = Server.MapPath(eventsPath);
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
                string dltact = "delete from customerdetails where customerid='" + customerid + "'; delete from albumdetails where customerid='" + customerid + "'; delete from photodetails where customerid='" + customerid + "'; delete from videodetails where customerid='" + customerid + "'; delete from loginusers where customerid='"+customerid+"'; delete from orders where customerid='"+customerid+"'";
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
        bindCustomerDetails();
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