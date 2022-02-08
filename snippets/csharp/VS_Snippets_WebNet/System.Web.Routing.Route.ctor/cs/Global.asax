﻿<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    // <Snippet1>
    void Application_Start(object sender, EventArgs e) 
    {
        RegisterRoutes(RouteTable.Routes);
    }

    public static void RegisterRoutes(RouteCollection routes)
    {
        Route reportRoute = new Route("{locale}/{year}", new ReportRouteHandler());
        reportRoute.Defaults = new RouteValueDictionary { { "locale", "en-US" }, { "year", DateTime.Now.Year.ToString() } };
        reportRoute.Constraints = new RouteValueDictionary { { "locale", "[a-z]{2}-[a-z]{2}" }, { "year", @"\d{4}" } };
        reportRoute.DataTokens = new RouteValueDictionary { { "format", "short" } };
        routes.Add(reportRoute);
    }
    // </Snippet1>
    
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
