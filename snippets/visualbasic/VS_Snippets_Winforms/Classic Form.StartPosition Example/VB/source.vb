﻿Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected form1 As Form1
    
    ' <Snippet1>
    Public Sub CreateMyForm()
        ' Create a new instance of the form.
        Dim form1 As New Form()
        ' Create two buttons to use as the accept and cancel buttons.
        Dim button1 As New Button()
        Dim button2 As New Button()
        
        ' Set the text of button1 to "OK".
        button1.Text = "OK"
        ' Set the position of the button on the form.
        button1.Location = New Point(10, 10)
        ' Set the text of button2 to "Cancel".
        button2.Text = "Cancel"
        ' Set the position of the button based on the location of button1.
        button2.Location = New Point(button1.Left, button1.Height + button1.Top + 10)
        ' Set the caption bar text of the form.   
        form1.Text = "My Dialog Box"
        ' Display a help button on the form.
        form1.HelpButton = True
        
        ' Define the border style of the form to a dialog box.
        form1.FormBorderStyle = FormBorderStyle.FixedDialog
        ' Set the accept button of the form to button1.
        form1.AcceptButton = button1
        ' Set the cancel button of the form to button2.
        form1.CancelButton = button2
        ' Set the start position of the form to the center of the screen.
        form1.StartPosition = FormStartPosition.CenterScreen
        
        ' Add button1 to the form.
        form1.Controls.Add(button1)
        ' Add button2 to the form.
        form1.Controls.Add(button2)
        
        ' Display the form as a modal dialog box.
        form1.ShowDialog()
    End Sub
    ' </Snippet1>
End Class

