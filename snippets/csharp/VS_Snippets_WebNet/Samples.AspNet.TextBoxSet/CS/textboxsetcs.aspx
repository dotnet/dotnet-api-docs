<!-- <snippet1> -->
<%@Page language="c#" %>
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.Controls.CS" 
    Assembly="Samples.AspNet.Controls.CS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>TextBoxSet Data-Bound Control  - C# Example</title>
  </head>

  <body>
    <form id="Form1" method="post" runat="server">

        <aspSample:textboxset
          id="TextBoxSet1"
          runat="server"
          datasourceid="AccessDataSource1" />

        <asp:accessdatasource
          id="AccessDataSource1"
          runat="server"
          datafile="Northwind.mdb"
          selectcommand="SELECT lastname FROM Employees" />
          
    </form>
  </body>
</html>
<!-- </snippet1> -->