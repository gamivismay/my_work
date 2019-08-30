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

public partial class registered_users : System.Web.UI.Page
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
                bindUsersDetails();
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
            Page.RegisterStartupScript("UserMsg", "<script>alert('Failed1. Try again later. If still problem persist than contact admin');if(alert){ window.location='dashboard';}</script>");

        }
        productpanel.Visible = false;
    }


    public void bindUsersDetails()
    {
        string coid1 = Session["coid"].ToString();
        string s1 = "select id, customerid, username, emailid, phone, accountname, devicetype, date from loginusers where companyid='" + coid1 + "' order by id desc";
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
            GridView2.DataSource = dt;
            GridView2.DataBind();

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
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        GridView2.DataBind();
        bindUsersDetails();


    }
    protected void viewdetails_Command(object sender, CommandEventArgs e)
    {
        productpanel.Visible = true;
        string emailid = Convert.ToString(e.CommandArgument);
        string s1 = "select * from loginusers where emailid='" + emailid + "'";
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
                editcustomeridlbl.Text = "" + dr["customerid"].ToString();
                editusernamelbl.Text = "" + dr["username"].ToString();
                editemailidlbl.Text = "" + dr["emailid"].ToString();
                editpasswordlbl.Text = "" + dr["password"].ToString();
                editphonelbl.Text = "" + dr["phone"].ToString();
                editaddresslbl.Text = "" + dr["address"].ToString();
                editcitylbl.Text = "" + dr["city"].ToString();
                editstatelbl.Text = "" + dr["state"].ToString();
                editpincodelbl.Text = "" + dr["pincode"].ToString();
                editbirthdatelbl.Text = "" + dr["birthdate"].ToString();
                editaccountnamelbl.Text = "" + dr["accountname"].ToString();
                editdevicetypelbl.Text = "" + dr["devicetype"].ToString();
                editdevicetokenlbl.Text = "" + dr["devicetoken"].ToString();
                string loginstatus = "" + dr["loginstatus"].ToString();
                string userstatus = "" + dr["userstatus"].ToString();
                editdatelbl.Text = "" + dr["date"].ToString();

                if (loginstatus == "0")
                {
                    editloginstatuslbl.Text = "Not logged in..!";
                }
                if (loginstatus == "1")
                {
                    editloginstatuslbl.Text = "logged in..!";
                }
                if (userstatus == "0")
                {
                    edituserstatuslbl.Text = "User Account";
                }
                if (userstatus == "1")
                {
                    edituserstatuslbl.Text = "Owner Account";
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
            Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='registered-users';}</script>");

        }
        finally
        {
            con.Close();

        }

    }
    
    protected void delete_Command(object sender, CommandEventArgs e)
    {
        string emailid = Convert.ToString(e.CommandArgument);
        try
        {

            string productPath = System.Configuration.ConfigurationManager.AppSettings["userDataPath"] + emailid;
            string strng = Server.MapPath(productPath);
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
                string dltact = "delete from loginusers where emailid='" + emailid + "'";
                SqlConnection conact = new SqlConnection();
                conact.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                try
                {
                    SqlCommand cmdact = new SqlCommand(dltact, conact);
                    conact.Open();
                    cmdact.ExecuteNonQuery();
                    bindUsersDetails();
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
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton l = (LinkButton)e.Row.FindControl("delete");
            l.Attributes.Add("onclick", "javascript:return " +
    "confirm('Are you sure you want to delete this record')");
        }
    }
}