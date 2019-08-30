<%@ Page Title="" Language="C#" MasterPageFile="~/menu.master" AutoEventWireup="true" CodeFile="gallery-albums.aspx.cs" Inherits="gallery_albums" %>

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
        <div class="row mtbox" style="margin-top:60px;">
                 <div class="form-panel">
               
               <div class="form-group" style="float:right; margin-left:5px;">
                                       <asp:Button ID="backbtn" class="btn btn-default" runat="server" Text="<<< Back" onclick="backbtn_Click"
                                           />
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
                        <br />
                        <div>
                        <asp:Label ID="Label3" runat="server" Text=" Gallery Name:"></asp:Label>
                        <b>
                        
                        <asp:Label ID="gallerynamelbl" runat="server"></asp:Label>
                        
                        </div>
                        </div>
                                   
                                         
                  </div>
                   
                  <div class="form-panel">
                              <h4 class="mb">
                                  <i class="fa fa-edit"></i> Edit album gallery for APP <a style="color:Black;" data-toggle="modal" href="#myModal1"><img src="images/info.png"/ width="15" height="15"></a></h4>
                              <div class="form-horizontal style-form">
                                  <div class="form-group">
                                      <label class="col-sm-2 col-sm-2 control-label">
                                         Set album cover image : </label>
                                      <div class="col-sm-10">
                        <asp:FileUpload ID="uploadalbumthumbimg" class="form-control" runat="server" />
                                      </div>
                                  </div>
                                   <div class="form-group">
                                      <label class="col-sm-2 col-sm-2 control-label">
                                         Set album audio : </label>
                                      <div class="col-sm-10">
                        <asp:FileUpload ID="uploadalbumaudio" class="form-control" runat="server" />
                                      </div>
                                  </div>
                                   <div class="form-group">
                                      <label class="col-sm-2 col-sm-2 control-label">
                                          Upload album images : </label>
                                      <div class="col-sm-10">
                        <asp:FileUpload ID="uploadalbumimgs" class="form-control" runat="server" />
                        <h4 style="color:Red;">Change name of files to only intezer</h4>
                                      </div>
                                  </div>
                                   <div class="form-group">
                                      <label class="col-sm-2 col-sm-2 control-label">
                                      </label>
                                     <a style="line-height:20px;" class="btn btn-info" href="javascript:$('#<%=uploadalbumthumbimg.ClientID%>').fileUploadStart(); javascript:$('#<%=uploadalbumaudio.ClientID%>').fileUploadStart(); javascript:$('#<%=uploadalbumimgs.ClientID%>').fileUploadStart()">Start Upload</a>
                                     <asp:Button ID="Refresh" class="btn btn-default" runat="server" Text="Refresh" 
                                           onclick="Refresh_Click" />
                                  </div>
                                 
                              </div>
                          </div>
  
                            <asp:Panel ID="viewphotopnl" runat="server">
       
    <div class="form-panel">
       <center>
                          <h4 class="mb"><asp:Label ID="eventnamelbl" runat="server" Text=""></asp:Label> Album Photos
                          <asp:ImageButton ID="photodelete" runat="server" Height="20px" 
                                      ImageUrl="~/images/Recycle_Bin_Full.png" Width="20px" 
                                  onclick="photodelete_Click" /> </h4>
                           <div class="form-horizontal style-form">
                                  <div class="form-group">
                                  
                <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>

                      <div style=" height:180px; float:left; margin:10px; padding:5px; background:#f2f2f2; border-radius:15px;">
                 <asp:CheckBox ID="chck" runat="server"></asp:CheckBox>
                               <br />
                              
                               <center>
                <a class="example-image-link" href='<%#Eval("albumsPhotoPath1") %>' data-lightbox="example-set" style="margin:0 5px 0 5px;">
                                    <asp:Image ID="Image1" style=" width:auto; height:110px;  border:2px solid gray;" runat="server" ImageUrl='<%#Eval("albumsPhotoPath1") %>'></asp:Image>
                               <br />
                                <asp:Label ID="filenamelbl" style="margin:5px;" runat="server" Text='  <%#Eval("albumsPhotoNamePath1") %>'></asp:Label>
                                 <br />
         Original Name : <asp:Label ID="Label1" style="margin:5px;" runat="server" Text='<%#Eval("albumsPhotoONPath1") %>'></asp:Label>
                             
                                </a>
                                </center>
                                 
                               </div>

                                </ItemTemplate>
                </asp:Repeater>  
              
                                  </div>
                                  </div>
                                 </center>  
                          </div>
                           </asp:Panel>  
            
          

        </div>
                  <div aria-hidden="true" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" id="myModal1" class="modal fade">
		              <div class="modal-dialog">
		                  <div class="modal-content">
		                  
						<center>
						<div class="form-panel">
                        <h4 class="mb"><i class="fa fa-edit"></i> Edit album gallery for APP</h4>
                        
                        <div class="form-horizontal style-form">
                         <div class="form-group">
                            
                            <img src="images/customeralbums2.png" style="width:100%; height:auto;"/>

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
     
<script type = "text/javascript">
    $(window).load(
    function () {
        $("#<%=uploadalbumthumbimg.ClientID%>").fileUpload({
            'uploader': 'scripts/uploader.swf',
            'cancelImg': 'images/cancel.png',
            'buttonText': 'Choose File..!!',
            'script': 'uploadalbumthumbimg.ashx',
            'folder': 'uploads',
            'fileDesc': 'Image Files',
            'fileExt': '*.jpg;*.jpeg;*.JPG;*.JPEG',
            'scriptData': { "coid": "<%=companyidlbl.Text%>", "eventname": "<%=gallerynamelbl.Text %>", "albumid": "<%=eventnamelbl.Text %>", "customerid": "<%=customeridlbl.Text %>" },
            'multi': false,
            'auto': false

        });
    });
</script>
<script type = "text/javascript">
    $(window).load(
    function () {
        $("#<%=uploadalbumaudio.ClientID%>").fileUpload({
            'uploader': 'scripts/uploader.swf',
            'cancelImg': 'images/cancel.png',
            'buttonText': 'Choose File..!!',
            'script': 'uploadalbumaudio.ashx',
            'folder': 'uploads',
            'fileDesc': 'Image Files',
            'fileExt': '*.mp3;*.MP3',
            'scriptData': { "coid": "<%=companyidlbl.Text%>", "eventname": "<%=gallerynamelbl.Text %>", "albumid": "<%=eventnamelbl.Text %>", "customerid": "<%=customeridlbl.Text %>" },
            'multi': false,
            'auto': false

        });
    });
</script>
<script type = "text/javascript">
    $(window).load(
    function () {
        $("#<%=uploadalbumimgs.ClientID%>").fileUpload({
            'uploader': 'scripts/uploader.swf',
            'cancelImg': 'images/cancel.png',
            'buttonText': 'Choose File..!!',
            'script': 'uploadcustomeralbums.ashx',
            'folder': 'uploads',
            'fileDesc': 'Image Files',
            'fileExt': '*.jpg;*.jpeg;*.JPG;*.JPEG',
            'scriptData': { "coid": "<%=companyidlbl.Text%>", "eventname": "<%=gallerynamelbl.Text %>", "albumid": "<%=eventnamelbl.Text %>", "customerid": "<%=customeridlbl.Text %>" },
            'multi': true,
            'auto': false

        });
    });
</script>
</asp:Content>

