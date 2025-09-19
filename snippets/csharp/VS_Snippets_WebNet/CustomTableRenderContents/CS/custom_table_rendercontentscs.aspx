<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS.Controls" Assembly="Samples.AspNet.CS" %>
<%@ Page Language="C#" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
        <title>Custom Table - RenderContents - C# Example</title>
    </head>
    <body>
        <form id="Form1" method="post" runat="server">
            <h3>Custom Table - RenderContents - C# Example</h3>
            
            <aspSample:CustomTableRenderContents 
              id="Table1" 
              runat="server" 
              GridLines="Both">
        <asp:TableRow>
          <asp:TableCell>Row 0, Col 0</asp:TableCell>
          <asp:TableCell>Row 0, Col 1</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
          <asp:TableCell>Row 1, Col 0</asp:TableCell>
          <asp:TableCell>Row 1, Col 1</asp:TableCell>
        </asp:TableRow>
      </aspSample:CustomTableRenderContents>
        
        </form>
    </body>
</html>
<!-- </Snippet1> -->
