<%@ Page Title="" Language="C#" MasterPageFile="~/menu.master" AutoEventWireup="true" CodeFile="company-profile.aspx.cs" Inherits="company_profile" %>

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

      <!--main content start-->
      <section id="main-content">
          <section class="wrapper">

              <div class="row">
                  <div class="col-lg-9 main-chart" style="width:100%;">
                  
                  	<!-- /row mt -->	
                  
                      
                      <div class="row mtbox" style="margin-bottom:0px;">
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
                                     <a style="color:Black;" data-toggle="modal" href="#myModal"> Upload new profile & cover image</a> 
		                           </h4>
								</div>
                              </div>
							
						</div>
                         <div class="col-lg-4 col-md-4 col-sm-4 mb">
                              <div class="steps pn" style="height:65px;">
                                 
                                  <asp:Button Style="border-bottom: 1px solid grey;" ID="photobtn" runat="server" Text="Add/Edit Service Portfolio >>>"
                                      Height="65px" onclick="photobtn_Click" />
                                
                                 
                              </div>
                          </div>
                      <!-- SERVER STATUS PANELS -->
                      	<!-- /col-md-4-->
                      	

                      	<! -- PROFILE 02 PANEL -->
						<!--/ col-md-4 --><!-- /col-md-4 -->
                      

                    </div><!-- /row -->
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
                     <!-- Modal -->
		          <div aria-hidden="true" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" id="myModal" class="modal fade">
		              <div class="modal-dialog">
		                  <div class="modal-content">
		                  
						<center>
						<div class="form-panel">
                        <h4 class="mb"><i class="fa fa-edit"></i> Change company's profile & cover image</h4>
                        
                        <div class="form-horizontal style-form">
                         <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label" style="width:30%;">Change profile image</label>
                              <div class="col-sm-10" style="width:65%;">

                        <asp:FileUpload ID="uploadcoprofimg" class="form-control" runat="server" />
                              </div>
                          </div>
                          <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label" style="width:30%;">Change cover image</label>
                              <div class="col-sm-10" style="width:65%;">

                        <asp:FileUpload ID="uploadcocoverimg" class="form-control" runat="server" />
                              </div>
                          </div>
                          <div class="form-group" style="width:100%; margin:0%;">
 <label class="control-label" style="padding:0%; color:Red;">
                                         * Use image size of 100kb only for better perfomance</label>

