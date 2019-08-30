<%@ Page Title="" Language="C#" MasterPageFile="~/companyaccess/company-menu.master" AutoEventWireup="true" CodeFile="company-products.aspx.cs" Inherits="company_products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="Dashboard">
    <meta name="keyword" content="Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina">
    <title>Fotolivin</title>
    <script>
        // WRITE THE VALIDATION SCRIPT IN THE HEAD TAG.
        function isNumber(evt) {
            var iKeyCode = (evt.which) ? evt.which : evt.keyCode
            if (iKeyCode != 46 && iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57))
                return false;

            return true;
        }    
</script>
<script>
    // WRITE THE VALIDATION SCRIPT IN THE HEAD TAG.
    function isNumber1(evt) {
        var iKeyCode = (evt.which) ? evt.which : evt.keyCode
        if ((iKeyCode >= 0 && iKeyCode < 32) || (iKeyCode > 32 && iKeyCode < 48) || (iKeyCode > 57 && iKeyCode < 65) || (iKeyCode > 90 && iKeyCode < 97) || iKeyCode > 122)
            return false;

        return true;
    }    
</script>
    <link href="assets/css/lightbox.css" rel="stylesheet" type="text/css" />
    <!-- Bootstrap core CSS -->
    <link href="assets/css/bootstrap.css" rel="stylesheet">
    <!--external css-->
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="assets/css/zabuto_calendar.css">
    <link rel="stylesheet" type="text/css" href="assets/js/gritter/css/jquery.gritter.css" />
    <link rel="stylesheet" type="text/css" href="assets/lineicons/style.css">
    <!-- Custom styles for this template -->
    <link href="assets/css/style.css" rel="stylesheet">
    <link href="assets/css/style-responsive.css" rel="stylesheet">
    <script src="assets/js/chart-master/Chart.js"></script>
    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
      <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" Runat="Server">
    <!--main content start-->
    <section id="main-content">
        <section class="wrapper">

              <div class="row">
                  <div class="col-lg-9 main-chart" style="width: 100%;">
                  
                                        <asp:Panel ID="addpnl" runat="server">
                      <div class="row mtbox"  style="margin-top:40px; margin-bottom:0px;">
                          <div class="form-panel">
                              <h4 class="mb">
                                  <i class="fa fa-edit"></i>Add new product..!! <a style="color:Black;" data-toggle="modal" href="#myModal1"><img src="images/info.png"/ width="15" height="15"></a></h4>
                              <div class="form-horizontal style-form" >
                              <div class="form-group" style="width:48%; float:left; margin:0%;">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                          Product Name:</label>
                                      <div class="col-sm-10">
                                          <asp:TextBox ID="productnametb" MaxLength="45" class="form-control" runat="server" onkeypress="javascript:return isNumber1(event)"></asp:TextBox>
                                      </div>
                                  </div>
                                  <div class="form-group" style="width:48%;float:left; margin:0%;">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                          Product Size:</label>
                                      <div class="col-sm-10">
                                          <asp:TextBox ID="productsizetb" MaxLength="15" class="form-control" runat="server" onkeypress="javascript:return isNumber1(event)"></asp:TextBox>
                                      </div>
                                  </div>
                                  <div class="form-group" style="width:48%; margin:0%;">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                          Product Price:</label>
                                      <div class="col-sm-10">
                                          <asp:TextBox ID="productpricetb" MaxLength="15" onkeypress="javascript:return isNumber(event)" class="form-control" runat="server"></asp:TextBox>
                                      </div>
                                  </div>
                                 
                                 
                                  <div class="form-group" style="width:100%; margin:0%;">
                                    <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                         Upload Product Image</label>
                                <div class="col-sm-10">
                                  <asp:FileUpload ID="FileUpload1" runat="server" />
                                  </div>
                                

</div>
<div class="form-group" style="width:100%; margin:0%;">
<label class="control-label" style="padding:0%; color:Red;">
                                         * Only .png or .PNG files are allowed</label>
                                         <br />
 <label class="control-label" style="padding:0%; color:Red;">
                                         * Use image size of 100kb only for better perfomance</label>

