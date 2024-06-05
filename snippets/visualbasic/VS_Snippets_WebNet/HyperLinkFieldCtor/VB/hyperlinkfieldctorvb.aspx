<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
  
    ' Dynamically create field columns to display the desired
    ' fields from the data source. This only needs to be done
    ' the first time the page is loaded because the GridView
    ' control persists its column fields. 
    If Not IsPostBack Then
      
      ' Create a HyperLinkField object to display the company's 
      ' name. Bind the CompanyName and HomePage fields from the
      ' Northwind database to the caption and URL of the hyperlinks  
      ' in the HyperLinkField field column. Note that the URLs
      ' specified in the Northwind database might not be valid URLs.
      Dim companyNameBoundField As New HyperLinkField
      Dim dataNavigateUrlFields() As String = {"HomePage"}

      companyNameBoundField.DataTextField = "CompanyName"
      companyNameBoundField.DataNavigateUrlFields = dataNavigateUrlFields
      companyNameBoundField.HeaderText = "Company Name"
      companyNameBoundField.Target = "_blank"

      ' Create a BoundField object to display the company's city.
      Dim cityBoundField As New BoundField

      cityBoundField.DataField = "city"
      cityBoundField.HeaderText = "City"

      ' Add the field columns to the Columns collection of the
      ' GridView control.
      SuppliersGridView.Columns.Add(companyNameBoundField)
      SuppliersGridView.Columns.Add(cityBoundField)
      
    End If
    
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>HyperLinkField Constructor Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>HyperLinkField Constructor Example</h3>

      <asp:gridview id="SuppliersGridView" 
        datasourceid="SuppliersSqlDataSource" 
        autogeneratecolumns="False"
        runat="server">                
      </asp:gridview>
            
      <!-- This example uses Microsoft SQL Server and connects -->
      <!-- to the Northwind sample database.                   -->
      <asp:sqldatasource id="SuppliersSqlDataSource"  
        selectcommand="SELECT [SupplierID], [CompanyName], [City], [HomePage] FROM [Suppliers]"
        connectionstring="server=localhost;database=northwind;integrated security=SSPI"
        runat="server">
      </asp:sqldatasource>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->