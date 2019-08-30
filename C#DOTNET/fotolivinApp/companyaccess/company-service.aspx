<%@ Page Title="" Language="C#" MasterPageFile="~/companyaccess/company-menu.master" AutoEventWireup="true" CodeFile="company-service.aspx.cs" Inherits="company_service" %>

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
            <!-- Chang URLs to wherever Video.js files will be hosted -->
    <link href="assets/css/video-js.css" rel="stylesheet" type="text/css" />
  <!-- video.js must be in the <head> for older IEs to work. -->
  
    <script src="assets/js/video.js" type="text/javascript"></script>
  <!-- Unless using the CDN hosted version, update the URL to the Flash SWF -->
  <script>
      videojs.options.flash.swf = "video-js.swf";
  </script>
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
                  <div class="col-lg-9 main-chart" style="width:100%;">
                  	<!-- /row mt -->	
                  
                      
                   
					<div class="row mtbox" style="margin-top:40px; margin-bottom:0px;">
						
						<div class="form-panel">
                        <h4 class="mb"><i class="fa fa-edit"></i> Add new service..!! <a style="color:Black;" data-toggle="modal" href="#myModal1"><img src="images/info.png"/ width="15" height="15"></a></h4>
                        <div class="form-horizontal style-form">
                        <div class="form-group">
                                      <label class="col-sm-2 col-sm-2 control-label">
                                          Choose category/event name : </label>
                                      <div class="col-sm-10">
                                          <asp:DropDownList ID="eventnamelist" class="form-control"  runat="server">
                                           <asp:ListItem>Other</asp:ListItem>
                                          <asp:ListItem>Kids Portfolio</asp:ListItem>
                            <asp:ListItem>Portrait Photography</asp:ListItem>
                             <asp:ListItem>Pre Wedding Shoots</asp:ListItem>
                            <asp:ListItem>Cinema Shoot</asp:ListItem>
                            <asp:ListItem>Traditional Photography</asp:ListItem>
                            <asp:ListItem>Wedding Candid</asp:ListItem>
                            <asp:ListItem>Event Photography</asp:ListItem>
                            <asp:ListItem>Commercial Photography</asp:ListItem>
                            <asp:ListItem>Product Photography</asp:ListItem>
                                          </asp:DropDownList>
                                        
                                      </div>
                                     
                                  </div>
                          <div class="form-group" style="width:48%; float:left; margin:0%;">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                         Starting Cost:</label>
                                      <div class="col-sm-10">
                                           <asp:TextBox ID="startingcost" MaxLength="15" onkeypress="javascript:return isNumber(event)" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                  </div>
                         <div class="form-group" style="width:48%; float:left; margin:0%;">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                          Payment Terms:</label>
                                      <div class="col-sm-10">
                                          <asp:DropDownList ID="Paymentterms" class="form-control"  runat="server">
                                          <asp:ListItem>No Advance</asp:ListItem>
                                          <asp:ListItem>25% Advance</asp:ListItem>
                            <asp:ListItem>50% Advance</asp:ListItem>
                            <asp:ListItem>75% Advance</asp:ListItem>
                            <asp:ListItem>100% Advance</asp:ListItem>
                            <asp:ListItem>Not fixed</asp:ListItem>
                            <asp:ListItem>Depends on work</asp:ListItem>
                                          </asp:DropDownList>
                                      </div>
                                  </div>

                                  <div class="form-group" style="width:48%;float:left; margin:0%;">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                          Travel cost:</label>
                                      <div class="col-sm-10">
                                         <asp:DropDownList ID="travelcost" class="form-control"  runat="server">
                                          <asp:ListItem>Outstation travel & stay charges borne by client</asp:ListItem>
                                         <asp:ListItem>Outstation travel & stay charges borne by company</asp:ListItem>
                                          <asp:ListItem>Depends on work and place</asp:ListItem>
                                            <asp:ListItem>Not Required</asp:ListItem>
                            
                            <asp:ListItem>Not Fixed</asp:ListItem>
                            

                                          </asp:DropDownList>
                                      </div>
                                  </div>
                                  <div class="form-group" style="width:48%; margin:0%;">
                                    <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                         Upload Sample Images</label>
                                <div class="col-sm-10">
                                  <asp:FileUpload ID="FileUpload1" AllowMultiple="true" runat="server" />
                                  </div>

</div>
<div class="form-group" style="width:100%; margin:0%;">
 <label class="control-label" style="padding:0%; color:Red;">
                                         * Use image size of 100kb only for better perfomance</label>

