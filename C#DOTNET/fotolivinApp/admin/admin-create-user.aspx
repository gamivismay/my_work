﻿<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin-menu.master" AutoEventWireup="true" CodeFile="admin-create-user.aspx.cs" Inherits="admin_create_user" %>

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
                 
                  <div class="row mtbox" style="margin-top:40px;">
						
						
						<div class="form-panel">
                        <h4 class="mb"><i class="fa fa-edit"></i> Create New User Account</h4>
                        <div class="form-horizontal style-form">
                         <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Username :</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="usernametb" MaxLength="45" class="form-control" runat="server"></asp:TextBox>
                              </div>
                          </div>
                         
                          <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Email :</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="emailtb" MaxLength="45" class="form-control" runat="server" TextMode="Email"></asp:TextBox>
                              </div>
                          </div>
                          <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Password :</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="passwordtb" MaxLength="45" class="form-control" runat="server"></asp:TextBox>
                              </div>
                          </div>
                          <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Phone :</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="phonetb" MaxLength="15" class="form-control" runat="server" TextMode="Phone"></asp:TextBox>
                              </div>
                          </div>
                          <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Birthdate :</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="birthdatetb" MaxLength="45" class="form-control" runat="server"></asp:TextBox>
                              </div>
                          </div>
                          <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Companyid :</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="companyidtb" MaxLength="45" class="form-control" runat="server"></asp:TextBox>
                              </div>
                          </div>
                          <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Customerid :</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="customeridtb" MaxLength="45" class="form-control" runat="server"></asp:TextBox>
                              </div>
                          </div>
                           <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label"></label>
                               <asp:Button ID="companycreateaccountbtn" class="btn btn-default" runat="server" 
                                   Text="Create Account" onclick="companycreateaccountbtn_Click" />
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

</asp:Content>

