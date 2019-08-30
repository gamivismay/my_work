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

public partial class company_service : System.Web.UI.Page
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
                bindExploreDetails();
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
            Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later. If still problem persist than contact admin');if(alert){ window.location='company-dashboard';}</script>");

        }
        productpanel.Visible = false;
    }


    protected void addbtn_Click(object sender, EventArgs e)
    {
        string coid1 = Session["ccoid"].ToString();
        string scheck = "select servicename from service where servicename='" + eventnamelist.Text + "' AND companyid='"+coid1+"'";
        SqlConnection concheck = new SqlConnection();
        concheck.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {
            SqlCommand cmdcheck = new SqlCommand(scheck, concheck);
            concheck.Open();
            cmdcheck.ExecuteNonQuery();
            SqlDataAdapter dacheck = new SqlDataAdapter(cmdcheck);
            DataTable dtcheck = new DataTable();
            dacheck.Fill(dtcheck);
            if (dtcheck.Rows.Count == 0)
            {

                string exploreImage = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + coid1 + "\\" + "service" + "\\" + eventnamelist.Text;
                Directory.CreateDirectory(Server.MapPath(exploreImage));


                foreach (HttpPostedFile uploadedFile in FileUpload1.PostedFiles)
                {
                    string filename = uploadedFile.FileName;
                    string fileext = Path.GetExtension(uploadedFile.FileName);
                    if (fileext == ".jpg" || fileext == ".JPG" || fileext == ".jpeg" || fileext == ".JPEG" || fileext == ".png" || fileext == ".PNG")
                    {
                        string companyservicepath = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + coid1 + "\\" + "service" + "\\" + eventnamelist.Text + "\\" + filename;

                        string SaveAsImage = System.IO.Path.Combine(Server.MapPath(companyservicepath));
                        uploadedFile.SaveAs(SaveAsImage);

                    }
                    else
                    {
                        Page.RegisterStartupScript("UserMsg", "<script>alert('Please upload a image..! or Check file format..! Only .jpg and .png is allowed.');if(alert){ window.location='company-service';}</script>");

                    }
                }
                string s1 = "insert into service values('" + coid1 + "','" + eventnamelist.Text + "','" + startingcost.Text + "','" + Paymentterms.Text + "','" + travelcost.Text + "')";
                SqlCommand cmd = new SqlCommand(s1, concheck);
                cmd.ExecuteNonQuery();
                Page.RegisterStartupScript("UserMsg", "<script>alert('Upload complete..!');if(alert){ window.location='company-service';}</script>");




            }
            else if (dtcheck.Rows.Count > 0)
            {
                Page.RegisterStartupScript("UserMsg", "<script>alert('Service already exists. Please edit service in details.');if(alert){ window.location='company-service';}</script>");

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
            concheck.Close();

        }
        
       
        
    }
  
    public void bindExploreDetails()
    {
        string coid1 = Session["ccoid"].ToString();
        string s1 = "select * from service where companyid='"+coid1+"'";
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
        bindExploreDetails();


    }
    protected void viewdetails_Command(object sender, CommandEventArgs e)
    {

        productpanel.Visible = true;
        string coid1 = Session["ccoid"].ToString();
        string servicename = Convert.ToString(e.CommandArgument);
        string s1 = "select * from service where servicename='" + servicename + "' AND companyid='" + coid1 + "'";
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
                editservicename.Text = "" + dr["servicename"].ToString();
                editpaymentterms.SelectedValue = "" + dr["paymentterms"].ToString();
                edittravelcost.SelectedValue = "" + dr["travelcost"].ToString();
                editstartingcost.Text = "" + dr["startingcost"].ToString();
                string exploreImage = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + coid1 + "\\" + "service" + "\\" + editservicename.Text;
                string exploreImage1;
                DirectoryInfo dir = new DirectoryInfo(MapPath(exploreImage));
                FileInfo[] file = dir.GetFiles();
                DataTable dt = new DataTable();
                dt.Columns.Add("exploreImage1");
                foreach (FileInfo image in file)
                {
                    if (image.Exists)
                    {
                        exploreImage1 = exploreImage + "\\" + image;
                        dt.Rows.Add(exploreImage1);
                        
                    }
                }
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
           
            dr.Close();
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
            Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='company-service';}</script>");

        }
        finally
        {
            con.Close();

        }

    }

    protected void updateinfobtn_Click(object sender, EventArgs e)
    {
        if (FileUpload2.HasFile)
        {
            productpanel.Visible = true;
            string coid1 = Session["ccoid"].ToString();

            
            string exploreImage = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + coid1 + "\\" + "service" + "\\" + editservicename.Text;

            foreach (HttpPostedFile uploadedFile1 in FileUpload2.PostedFiles)
            {
                string filename = uploadedFile1.FileName;
                string fileext = Path.GetExtension(uploadedFile1.FileName);
                if (fileext == ".jpg" || fileext == ".JPG" || fileext == ".jpeg" || fileext == ".JPEG" || fileext == ".png" || fileext == ".PNG")
                {
                    string companyservicepath = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + coid1 + "\\" + "service" + "\\" + editservicename.Text + "\\" + filename;

                    string SaveAsImage = System.IO.Path.Combine(Server.MapPath(companyservicepath));
                    uploadedFile1.SaveAs(SaveAsImage);

                }
                else
                {
                    Page.RegisterStartupScript("UserMsg", "<script>alert('Please upload a image..! or Check file format..! Only .jpg and .png is allowed.');if(alert){ window.location='company-service';}</script>");

                }
            }
            string insert = "update service set startingcost = '" + editstartingcost.Text + "', paymentterms='" + editpaymentterms.Text + "', travelcost='" + edittravelcost.Text + "' where servicename = '" + editservicename.Text + "' AND companyid='" + coid1 + "'";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            try
            {
                SqlCommand cmd = new SqlCommand(insert, con);
                con.Open();
                cmd.ExecuteNonQuery();
                Page.RegisterStartupScript("UserMsg", "<script>alert('Service updated..!');if(alert){ window.location='company-service';}</script>");

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
        else
        {
            productpanel.Visible = true;
            string coid1 = Session["ccoid"].ToString();

            string insert = "update service set startingcost = '" + editstartingcost.Text + "', paymentterms='" + editpaymentterms.Text + "', travelcost='" + edittravelcost.Text + "' where servicename = '" + editservicename.Text + "' AND companyid='" + coid1 + "'";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            try
            {
                SqlCommand cmd = new SqlCommand(insert, con);
                con.Open();
                cmd.ExecuteNonQuery();
                Page.RegisterStartupScript("UserMsg", "<script>alert('Service updated..!');if(alert){ window.location='company-service';}</script>");

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
    protected void deletebtn_Click(object sender, EventArgs e)
    {
        string coid1 = Session["ccoid"].ToString();
        string servicename = editservicename.Text;
        try
        {

            string exploreImage = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + coid1 + "\\" + "service" + "\\" + servicename;
            string strng = Server.MapPath(exploreImage);
            try
            {
                foreach (string file in Directory.GetFiles(strng))
                {
                    File.Delete(file);
                }
                foreach (string subfolder in Directory.GetDirectories(strng))
                {
                    removedirectories(subfolder);
                }
                Page.RegisterStartupScript("UserMsg", "<script>alert('Images deleted..!');if(alert){ window.location='company-service';}</script>");

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
    protected void delete_Command(object sender, CommandEventArgs e)
    {
        string coid1 = Session["ccoid"].ToString();
        string servicename = Convert.ToString(e.CommandArgument);
        try
        {

            string exploreImage = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + coid1 + "\\" + "service" + "\\" + servicename;
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
                string dltact = "delete from service where servicename='" + servicename + "' AND companyid='" + coid1 + "'";
                SqlConnection conact = new SqlConnection();
                conact.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                try
                {
                    SqlCommand cmdact = new SqlCommand(dltact, conact);
                    conact.Open();
                    cmdact.ExecuteNonQuery();
                    bindExploreDetails();
                    Page.RegisterStartupScript("UserMsg", "<script>alert('Service deleted..!');if(alert){ window.location='company-service';}</script>");

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