</div>
                                   <div class="form-group">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                      </label>
                                      <asp:Button ID="addbtn" class="btn btn-default" runat="server" 
                                           Text="Add Service" onclick="addbtn_Click" />
                                          
                                  </div>
                       
                          </div>
                        </div>
					
					</div><!-- /row -->

					 <div class="row"">
                       <div class="form-panel">
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
                                                                                                                                                 
                                                                                                                                                     
                          <asp:BoundField DataField="servicename" HeaderText="Service Name" />
                          <asp:BoundField DataField="startingcost" HeaderText="Starting Cost"></asp:BoundField>
                          <asp:BoundField DataField="paymentterms" HeaderText="Payment Terms" />
                          <asp:BoundField DataField="travelcost" HeaderText="Travel Cost" />
                          <asp:TemplateField HeaderText="Detail">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="viewdetails" runat="server" CommandArgument='<%# Bind("servicename") %>' oncommand="viewdetails_Command">view more</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="delete" runat="server" CommandArgument='<%# Bind("servicename") %>' oncommand="delete_Command">Delete</asp:LinkButton>
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
                      

                      <asp:Panel ID="productpanel" runat="server">

                      <div class="row mtbox"  style="margin-top:0px; margin-bottom:0px;">
                          <div class="form-panel">
                              <h4 class="mb">
                                  <i class="fa fa-edit"></i> View & Edit photo details <a style="color:Black;" data-toggle="modal" href="#myModal2"><img src="images/info.png"/ width="15" height="15"></a></h4>
                              <div class="form-horizontal style-form">
                              <div class="form-group" style="width:48%; float:left; margin:0%;">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;" >
                                          Event:</label>
                                      <div class="col-sm-10">
                                       <asp:Label ID="editservicename" class="form-control" runat="server"></asp:Label>
                                 
                                      </div>
                                  </div>
                                    <div class="form-group" style="width:48%; float:left; margin:0%;">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                         Starting Cost:</label>
                                      <div class="col-sm-10">
                                         <asp:TextBox ID="editstartingcost" MaxLength="15" onkeypress="javascript:return isNumber(event)" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                  </div>
                         <div class="form-group" style="width:48%; float:left; margin:0%;">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                          Payment Terms:</label>
                                      <div class="col-sm-10">
                                          <asp:DropDownList ID="editpaymentterms" class="form-control"  runat="server">
                                          <asp:ListItem>No Advance</asp:ListItem>
                                          <asp:ListItem>25% Advance</asp:ListItem>
                            <asp:ListItem>50% Advance</asp:ListItem>
                            <asp:ListItem>75% Advance</asp:ListItem>
                            <asp:ListItem>100% Advance</asp:ListItem>
                            <asp:ListItem>Not fixed</asp:ListItem>
                            <asp:ListItem>Depends on work</asp:ListItem>
                                          </asp:DropDownList>
                                      </div>
                                  </div>

                                  <div class="form-group" style="width:48%;float:left; margin:0%;">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                          Travel cost:</label>
                                      <div class="col-sm-10">
                                           <asp:DropDownList ID="edittravelcost" class="form-control"  runat="server">
                                          <asp:ListItem>Outstation travel & stay charges borne by client</asp:ListItem>
                                          <asp:ListItem>Outstation travel & stay charges borne by company</asp:ListItem>
                                          <asp:ListItem>Depends on work and place</asp:ListItem>
                                            <asp:ListItem>Not Required</asp:ListItem>
                            <asp:ListItem>Not Fixed</asp:ListItem>
                            


                                          </asp:DropDownList>
                                      </div>
                                  </div>
                                  
                                
                                    <div class="form-group" style="width:100%;float:left; margin:0%;">
                                    <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                         Upload Image</label>
                                <div class="col-sm-10" style="width:50%;">
                                  <asp:FileUpload ID="FileUpload2" AllowMultiple="true" runat="server" />
                                  </div>

</div>
<div class="form-group" style="width:100%;float:left;  margin:0%;">
 <label class="control-label" style="padding:0%; color:Red;">
                                         * Use image size of 100kb only for better perfomance</label>

</div>
 <div class="form-group"  style="width:100%;float:left; margin:0%;">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                      </label>
                                      <asp:Button ID="updateinfobtn" class="btn btn-default" runat="server" 
                                          Text="Update Service" onclick="updateinfobtn_Click"/>
                                            <asp:Button ID="deletebtn" class="btn btn-default" runat="server" 
                                          Text="Delete Images" onclick="deletebtn_Click"/>
                                          
                                           
                                  </div>
                                 <div class="form-group" style="width:100%;  margin:0%;">
                                   
                                 <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
           <div style=" height:215px; float:left; margin:10px; padding:5px; background:#f2f2f2;">
        <a class="example-image-link" href='<%#Eval("exploreImage1") %>' data-lightbox="example-set">
                                      <img src="<%#Eval("exploreImage1") %>"  width="auto" height="200">
                                      </a>
                                      </div>
                                       </ItemTemplate>
         </asp:Repeater> 

</div>

                                  
                              </div>
                          </div>
                      </div>
                      
                     </asp:Panel>
                      <div aria-hidden="true" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" id="myModal1" class="modal fade">
		              <div class="modal-dialog">
		                  <div class="modal-content">
		                  
						<center>
						<div class="form-panel">
                        <h4 class="mb"><i class="fa fa-edit"></i> Add new service details and sample images in app</h4>
                        
                        <div class="form-horizontal style-form">
                         <div class="form-group">
                            
                            <img src="images/service1.png" style="width:100%; height:auto;"/>

                          </div>
                         
                          
                          </div>
                        
                        </div>
					</center>
		                  </div>
		              </div>
		          </div>
                  <div aria-hidden="true" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" id="myModal2" class="modal fade">
		              <div class="modal-dialog">
		                  <div class="modal-content">
		                  
						<center>
						<div class="form-panel">
                        <h4 class="mb"><i class="fa fa-edit"></i> Edit existing service details and sample images in app</h4>
                        
                        <div class="form-horizontal style-form">
                         <div class="form-group">
                            
                            <img src="images/service1.png" style="width:100%; height:auto;"/>

                          </div>
                         
                          
                          </div>
                        
                        </div>
					</center>
		                  </div>
		              </div>
		          </div>
                      <!-- /row -->
					<div class="row mt">
                     
					</div><!-- /row -->	
					
                  </div><!-- /col-lg-9 END SECTION MIDDLE -->
                  
                  
      <!-- **********************************************************************************************************************************************************
      RIGHT SIDEBAR CONTENT
      *********************************************************************************************************************************************************** -->                  
                  
                  <!-- /col-lg-3 -->
              </div><! --/row -->
          </section>
      </section>
    <asp:HiddenField ID="explorespacehf" runat="server" />
            <script src="assets/js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script src="assets/js/lightbox.js" type="text/javascript"></script>
        

</asp:Content>

