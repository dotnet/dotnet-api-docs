<!-- <snippet1> -->
<%@ page language="C#" %>
<%@ register TagPrefix="uc1" 
  TagName="DisplayModeMenuCS" 
  Src="DisplayModeMenuCS.ascx" %>
<%@ register tagprefix="aspSample" 
  Namespace="Samples.AspNet.CS.Controls" 
  Assembly="TextDisplayWebPartCS"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
  <form id="Form1" runat="server">
    <asp:webpartmanager id="WebPartManager1" runat="server" />
    <uc1:DisplayModeMenuCS ID="DisplayModeMenu1" runat="server" />
    <asp:webpartzone
      id="WebPartZone1"
      runat="server"
      title="Zone 1"
      PartChromeType="TitleAndBorder">
        <parttitlestyle font-bold="true" ForeColor="#3300cc" />
        <partstyle
          borderwidth="1px"   
          borderstyle="Solid"  
          bordercolor="#81AAF2" />
        <zonetemplate>
          <aspSample:TextDisplayWebPart 
            runat="server"   
            id="textwebpart" 
            title = "Text Content WebPart"
            AllowEdit="true" />
        </zonetemplate>
    </asp:webpartzone>
    <asp:EditorZone id="EditZone1" Runat="server">
      <ZoneTemplate>
        <asp:AppearanceEditorPart ID="editor1" Runat="server" />
      </ZoneTemplate>
    </asp:EditorZone>
  </form>
</body>
</html>
<!-- </snippet1> -->