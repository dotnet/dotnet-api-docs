
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  private void Page_Load(object sender, EventArgs e)
  {
    // <snippet1>
    Request.SaveAs("c:\\temp\\HttpRequest.txt", true);
    // </snippet1>
  }

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>ASP.NET Example</title>
</head>
<body>

</body>
</html>
