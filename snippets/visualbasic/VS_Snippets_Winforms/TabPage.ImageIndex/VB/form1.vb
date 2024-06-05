﻿' <snippet1>
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Resources

Public Class Form1
    Inherits Form

    Public Sub New()
        Dim components = New Container()
        Dim resources As New ResourceManager(GetType(Form1))
        Dim tabControl1 As New TabControl()
        Dim tabPage1 As New TabPage()
        Dim myImages As New ImageList(components)

        tabControl1.Controls.Add(tabPage1)

        ' Displays images from myImages on the tabs of tabControl1.
        tabControl1.ImageList = myImages

        ' Specifies which image to display (on the tab of tabPage1) by its index.
        tabPage1.ImageIndex = 0

        tabPage1.Text = "tabPage1"

        myImages.ImageStream = CType(resources.GetObject("myImages.ImageStream"), ImageListStreamer)
        myImages.ColorDepth = ColorDepth.Depth8Bit
        myImages.ImageSize = New Size(16, 16)
        myImages.TransparentColor = Color.Transparent

        Me.Controls.Add(tabControl1)
    End Sub

    Shared Sub Main()
        Application.Run(New Form1())
    End Sub
End Class
' </snippet1>
