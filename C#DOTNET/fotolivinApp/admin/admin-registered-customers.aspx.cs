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

public partial class admin_registered_customers : System.Web.UI.Page
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
        string s1 = "select id, companyid, companyname, email, phone, password, date from companydetails order by id desc";
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
        string coid1 = Convert.ToString(e.CommandArgument);
        string s1 = "select * from companydetails where companyid='" + coid1 + "'";
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
                editfullnametb.Text = "" + dr["fullname"].ToString();
                editcompanynametb.Text = "" + dr["companyname"].ToString();
                editaddresstb.Text = "" + dr["address"].ToString();
                editemailtb.Text = "" + dr["email"].ToString();
                editpasswordtb.Text = "" + dr["password"].ToString();
                editphonetb.Text = "" + dr["phone"].ToString();
                editcitytb.Text = "" + dr["city"].ToString();
                editstatetb.Text = "" + dr["state"].ToString();
                editcountrytb.Text = "" + dr["country"].ToString();
                editaboutinfotb.Text = "" + dr["about"].ToString();
                editachievementtb.Text = "" + dr["achievement"].ToString();
                editsmscreditslbl.Text = "" + dr["smscredit"].ToString();
                editsmsapikeylbl.Text = "" + dr["smsapikey"].ToString();
                editsmsuseridlbl.Text = "" + dr["smsuserid"].ToString();
                editsmssenderidlbl.Text = "" + dr["smssenderid"].ToString();
                editcompanyidlbl.Text = "" + dr["companyid"].ToString();
                editsampleaccountidlbl.Text = "" + dr["sampleaccountid"].ToString();
                editdatelbl.Text = "" + dr["date"].ToString();
                editdevicetypelbl.Text = "" + dr["devicetype"].ToString();
                editdevicetokenlbl.Text = "" + dr["devicetoken"].ToString();
                bindCustomerDetails();
                Panel1.Visible = true;
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
        string s1 = "update companydetails set fullname='" + editfullnametb.Text + "', companyname='" + editcompanynametb.Text + "',address='" + editaddresstb.Text + "',email='" + editemailtb.Text + "',phone='" + editphonetb.Text + "',city='" + editcitytb.Text + "',state='" + editstatetb.Text + "',country='" + editcountrytb.Text + "',about='" + editaboutinfotb.Text + "',achievement='" + editachievementtb.Text + "', smscredit='"+editsmscreditslbl.Text+"', smsapikey='"+editsmsapikeylbl.Text+"',smsuserid='"+editsmsuseridlbl.Text+"',smssenderid='"+editsmssenderidlbl.Text+"', password='" + editpasswordtb.Text + "', sampleaccountid='"+editsampleaccountidlbl.Text+"' where companyid='" + editcompanyidlbl.Text + "'";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmd = new SqlCommand(s1, con);
            con.Open();
            cmd.ExecuteNonQuery();
            bindCustomerDetails();
            Panel1.Visible = true;
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
    protected void loginlb_Command(object sender, CommandEventArgs e)
    {
        string coid1 = Convert.ToString(e.CommandArgument);
        string s1 = "select email, password, companyid from companydetails where email='" + coid1 + "'";
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
                string email = "" + dr["email"].ToString();
                string password = "" + dr["password"].ToString();
                string companyid = "" + dr["companyid"].ToString();
                Session["u"] = email;
                Session["p"] = password;
                Session["coid"] = companyid;
                Response.Redirect("~/" + "dashboard");
      
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

        string companyid = Convert.ToString(e.CommandArgument);       
            try
            {

                string companyPath = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + companyid;
                string customerPath = System.Configuration.ConfigurationManager.AppSettings["customerDataPath1"] + companyid;
                string strng = Server.MapPath(companyPath);
                string strng1 = Server.MapPath(customerPath);

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
                    if (Directory.Exists(strng1))
                    {
                        foreach (string file in Directory.GetFiles(strng1))
                        {
                            File.Delete(file);
                        }
                        foreach (string subfolder in Directory.GetDirectories(strng1))
                        {
                            removedirectories1(subfolder);
                        }
                        Directory.Delete(strng1);

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
                    string dltact = "delete from companydetails where companyid='" + companyid + "'; delete from customerdetails where companyid='" + companyid + "'; delete from albumdetails where companyid='" + companyid + "'; delete from photodetails where companyid='" + companyid + "'; delete from videodetails where companyid='" + companyid + "'; delete from exploredetails where companyid='" + companyid + "'; delete from products where companyid='" + companyid + "'; delete from service where companyid='" + companyid + "'; delete from addetails where companyid='" + companyid + "'; delete from orders where companyid='" + companyid + "'";
                    string updte = "update loginusers set companyid='"+""+"', customerid='"+""+"' where companyid='"+companyid+"'";
                    SqlConnection conact = new SqlConnection();
                    conact.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    try
                    {
                        SqlCommand cmdact = new SqlCommand(dltact, conact);
                        SqlCommand cmdact1 = new SqlCommand(updte, conact);
                        conact.Open();
                        cmdact.ExecuteNonQuery();
                        cmdact1.ExecuteNonQuery();

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