﻿' <snippet1>
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Private tabControl1 As TabControl
    Private tabPage1 As TabPage

    Public Sub New()
        Me.tabControl1 = New TabControl()
        Me.tabPage1 = New TabPage()

        ' Gets the controls collection for tabControl1.
        ' Adds the tabPage1 to this collection.
        Me.tabControl1.TabPages.Add(tabPage1)

        Me.tabControl1.Location = New Point(25, 25)
        Me.tabControl1.Size = New Size(250, 250)

        Me.ClientSize = New Size(300, 300)
        Me.Controls.Add(tabControl1)
    End Sub

    Shared Sub Main()
        Application.Run(New Form1())
    End Sub
End Class
' </snippet1>