<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void Data_Bound(Object sender, TreeNodeEventArgs e)
  {

    // Determine the depth of a node as it is bound to data.
    // If the depth is 1, expand the node.
    if(e.Node.Depth == 1)
    {

      // Expand the node using the ExpandAll method.
      e.Node.ExpandAll();

    }
    else
    {

      // Collapse the node using the CollapseAll method.
      e.Node.CollapseAll();

    }

  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TreeNode ExpandAll and CollapseAll Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>TreeNode ExpandAll and CollapseAll Example</h3>
      
      <h5>Expand the root node. Notice that the child nodes are already expanded.</h5>
    
      <asp:TreeView id="BookTreeView" 
         DataSourceID="BookXmlDataSource"
         OnTreeNodeDataBound="Data_Bound"
         runat="server">
         
        <DataBindings>
          <asp:TreeNodeBinding DataMember="Book" TextField="Title"/>
          <asp:TreeNodeBinding DataMember="Chapter" TextField="Heading"/>
          <asp:TreeNodeBinding DataMember="Section" TextField="Heading"/>
        </DataBindings>
         
      </asp:TreeView>
      
      <asp:XmlDataSource id="BookXmlDataSource"  
         DataFile="Book.xml"
         runat="server">
      </asp:XmlDataSource>
    
    </form>
  </body>
</html>

<!-- </Snippet1> -->
