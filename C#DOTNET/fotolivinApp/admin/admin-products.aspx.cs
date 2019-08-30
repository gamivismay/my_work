using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class admin_products : System.Web.UI.Page
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
            Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later. If still problem persist than contact admin');if(alert){ window.location='admin-dashboard';}</script>");

        }
        productpanel.Visible = false;
    }
   
    protected void addbtn_Click(object sender, EventArgs e)
    {
        string companyid = companyidlist.Text;
        if (FileUpload1.HasFile)
        {
           
                int digit1 = Convert.ToInt32("8");
                string allowedChars = "";
                allowedChars = "1,2,3,4,5,6,7,8,9,0,A,B,C,D,E,F,G,H,I,J,K,L,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
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
                string productid = preproductid;

                DateTime datetime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
                string productpath = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + companyid + "\\" + "productdata" + "\\" + productid;
                Directory.CreateDirectory(Server.MapPath(productpath));

                string productimagepath = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + companyid + "\\" + "productdata" + "\\" + productid + "\\";
                
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string fileext = Path.GetExtension(FileUpload1.PostedFile.FileName);
                if(fileext == ".png" || fileext == ".PNG")
                {
                    FileUpload1.PostedFile.SaveAs(Server.MapPath(productimagepath) + productid + fileext);
                    string insert = "insert into products values('" + companyidlist.Text + "','" + productid + "','" + productnametb.Text + "','" + productsizetb.Text + "','" + productpricetb.Text + "','" + datetime + "')";
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                    try
                    {
                        SqlCommand cmd = new SqlCommand(insert, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        Page.RegisterStartupScript("UserMsg", "<script>alert('Product added..!');if(alert){ window.location='admin-products';}</script>");

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
                        Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='admin-products';}</script>");

                    }
                    finally
                    {
                        con.Close();

                    }
                }
                else
                {
                    Page.RegisterStartupScript("UserMsg", "<script>alert('Image file not supported..! only png file format is supported..!');if(alert){ window.location='admin-products';}</script>");

                }
                
        }
        else
        {
            Page.RegisterStartupScript("UserMsg", "<script>alert('Please upload a product image..!');if(alert){ window.location='admin-products';}</script>");

        }
    }

    protected void updateinfobtn_Click(object sender, EventArgs e)
    {
        string companyid = editcompanyidlbl.Text;
        if (FileUpload2.HasFile)
        {
            productpanel.Visible = true;
            string productid = editproductidlbl.Text;

            DateTime datetime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));

            string productimagepath = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + companyid + "\\" + "productdata" + "\\" + productid + "\\";

            string fileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
            string fileext = Path.GetExtension(FileUpload2.PostedFile.FileName);
            if (fileext == ".png" || fileext == ".PNG")
            {
            FileUpload2.PostedFile.SaveAs(Server.MapPath(productimagepath) + productid + fileext);
            string insert = "update products set productname = '" + editproductnametb.Text + "', productsize = '" + editproductsizetb.Text + "', productprice = '" + editproductpricetb.Text + "', date = '" + datetime + "' where productid = '" + productid + "'";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            try
            {
                SqlCommand cmd = new SqlCommand(insert, con);
                con.Open();
                cmd.ExecuteNonQuery();
                Page.RegisterStartupScript("UserMsg", "<script>alert('Product updated..!');if(alert){ window.location='admin-products';}</script>");
                
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
                Page.RegisterStartupScript("UserMsg", "<script>alert('Image file not supported..! only png file format is supported..!!');if(alert){ window.location='admin-products';}</script>");

            }
        }
        else 
        {
            productpanel.Visible = true;
            string productid = editproductidlbl.Text;

            DateTime datetime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            string insert = "update products set productname = '" + editproductnametb.Text + "', productsize = '" + editproductsizetb.Text + "', productprice = '" + editproductpricetb.Text + "', date = '" + datetime + "' where productid = '" + productid + "'";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            try
            {
                SqlCommand cmd = new SqlCommand(insert, con);
                con.Open();
                cmd.ExecuteNonQuery();
                Page.RegisterStartupScript("UserMsg", "<script>alert('Product updated..!');if(alert){ window.location='admin-products';}</script>");
                
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

    protected void cancelbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("admin-products");
    }

    public void displayEvents()
    {

        string productid1;
        string productname1;
        string productprice1;
        string productsize1;
        string imagepath1;
        string date1;
        string companyid1;
        {
            string s1 = "select * from products order by id desc";
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
                dt1.Columns.Add("productid1");
                dt1.Columns.Add("productname1");
                dt1.Columns.Add("productprice1");
                dt1.Columns.Add("productsize1");
                dt1.Columns.Add("imagepath1");
                dt1.Columns.Add("date1");
                dt1.Columns.Add("companyid1");
                foreach (DataRow dr in dt.Rows)
                {
                    string productid2 = "" + dr["productid"].ToString();
                    string productname2 = "" + dr["productname"].ToString();
                    string productprice2 = "" + dr["productprice"].ToString();
                    string productsize2 = "" + dr["productsize"].ToString();
                    string date2 = "" + dr["date"].ToString();
                    string companyid2 = "" + dr["companyid"].ToString();

                    string imagePath = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + companyid2 + "\\" + "productdata" + "\\" + productid2;


                    DirectoryInfo dir = new DirectoryInfo(MapPath(imagePath));
                    FileInfo[] file = dir.GetFiles();
                    foreach (FileInfo image in file)
                    {
                        if (image.Exists)
                        {

                            productid1 = productid2;
                            productname1 = productname2;
                            productprice1 = productprice2;
                            productsize1 = productsize2;
                            imagepath1 = imagePath + "\\" + image;
                            date1 = date2;
                            companyid1 = companyid2;
                            dt1.Rows.Add(productid1, productname1, productprice1, productsize1, imagepath1, date1, companyid2);

                        }
                    }
                }
                Repeater2.DataSource = dt1;
                Repeater2.DataBind();
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

    protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            Label Label1 = (Label)e.Item.FindControl("companyidlbl");

            string coid1 = Label1.Text;

            string productid = e.CommandArgument.ToString();

            try
            {

                string imagePath = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + coid1 + "\\" + "productdata" + "\\" + productid;
                string strng = Server.MapPath(imagePath);
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
                    string dltact = "delete from products where productid='" + productid + "' AND companyid='" + coid1 + "'";
                    SqlConnection conact = new SqlConnection();
                    conact.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    try
                    {
                        SqlCommand cmdact = new SqlCommand(dltact, conact);
                        conact.Open();
                        cmdact.ExecuteNonQuery();
                        displayEvents();
                        Page.RegisterStartupScript("UserMsg", "<script>alert('Date deleted..!');if(alert){ window.location='admin-products';}</script>");

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
        if (e.CommandName == "edit")
        {
            productdetailspnl.Visible = false;
            addpnl.Visible = false;
            productpanel.Visible = true;
            string productid = Convert.ToString(e.CommandArgument);
            string s1 = "select * from products where productid='" + productid + "'";
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
                    string companyid = "" + dr["companyid"].ToString();
                    editcompanyidlbl.Text = "" + dr["companyid"].ToString();
                    editproductidlbl.Text = "" + dr["productid"].ToString();
                    editproductnametb.Text = "" + dr["productname"].ToString();
                    editproductsizetb.Text = "" + dr["productsize"].ToString();
                    editproductpricetb.Text = "" + dr["productprice"].ToString();
                    editdatelbl.Text = "" + dr["date"].ToString();
                    string productImage = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + companyid + "\\" + "productdata" + "\\" + productid;
                    string productImage1;
                    DirectoryInfo dir = new DirectoryInfo(MapPath(productImage));
                    FileInfo[] file = dir.GetFiles();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("productImage1");
                    productImage1 = productImage + "\\" + productid + ".png";
                    dt.Rows.Add(productImage1);
                    Repeater1.DataSource = dt;
                    Repeater1.DataBind();
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
                Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='admin-products';}</script>");

            }
            finally
            {
                con.Close();

            }
        }
    }

    //protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        LinkButton l = (LinkButton)e.Row.FindControl("delete");
    //        l.Attributes.Add("onclick", "javascript:return " +
    //"confirm('Are you sure you want to delete this record')");
    //    }
    //}
    //protected void delete_Command(object sender, CommandEventArgs e)
    //{
    //    string companyid = editcompanyidlbl.Text;
    //    string productid = Convert.ToString(e.CommandArgument);
    //    try
    //    {

    //        string productPath = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + companyid + "\\" + "productdata" + "\\" + productid;
    //        string strng = Server.MapPath(productPath);
    //        try
    //        {

    //            if (Directory.Exists(strng))
    //            {
    //                foreach (string file in Directory.GetFiles(strng))
    //                {
    //                    File.Delete(file);
    //                }
    //                foreach (string subfolder in Directory.GetDirectories(strng))
    //                {
    //                    removedirectories(subfolder);
    //                }
    //                Directory.Delete(strng);

    //            }


    //        }
    //        catch (Exception ex)
    //        {
    //            Exception ex22 = ex;
    //            string errorMessage = string.Empty;
    //            while (ex22 != null)
    //            {
    //                errorMessage += ex22.ToString();
    //                ex22 = ex22.InnerException;
    //            }
    //        }
    //        try
    //        {
    //            string dltact = "delete from products where productid='" + productid + "'";
    //            SqlConnection conact = new SqlConnection();
    //            conact.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    //            try
    //            {
    //                SqlCommand cmdact = new SqlCommand(dltact, conact);
    //                conact.Open();
    //                cmdact.ExecuteNonQuery();
    //                bindProductDetails();
    //            }
    //            catch (Exception ex)
    //            {
    //                throw ex;
    //            }
    //            finally
    //            {
    //                conact.Close();
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            Exception ex22 = ex;
    //            string errorMessage = string.Empty;
    //            while (ex22 != null)
    //            {
    //                errorMessage += ex22.ToString();
    //                ex22 = ex22.InnerException;
    //            }
    //        }

    //    }

    //    catch (Exception ex)
    //    {
    //        Exception ex2 = ex;
    //        string errorMessage = string.Empty;
    //        while (ex2 != null)
    //        {
    //            errorMessage += ex2.ToString();
    //            ex2 = ex2.InnerException;
    //        }

    //    }

    //}
    //public void bindProductDetails()
    //{
    //    string s1 = "select * from products order by id desc";
    //    SqlConnection con = new SqlConnection();
    //    con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    //    try
    //    {
    //        SqlCommand cmd = new SqlCommand(s1, con);
    //        con.Open();
    //        cmd.ExecuteNonQuery();
    //        SqlDataAdapter da = new SqlDataAdapter(cmd);
    //        DataTable dt = new DataTable();
    //        da.Fill(dt);
    //        GridView2.DataSource = dt;
    //        GridView2.DataBind();

    //    }

    //    catch (Exception ex)
    //    {
    //        Exception ex2 = ex;
    //        string errorMessage = string.Empty;
    //        while (ex2 != null)
    //        {
    //            errorMessage += ex2.ToString();
    //            ex2 = ex2.InnerException;
    //        }

    //    }
    //    finally
    //    {
    //        con.Close();

    //    }
    //}
    //protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    GridView2.PageIndex = e.NewPageIndex;
    //    GridView2.DataBind();
    //    bindProductDetails();


    //}
    //protected void viewdetails_Command(object sender, CommandEventArgs e)
    //{
    //    productpanel.Visible = true;
    //    string productid = Convert.ToString(e.CommandArgument);
    //    string s1 = "select * from products where productid='" + productid + "'";
    //    SqlConnection con = new SqlConnection();
    //    con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    //    try
    //    {
    //        SqlCommand cmd = new SqlCommand(s1, con);
    //        con.Open();
    //        cmd.ExecuteNonQuery();
    //        SqlDataAdapter da = new SqlDataAdapter(cmd);
    //        SqlDataReader dr = cmd.ExecuteReader();
    //        while (dr.Read())
    //        {
    //            string companyid = "" + dr["companyid"].ToString();
    //            editcompanyidlbl.Text = companyid;
    //            editproductidlbl.Text = "" + dr["productid"].ToString();
    //            editproductnametb.Text = "" + dr["productname"].ToString();
    //            editproductsizetb.Text = "" + dr["productsize"].ToString();
    //            editproductpricetb.Text = "" + dr["productprice"].ToString();
    //            editdatelbl.Text = "" + dr["date"].ToString();

    //            string productImage = System.Configuration.ConfigurationManager.AppSettings["companyDataPath1"] + companyid + "\\" + "productdata" + "\\" + productid;
    //            string productImage1;
    //            DirectoryInfo dir = new DirectoryInfo(MapPath(productImage));
    //            FileInfo[] file = dir.GetFiles();
    //            DataTable dt = new DataTable();
    //            dt.Columns.Add("productImage1");
    //            productImage1 = productImage + "\\" + productid + ".png";
    //            dt.Rows.Add(productImage1);
    //            Repeater1.DataSource = dt;
    //            Repeater1.DataBind();
    //        }
    //    }

    //    catch (Exception ex)
    //    {
    //        Exception ex2 = ex;
    //        string errorMessage = string.Empty;
    //        while (ex2 != null)
    //        {
    //            errorMessage += ex2.ToString();
    //            ex2 = ex2.InnerException;
    //        }
    //        Page.RegisterStartupScript("UserMsg", "<script>alert('Failed. Try again later');if(alert){ window.location='admin-products';}</script>");

    //    }
    //    finally
    //    {
    //        con.Close();

    //    }

    //}
}