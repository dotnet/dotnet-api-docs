﻿Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    Protected myCounter As Integer
    ' <Snippet1>
    Protected domainUpDown1 As DomainUpDown
    
    
    Private Sub InitializeMyDomainUpDown()
        ' Create and initialize the DomainUpDown control.
        domainUpDown1 = New DomainUpDown()
        
        ' Add the DomainUpDown control to the form.
        Controls.Add(domainUpDown1)
    End Sub
    
    
    Private Sub button1_Click(sender As Object, e As EventArgs)
        ' Add the text box contents and initial location in the collection
        ' to the DomainUpDown control.
        domainUpDown1.Items.Add((textBox1.Text.Trim() & " - " & myCounter))
        
        ' Increment the counter variable.
        myCounter = myCounter + 1
        
        ' Clear the TextBox.
        textBox1.Text = ""
    End Sub
    
    
    Private Sub checkBox1_Click(sender As Object, e As EventArgs)
        ' If Sorted is set to true, set it to false; 
        ' otherwise set it to true.
        If domainUpDown1.Sorted Then
            domainUpDown1.Sorted = False
        Else
            domainUpDown1.Sorted = True
        End If
    End Sub
    
    
    Private Sub domainUpDown1_SelectedItemChanged _
        (sender As Object, e As EventArgs)
        
        ' Display the SelectedIndex and 
        ' SelectedItem property values in a MessageBox.
        MessageBox.Show(("SelectedIndex: " & domainUpDown1.SelectedIndex.ToString() & _
            ControlChars.Cr & "SelectedItem: " & domainUpDown1.SelectedItem.ToString()))
    End Sub
    ' </Snippet1>
End Class


