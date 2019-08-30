﻿<%@ Page Title="" Language="C#" MasterPageFile="~/companyaccess/company-menu.master" AutoEventWireup="true" CodeFile="company-customer-videos.aspx.cs" Inherits="company_customer_videos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="Dashboard">
    <meta name="keyword" content="Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina">
    <title>Fotolivin</title>
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
        <div class="row mtbox" style="margin-top:60px;">
               <div class="form-panel">
            <div class="form-group" style="float:right; margin-left:5px;">
                <asp:Button ID="albumbtn" class="btn btn-default" runat="server" Text="Albums" OnClick="albumbtn_Click" />
                </div>
                <div class="form-group" style="float:right; margin-left:5px;">
                <asp:Button ID="photobtn" class="btn btn-default" runat="server" Text="Photos" OnClick="photobtn_Click" />
                </div>
                
           <div class="form-group" style="float:right; margin-left:5px;">
                <asp:Button ID="backbtn" class="btn btn-default" runat="server" Text="<<< Back" OnClick="backbtn_Click" />
                </div>
                    <div class="form-group">
                        <div>
                        
                        <asp:Label ID="Label1" runat="server" Text="Company ID:"></asp:Label>
                        <b>
                        <asp:Label ID="companyidlbl" runat="server"></asp:Label>
                        </b>
                        </div>
                         <br />
                        <div>
                        <asp:Label ID="Label2" runat="server" Text="Customer ID:"></asp:Label>
                        <b>
                        
                        <asp:Label ID="customeridlbl" runat="server"></asp:Label>                        
                        </b>
                        </div>
                       
                    </div>
               
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>

  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
            <asp:Panel ID="viewvideogallerypnl" runat="server">
       
    <div class="form-panel">
        
                          <h4 class="mb">
                                  <i class="fa fa-edit"></i> View Video Gallery  <a style="color:Black;" data-toggle="modal" href="#myModal2"><img src="images/info.png"/ width="15" height="15"></a>
                                 </h4>
        
                           <div class="form-horizontal style-form">
                                  <div class="form-group">
                <asp:DataList ID="eventsdl" runat="server" Width="100%" 
                HorizontalAlign="Center" RepeatColumns="5" RepeatDirection="Horizontal">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemTemplate>
                
                    <asp:ImageButton ID="eventsib" runat="server"  
                        Height="150px" BorderStyle="None" ForeColor="black" ImageUrl="~/images/videocover.png" 
                        onclick="eventsib_Click" ></asp:ImageButton>
                         <br />
                          <asp:Label ID="eventslbl" runat="server" Text='<%# Bind("eventsPath1") %>'></asp:Label>
                     &nbsp;&nbsp;&nbsp;
                  
             
                </ItemTemplate>
            </asp:DataList>    
                                  </div>
                                  </div>
                          </div>
                           </asp:Panel>
           
                           <asp:Panel ID="viewvideopnl" runat="server">
       
    <div class="form-panel">
       <center>
                          <h4 class="mb"><asp:Label ID="eventnamelbl" runat="server" Text="Label"></asp:Label> Videos
                           </h4>
                           <div class="form-horizontal style-form">
                                  <div class="form-group">
                                  
                <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>

                      <div style="height:300px; float:left; margin:10px; padding:5px; background:#f2f2f2; border-radius:15px;">
                
                               
                               <br />
                               <center>
                               <video id="Video1" class="video-js vjs-default-skin" controls preload="none" height="200px" poster="~/images/playvideo.png" data-setup="{}">
                    <source src='<%#Eval("videosPath1") %>' type='video/mp4' />
                   
                    </video>
               
                                </center>
                                  <asp:Label ID="filenamelbl" style="margin:5px;" runat="server" Text='  <%#Eval("videosNamePath1") %>'></asp:Label>
                                  <br />
         Original Name : <asp:Label ID="Label4" style="margin:5px;" runat="server" Text='<%#Eval("videosONPath1") %>'></asp:Label>
                                  <br />
         views : <asp:Label ID="Label1" style="margin:5px;" runat="server" Text='<%#Eval("videosViewsPath1") %>'></asp:Label>
          | 
           likes : <asp:Label ID="Label2" style="margin:5px;" runat="server" Text='<%#Eval("videosLikesPath1") %>'></asp:Label>
          <br />
          Size : <asp:Label ID="Label3" style="margin:5px;" runat="server" Text='<%#Eval("videosSizePath1") %>'></asp:Label>
                               </div>

                                </ItemTemplate>
                </asp:Repeater>  
             
                                  </div>
                                  </div>
                                 </center>  
                          </div>
                           </asp:Panel>  
            
            </ContentTemplate>
            
            </asp:UpdatePanel>
             
        </div>
         <div aria-hidden="true" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" id="myModal2" class="modal fade">
		              <div class="modal-dialog">
		                  <div class="modal-content">
		                  
						<center>
						<div class="form-panel">
                        <h4 class="mb"><i class="fa fa-edit"></i> Video galleries for APP</h4>
                        
                        <div class="form-horizontal style-form">
                         <div class="form-group">
                            
                            <img src="images/customervideos2.png" style="width:100%; height:auto;"/>

                          </div>
                         
                          
                          </div>
                        
                        </div>
					</center>
		                  </div>
		              </div>
		          </div>
              <div class="row">
                  <div class="col-lg-9 main-chart" style="width: 100%;">
                     
                      <!-- /row -->
                      <div class="row">
                          
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
            <script src="assets/js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script src="assets/js/lightbox.js" type="text/javascript"></script>
     
</asp:Content>

