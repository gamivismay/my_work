<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin-menu.master" AutoEventWireup="true" CodeFile="admin-dashboard.aspx.cs" Inherits="admin_dashboard" %>

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
 <!--main content start-->
      <section id="main-content">
          <section class="wrapper">

              <div class="row">
                  <div class="col-lg-9 main-chart" style="width:100%;">
                  
                  	<div class="row mtbox" style="margin-top:40px;">
                    		<h3 style="text-decoration:underline; text-align:center; color:#fff;">Admin Information..!!</h3>
                  
                  		
                  		<div class="col-md-2 col-sm-2 col-md-offset-1 box0">
                  			<div class="box1">
					  			<span><i class="fa fa-eye"></i></span>
					  			<h3>
                                      <asp:Label ID="displayviews1" Font-Size="Large" runat="server" Text=""></asp:Label></h3>
                  			</div>
					  			<p>Total 
                                      <asp:Label ID="displayviews2" runat="server" Text=""></asp:Label> views.</p>
                  		</div>
                  		
                  		<div class="col-md-2 col-sm-2 box0">
                  			<div class="box1">
					  			<span><i class="fa fa-thumbs-up"></i></span>
					  			<h3>
                                      <asp:Label ID="displaylikes1" Font-Size="Large" runat="server" Text=""></asp:Label></h3>
                  			</div>
					  			<p>Total 
                                      <asp:Label ID="displaylikes2" runat="server" Text=""></asp:Label> likes.</p>
                  		</div>
                  		<div class="col-md-2 col-sm-2 box0">
                  			<div class="box1">
					  			<span><i class="fa fa-cloud"></i></span>
					  			<h3>
                                      <asp:Label ID="displayspace1" Font-Size="Large" runat="server" Text=""></asp:Label></h3>
                  			</div>
					  			<p> Total 
                                      <asp:Label ID="displayspace2" runat="server" Text=""></asp:Label> space is used.</p>
                  		</div>
                  	
                  	</div><!-- /row mt -->	
                  
                      
                      <div class="row mt">
                         	<! -- PROFILE 02 PANEL -->
						<!--/ col-md-4 --><!-- /col-md-4 -->
                      	
						<div class="col-md-4 mb">
							<!-- WHITE PANEL - TOP USER -->
							<div class="white-panel pn" style="height:auto;">
								<div class="white-header">

									<h5 style="color:rgb(0,147,221);">Total Users </h5>
								</div>
								
								<p style="color:rgb(0,147,221);"><b>
                                   <asp:Label ID="userslbl" runat="server" Text="Label"></asp:Label> </b></p>
								
							</div>
						</div><!-- /col-md-4 -->
                      	<div class="col-md-4 mb">
							<!-- WHITE PANEL - TOP USER -->
							<div class="white-panel pn" style="height:auto;">
								<div class="white-header">

									<h5 style="color:rgb(0,147,221);">Total Company </h5>
								</div>
								
								<p style="color:rgb(0,147,221);"><b>
                                   <asp:Label ID="companylbl" runat="server" Text="Label"></asp:Label> </b></p>
								
							</div>
						</div>
                        <div class="col-md-4 mb">
							<!-- WHITE PANEL - TOP USER -->
							<div class="white-panel pn" style="height:auto;">
								<div class="white-header">

									<h5 style="color:rgb(0,147,221);">Total Customers </h5>
								</div>
								
								<p style="color:rgb(0,147,221);"><b>
                                   <asp:Label ID="customerlbl" runat="server" Text="Label"></asp:Label> </b></p>
								
							</div>
						</div>

                    </div><!-- /row -->
               
                    				
					<div class="row">
						
						
						<div class="form-panel">
                        <h4 class="mb"><i class="fa fa-edit"></i> Edit admin profile information</h4>
                        <div class="form-horizontal style-form">
                         
                          <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Full Name :</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editcompanynametb" MaxLength="45" class="form-control" runat="server"></asp:TextBox>
                              </div>
                          </div>
                         
                          <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Email(Username) :</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editemailtb" MaxLength="45" class="form-control" runat="server" TextMode="Email"></asp:TextBox>
                              </div>
                          </div>
                           <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Password :</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editpasswordtb" MaxLength="45" class="form-control" runat="server"></asp:TextBox>
                              </div>
                          </div>
                           <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Phone :</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editphonetb" MaxLength="15" class="form-control" runat="server" TextMode="Phone"></asp:TextBox>
                              </div>
                          </div>
                           <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Sms Apikey :</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="smsapikeytb" MaxLength="45" class="form-control" runat="server"></asp:TextBox>
                              </div>
                          </div>
                            <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Sms userid :</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="smsuseridtb" MaxLength="45" class="form-control" runat="server"></asp:TextBox>
                              </div>
                          </div>
                            <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Sms senderid :</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="smssenderidtb" MaxLength="15" class="form-control" runat="server"></asp:TextBox>
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
      <asp:HiddenField ID="albumsviewhf" runat="server" />
        <asp:HiddenField ID="exploreviewhf" runat="server" />
            <asp:HiddenField ID="photoviewhf" runat="server" />
                <asp:HiddenField ID="videoviewhf" runat="server" />
                
                <asp:HiddenField ID="albumslikehf" runat="server" />
        <asp:HiddenField ID="explorelikehf" runat="server" />
            <asp:HiddenField ID="photolikehf" runat="server" />
                <asp:HiddenField ID="videolikehf" runat="server" />

                <asp:HiddenField ID="albumsspacehf" runat="server" />
        <asp:HiddenField ID="explorespacehf" runat="server" />
            <asp:HiddenField ID="photospacehf" runat="server" />
                <asp:HiddenField ID="videospacehf" runat="server" />
</asp:Content>

