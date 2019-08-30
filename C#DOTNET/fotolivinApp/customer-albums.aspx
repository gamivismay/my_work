<%@ Page Title="" Language="C#" MasterPageFile="~/menu.master" AutoEventWireup="true"
    CodeFile="customer-albums.aspx.cs" Inherits="customer_albums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
        <div class="row mtbox" style="margin-top: 60px;">
            <div class="form-panel">
            <div class="form-group" style="float:right; margin-left:5px;">
                <asp:Button ID="videobtn" class="btn btn-default" runat="server" Text="Videos" OnClick="videobtn_Click" />
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
                        <br />
                       
                    </div>
                
            </div>
            <div class="form-panel">
                <h4 class="mb">
                    <i class="fa fa-edit"></i>Choose main cover thumbnail for album gallery <a style="color:Black;" data-toggle="modal" href="#myModal1"><img src="images/info.png"/ width="15" height="15"></a></h4>
                <div class="form-horizontal style-form">
                    <div class="form-group">
                        <label class="col-sm-2 col-sm-2 control-label">
                            Set main cover thumbnail :
                        </label>
                        <div class="col-sm-10">
                            <asp:FileUpload ID="uploadalbumcoverimg" class="form-control" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 col-sm-2 control-label">
                        </label>
                        <asp:Button ID="refresh1" class="btn btn-default" runat="server" Text="Refresh" OnClick="refresh1_Click" />
                        <asp:Repeater ID="Repeater2" runat="server">
                            <ItemTemplate>
                                <div style="float: left; margin: 10px; padding: 5px; background: #f2f2f2; border-radius: 15px;">
                                    <center>
                <a class="example-image-link" href='<%#Eval("coverPath1") %>' data-lightbox="example-set" style="margin:0 5px 0 5px;">
                                   
                               
                               Preview
                             
                                </a>
                                </center>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
            <div class="form-panel">
                <h4 class="mb">
                    <i class="fa fa-edit"></i>Create album gallery for APP <a style="color:Black;" data-toggle="modal" href="#myModal2"><img src="images/info.png"/ width="15" height="15"></a></h4>
                <div class="form-horizontal style-form">
                    <div class="form-group">
                        <label class="col-sm-2 col-sm-2 control-label">
                            Choose category/event name :
                        </label>
                        <div class="col-sm-10" style="width: 40%;">
                            <asp:DropDownList ID="eventsddl1" class="form-control" runat="server" OnSelectedIndexChanged="eventsddl1_SelectedIndexChanged"
                                AutoPostBack="True">
                                <asp:ListItem>Other</asp:ListItem>
                                          <asp:ListItem>Wedding</asp:ListItem>
                            <asp:ListItem>Birthday Event</asp:ListItem>
                            <asp:ListItem>Engagement/Ring ceremony</asp:ListItem>
                            <asp:ListItem>Mehndi</asp:ListItem>
                            <asp:ListItem>Reception</asp:ListItem>
                            <asp:ListItem>Sangeet</asp:ListItem>
                            <asp:ListItem>Cocktails</asp:ListItem>
                            <asp:ListItem>Marriage Anniversary</asp:ListItem>
                            <asp:ListItem>Roka ceremony</asp:ListItem>
                            <asp:ListItem>Travel photos</asp:ListItem>
                            <asp:ListItem>Picnic</asp:ListItem>
                            <asp:ListItem>Gettogether</asp:ListItem>
                            <asp:ListItem>Annual conference</asp:ListItem>
                           <asp:ListItem>Customer/Executive visits</asp:ListItem>
                                          <asp:ListItem>Occasion Photography</asp:ListItem>
                                          <asp:ListItem>Abstract Photography</asp:ListItem>
                                          <asp:ListItem>Animals Photography</asp:ListItem>
                                          <asp:ListItem>Commercial Photography</asp:ListItem>
                                          <asp:ListItem>Creative Photography</asp:ListItem>
                                          <asp:ListItem>Product Photography</asp:ListItem>
                                          <asp:ListItem>Event Photography</asp:ListItem>
                                          <asp:ListItem>Family Photography</asp:ListItem>
                                          <asp:ListItem>People Photography</asp:ListItem>
                                          <asp:ListItem>Portrait Photography</asp:ListItem>
                                          <asp:ListItem>Sport Photography</asp:ListItem>
                                          <asp:ListItem>Still Life Photography</asp:ListItem>
                                          <asp:ListItem>Street Photography</asp:ListItem>
                                          <asp:ListItem>Macro Photography</asp:ListItem>
                                          <asp:ListItem>Birds Photography</asp:ListItem>
                                          <asp:ListItem>Nature Photography</asp:ListItem>
                                          <asp:ListItem>Kids Photography</asp:ListItem>
                                          <asp:ListItem>Holiday Photography</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="eventsddl" runat="server" Text=""></asp:Label>
                                <br />
                                <asp:Label ID="albumid" runat="server" Text="AlbumID:"></asp:Label>
                                <asp:Label ID="albumidlbl" runat="server" Text=""></asp:Label>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="eventsddl1" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                    <asp:Panel ID="othereventpnl" runat="server">
                        <div class="form-group">
                            <label class="col-sm-2 col-sm-2 control-label">
                                other eventname :
                            </label>
                            <div class="col-sm-10" style="width: 40%;">
                                <asp:TextBox ID="othereventnametb" MaxLength="45" class="form-control" runat="server" onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                                <asp:Button ID="donebtn" class="btn btn-default" runat="server" Text="Done" OnClick="donebtn_Click" />
                            </div>
                        </div>
                    </asp:Panel>
                    <div class="form-group">
                        <label class="col-sm-2 col-sm-2 control-label">
                            Set album cover image :
                        </label>
                        <div class="col-sm-10">
                            <asp:FileUpload ID="uploadalbumthumbimg" class="form-control" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 col-sm-2 control-label">
                            Set album audio :
                        </label>
                        <div class="col-sm-10">
                            <asp:FileUpload ID="uploadalbumaudio" class="form-control" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 col-sm-2 control-label">
                            Upload album images :
                        </label>
                        <div class="col-sm-10">
                            <asp:FileUpload ID="uploadalbumimgs" class="form-control" runat="server" />
                            <h4 style="color:Red;">Change name of files to only intezer</h4>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 col-sm-2 control-label">
                        </label>
                        <a style="line-height: 20px;" class="btn btn-info" href="javascript:$('#<%=uploadalbumthumbimg.ClientID%>').fileUploadStart(); javascript:$('#<%=uploadalbumaudio.ClientID%>').fileUploadStart(); javascript:$('#<%=uploadalbumimgs.ClientID%>').fileUploadStart()">
                            Start Upload</a>
                        <asp:Button ID="Refresh" class="btn btn-default" runat="server" Text="Refresh" OnClick="Refresh_Click" />
                    </div>
                </div>
            </div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="viewalbumgallerypnl" runat="server">
                        <div class="form-panel">
                            <h4 class="mb">
                                <i class="fa fa-edit"></i>View Events
                                <asp:ImageButton ID="albumdirdelete" runat="server" Height="20px" ImageUrl="~/images/Recycle_Bin_Full.png"
                                    Width="20px" OnClick="albumdirdelete_Click" /></h4>
                            <div class="form-horizontal style-form">
                                <div class="form-group">
                                    <asp:DataList ID="eventsdl1" runat="server" Width="100%" HorizontalAlign="Center"
                                        RepeatColumns="5" RepeatDirection="Horizontal">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="eventsib1" runat="server" Height="150px" BorderStyle="None" ForeColor="black"
                                                ImageUrl="~/images/GalleryIcon.png" OnClick="eventsib1_Click"></asp:ImageButton>
                                            <br />
                                            <asp:Label ID="eventslbl1" runat="server" Text='<%# Bind("eventsPath1") %>'></asp:Label>
                                            &nbsp;&nbsp;&nbsp;
                                            <asp:CheckBox ID="eventschck1" runat="server"></asp:CheckBox>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="viewalbumthumbpnl" runat="server">
                        <div class="form-panel">
                            <h4 class="mb">
                                <i class="fa fa-edit"></i>View
                                <asp:Label ID="albumcategorynamelbl" runat="server" Text="Label"></asp:Label>
                                Album Gallery
                                <asp:ImageButton ID="albumthumbdelete" runat="server" Height="20px" ImageUrl="~/images/Recycle_Bin_Full.png"
                                    Width="20px" OnClick="albumthumbdelete_Click" /></h4>
                            <div class="form-horizontal style-form">
                                <div class="form-group">
                                    <asp:DataList ID="eventsdl2" runat="server" Width="100%" HorizontalAlign="Center"
                                        RepeatColumns="5" RepeatDirection="Horizontal">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="eventsib2" runat="server" Style="border: 1.5px solid rgb(0,147,221);"
                                                Height="100px" BorderStyle="None" ForeColor="black" ImageUrl='<%# Eval("albumsCoverPath1") %>'
                                                OnClick="eventsib2_Click"></asp:ImageButton>
                                            <br />
                                            <asp:Label ID="eventslbl2" runat="server" Text='<%# Bind("albumsPath1") %>'></asp:Label>
                                            &nbsp;&nbsp;&nbsp;
                                            <asp:CheckBox ID="eventschck2" runat="server"></asp:CheckBox>
                                            <br />
                                            views :
                                            <asp:Label ID="Label1" Style="margin: 5px;" runat="server" Text='<%#Eval("albumsPhotoViewsPath1") %>'></asp:Label>
                                            | likes :
                                            <asp:Label ID="Label2" Style="margin: 5px;" runat="server" Text='<%#Eval("albumsPhotoLikesPath1") %>'></asp:Label>
                                            <br />
                                        </ItemTemplate>
                                    </asp:DataList>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

                  <div aria-hidden="true" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" id="myModal1" class="modal fade">
		              <div class="modal-dialog">
		                  <div class="modal-content">
		                  
						<center>
						<div class="form-panel">
                        <h4 class="mb"><i class="fa fa-edit"></i> Album gallery cover image in app</h4>
                        
                        <div class="form-horizontal style-form">
                         <div class="form-group">
                            
                            <img src="images/customeralbums1.png" style="width:100%; height:auto;"/>

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
                        <h4 class="mb"><i class="fa fa-edit"></i> Create album gallery for APP</h4>
                        
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
    <script type="text/javascript">
        $(window).load(
    function () {
        $("#<%=uploadalbumcoverimg.ClientID%>").fileUpload({
            'uploader': 'scripts/uploader.swf',
            'cancelImg': 'images/cancel.png',
            'buttonText': 'Choose File..!!',
            'script': 'uploadalbumcoverimg.ashx',
            'folder': 'uploads',
            'fileDesc': 'Image Files',
            'fileExt': '*.jpg;*.jpeg;*.JPG;*.JPEG',
            'scriptData': { "coid": "<%=companyidlbl.Text%>", "customerid": "<%=customeridlbl.Text%>" },
            'multi': false,
            'auto': true

        });
    });
    </script>
    <script type="text/javascript">
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
            'scriptData': { "coid": "<%=companyidlbl.Text%>", "eventname": "<%=eventsddl.Text %>", "albumid": "<%=albumidlbl.Text %>", "customerid": "<%=customeridlbl.Text %>" },
            'multi': false,
            'auto': false

        });
    });
    </script>
    <script type="text/javascript">
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
            'scriptData': { "coid": "<%=companyidlbl.Text%>", "eventname": "<%=eventsddl.Text %>", "albumid": "<%=albumidlbl.Text %>", "customerid": "<%=customeridlbl.Text %>" },
            'multi': false,
            'auto': false

        });
    });
    </script>
    <script type="text/javascript">
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
            'scriptData': { "coid": "<%=companyidlbl.Text%>", "eventname": "<%=eventsddl.Text %>", "albumid": "<%=albumidlbl.Text %>", "customerid": "<%=customeridlbl.Text %>" },
            'multi': true,
            'auto': false

        });
    });
    </script>
</asp:Content>
