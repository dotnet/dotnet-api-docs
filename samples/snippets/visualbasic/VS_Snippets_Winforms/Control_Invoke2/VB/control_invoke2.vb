﻿' System.Windows.Forms.Control.Invoke(Delegate);
' <Snippet1>
' The following example demonstrates the 'Invoke(Delegate)' method of 'Control class.
' A 'ListBox' and a 'Button' control are added to a form, containing a delegate
' which encapsulates a method that adds items to the listbox. This function is executed
' on the thread that owns the underlying handle of the form. When user clicks on button
' the above delegate is executed using 'Invoke' method.

Imports System.Drawing
Imports System.Windows.Forms
Imports System.Threading

Public Class MyFormControl
   Inherits Form

   Delegate Sub AddListItem()
   Public myDelegate As AddListItem
   Private myButton As Button
   Private myThread As Thread
   Private myListBox As ListBox

   Public Sub New()
      myButton = New Button()
      myListBox = New ListBox()
      myButton.Location = New Point(72, 160)
      myButton.Size = New Size(152, 32)
      myButton.TabIndex = 1
      myButton.Text = "Add items in list box"
      AddHandler myButton.Click, AddressOf Button_Click
      myListBox.Location = New Point(48, 32)
      myListBox.Name = "myListBox"
      myListBox.Size = New Size(200, 95)
      myListBox.TabIndex = 2
      ClientSize = New Size(292, 273)
      Controls.AddRange(New Control() {myListBox, myButton})
      Text = " 'Control_Invoke' example"
      myDelegate = New AddListItem(AddressOf AddListItemMethod)
   End Sub

   Shared Sub Main()
      Dim myForm As New MyFormControl()
      myForm.ShowDialog()
   End Sub

   Public Sub AddListItemMethod()
      Dim myItem As String
      Dim i As Integer
      For i = 1 To 5
         myItem = "MyListItem" + i.ToString()
         myListBox.Items.Add(myItem)
         myListBox.Update()
         Thread.Sleep(300)
      Next i
   End Sub

   Private Sub Button_Click(sender As Object, e As EventArgs)
      myThread = New Thread(New ThreadStart(AddressOf ThreadFunction))
      myThread.Start()
   End Sub

   Private Sub ThreadFunction()
      Dim myThreadClassObject As New MyThreadClass(Me)
      myThreadClassObject.Run()
   End Sub
End Class


' The following code assumes a 'ListBox' and a 'Button' control are added to a form, 
' containing a delegate which encapsulates a method that adds items to the listbox.
Public Class MyThreadClass
   Private myFormControl1 As MyFormControl

   Public Sub New(myForm As MyFormControl)
      myFormControl1 = myForm
   End Sub

   Public Sub Run()
      ' Execute the specified delegate on the thread that owns
      ' 'myFormControl1' control's underlying window handle.
      myFormControl1.Invoke(myFormControl1.myDelegate)
   End Sub

End Class
' </Snippet1>