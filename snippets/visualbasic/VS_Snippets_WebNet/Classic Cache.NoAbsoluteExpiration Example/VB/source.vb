﻿Option Explicit
Option Strict

Imports System.Web
Imports System.Web.UI



Public Class Page1
    Inherits Page
    
    Private Sub Page_Load(sender As Object, e As EventArgs)
        Dim connectionString As String = ""
        ' <Snippet1>
        Cache.Insert("DSN", connectionString, Nothing, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromSeconds(10))
        ' </Snippet1>
    End Sub
End Class