</div>
                           <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label"></label>
                               <asp:Button ID="refresh" class="btn btn-default" runat="server" 
                                   Text="Refresh" onclick="refresh_Click" />
                          </div>
                          </div>
                        
                        </div>
					</center>
		                  </div>
		              </div>
		          </div>
		          <!-- modal -->
                    <div aria-hidden="true" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" id="myModal2" class="modal fade">
		              <div class="modal-dialog">
		                  <div class="modal-content">
		                  
						<center>
						<div class="form-panel">
                        <h4 class="mb"><i class="fa fa-edit"></i> Company profile details in app</h4>
                        
                        <div class="form-horizontal style-form">
                         <div class="form-group">
                            
                            <img src="images/companyprofile2.png" style="width:100%; height:auto;"/>

                          </div>
                         
                          
                          </div>
                        
                        </div>
					</center>
		                  </div>
		              </div>
		          </div>
                    				
					<div class="row">
						
						
						<div class="form-panel">
                        <h4 class="mb"><i class="fa fa-edit"></i> Edit company profile information <a style="color:Black;" data-toggle="modal" href="#myModal2"><img src="images/info.png"/ width="15" height="15"></a></h4>
                        <div class="form-horizontal style-form">
                         <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Company ID :</label>
                              <div class="col-sm-10">

                                  <asp:Label ID="editcompanyidlbl"  runat="server" Text=""></asp:Label>
                              </div>
                          </div>
                           <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Sample Account ID:</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editsampleaccountidlbl" MaxLength="45" class="form-control" PlaceHolder="Sample account id" runat="server" onkeypress="javascript:return isNumber1(event)"></asp:TextBox>
                              </div>
                          </div>
                         <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Full Name :</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editfullnametb" MaxLength="45" class="form-control" PlaceHolder="fullname" runat="server" onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                              </div>
                          </div>
                          <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Company Name :</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editcompanynametb" MaxLength="45" class="form-control" PlaceHolder="company name" runat="server" onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                              </div>
                          </div>
                          <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Address :</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editaddresstb" MaxLength="495" class="form-control" PlaceHolder="address" runat="server" onkeypress="javascript:return isNumber2(event)"></asp:TextBox>
                              </div>
                          </div>
                          <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Email(Username) :</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editemailtb" MaxLength="45" class="form-control" runat="server" TextMode="Email"></asp:TextBox>
                              </div>
                          </div>
                          <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">password :</label>
                              <div class="col-sm-10">
                              <asp:TextBox ID="editpasswordtb" MaxLength="45" class="form-control" runat="server" onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                              </div>
                          </div>
                          <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Phone :</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editphonetb" MaxLength="15" class="form-control" PlaceHolder="phone number" runat="server" TextMode="Phone"></asp:TextBox>
                              </div>
                          </div>
                          <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">City :</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editcitytb" MaxLength="45" class="form-control" runat="server" onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                              </div>
                          </div>
                           <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">State :</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editstatetb" MaxLength="45" class="form-control" runat="server" onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                              </div>
                          </div>
                           <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Country :</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editcountrytb" MaxLength="45" class="form-control" runat="server" onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                              </div>
                          </div>
                           <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">About info :</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editaboutinfotb" MaxLength="495" class="form-control" PlaceHolder="about info" runat="server" onkeypress="javascript:return isNumber2(event)"></asp:TextBox>
                              </div>
                          </div>
                         
                           <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Achievements/Awards :</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editachievementtb" MaxLength="495" class="form-control" runat="server"  onkeypress="javascript:return isNumber2(event)"></asp:TextBox>
                              </div>
                          </div>
                          <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Facebook Link:</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editfblinktb" MaxLength="145" class="form-control" runat="server" TextMode="Url"></asp:TextBox>
                              </div>
                          </div>
                          <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Instagram Link:</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editinstagramlinktb" MaxLength="145" class="form-control" runat="server" TextMode="Url"></asp:TextBox>
                              </div>
                          </div>
                          <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Google+ Link:</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editgooglepluslinktb" MaxLength="145" class="form-control" runat="server" TextMode="Url"></asp:TextBox>
                              </div>
                          </div>
                          <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Twitter Link:</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="edittwitterlinktb" MaxLength="145" class="form-control" runat="server" TextMode="Url"></asp:TextBox>
                              </div>
                          </div>
                          <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Youtube Link:</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="edityoutubelinktb" MaxLength="145" class="form-control" runat="server" TextMode="Url"></asp:TextBox>
                              </div>
                          </div>
                          <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">Website Link:</label>
                              <div class="col-sm-10">

                                  <asp:TextBox ID="editwebsitelinktb" MaxLength="145" class="form-control" runat="server" TextMode="Url"></asp:TextBox>
                              </div>
                          </div>

                           <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">SMS Credits :</label>
                              <div class="col-sm-10">

                                  <asp:Label ID="editsmscreditslbl" runat="server" Text=""></asp:Label>
                              </div>
                          </div>
                           <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">SMS senderid :</label>
                              <div class="col-sm-10">

                                  <asp:Label ID="editsmssenderidlbl"  runat="server" Text=""></asp:Label>
                              </div>
                          </div>
                          
                          
                          
                           <div class="form-group">
                              <label class="col-sm-2 col-sm-2 control-label">date :</label>
                              <div class="col-sm-10">

                                  <asp:Label ID="editdatelbl"  runat="server" Text=""></asp:Label>
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

                    <script src="assets/js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script src="assets/js/lightbox.js" type="text/javascript"></script>
      
      <!--main content end-->
  <script type = "text/javascript">
        $(window).load(
    function () {
        $("#<%=uploadcoprofimg.ClientID%>").fileUpload({
            'uploader': 'scripts/uploader.swf',
            'cancelImg': 'images/cancel.png',
            'buttonText': 'Choose File..!!',
            'script': 'uploadcoprofimg.ashx',
            'folder': 'uploads',
            'fileDesc': 'Image Files',
            'fileExt': '*.jpg;*.jpeg;*.JPG;*.JPEG',
            'scriptData': { "coid": "<%=editcompanyidlbl.Text%>" },
            'multi': false,
            'auto': true

        });
    });
</script>
<script type = "text/javascript">
    $(window).load(
    function () {
        $("#<%=uploadcocoverimg.ClientID%>").fileUpload({
            'uploader': 'scripts/uploader.swf',
            'cancelImg': 'images/cancel.png',
            'buttonText': 'Choose File..!!',
            'script': 'uploadcocoverimg.ashx',
            'folder': 'uploads',
            'fileDesc': 'Image Files',
            'fileExt': '*.jpg;*.jpeg;*.JPG;*.JPEG',
            'scriptData': { "coid": "<%=editcompanyidlbl.Text%>" },
            'multi': false,
            'auto': true

        });
    });
</script>
</asp:Content>


