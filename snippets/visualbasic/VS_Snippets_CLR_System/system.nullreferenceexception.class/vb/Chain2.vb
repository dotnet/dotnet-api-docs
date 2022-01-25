﻿' Visual Basic .NET Document
Option Strict On

' <Snippet7>
Module Example
   Public Sub Main()
      Dim pages As New Pages()
      Dim current As Page = pages.CurrentPage
      If current IsNot Nothing Then 
         Dim title As String = current.Title
         Console.WriteLine("Current title: '{0}'", title)
      Else
         Console.WriteLine("There is no page information in the cache.")
      End If   
   End Sub
End Module
' The example displays the following output:
'       There is no page information in the cache.
' </Snippet7>

Public Class Pages 
   Dim page(9) As Page
   Dim ctr As Integer = 0
   
   Public Property CurrentPage As Page
      Get
         Return page(ctr)
      End Get
      Set
         ' Move all the page objects down to accommodate the new one.
         If ctr > page.GetUpperBound(0) Then
            For ndx As Integer = 1 To page.GetUpperBound(0)
               page(ndx - 1) = page(ndx)
            Next
         End If    
         page(ctr) = value
         If ctr < page.GetUpperBound(0) Then ctr += 1 
      End Set
   End Property
   
   Public ReadOnly Property PreviousPage As Page
      Get
         If ctr = 0 Then 
            If page(0) Is Nothing Then
               Return Nothing
            Else
               Return page(0)
            End If   
         Else
            ctr -= 1
            Return page(ctr + 1)
         End If
      End Get
   End Property         
End Class

Public Class Page
   Public URL As Uri
   Public Title As String
End Class
