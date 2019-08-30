<%@ Page Title="" Language="C#" MasterPageFile="~/menu.master" AutoEventWireup="true" CodeFile="dashboard.aspx.cs" Inherits="dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="Dashboard">
    <meta name="keyword" content="Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina">

    <title>Fotolivin</title>
    
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
                  <div class="col-lg-9 main-chart" style="width:100%;">
                  
                  	<div class="row mtbox" style="margin-top:40px;">
                    		<h3 style="text-decoration:underline; text-align:center; color:#fff;">Company Information..!!</h3>
                  
                  		<div class="col-md-2 col-sm-2 col-md-offset-1 box0">
                  			<div class="box1">
					  			<span><i class="fa fa-download"></i></span>
					  			<h3>
                                      <asp:Label ID="displayfollowers1" Font-Size="Large" runat="server" Text=""></asp:Label></h3>
                  			</div>
					  			<p>You have total 
                                      <asp:Label ID="displayfollowers2" runat="server" Text=""></asp:Label> users...!!</p>
                  		</div>
                        <div class="col-md-2 col-sm-2 box0">
                  			<div class="box1">
					  			<span><i class="fa fa-users"></i></span>
					  			<h3>
                                      <asp:Label ID="displaycustomers1" Font-Size="Large" runat="server" Text=""></asp:Label></h3>
                  			</div>
					  			<p>You have total 
                                      <asp:Label ID="displaycustomers2" runat="server" Text=""></asp:Label> customers</p>
                  		</div>
                  		<div class="col-md-2 col-sm-2 box0">
                  			<div class="box1">
					  			<span><i class="fa fa-eye"></i></span>
					  			<h3>
                                      <asp:Label ID="displayviews1" Font-Size="Large" runat="server" Text=""></asp:Label></h3>
                  			</div>
					  			<p>You have 
                                      <asp:Label ID="displayviews2" runat="server" Text=""></asp:Label> viewers following your profile.</p>
                  		</div>
                  		
                  		<div class="col-md-2 col-sm-2 box0">
                  			<div class="box1">
					  			<span><i class="fa fa-thumbs-up"></i></span>
					  			<h3>
                                      <asp:Label ID="displaylikes1" Font-Size="Large" runat="server" Text=""></asp:Label></h3>
                  			</div>
					  			<p>You have total 
                                      <asp:Label ID="displaylikes2" runat="server" Text=""></asp:Label> likes in your profile.</p>
                  		</div>
                  		<div class="col-md-2 col-sm-2 box0">
                  			<div class="box1">
					  			<span><i class="fa fa-cloud"></i></span>
					  			<h3>
                                      <asp:Label ID="displayspace1" Font-Size="Large" runat="server" Text=""></asp:Label></h3>
                  			</div>
					  			<p>You have used total 
                                      <asp:Label ID="displayspace2" runat="server" Text=""></asp:Label></p>
                  		</div>
                  	
                  	</div><!-- /row mt -->	
                  
                      
                      <div class="row mt">
                      <div class="col-lg-4 col-md-4 col-sm-4 mb">
             			    <div class="white-panel pn">
                                  <div class="white-header">
                                      <h5 style="color: rgb(0,147,221);">
                                          <asp:Label ID="displaycompanynamelbl" runat="server" Text=""></asp:Label> </h5>
                                  </div>
                                   <h5 style="color: rgb(0,147,221);">Company's Profile & Cover Image <a style="color:Black;" data-toggle="modal" href="#myModal1"><img src="images/info.png"/ width="15" height="15"></a></h5>
                            
                                       <asp:Repeater ID="Repeater2" runat="server">
        <ItemTemplate>
        <a class="example-image-link" href='<%#Eval("companyProfImgPath1") %>' data-lightbox="example-set">
                                      <img src="<%#Eval("companyProfImgPath1") %>" class="img-circle" width="100" height="100">
                                      </a>
                                       </ItemTemplate>
         </asp:Repeater> 
         <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
        <a class="example-image-link" href='<%#Eval("companyCoverImgPath1") %>' data-lightbox="example-set">
                                       <img src="<%#Eval("companyCoverImgPath1") %>" class="img-circle"  width="100" height="100">
                                       </a>
                                       </ItemTemplate>
         </asp:Repeater> 
                                      
                                       <p style="color: rgb(0,147,221);">
                                      <b>Company ID: 
                                          <asp:Label ID="displaycompanyidlbl" runat="server" Text=""></asp:Label></b></p>
                             
                                 <div class="pr2-social centered">
									<h4>
                                     <a style="color:Black;" href="company-profile"> View/Edit Company Profile</a>
                                     
		                           </h4>
								</div>
                              </div>
							
						</div>
                        <!-- Modal -->
		          <div aria-hidden="true" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" id="myModal1" class="modal fade">
		              <div class="modal-dialog">
		                  <div class="modal-content">
		                  
						<center>
						<div class="form-panel">
                        <h4 class="mb"><i class="fa fa-edit"></i> Company profile & cover sample image in app</h4>
                        
                        <div class="form-horizontal style-form">
                         <div class="form-group">
                            
                            <img src="images/companyprofile1.png" style="width:100%; height:auto;"/>

                          </div>
                         
                          
                          </div>
                        
                        </div>
					</center>
		                  </div>
		              </div>
		          </div>
		          <!-- modal -->
                      <!-- SERVER STATUS PANELS -->
                      	<div class="col-md-4 mb">
                      		<div class="darkblue-panel pn">
                      			<div class="darkblue-header">
						  			<h5>SMS STATISTICS</h5>
                      			</div>
								<i class="fa fa-envelope-square" style="font-size:120px;"></i>
								<h5>
                                Credit: 
                                    <asp:Label ID="totalsmslbl" runat="server" Text=""></asp:Label></h5>
								<footer>
									<div class="pull-left">
										<h5>Sent: 
                                            <asp:Label ID="sentsmslbl" runat="server" Text=""></asp:Label> </h5>
									</div>
									<div class="pull-right">
										<h5>
                                       
                                            <asp:Label ID="remainingsmslbl" runat="server" Text=""></asp:Label></h5>
									</div>
								</footer>
                      		</div><! -- /darkblue panel -->
						</div><!-- /col-md-4-->
                      	

                      	<! -- PROFILE 02 PANEL -->
						<!--/ col-md-4 --><!-- /col-md-4 -->
                          <asp:Panel ID="profilepnl" runat="server">
                          
						<div class="col-md-4 mb">
							<!-- WHITE PANEL - TOP USER -->
							<div class="white-panel pn">
								<div class="white-header">
                                    <asp:HiddenField ID="topcustomergalleryidhf" runat="server" />
									<h5 style="color:rgb(0,147,221);">Users Statistics</h5>
								</div>
								<p>
                      
								<i class="fa fa-users" style="font-size:120px;"></i>
                       
                                </p>
								<p style="color:rgb(0,147,221);"><b>
                                Total Users : 
                                   <asp:Label ID="userslbl" runat="server" Text=""></asp:Label> </b></p>
								<div class="row">

                                          <div class="pr2-social centered">
									<h4>
                                     <a style="color:Black;" href="registered-users">View all users >>></a>
		                           </h4>
								</div>

								</div>
							</div>
						</div><!-- /col-md-4 -->
                      	</asp:Panel>



                    </div><!-- /row -->
                     <!-- Modal -->
		          

		          <!-- modal -->
                    
                    				
					<div class="row">
						
						
						
					
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

                    <script src="assets/js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script src="assets/js/lightbox.js" type="text/javascript"></script>
      
      <!--main content end-->
 
</asp:Content>


