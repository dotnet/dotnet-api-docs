<%@ Page Language="C#" Debug="true"  %>
<%@ Register TagPrefix="MyControl" Namespace="RenderChildrenSample" Assembly = "Control_Sample" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
      <script language="C#" runat="server">
    </script>
      <form id="form1" method="POST" runat="server">
         <MyControl:ParentControl id="myControl" runat="server" />
      </form>
   </body>
</html>
