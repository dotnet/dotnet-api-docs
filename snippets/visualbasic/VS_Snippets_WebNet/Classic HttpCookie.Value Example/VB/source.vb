﻿Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

 Protected MyCookie As HttpCookie

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
MyCookie.Value = "abc123"
    
' </Snippet1>
 End Sub
End Class
