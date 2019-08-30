<%@ Page Title="" Language="C#" MasterPageFile="~/companyaccess/company-menu.master" AutoEventWireup="true"
    CodeFile="company-customer-profile.aspx.cs" Inherits="company_customer_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="Server">
    <!--main content start-->
    <section id="main-content">
        <section class="wrapper">

              <div class="row">
                  <div class="col-lg-9 main-chart" style="width: 100%;">
                      <div class="row mtbox" style="margin-top:40px;">
                      		<h3 style="text-decoration:underline; text-align:center; color:#fff;">Customer Information..!!</h3>
                  
                          <div class="col-md-2 col-sm-2 col-md-offset-1 box0">
                              <div class="box1">
                                  <span><i class="fa fa-users"></i></span>
                                  <h3>
                                      <asp:Label ID="displaycustomeruserlbl1" runat="server" Font-Size="Large" Text=""></asp:Label> </h3>
                              </div>
                              <p>
                                  This customer have total 
                                  <asp:Label ID="displaycustomeruserlbl2" runat="server" Text=""></asp:Label> users</p>
                          </div>
                          <div class="col-md-2 col-sm-2 box0">
                              <div class="box1">
                                  <span><i class="fa fa-eye"></i></span>
                                  <h3>
                                      <asp:Label ID="displaycustomerviewlbl1" runat="server" Font-Size="Large" Text=""></asp:Label> </h3>
                              </div>
                              <p>
                                  Total 
                                  <asp:Label ID="displaycustomerviewlbl2" runat="server" Text=""></asp:Label> views in this profile.</p>
                          </div>
                          <div class="col-md-2 col-sm-2 box0">
                              <div class="box1">
                                  <span><i class="fa fa-thumbs-up"></i></span>
                                  <h3>
                                      <asp:Label ID="displaycustomerlikelbl1" runat="server" Font-Size="Large" Text=""></asp:Label></h3>
                              </div>
                              <p>
                                  Total 
                                  <asp:Label ID="displaycustomerlikelbl2" runat="server" Text=""></asp:Label> likes to this profile</p>
                          </div>
                          <div class="col-md-2 col-sm-2 box0">
                              <div class="box1">
                                  <span><i class="fa fa-cloud"></i></span>
                                  <h3>
                                      <asp:Label ID="displaycustomerspacelbl1" runat="server" Font-Size="Large" Text=""></asp:Label> </h3>
                              </div>
                              <p>
                                  This customer has used 
                                  <asp:Label ID="displaycustomerspacelbl2" runat="server" Text=""></asp:Label> of total storage</p>
                          </div>
                      </div>
                      <!-- /row mt -->
                      <div class="row">
                          <!-- SERVER STATUS PANELS -->
                          <div class="col-md-4 mb">
                              <!-- WHITE PANEL - TOP USER -->
                              <div class="white-panel pn">
                                  <div class="white-header">
                                      <h5 style="color: rgb(0,147,221);">
                                          <asp:Label ID="displaycustomernamelbl" runat="server" Text=""></asp:Label> <a style="color:Black;" data-toggle="modal" href="#myModal1"><img src="images/info.png"/ width="15" height="15"></a></h5>
                                  </div>
                                   <h5 style="color: rgb(0,147,221);">Customer's Profile & Cover Image</h5>
                            
                                       <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
        <a class="example-image-link" href='<%#Eval("customerProfImgPath1") %>' data-lightbox="example-set">
                                      <img src="<%#Eval("customerProfImgPath1") %>" class="img-circle" width="80" height="80">
                                      </a>
                                       </ItemTemplate>
         </asp:Repeater> 
         <asp:Repeater ID="Repeater2" runat="server">
        <ItemTemplate>
        <a class="example-image-link" href='<%#Eval("customerCoverImgPath1") %>' data-lightbox="example-set">
                                       <img src="<%#Eval("customerCoverImgPath1") %>" class="img-circle"  width="80" height="80">
                                       </a>
                                       </ItemTemplate>
         </asp:Repeater> 
                                      
                                  <p style="color: rgb(0,147,221);">
                                      <b>Customer ID: 
                                          <asp:Label ID="displaycustomeridlbl" runat="server" Text=""></asp:Label></b></p>
                                  <div class="row">
                                      <div class="col-md-6">
                                          <p style="color: #444c57;" class="small mt">
                                              MEMBER SINCE</p>
                                          <p style="color: #444c57;">
                                              <asp:Label ID="displaycustomerdatelbl" runat="server" Text=""></asp:Label> </p>
                                      </div>
                                      <div class="col-md-6">
                                          <p class="small mt" style="color: #444c57;">
                                              TOTAL USERS</p>
                                          <p style="color: #444c57;">
                                              <asp:Label ID="displaycustomeruserlbl" runat="server" Text=""></asp:Label> </p> 
                                      </div>
                                  </div>
                              </div>
                          </div>
                          <!-- /col-md-4 -->
                          <!-- /col-md-4-->
                           <div class="col-md-4 mb">
                              <!-- WHITE PANEL - TOP USER -->
                              <div class="white-panel pn">
                                  <div class="white-header">
                                      <h5 style="color: rgb(0,147,221);">
                                          Send sms to customer <a style="color:Black;" data-toggle="modal" href="#myModal2"><img src="images/info.png"/ width="15" height="15"></a></h5>
                                  </div>
                                  <p>

                                   <p style="color:Black; font-weight:normal; font-size:12px;">
                                      "Dear 
                                          <asp:Label ID="smscustomername1" runat="server" Text=""></asp:Label>, Your fotolivin app account's username is <b><asp:Label ID="smsusername1" runat="server" Text=""></asp:Label></b> and your password is <b><asp:Label ID="smspassword1" runat="server" Text=""></asp:Label></b> (Your username and password are for your personal use only, do not share it to anyone). Your customerid is <b><asp:Label ID="smscustomerid1" runat="server" Text=""></asp:Label></b>. Share your customerid only to invite friends and family, enjoy sharing with all...!! Download fotolivin app from http://fotolivin.com/app " </p>
                                  <div class="row">
                                      <div class="col-md-6">
                                          <p style="color: #444c57;" >
                                             Customer's no: <asp:Label ID="displaycustomerphonelbl" runat="server" Text="label"></asp:Label> </p>
                                         
                                      </div>
                                      <div class="col-md-6">
                                          <p class="small mt" style="color: #444c57;">
                                              <asp:Button ID="sendsmsbtn" class="btn btn-default" runat="server" 
                                                  Text="Send sms" onclick="sendsmsbtn_Click" /> </p>
                                          
                                      </div>
                                     
                                  </div>
                              </div>
                          </div>
                         
                          <div class="col-lg-4 col-md-4 col-sm-4 mb">
                              <div class="steps pn">
                                  <label>
                                      Manage Gallery <a style="color:Black;" data-toggle="modal" href="#myModal3"><img src="images/info.png"/ width="15" height="15"></a></label>
                                  <asp:Button Style="border-bottom: 1px solid grey;" ID="photobtn" runat="server" Text="Photos >>>"
                                      Height="65px" onclick="photobtn_Click" />
                                  <asp:Button Style="border-bottom: 1px solid grey;" ID="videobtn" runat="server" Text="Videos >>>"
                                      Height="65px" onclick="videobtn_Click" />
                                  <asp:Button Style="border-bottom: 1px solid grey;" ID="albumbtn" runat="server" Text="Albums >>>"
                                      Height="65px" onclick="albumbtn_Click" />
                              </div>
                          </div>
                      </div>

                       
                      <!-- /row -->
                      <div class="row">
                          
                      </div>
                      <div class="row">
                          <div class="form-panel">
                              <h4 class="mb">
                                  <i class="fa fa-edit"></i> View Customer Profile Information <a style="color:Black;" data-toggle="modal" href="#myModal5"><img src="images/info.png"/ width="15" height="15"></a></h4>
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
                                          Customer Name:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editcustomernametb"  runat="server"></asp:Label>
                                      </div>
                                  </div>
                                  <div class="form-group">
                                      <label class="col-sm-2 col-sm-2 control-label">
                                          Account Name Description:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editsecondnametb"  runat="server"></asp:Label>
                                      </div>
                                  </div>
                                  
                                  <div class="form-group">
                                      <label class="col-sm-2 col-sm-2 control-label">
                                          Email ID:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editcustomeremailtb" runat="server"></asp:Label>
                                      </div>
                                  </div>
                                  <div class="form-group">
                                      <label class="col-sm-2 col-sm-2 control-label">
                                          Phone:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editcustomerphonetb"  runat="server"></asp:Label>
                                      </div>
                                  </div>
                                  <div class="form-group">
                                      <label class="col-sm-2 col-sm-2 control-label">
                                          City:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editcustomercitytb" runat="server"></asp:Label>
                                      </div>
                                  </div>
                                  <div class="form-group">
                                      <label class="col-sm-2 col-sm-2 control-label">
                                          State:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editcustomerstatetb" runat="server"></asp:Label>
                                      </div>
                                  </div>
                                  <div class="form-group">
                                      <label class="col-sm-2 col-sm-2 control-label">
                                          Country:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editcustomercountrytb"  runat="server"></asp:Label>
                                      </div>
                                  </div>
                                 
                                  <div class="form-group">
                                      <label class="col-sm-2 col-sm-2 control-label">
                                          Date:</label>
                                      <div class="col-sm-10">
                                          <asp:Label ID="editdatelbl" runat="server" Text=""></asp:Label>
                                      </div>
                                  </div>
                                 
                              </div>
                          </div>
                      </div>
                      <div aria-hidden="true" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" id="myModal1" class="modal fade">
		              <div class="modal-dialog">
		                  <div class="modal-content">
		                  
						<center>
						<div class="form-panel">
                        <h4 class="mb"><i class="fa fa-edit"></i> Customer's profile & cover sample image in app</h4>
                        
                        <div class="form-horizontal style-form">
                         <div class="form-group">
                            
                            <img src="images/customerprofile1.png" style="width:100%; height:auto;"/>

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
                        <h4 class="mb"><i class="fa fa-edit"></i> Send predefined text sms to custmer(owner of this account) regarding details of credentials.</h4>
                        
                        
                        
                        </div>
					</center>
		                  </div>
		              </div>
		          </div>
                  <div aria-hidden="true" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" id="myModal3" class="modal fade">
		              <div class="modal-dialog">
		                  <div class="modal-content">
		                  
						<center>
						<div class="form-panel">
                        <h4 class="mb"><i class="fa fa-edit"></i> Add & edit customer or account's photos, videos and photobooks in app.</h4>
                        
                        <div class="form-horizontal style-form">
                         <div class="form-group">
                            
                            <img src="images/customerprofile1.png" style="width:100%; height:auto;"/>

                          </div>
                         
                          
                          </div>
                        
                        </div>
					</center>
		                  </div>
		              </div>
		          </div>
                  <div aria-hidden="true" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" id="myModal4" class="modal fade">
		              <div class="modal-dialog">
		                  <div class="modal-content">
		                  
						<center>
						<div class="form-panel">
                        <h4 class="mb"><i class="fa fa-edit"></i>Edit customers's or account's profile & cover image in app</h4>
                        
                        <div class="form-horizontal style-form">
                         <div class="form-group">
                            
                            <img src="images/customerprofile1.png" style="width:100%; height:auto;"/>

                          </div>
                         
                          
                          </div>
                        
                        </div>
					</center>
		                  </div>
		              </div>
		          </div>
                  <div aria-hidden="true" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" id="myModal5" class="modal fade">
		              <div class="modal-dialog">
		                  <div class="modal-content">
		                  
						<center>
						<div class="form-panel">
                        <h4 class="mb"><i class="fa fa-edit"></i>  View customer's or account's details in app</h4>
                        
                        <div class="form-horizontal style-form">
                         <div class="form-group">
                            
                            <img src="images/customerprofile2.png" style="width:100%; height:auto;"/>

                          </div>
                         
                          
                          </div>
                        
                        </div>
					</center>
		                  </div>
		              </div>
		          </div>
                      
                      <!-- /row -->
                      <div class="row mt">
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
     <asp:HiddenField ID="albumsviewhf" runat="server" />
            <asp:HiddenField ID="photoviewhf" runat="server" />
                <asp:HiddenField ID="videoviewhf" runat="server" />
                
                <asp:HiddenField ID="albumslikehf" runat="server" />
            <asp:HiddenField ID="photolikehf" runat="server" />
                <asp:HiddenField ID="videolikehf" runat="server" />

                <asp:HiddenField ID="albumsspacehf" runat="server" />
            <asp:HiddenField ID="photospacehf" runat="server" />
                <asp:HiddenField ID="videospacehf" runat="server" />

    <script src="assets/js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script src="assets/js/lightbox.js" type="text/javascript"></script>

  
</asp:Content>
