﻿Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Dim str As String
 str = Request.Cookies("LastVisit").Value
    
' </Snippet1>
 End Sub
End Class
