﻿Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    ' <Snippet2>
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomLinkButtonRenderContents
        Inherits System.Web.UI.WebControls.LinkButton

        Protected Overrides Sub RenderContents(ByVal writer As System.Web.UI.HtmlTextWriter)

            ' Call the base RenderContents method.
            MyBase.RenderContents(writer)

            ' Append some text to the LinkButton.
            writer.Write(" Home Page")
        End Sub
    End Class
    ' </Snippet2>
End Namespace