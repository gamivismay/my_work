<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin-menu.master" AutoEventWireup="true" CodeFile="admin-order-history.aspx.cs" Inherits="admin_order_history" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="Dashboard">
    <meta name="keyword" content="Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina">

    <title>Fotolivin</title>

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
<section id="main-content">
          <section class="wrapper">
          <div class="row">
          <div class="col-lg-9 main-chart" style="width:100%;">
          
          </div>
          </div>
              <div class="row">
                  <div class="col-lg-9 main-chart" style="width:100%;">
                 
                  <div class="row mt">
                      <asp:ScriptManager ID="ScriptManager1" runat="server">
                      </asp:ScriptManager>
                      
                      <div class="col-lg-12">
                      <div class="form-panel">
						  <h4><i class="fa fa-angle-right"></i> All Order Details</h4>
                        <section id="no-more-tables">
                                                   
                        <asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False"  
                      HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                HeaderStyle-VerticalAlign="Middle" 
                      RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle"
                                Width="100%" Height="100%" AllowPaging="True" 
                              OnPageIndexChanging="GridView1_PageIndexChanging" BackColor="#CCCCCC" 
                              BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" 
                              CellSpacing="3" ForeColor="Black" PageSize="50">
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
                          <asp:BoundField DataField="customerid" HeaderText="CustomerID" />
                          <asp:BoundField DataField="orderid" HeaderText="Order ID" />                                                                <asp:BoundField DataField="productname" HeaderText="Product Name" /> 
                          <asp:BoundField DataField="username" HeaderText="Username" />
                          <asp:BoundField DataField="emailid" HeaderText="EmailID"></asp:BoundField>
                          <asp:BoundField DataField="phone" HeaderText="Phone" />
                          <asp:BoundField DataField="orderstatus" HeaderText="Status" />
                          <asp:BoundField DataField="totalamount" HeaderText="Amount" />
                          <asp:BoundField DataField="date" HeaderText="Date" />
                          <asp:TemplateField HeaderText="Detail">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="viewdetails" runat="server" CommandArgument='<%# Bind("orderid") %>' oncommand="viewdetails_Command">view more</asp:LinkButton>
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
                
                
                  </section>
                          </div>
                        </div>
					
				
					</div><!-- /row -->
                    
                      <asp:Panel ID="Panel1" runat="server">
                      
					<div class="row">
                     <div class="form-panel">
                              <h4 class="mb">
                                  <i class="fa fa-edit"></i> View & Edit order details</h4>
                              <div class="form-horizontal style-form">
                              <div class="form-group">
                                      <label class="col-sm-2 col-sm-2 control-label">
                                          Company ID:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editcompanyidlbl" runat="server"></asp:Label>
                                      </div>
                                  </div>
                                  <div class="form-group">
                                      <label class="col-sm-2 col-sm-2 control-label">
                                          Customer ID:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editcustomeridlbl" runat="server"></asp:Label>
                                      </div>
                                  </div>
                                  <div class="form-group">
                                      <label class="col-sm-2 col-sm-2 control-label">
                                          Username:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editusernamelbl" runat="server"></asp:Label>
                                      </div>
                                  </div>
                                  <div class="form-group">
                                      <label class="col-sm-2 col-sm-2 control-label">
                                          Email ID:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editemailidlbl" runat="server"></asp:Label>
                                      </div>
                                  </div>
                                  <div class="form-group">
                                      <label class="col-sm-2 col-sm-2 control-label">
                                          Phone:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editphonelbl" runat="server"></asp:Label>
                                      </div>
                                  </div>
                                  <div class="form-group">
                                      <label class="col-sm-2 col-sm-2 control-label">
                                          Address:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editaddresslbl" runat="server"></asp:Label>
                                      </div>
                                  </div>
                                  <div class="form-group">
                                      <label class="col-sm-2 col-sm-2 control-label">
                                          Order ID:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editorderidlbl" runat="server"></asp:Label>
                                      </div>
                                  </div>
                                  <div class="form-group">
                                      <label class="col-sm-2 col-sm-2 control-label">
                                          Product ID:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editproductidlbl" runat="server"></asp:Label>
                                      </div>
                                  </div>
                                   <div class="form-group">
                                      <label class="col-sm-2 col-sm-2 control-label">
                                          Product Name:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editproductnamelbl" runat="server"></asp:Label>
                                      </div>
                                  </div>
                                   <div class="form-group">
                                      <label class="col-sm-2 col-sm-2 control-label">
                                          Product Size:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editproductsizelbl" runat="server"></asp:Label>
                                      </div>
                                  </div>
                                   <div class="form-group">
                                      <label class="col-sm-2 col-sm-2 control-label">
                                          Product Price:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editproductpricelbl" runat="server"></asp:Label>
                                      </div>
                                  </div>
                                   <div class="form-group">
                                      <label class="col-sm-2 col-sm-2 control-label">
                                          Image Price:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editimagepricelbl" runat="server"></asp:Label>
                                      </div>
                                  </div>
                                  
                                  <div class="form-group">
                                      <label class="col-sm-2 col-sm-2 control-label">
                                          Order Status:</label>
                                      <div class="col-sm-10">
                                          <asp:DropDownList ID="DropDownList1" class="form-control" runat="server">
                                              <asp:ListItem>pending</asp:ListItem>
                                              <asp:ListItem>confirmed</asp:ListItem>
                                              <asp:ListItem>delivered</asp:ListItem>
                                          </asp:DropDownList>
                                      </div>
                                  </div>
                                  <div class="form-group">
                                      <label class="col-sm-2 col-sm-2 control-label">
                                          Total Amount:</label>
                                      <div class="col-sm-10">
                                          <asp:label ID="edittotalamountlbl" runat="server"></asp:Label>
                                      </div>
                                  </div>
                                  <div class="form-group">
                                      <label class="col-sm-2 col-sm-2 control-label">
                                          Date:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editdatelbl" runat="server"></asp:Label>
                                      </div>
                                  </div>
                                 
                                  <div class="form-group">
                                      <label class="col-sm-2 col-sm-2 control-label">
                                      </label>
                                      <asp:Button ID="updateinfobtn" class="btn btn-default" runat="server" Text="Update"
                                          OnClick="updateinfobtn_Click" />
                                            <asp:Button ID="downloadimgbtn" class="btn btn-default" runat="server" 
                                          Text="Download Images" onclick="downloadimgbtn_Click" />
                                            <asp:Button ID="deletebtn" class="btn btn-default" runat="server" 
                                          Text="Delete" onclick="deletebtn_Click" />
                                  </div>
                                  
                              </div>
                          </div>
					</div><!-- /row -->	
				
                      <div class="row"">
                      
                      </div>
                     </asp:Panel>
                     
                  </div><!-- /col-lg-9 END SECTION MIDDLE -->
                  
                  
      <!-- **********************************************************************************************************************************************************
      RIGHT SIDEBAR CONTENT
      *********************************************************************************************************************************************************** -->                  
                  
                  <!-- /col-lg-3 -->
              </div><! --/row -->
          </section>
      </section>
</asp:Content>

