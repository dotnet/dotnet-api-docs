﻿Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        ' <Snippet1>
        Dim MyObject As Object
        MyObject = Application("MyAppVar1")

        ' </Snippet1>
    End Sub
End Class
