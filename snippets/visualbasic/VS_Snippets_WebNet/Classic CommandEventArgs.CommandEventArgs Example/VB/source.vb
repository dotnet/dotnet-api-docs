﻿Option Explicit
Option Strict

Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
    ' <Snippet1>
    Private Sub Command_Button_Click(sender As Object, e As CommandEventArgs)
        Dim args As New CommandEventArgs(e)
    End Sub
    ' </Snippet1>
End Class
