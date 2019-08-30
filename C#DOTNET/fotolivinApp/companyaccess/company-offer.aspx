<%@ Page Title="" Language="C#" MasterPageFile="~/companyaccess/company-menu.master" AutoEventWireup="true" CodeFile="company-offer.aspx.cs" Inherits="company_offer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="Dashboard">
    <meta name="keyword" content="Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina">
    <title>Fotolivin</title>
    <script>
        // WRITE THE VALIDATION SCRIPT IN THE HEAD TAG.
        function isNumber1(evt) {
            var iKeyCode = (evt.which) ? evt.which : evt.keyCode
            if ((iKeyCode >= 0 && iKeyCode < 32) || (iKeyCode > 32 && iKeyCode < 48) || (iKeyCode > 57 && iKeyCode < 65) || (iKeyCode > 90 && iKeyCode < 97) || iKeyCode > 122)
                return false;

            return true;
        }    
</script>
<script>
    // WRITE THE VALIDATION SCRIPT IN THE HEAD TAG.
    function isNumber2(evt) {
        var iKeyCode = (evt.which) ? evt.which : evt.keyCode
        if (iKeyCode == 127 || iKeyCode == 8 || iKeyCode == 9 || iKeyCode == 13 || iKeyCode == 32 || iKeyCode == 40 || iKeyCode == 41 || (iKeyCode >= 48 && iKeyCode <= 57) || (iKeyCode >= 65 && iKeyCode <= 90) || (iKeyCode >= 97 && iKeyCode <= 122) || iKeyCode == 44 || iKeyCode == 46)
            return true;

        return false;
    }    
</script>
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
 <section id="main-content">
        <section class="wrapper">

              <div class="row">
              <div class="col-lg-9 main-chart" style="width: 100%;">
              <div class="row mtbox"  style="margin-top:40px; margin-bottom:0px;">
                          <div class="form-panel">
                              <h4 class="mb">
                                  <i class="fa fa-edit"></i>Post new Ad..!! <a style="color:Black;" data-toggle="modal" href="#myModal1"><img src="images/info.png"/ width="15" height="15"></a>
                                  
                                   <asp:Button ID="downloadsample" runat="server" Text="Download Sample Templates" 
                                          BackColor="Transparent" BorderStyle="None" onclick="downloadsample_Click" 
                                          ForeColor="Red" />
                                  
                                  </h4>
                              <div class="form-horizontal style-form" >
                              <div class="form-group" style="width:100%; float:left; margin:0%;">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                          Ad Name:</label>
                                      <div class="col-sm-10">
                                          <asp:TextBox ID="adnametb" MaxLength="45" class="form-control" runat="server" onkeypress="javascript:return isNumber1(event)"></asp:TextBox>
                                      </div>
                                  </div>
                                  <div class="form-group" style="width:100%;  margin:0%;">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                          Ad Details:</label>
                                      <div class="col-sm-10">
                                          <asp:TextBox ID="addetailtb" MaxLength="495" class="form-control" runat="server" onkeypress="javascript:return isNumber2(event)"></asp:TextBox>
                                      </div>
                                  </div>
                                  
                                 
                                  <div class="form-group" style="width:100%; margin:0%;">
                                    <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                         Upload Ad Image:</label>
                                <div class="col-sm-10">
                                  <asp:FileUpload ID="FileUpload1" runat="server" />
                                  </div>

</div>
<div class="form-group" style="width:100%; margin:0%;">
 <label class="control-label" style="padding:0%; color:Red;">
                                         * Use image size of around 100kb only for better perfomance</label>

</div>
                                   <div class="form-group">
                                      <label class="col-sm-2 col-sm-2 control-label" style="padding:0%;">
                                      </label>
                                      <asp:Button ID="addbtn" class="btn btn-default" runat="server" 
                                           Text="Post Ad" onclick="addbtn_Click"/>
                                          
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
                        <h4 class="mb"><i class="fa fa-edit"></i> Add new ads for digital marketing to grow your network and remain live with all your users via app..!!</h4>
                        
                        <div class="form-horizontal style-form">
                         <div class="form-group">
                            
                            <img src="images/ad1.png" style="width:100%; height:auto;"/>

                          </div>
                         
                          
                          </div>
                        
                        </div>
					</center>
		                  </div>
		              </div>
		          </div>
                  <asp:Repeater ID="Repeater1" runat="server" onitemcommand="Repeater1_ItemCommand">
                  <ItemTemplate>
                  <div class="col-lg-9 main-chart" style="width:33.3%; padding-top:0px;">
                      <div class="row mtbox" style="margin-top:0px; margin-bottom:0px;">
                          <div class="form-panel" style="min-height:400px;">
                              <h4 class="mb" style="text-decoration: underline;">
                                 
                                  <asp:Label ID="title" runat="server" Text='<%#Eval("adNamePath1") %>'></asp:Label>
                                  </h4>
                                   <div class="form-horizontal style-form">
                                  <div class="form-group">
                                      <div class="col-sm-10" style="width: 100%;">
                                      <asp:Image ID="Image1" style=" width:100%; height:auto;" runat="server" ImageUrl='<%#Eval("adPath1") %>'></asp:Image>
                                     <p></p>
                                          <p>
                                              <asp:Label ID="details" runat="server" Text='<%#Eval("addetailPath1") %>'></asp:Label>
                                              <p>
               
                                      </div>
                                  </div>
                                 <asp:LinkButton ID="lnkDelete" runat="server" CommandName="delete" OnClientClick='javascript:return confirm("Are you sure you want to delete?")' 
            CommandArgument='<%#Eval("adidPath1") %>'>Delete</asp:LinkButton>
                              </div>
                          </div>
                          
                      </div>
                      <!-- /row -->
                      
                      <!-- /row -->
                  </div>
                  </ItemTemplate>
                  </asp:Repeater>
                  
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

