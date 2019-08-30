<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin-menu.master" AutoEventWireup="true" CodeFile="admin-registered-customers.aspx.cs" Inherits="admin_registered_customers" %>

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
                      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                      <ContentTemplate>
                      <div class="col-lg-12">
                      <div class="form-panel">
						  <h4><i class="fa fa-angle-right"></i> All Company Details</h4>
                        <section id="no-more-tables">
                                                   
                        <asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False"  
                      HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                HeaderStyle-VerticalAlign="Middle" 
                      RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle"
                                Width="100%" Height="100%" AllowPaging="True" 
                              OnPageIndexChanging="GridView1_PageIndexChanging" BackColor="#CCCCCC" 
                              BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" 
                              CellSpacing="3" ForeColor="Black" onrowdatabound="GridView1_RowDataBound" PageSize="50">
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
                          <asp:BoundField DataField="companyid" HeaderText="CompanyID" />
                          <asp:BoundField DataField="companyname" HeaderText="Company Name" />
                          <asp:BoundField DataField="email" HeaderText="EmailID"></asp:BoundField>
                          <asp:BoundField DataField="phone" HeaderText="Phone" />
                          <asp:BoundField DataField="password" HeaderText="Password" />
                          <asp:BoundField DataField="date" HeaderText="Date" />
                           
                          <asp:TemplateField HeaderText="Edit">
                             
                              <ItemTemplate>
                                  <asp:LinkButton ID="editlb" runat="server" 
                                      CommandArgument='<%# Bind("companyid") %>' oncommand="editlb_Command">Edit</asp:LinkButton>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Login">
                              <EditItemTemplate>
                                  <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                              </EditItemTemplate>
                              <ItemTemplate>
                                  <asp:LinkButton ID="loginlb" runat="server" 
                                      CommandArgument='<%# Bind("email") %>' oncommand="loginlb_Command" >login</asp:LinkButton>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Delete">
                              <EditItemTemplate>
                                  <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                              </EditItemTemplate>
                              <ItemTemplate>
                                  <asp:LinkButton ID="delete" runat="server" 
                                      CommandArgument='<%# Bind("companyid") %>' oncommand="delete_Command">Delete</asp:LinkButton>
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
					</ContentTemplate>
                      </asp:UpdatePanel>
				
					</div><!-- /row -->

                      <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                      <ContentTemplate>
                          <asp:Panel ID="Panel1" runat="server">
                          
                      <div class="row">
                     <div class="form-panel">
                        <h4 class="mb"><i class="fa fa-edit"></i> Edit company profile information</h4>
                        <div class="form-horizontal style-form">
                         <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Company ID:</label>
                              <div class="col-sm-10">

                                  <asp:Label ID="editcompanyidlbl"  runat="server" Text=""></asp:Label>
                              </div>
                          </div>
                          <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Sample Account ID:</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editsampleaccountidlbl" class="form-control" runat="server" Text="" MaxLength="45" onkeypress="javascript:return isNumber1(event)"></asp:TextBox>
                              </div>
                          </div>
                         <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Full Name:</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editfullnametb" MaxLength="45" class="form-control" runat="server"></asp:TextBox>
                              </div>
                          </div>
                          <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Company Name:</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editcompanynametb" MaxLength="45" class="form-control" runat="server"></asp:TextBox>
                              </div>
                          </div>
                          <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Address:</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editaddresstb" MaxLength="495" class="form-control" runat="server"></asp:TextBox>
                              </div>
                          </div>
                          <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Email(Username):</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editemailtb" MaxLength="45" class="form-control" runat="server" TextMode="Email"></asp:TextBox>
                              </div>
                          </div>
                           <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">password:</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editpasswordtb" MaxLength="45" class="form-control" runat="server"></asp:TextBox>
                              </div>
                          </div>
                          <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Phone:</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editphonetb" MaxLength="15" class="form-control" runat="server" TextMode="Phone"></asp:TextBox>
                              </div>
                          </div>
                          <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">City:</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editcitytb" MaxLength="45" class="form-control" runat="server"></asp:TextBox>
                              </div>
                          </div>
                           <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">State:</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editstatetb" MaxLength="45" class="form-control" runat="server"></asp:TextBox>
                              </div>
                          </div>
                           <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Country:</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editcountrytb" MaxLength="45" class="form-control" runat="server"></asp:TextBox>
                              </div>
                          </div>
                           <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">About info:</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editaboutinfotb" MaxLength="495" class="form-control" runat="server" ></asp:TextBox>
                              </div>
                          </div>
                          
                           <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Achievements/Awards:</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editachievementtb" MaxLength="495" class="form-control" runat="server" ></asp:TextBox>
                              </div>
                          </div>
                           <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">SMS Credits:</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editsmscreditslbl" MaxLength="15" class="form-control" runat="server" Text=""></asp:TextBox>
                              </div>
                          </div>
                           <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">SMS Apikey:</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editsmsapikeylbl" MaxLength="45" class="form-control" runat="server" Text=""></asp:TextBox>
                              </div>
                          </div>
                           <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">SMS Userid:</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editsmsuseridlbl" MaxLength="45" class="form-control" runat="server" Text=""></asp:TextBox>
                              </div>
                          </div>
                           <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">SMS senderid:</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editsmssenderidlbl" MaxLength="15" class="form-control"  runat="server" Text=""></asp:TextBox>
                              </div>
                          </div>
                          
                          <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Device type:</label>
                              <div class="col-sm-10">

                                  <asp:Label ID="editdevicetypelbl"  runat="server" Text=""></asp:Label>
                              </div>
                          </div>
                           <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Device Token:</label>
                              <div class="col-sm-10">

                                  <asp:Label ID="editdevicetokenlbl" runat="server" Text=""></asp:Label>
                              </div>
                          </div>
                          
                           <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">date:</label>
                              <div class="col-sm-10">

                                  <asp:Label ID="editdatelbl" runat="server" Text=""></asp:Label>
                              </div>
                          </div>
                         
                           <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label"></label>
                               <asp:Button ID="updateinfobtn" class="btn btn-default" runat="server" 
                                   Text="Update" onclick="updateinfobtn_Click" />
                          </div>
                          </div>
                        </div>
					</div><!-- /row -->	
					</asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                    <asp:PostBackTrigger ControlID="updateinfobtn" />
                    </Triggers>
                      </asp:UpdatePanel>
					
                  </div><!-- /col-lg-9 END SECTION MIDDLE -->
                  
                  
      <!-- **********************************************************************************************************************************************************
      RIGHT SIDEBAR CONTENT
      *********************************************************************************************************************************************************** -->                  
                  
                  <!-- /col-lg-3 -->
              </div><! --/row -->

          </section>
      </section>
</asp:Content>

