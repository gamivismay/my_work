<%@ Page Title="" Language="C#" MasterPageFile="~/companyaccess/company-menu.master" AutoEventWireup="true" CodeFile="company-registered-users.aspx.cs" Inherits="company_registered_users" %>

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
                  <div class="col-lg-9 main-chart" style="width: 100%;">
                      
                      <!-- /row mt -->
                      
                       <div class="row mtbox"  style="margin-top:40px; margin-bottom:0px;">
                          
                              </div>
                              
                       
                      <!-- /row -->
                      
                       <asp:ScriptManager ID="ScriptManager1" runat="server">
                      </asp:ScriptManager>
                      <!-- /row -->
                    
                      <div class="row">
                       <div class="form-panel">
                        <div class="form-horizontal style-form">
                       						  <h4><i class="fa fa-angle-right"></i> All Users Details <a style="color:Black;" data-toggle="modal" href="#myModal1"><img src="images/info.png"/ width="15" height="15"></a></h4>
                       <asp:GridView ID="GridView2"  runat="server" AutoGenerateColumns="False"  
                      HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                HeaderStyle-VerticalAlign="Middle" 
                      RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle"
                                Width="100%" Height="100%" AllowPaging="True" 
                              OnPageIndexChanging="GridView2_PageIndexChanging" BackColor="#CCCCCC" 
                              BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" 
                              CellSpacing="3" ForeColor="Black" PageSize="100">
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
                          </asp:TemplateField>                                                                                                        <asp:BoundField DataField="customerid" HeaderText="Customer ID" /> 
                          <asp:BoundField DataField="username" HeaderText="Username" />
                          <asp:BoundField DataField="emailid" HeaderText="Email"></asp:BoundField>
                          <asp:BoundField DataField="phone" HeaderText="Phone" />
                          <asp:BoundField DataField="accountname" HeaderText="Account Name" />
                          <asp:BoundField DataField="devicetype" HeaderText="Device Type" />
                          <asp:BoundField DataField="date" HeaderText="Date" />
                          <asp:TemplateField HeaderText="Detail">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="viewdetails" runat="server" CommandArgument='<%# Bind("emailid") %>' oncommand="viewdetails_Command">view more</asp:LinkButton>
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
                      </div>
                      
                      <div aria-hidden="true" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" id="myModal1" class="modal fade">
		              <div class="modal-dialog">
		                  <div class="modal-content">
		                  
						<center>
						<div class="form-panel">
                        <h4 class="mb"><i class="fa fa-edit"></i>View all Users list and their details registered to your network in app</h4>
                       
                        
                        </div>
					</center>
		                  </div>
		              </div>
		          </div>
                      <asp:Panel ID="productpanel" runat="server">

                      <div class="row mtbox"  style="margin-top:0px; margin-bottom:0px;">
                          <div class="form-panel">
                              <h4 class="mb">
                                  <i class="fa fa-edit"></i> View users details</h4>
                              <div class="form-horizontal style-form">
                               <div class="form-group" style="width:48%; float:left; margin:0%;">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;" >
                                          CustomerID:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editcustomeridlbl" runat="server"></asp:Label>
                                      </div>
                                  </div>
                              <div class="form-group" style="width:48%; float:left; margin:0%;">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;" >
                                          Username:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editusernamelbl"  runat="server"></asp:Label>
                                      </div>
                                  </div>
                                  <div class="form-group" style="width:48%; float:left; margin:0%;">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                          Email ID:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editemailidlbl"  runat="server"></asp:Label>
                                      </div>
                                  </div>
                                  <div class="form-group" style="width:48%; float:left; margin:0%;">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                          Password:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editpasswordlbl"  runat="server"></asp:Label>
                                      </div>
                                  </div>
                                  <div class="form-group" style="width:48%; float:left; margin:0%;">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                          Phone:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editphonelbl"  runat="server"></asp:Label>
                                      </div>
                                  </div>
                                   <div class="form-group" style="width:48%; float:left; margin:0%;">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                          Birthdate:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editbirthdatelbl"  runat="server"></asp:Label>
                                      </div>
                                  </div>
                                  <div class="form-group" style="width:100%; float:left; margin:0%;">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                          Address:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editaddresslbl"  runat="server"></asp:Label>
                                      </div>
                                  </div>
                                   <div class="form-group" style="width:48%; float:left; margin:0%;">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                          City:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editcitylbl"  runat="server"></asp:Label>
                                      </div>
                                  </div>
                                   <div class="form-group" style="width:48%; float:left; margin:0%;">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                          State:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editstatelbl"  runat="server"></asp:Label>
                                      </div>
                                  </div>
                                  
                                  
                                  <div class="form-group" style="width:48%; float:left; margin:0%;">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                          Device Type:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editdevicetypelbl"  runat="server"></asp:Label>
                                      </div>
                                  </div>
                                 
                                  <div class="form-group" style="width:48%; float:left; margin:0%;">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                          Login Status:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editloginstatuslbl"  runat="server"></asp:Label>
                                      </div>
                                  </div>
                                  <div class="form-group" style="width:48%; float:left; margin:0%;">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                          User Status:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="edituserstatuslbl"  runat="server"></asp:Label>
                                      </div>
                                  </div>
                                   <div class="form-group" style="width:48%; margin:0%; ">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                          Date:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editdatelbl" runat="server"></asp:Label>
                                      </div>
                                  </div>
                                   
                                 
                                 
                              </div>
                          </div>
                      </div>
                      
                     </asp:Panel>
                     
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

