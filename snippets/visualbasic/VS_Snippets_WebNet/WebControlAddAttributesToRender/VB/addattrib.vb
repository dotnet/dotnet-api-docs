﻿'<Snippet1>

Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace ControlTest
   
   ' Renders the following HTML: 
   ' <span onclick="alert('Hello');" style="color:Red;">Custom Contents</span>
   Public Class MyWebControl
      Inherits WebControl
      
      
      Public Sub New()
         MyBase.New(HtmlTextWriterTag.Span)
      End Sub
      
      <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
      Protected Overrides Sub AddAttributesToRender(writer As HtmlTextWriter)
         
         writer.AddAttribute(HtmlTextWriterAttribute.Onclick, "alert('Hello');")
         writer.AddStyleAttribute(HtmlTextWriterStyle.Color, "Red")
         MyBase.AddAttributesToRender(writer)

      End Sub

      <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
      Protected Overrides Sub RenderContents(writer As HtmlTextWriter)
         writer.Write("Custom Contents")
         MyBase.RenderContents(writer)
      End Sub

   End Class

End Namespace 'ControlTest

'</Snippet1>