﻿' <Snippet1>
Option Explicit
Option Strict

Imports System.Web
Imports System.Web.UI

Namespace SimpleControlSamples
    Public Class InnerContent
        Inherits Control
        <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="Execution")> _
        Protected Overrides Sub Render(output As HtmlTextWriter)
            
            If HasControls() And TypeOf Controls(0) Is LiteralControl Then
                output.Write("<H2>Your message : ")
                Controls(0).RenderControl(output)
                output.Write("</H2>")
            End If
        End Sub
    End Class
End Namespace 'SimpleControlSamples
' </Snippet1>
