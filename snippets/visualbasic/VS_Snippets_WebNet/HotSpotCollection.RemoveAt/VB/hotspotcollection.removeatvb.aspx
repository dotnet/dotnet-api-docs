<!--<Snippet1>-->
<%@ page language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    
    ' Programmatically create a CircleHotSpot object.
    Dim Circle1 As New CircleHotSpot
    Circle1.HotSpotMode = HotSpotMode.Navigate
    Circle1.NavigateUrl = "http://www.tailspintoys.com"
    Circle1.X = 145
    Circle1.Y = 120
    Circle1.Radius = 75
    Circle1.AlternateText = "Shop for toys"
           
    ' Programmatically create a second CircleHotSpot object.
    Dim Circle2 As New CircleHotSpot
    Circle2.HotSpotMode = HotSpotMode.Navigate
    Circle2.NavigateUrl = "http://www.cohowinery.com"
    Circle2.X = 145
    Circle2.Y = 290
    Circle2.Radius = 75
    Circle2.AlternateText = "Shop for wine"
    
    ' Add the HotSpot objects to the ImageMap's 
    ' HotSpotCollection.            
    Shop.HotSpots.Add(Circle1)
    Shop.HotSpots.Add(Circle2)
    
    ' Use the RemoveAt method to delete the HotSpot 
    ' object at the first index in HotSpotCollection.
    Shop.HotSpots.RemoveAt(0)
    
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
  <title>HotSpotCollection.RemoveAt Example</title>
</head>
  <body>
    <form id="Form1" runat="server">
    
      <h3>HotSpotCollection.RemoveAt Example</h3>
      
      <h4>Shopping Choices:</h4>
      
      <asp:imagemap id="Shop"           
        imageurl="Images/ShopChoice.jpg"
        alternatetext="Shopping choices" 
        runat="Server">
      </asp:imagemap>
      
    </form>      
  </body>
</html>
<!--</Snippet1>-->
