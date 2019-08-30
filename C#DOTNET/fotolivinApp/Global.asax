<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        RegisterRoutes(RouteTable.Routes);
    }
    static void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("extra", "extra", "~/extra.aspx");
        routes.MapPageRoute("app-admin", "app-admin", "~/app-admin.aspx");
        routes.MapPageRoute("app-company", "app-company", "~/app-company.aspx");
        routes.MapPageRoute("app-employee", "app-employee", "~/app-employee.aspx");
        routes.MapPageRoute("errorpage", "errorpage", "~/errorpage.aspx");
        routes.MapPageRoute("Default", "Default", "~/Default.aspx");
        routes.MapPageRoute("register", "register", "~/register.aspx");
        routes.MapPageRoute("dashboard", "dashboard", "~/dashboard.aspx");
        routes.MapPageRoute("login", "login", "~/login.aspx");
        routes.MapPageRoute("company-profile", "company-profile", "~/company-profile.aspx");
        routes.MapPageRoute("confirm-email", "confirm-email", "~/confirm-email.aspx");
        routes.MapPageRoute("about-us", "about-us", "~/about-us.aspx");
        routes.MapPageRoute("notification", "notification", "~/notification.aspx");
        routes.MapPageRoute("contact-us", "contact-us", "~/contact-us.aspx");
        routes.MapPageRoute("create-account", "create-account", "~/create-account.aspx");
        routes.MapPageRoute("customer-profile", "customer-profile", "~/customer-profile.aspx");
        routes.MapPageRoute("customer-photos", "customer-photos", "~/customer-photos.aspx");
        routes.MapPageRoute("gallery-photos", "gallery-photos", "~/gallery-photos.aspx");
        routes.MapPageRoute("customer-videos", "customer-videos", "~/customer-videos.aspx");
        routes.MapPageRoute("customer-albums", "customer-albums", "~/customer-albums.aspx");
        routes.MapPageRoute("gallery-albums", "gallery-albums", "~/gallery-albums.aspx");
        routes.MapPageRoute("explore", "explore", "~/explore.aspx");
        routes.MapPageRoute("order-history", "order-history", "~/order-history.aspx");
        routes.MapPageRoute("products", "products", "~/products.aspx");
        routes.MapPageRoute("privacy-policy", "privacy-policy", "~/privacy-policy.aspx");
        routes.MapPageRoute("faqs", "faqs", "~/faqs.aspx");
        routes.MapPageRoute("registered-users", "registered-users", "~/registered-users.aspx");
        routes.MapPageRoute("registered-customers", "registered-customers", "~/registered-customers.aspx");
        routes.MapPageRoute("sms", "sms", "~/sms.aspx");
        routes.MapPageRoute("service", "service", "~/service.aspx");
        routes.MapPageRoute("offer", "offer", "~/offer.aspx");
        
        routes.MapPageRoute("admin/admin-album-details", "admin/admin-album-details", "~/admin/admin-album-details.aspx");
        routes.MapPageRoute("admin/admin-create-admin", "admin/admin-create-admin", "~/admin/admin-create-admin.aspx");
        routes.MapPageRoute("admin/admin-create-account", "admin/admin-create-account", "~/admin/admin-create-account.aspx");
        routes.MapPageRoute("admin/admin-create-user", "admin/admin-create-user", "~/admin/admin-create-user.aspx");
        routes.MapPageRoute("admin/admin-customer-details", "admin/admin-customer-details", "~/admin/admin-customer-details.aspx");
        routes.MapPageRoute("admin/admin-dashboard", "admin/admin-dashboard", "~/admin/admin-dashboard.aspx");
        routes.MapPageRoute("admin/admin-explore-details", "admin/admin-explore-details", "~/admin/admin-explore-details.aspx");
        routes.MapPageRoute("admin/admin-login", "admin/admin-login", "~/admin/admin-login.aspx");
        routes.MapPageRoute("admin/admin-photo-details", "admin/admin-photo-details", "~/admin/admin-photo-details.aspx");
        routes.MapPageRoute("admin/admin-register", "admin/admin-register", "~/admin/admin-register.aspx");
        
        routes.MapPageRoute("admin/admin-registered-customers", "admin/admin-registered-customers", "~/admin/admin-registered-customers.aspx");
        routes.MapPageRoute("admin/admin-registered-users", "admin/admin-registered-users", "~/admin/admin-registered-users.aspx");
        routes.MapPageRoute("admin/admin-sms-details", "admin/admin-sms-details", "~/admin/admin-sms-details.aspx");
        routes.MapPageRoute("admin/admin-video-details", "admin/admin-video-details", "~/admin/admin-video-details.aspx");
        routes.MapPageRoute("admin/admin-products", "admin/admin-products", "~/admin/admin-products.aspx");
        routes.MapPageRoute("admin/admin-order-history", "admin/admin-order-history", "~/admin/admin-order-history.aspx");
        routes.MapPageRoute("admin/admin-notification", "admin/admin-notification", "~/admin/admin-notification.aspx");

        
        routes.MapPageRoute("companyaccess/company-login", "companyaccess/company-login", "~/companyaccess/company-login.aspx");
        routes.MapPageRoute("companyaccess/company-dashboard", "companyaccess/company-dashboard", "~/companyaccess/company-dashboard.aspx");
        routes.MapPageRoute("companyaccess/company-about-us", "companyaccess/company-about-us", "~/companyaccess/company-about-us.aspx");
        routes.MapPageRoute("companyaccess/company-notification", "companyaccess/company-notification", "~/companyaccess/company-notification.aspx");
        routes.MapPageRoute("companyaccess/company-contact-us", "companyaccess/company-contact-us", "~/companyaccess/company-contact-us.aspx");
        routes.MapPageRoute("companyaccess/company-company-profile", "companyaccess/company-company-profile", "~/companyaccess/company-company-profile.aspx");
        routes.MapPageRoute("companyaccess/company-customer-profile", "companyaccess/company-customer-profile", "~/companyaccess/company-customer-profile.aspx");
        routes.MapPageRoute("companyaccess/company-customer-photos", "companyaccess/company-customer-photos", "~/companyaccess/company-customer-photos.aspx");
        routes.MapPageRoute("companyaccess/company-gallery-photos", "companyaccess/company-gallery-photos", "~/companyaccess/company-gallery-photos.aspx");
        routes.MapPageRoute("companyaccess/company-customer-videos", "companyaccess/company-customer-videos", "~/companyaccess/company-customer-videos.aspx");
        routes.MapPageRoute("companyaccess/company-customer-albums", "companyaccess/company-customer-albums", "~/companyaccess/company-customer-albums.aspx");
        routes.MapPageRoute("companyaccess/company-gallery-albums", "companyaccess/company-gallery-albums", "~/companyaccess/company-gallery-albums.aspx");
        routes.MapPageRoute("companyaccess/company-explore", "companyaccess/company-explore", "~/companyaccess/company-explore.aspx");
        routes.MapPageRoute("companyaccess/company-order-history", "companyaccess/company-order-history", "~/companyaccess/company-order-history.aspx");
        routes.MapPageRoute("companyaccess/company-products", "companyaccess/company-products", "~/companyaccess/company-products.aspx");
        routes.MapPageRoute("companyaccess/company-privacy-policy", "companyaccess/company-privacy-policy", "~/companyaccess/company-privacy-policy.aspx");
        routes.MapPageRoute("companyaccess/company-faqs", "companyaccess/company-faqs", "~/companyaccess/company-faqs.aspx");
        routes.MapPageRoute("companyaccess/company-registered-users", "companyaccess/company-registered-users", "~/companyaccess/company-registered-users.aspx");
        routes.MapPageRoute("companyaccess/company-registered-customers", "companyaccess/company-registered-customers", "~/companyaccess/company-registered-customers.aspx");
        routes.MapPageRoute("companyaccess/company-sms", "companyaccess/company-sms", "~/companyaccess/company-sms.aspx");
        routes.MapPageRoute("companyaccess/company-confirm-email", "companyaccess/company-confirm-email", "~/companyaccess/company-confirm-email.aspx");
        routes.MapPageRoute("companyaccess/company-service", "companyaccess/company-service", "~/companyaccess/company-service.aspx");
        routes.MapPageRoute("companyaccess/company-offer", "companyaccess/company-offer", "~/companyaccess/company-offer.aspx");
      

    }
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
   
       
</script>
