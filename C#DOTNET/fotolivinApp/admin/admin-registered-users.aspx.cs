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

public partial class admin_registered_users : System.Web.UI.Page
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
            Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later. If still problem persist than contact admin');if(alert){ window.location='admin-dashboard';}</script>");

        }
        Panel1.Visible = false;
    }
    public void bindCustomerDetails()
    {
        string u1 = Session["au"].ToString();
        string p1 = Session["ap"].ToString();
        string s1 = "select id,companyid,customerid, emailid, phone, loginstatus, userstatus,date from loginusers order by id desc";
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
    

    protected void editlb_Command(object sender, CommandEventArgs e)
    {
        string id1 = Convert.ToString(e.CommandArgument);
        string s1 = "select * from loginusers where id='" + id1 + "'";
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
                editidlbl.Text = "" + dr["id"].ToString();
                editusernametb.Text = "" + dr["username"].ToString();
                editemailtb.Text = "" + dr["emailid"].ToString();
                editpasswordtb.Text = "" + dr["password"].ToString();
                editphonetb.Text = "" + dr["phone"].ToString();
                editaddresstb.Text = "" + dr["address"].ToString();
                editcitytb.Text = "" + dr["city"].ToString();
                editstatetb.Text = "" + dr["state"].ToString();
                editpincodetb.Text = "" + dr["pincode"].ToString();
                editbirthdatetb.Text = "" + dr["birthdate"].ToString();
                editcompanyidlbl.Text = "" + dr["companyid"].ToString();
                editcustomeridlbl.Text = "" + dr["customerid"].ToString();
                editaccountnamelbl.Text = "" + dr["accountname"].ToString();
                editdatelbl.Text = "" + dr["date"].ToString();
                editdevicetypelbl.Text = "" + dr["devicetype"].ToString();
                editdevicetokenlbl.Text = "" + dr["devicetoken"].ToString();
                loginstatusdl.SelectedValue = "" + dr["loginstatus"].ToString();
                userstatusdl.SelectedValue = "" + dr["userstatus"].ToString();
                bindCustomerDetails();
                Panel1.Visible = true;
                if(userstatusdl.SelectedIndex == 0)
                {
                    edituserstatuslbl.Text = "User Account";
                }
                if (userstatusdl.SelectedIndex == 1)
                {
                    edituserstatuslbl.Text = "Owner Account";
                }
                if (loginstatusdl.SelectedIndex == 0)
                {
                    editloginstatuslbl.Text = "Not logged in..!";
                }
                if (loginstatusdl.SelectedIndex == 1)
                {
                    editloginstatuslbl.Text = "logged in..!";
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
            Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='admin-dashboard';}</script>");

        }
        finally
        {
            con.Close();

        }
    }
    protected void updateinfobtn_Click(object sender, EventArgs e)
    {
        string s1 = "update loginusers set username='" + editusernametb.Text + "', emailid='" + editemailtb.Text + "',password='" + editpasswordtb.Text + "',phone='" + editphonetb.Text + "',address='" + editaddresstb.Text + "',city='" + editcitytb.Text + "',state='" + editstatetb.Text + "',pincode='" + editpincodetb.Text + "',birthdate='" + editbirthdatetb.Text + "',loginstatus='"+loginstatusdl.Text+"',userstatus='"+userstatusdl.Text+"' where id='" + editidlbl.Text + "'";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd = new SqlCommand(s1, con);
            con.Open();
            cmd.ExecuteNonQuery();
            bindCustomerDetails();
            Panel1.Visible = true;
            if (userstatusdl.SelectedIndex == 0)
            {
                edituserstatuslbl.Text = "User Account";
            }
            if (userstatusdl.SelectedIndex == 1)
            {
                edituserstatuslbl.Text = "Owner Account";
            }
            if (loginstatusdl.SelectedIndex == 0)
            {
                editloginstatuslbl.Text = "Not logged in..!";
            }
            if (loginstatusdl.SelectedIndex == 1)
            {
                editloginstatuslbl.Text = "logged in..!";
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
        finally
        {
            con.Close();

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

    protected void delete_Command(object sender, CommandEventArgs e)
    {

        string email = Convert.ToString(e.CommandArgument);       
            try
            {

                string companyPath = System.Configuration.ConfigurationManager.AppSettings["userDataPath1"] + email;
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
                    string dltact = "delete from loginusers where emailid='" + email + "'; delete from orders where emailid='"+ email +"'";
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