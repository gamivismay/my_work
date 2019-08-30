<%@ Page Title="" Language="C#" MasterPageFile="~/companyaccess/company-menu.master" AutoEventWireup="true" CodeFile="company-faqs.aspx.cs" Inherits="company_faqs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="Dashboard">
    <meta name="keyword" content="Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina">

    <title>Fotolivin</title>
    <link href="css/reset.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script src="js/modernizr.js" type="text/javascript"></script>
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
						
						<div class="form-panel">
                        <h4 class="mb"> Help </h4>
                        <div class="form-horizontal style-form">
                         <div class="form-group">
                              <div class="col-sm-10" style="width:100%;">
                        
                             <div class="cd-faq-items">
		<ul id="basics" class="cd-faq-group">

			<li>
				<a class="cd-faq-trigger" href="#0">How to edit and update company details ?</a>
				<div class="cd-faq-content">
                <p>Step 1 - Click View/Edit Company Profile</p>
                <p><img style="width:80%; height:auto;" src="images/faqs/cop1.jpg"/></p>
                <p>Step 2 - View details in next screen and change if needed than click on update button</p>
               <p> <img style="width:80%; height:auto;" src="images/faqs/cop4.jpg" /></p>
					
				</div> <!-- cd-faq-content -->
			</li>

			<li>
				<a class="cd-faq-trigger" href="#0">How to change company profile and cover image ?</a>
				<div class="cd-faq-content">
					 <p>Step 1 - Click View/Edit Company Profile</p>
                <p><img style="width:80%; height:auto;" src="images/faqs/cop1.jpg"/></p>
                <p>Step 2 - Click on upload new profile & cover image</p>
               <p> <img style="width:80%; height:auto;" src="images/faqs/cop2.jpg" /></p>
				 <p>Step 3 - Upload new cover and profile image to be changed and click refresh to see changes</p>
               <p> <img style="width:80%; height:auto;" src="images/faqs/cop3.jpg" /></p>	
				</div> <!-- cd-faq-content -->
			</li>

			<li>
				<a class="cd-faq-trigger" href="#0">How to add, edit company service portfolio and upload sample images to service ?</a>
				<div class="cd-faq-content">
				 <p>Step 1 - Click View/Edit Company Profile</p>
                <p><img style="width:80%; height:auto;" src="images/faqs/cop1.jpg"/></p>
               <p>Step 2 - Click Add/Edit Service portfolio</p>
               <p> <img style="width:80%; height:auto;" src="images/faqs/cop2a.jpg" /></p>
					
                <p>Step 3 - Add new srevice details and sample images to service. Click view more to see details of service and update it.</p>
               <p> <img style="width:80%; height:auto;" src="images/faqs/cop5.jpg" /></p>

				<p>Step 4 - Click view more to see details of service and update details and sample images.</p>
               <p> <img style="width:80%; height:auto;" src="images/faqs/cop6.jpg" /></p>
						
				</div> <!-- cd-faq-content -->
			</li>

			<li>
				<a class="cd-faq-trigger" href="#0">How to view if my customer account is created after data submission ?</a>
				<div class="cd-faq-content">
					 <p>Step 1 - Click registered customers to view list of your registered customers</p>
                <p><img style="width:80%; height:auto;" src="images/faqs/cp1.jpg"/></p>
                <p>Step 2 - View your registered customers or click view more to see more details and data.</p>
               <p> <img style="width:80%; height:auto;" src="images/faqs/cp2.jpg" /></p>
					
				</div> <!-- cd-faq-content -->
			</li>
            <li>
				<a class="cd-faq-trigger" href="#0">How to check details and view data of my customer ?</a>
				<div class="cd-faq-content">
			    <p>Step 1 - Click Registered customers</p>
                <p><img style="width:80%; height:auto;" src="images/faqs/cp1.jpg"/></p>
                <p>Step 2 - View list of registered customers. Click view more to view details of that customer</p>
                <p> <img style="width:80%; height:auto;" src="images/faqs/cp2.jpg" /></p>
				<p>Step 3 - View all details and statistics of particular customer with its profile and cover image. Click photos,  videos and albums to view respective data.</p>
                <p> <img style="width:80%; height:auto;" src="images/faqs/cp3.jpg" /></p>
			    <p></p>
                <p><img style="width:80%; height:auto;" src="images/faqs/cp4.jpg"/></p>
                <p>Step 4 - View photos galleries</p>
                <p> <img style="width:80%; height:auto;" src="images/faqs/cp5.jpg" /></p>
				<p>Step 5 - View photos of particular gallery</p>
                <p> <img style="width:80%; height:auto;" src="images/faqs/cp6.jpg" /></p>
				<p>Step 6 - View video galleries and its videos</p>
                <p><img style="width:80%; height:auto;" src="images/faqs/cp7.jpg"/></p>
                <p>Step 7 - View album galleries</p>
                <p> <img style="width:80%; height:auto;" src="images/faqs/cp8.jpg" /></p>
				<p>Step 8 - View photos of particular album</p>
                <p> <img style="width:80%; height:auto;" src="images/faqs/cp9.jpg" /></p>
					
				</div> <!-- cd-faq-content -->
			</li>
            <li>
				<a class="cd-faq-trigger" href="#0">How to Edit and upload explore photos ?</a>
				<div class="cd-faq-content">
					 <p>Step 1 - Click Explore blog</p>
                <p><img style="width:80%; height:auto;" src="images/faqs/ex1.jpg"/></p>
                <p>Step 2 - View statistics and upload new photo. Click edit or delete to view/edit details of explore photos and delete it.</p>
               <p> <img style="width:80%; height:auto;" src="images/faqs/ex2.jpg" /></p>
				<p>Step 3 - Click update to update details of photo from explore blog</p>
               <p> <img style="width:80%; height:auto;" src="images/faqs/ex3.jpg" /></p>
						
				</div> <!-- cd-faq-content -->
			</li>
            <li>
				<a class="cd-faq-trigger" href="#0">How to edit and upload products ?</a>
				<div class="cd-faq-content">
					 <p>Step 1 - Click Explore blog</p>
                <p><img style="width:80%; height:auto;" src="images/faqs/pro1.jpg"/></p>
                <p>Step 2 - View statistics and upload new photo. Click edit or delete to view/edit details of products</p>
               <p> <img style="width:80%; height:auto;" src="images/faqs/pro2.jpg" /></p>
				<p>Step 3 - Click update to update details of product</p>
               <p> <img style="width:80%; height:auto;" src="images/faqs/pro3.jpg" /></p>
					
				</div> <!-- cd-faq-content -->
			</li>
            <li>
				<a class="cd-faq-trigger" href="#0">How to see total users connected to my network ?</a>
				<div class="cd-faq-content">
					 <p>Step 1 - Click registered users</p>
                <p><img style="width:80%; height:auto;" src="images/faqs/users1.jpg"/></p>
                <p>Step 2 - Click view more to check more detail or user</p>
               <p> <img style="width:80%; height:auto;" src="images/faqs/users2.jpg" /></p>
				
				</div> <!-- cd-faq-content -->
			</li>
            <li>
				<a class="cd-faq-trigger" href="#0">How to post an ad to my user network ?</a>
				<div class="cd-faq-content">
					 <p>Step 1 - Click offers</p>
                <p><img style="width:80%; height:auto;" src="images/faqs/ad1.jpg"/></p>
                <p>Step 2 - Here, You can post your ad with ad image and ad details and also you delete older ads</p>
               <p> <img style="width:80%; height:auto;" src="images/faqs/ad2.jpg" /></p>
					
				</div> <!-- cd-faq-content -->
			</li>
            <li>
				<a class="cd-faq-trigger" href="#0">How to check all orders with details and download image for pending order ?</a>
				<div class="cd-faq-content">
					 <p>Step 1 - Click order history</p>
                <p><img style="width:80%; height:auto;" src="images/faqs/order1.jpg"/></p>
                <p>Step 2 - Here you can see list of all order placed by your all users connected in your network</p>
               <p> <img style="width:80%; height:auto;" src="images/faqs/order2.jpg" /></p>
				<p>Step 3 - Click update to change order status and download button to download ordered image</p>
               <p> <img style="width:80%; height:auto;" src="images/faqs/order3.jpg" /></p>
					
				</div> <!-- cd-faq-content -->
			</li>
		</ul> <!-- cd-faq-group -->

		
	</div>
                              </div>
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

    
      <!--main content end-->
    <script src="js/jquery-2.1.1.js" type="text/javascript"></script>
    <script src="js/jquery.mobile.custom.min.js" type="text/javascript"></script>
    <script src="js/main.js" type="text/javascript"></script>

</asp:Content>