</div>
                                   <div class="form-group">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                      </label>
                                      <asp:Button ID="addbtn" class="btn btn-default" runat="server" 
                                           Text="Add Product" onclick="addbtn_Click"/>
                                          
                                  </div>
                              </div>
                              </div>
                              </div>
                                        </asp:Panel>

                      <!-- /row mt -->
                     
                        <div aria-hidden="true" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" id="myModal1" class="modal fade">
		              <div class="modal-dialog">
		                  <div class="modal-content">
		                  
						<center>
						<div class="form-panel">
                        <h4 class="mb"><i class="fa fa-edit"></i> Add new product image with its details in app</h4>
                        
                        <div class="form-horizontal style-form">
                         <div class="form-group">
                            
                            <img src="images/product1.png" style="width:100%; height:auto;"/>

                          </div>
                         
                          
                          </div>
                        
                        </div>
					</center>
		                  </div>
		              </div>
		          </div>
                      <!-- /row -->
                      
                       <asp:ScriptManager ID="ScriptManager1" runat="server">
                      </asp:ScriptManager>
                      <!-- /row -->
                    
                      <%--<div class="row mtbox" style="margin-top:0px; margin-bottom:0px;">
                       <div class="form-panel">
                        <h4 class="mb">
                                  <i class="fa fa-edit"></i> Products</h4>
                           
                        <div class="form-horizontal style-form">
                       
                       <asp:GridView ID="GridView2"  runat="server" AutoGenerateColumns="False"  
                      HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                HeaderStyle-VerticalAlign="Middle" 
                      RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle"
                                Width="100%" Height="100%" AllowPaging="True" 
                              OnPageIndexChanging="GridView2_PageIndexChanging" BackColor="#CCCCCC" 
                              BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" 
                              CellSpacing="3" ForeColor="Black" onrowdatabound="GridView2_RowDataBound" PageSize="25">
                      <AlternatingRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                      <Columns>
                          <asp:TemplateField HeaderText="ID">
                              <EditItemTemplate>
                              <%#Container.DataItemIndex+1 %>   
                                  <asp:Label ID="labelid" Visible="False" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                              </EditItemTemplate>
                              <ItemTemplate>
                                  <%#Container.DataItemIndex+1 %>
                                  <asp:Label ID="Label1" Visible="False" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:BoundField DataField="companyid" HeaderText="Company ID" /> 
                          <asp:BoundField DataField="productid" HeaderText="Product ID" /> 
                          <asp:BoundField DataField="productname" HeaderText="Productname" />
                          <asp:BoundField DataField="productsize" HeaderText="ProductSize"></asp:BoundField>
                           <asp:BoundField DataField="date" HeaderText="Date" />
                          <asp:TemplateField HeaderText="Detail">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="viewdetails" runat="server" CommandArgument='<%# Bind("productid") %>' oncommand="viewdetails_Command">view more</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Delete">
                              <EditItemTemplate>
                                  <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                              </EditItemTemplate>
                              <ItemTemplate>
                                  <asp:LinkButton ID="delete" runat="server" 
                                      CommandArgument='<%# Bind("productid") %>' oncommand="delete_Command">Delete</asp:LinkButton>
                              </ItemTemplate>
                          </asp:TemplateField>
                      </Columns>
                            <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <FooterStyle BackColor="#CCCCCC" />
                      <HeaderStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />

                            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />

<RowStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="White"></RowStyle>

                      <SelectedRowStyle 
                          HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#000099" 
                                Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                  </asp:GridView>
                                  </div>
                       </div>
                      </div>--%>
                      
                      <asp:Panel ID="productdetailspnl" runat="server">
                      <asp:Repeater ID="Repeater2" runat="server" onitemcommand="Repeater2_ItemCommand">
                  <ItemTemplate>
                  <div class="col-lg-9 main-chart" style="width:20%; padding-top:0px;">
                      <div class="row mtbox" style="margin-top:0px; margin-bottom:0px;">
                          <div class="form-panel" style="min-height:380px; margin:5px; padding:5px;">
                             <center>
                              <h4 class="mb" style="text-decoration: underline;">
                                 
                                  <asp:Label ID="title" runat="server" Text='<%#Eval("productname1") %>'></asp:Label>
                                  </h4>
                             </center>
                                   <div class="form-horizontal style-form">
                                   <center>
                                  <div class="form-group" style="padding-bottom:0px;">
                                      <div class="col-sm-10" style="width: 100%;">
                                       
                                  <a class="example-image-link" href='<%#Eval("imagePath1") %>' data-lightbox="example-set">
                                      <asp:Image ID="Image1" style=" width:auto; height:120px;" runat="server" ImageUrl='<%#Eval("imagePath1") %>'></asp:Image>
                                      </a>
                                     <p></p>
                                          <p>
                                          ProductID: 
                                              <asp:Label ID="details" runat="server" Text='<%#Eval("productid1") %>'></asp:Label>
                                              </p>
                                               <p>
                                              Price: 
                                              <asp:Label ID="Label2" runat="server" Text='<%#Eval("productprice1") %>'></asp:Label>
                                              Rs
                                              </p>
                                               <p>
                                               Product Size:
                                               <asp:Label ID="Label4" runat="server" Text='<%#Eval("productsize1") %>'></asp:Label>
                                             
                                              </p>
                                             
                                              
               <p>
               Date:
                                              <asp:Label ID="Label6" runat="server" Text='<%#Eval("date1") %>'></asp:Label>
                                              </p>
                                      </div>
                                  </div>
                                  
                                    <asp:LinkButton ID="viewdetails" runat="server" CommandName="edit" CommandArgument='<%#Eval("productid1") %>' ForeColor="Red">Edit</asp:LinkButton>
                                    |
                                 <asp:LinkButton ID="lnkDelete" runat="server" CommandName="delete" OnClientClick='javascript:return confirm("Are you sure you want to delete?")' 
            CommandArgument='<%#Eval("productid1") %>' ForeColor="Red">Delete</asp:LinkButton>

           </center>
                              </div>
                          </div>
                          
                      </div>
                      <!-- /row -->
                      
                      <!-- /row -->
                  </div>
                  </ItemTemplate>
                  </asp:Repeater>
                      </asp:Panel>
                      <asp:Panel ID="productpanel" runat="server">

                      <div class="row"  style="margin-top:40px; margin-bottom:0px;">
                          <div class="form-panel">
                              <h4 class="mb">
                                  <i class="fa fa-edit"></i> View details <a style="color:Black;" data-toggle="modal" href="#myModal2"><img src="images/info.png"/ width="15" height="15"></a></h4>
                              <div class="form-horizontal style-form">
                              <div class="form-group" style="width:48%; float:left; margin:0%;">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;" >
                                          Product ID:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editproductidlbl" runat="server"></asp:Label>
                                      </div>
                                  </div>
                                  <div class="form-group" style="width:48%; float:left; margin:0%;">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                          Product Name:</label>
                                      <div class="col-sm-10">
                                          <asp:TextBox ID="editproductnametb" MaxLength="45" class="form-control" runat="server" onkeypress="javascript:return isNumber1(event)"></asp:TextBox>
                                      </div>
                                  </div>
                                  <div class="form-group" style="width:48%; float:left; margin:0%;">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                          Product Size:</label>
                                      <div class="col-sm-10">
                                          <asp:TextBox ID="editproductsizetb" MaxLength="15" class="form-control" runat="server" onkeypress="javascript:return isNumber1(event)"></asp:TextBox>
                                      </div>
                                  </div>
                                  <div class="form-group" style="width:48%; float:left; margin:0%;">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                          Product Price:</label>
                                      <div class="col-sm-10">
                                          <asp:TextBox ID="editproductpricetb" MaxLength="15" onkeypress="javascript:return isNumber(event)" class="form-control" runat="server"></asp:TextBox>
                                      </div>
                                  </div>
                                 
                                 
                                   <div class="form-group" style="width:48%; margin:0%; ">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                          Date:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editdatelbl"  runat="server"></asp:Label>
                                      </div>
                                  </div>
                                    <div class="form-group" style="width:60%; margin:0%;">
                                    <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                         Change Product Image</label>
                                <div class="col-sm-10">
                                  <asp:FileUpload ID="FileUpload2" runat="server" />
                                  </div>
                                
</div>
<div class="form-group" style="width:100%; margin:0%;">
<label class="control-label" style="padding:0%; color:Red;">
                                         * Only .png or .PNG files are allowed</label>
                                         <br />
 <label class="control-label" style="padding:0%; color:Red;">
                                         * Use image size of 100kb only for better perfomance</label>

</div>
                                 <div class="form-group" style="width:48%; margin:0%;">
                                   
                                  <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
        <a class="example-image-link" href='<%#Eval("productImage1") %>' data-lightbox="example-set">
                                      <img src="<%#Eval("productImage1") %>"  width="auto" height="200">
                                      </a>
                                       </ItemTemplate>
         </asp:Repeater> 

</div>
                                 <div class="form-group">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                      </label>
                                      <asp:Button ID="updateinfobtn" class="btn btn-default" runat="server" 
                                          Text="Update" onclick="updateinfobtn_Click"/>
                                             <asp:Button ID="cancelbtn" class="btn btn-default" runat="server" 
                                          Text="Cancel" onclick="cancelbtn_Click" />
                                  </div>   
                              </div>
                          </div>
                      </div>
                      
                     </asp:Panel>
                      <div aria-hidden="true" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" id="myModal2" class="modal fade">
		              <div class="modal-dialog">
		                  <div class="modal-content">
		                  
						<center>
						<div class="form-panel">
                        <h4 class="mb"><i class="fa fa-edit"></i> Edit existing product image and its details in app</h4>
                        
                        <div class="form-horizontal style-form">
                         <div class="form-group">
                            
                            <img src="images/product1.png" style="width:100%; height:auto;"/>

                          </div>
                         
                          
                          </div>
                        
                        </div>
					</center>
		                  </div>
		              </div>
		          </div>
                      <!-- /row -->
                  </div>
                  <!-- /col-lg-9 END SECTION MIDDLE -->
                  <!-- **********************************************************************************************************************************************************
      RIGHT SIDEBAR CONTENT
      *********************************************************************************************************************************************************** -->
                  <!-- /col-lg-3 -->
              </div><! --/row -->
          </section>
    </section>
     

    <script src="assets/js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script src="assets/js/lightbox.js" type="text/javascript"></script>

  
</asp:Content>

