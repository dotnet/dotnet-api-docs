﻿' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization
Imports System.Threading

Module Example
   Dim rnd As New Random()
   
   Public Sub Main()
      If Thread.CurrentThread.CurrentCulture.Name <> "fr-FR" Then
         ' If current culture is not fr-FR, set culture to fr-FR.
         Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fr-FR")
         Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("fr-FR")
      Else
         ' Set culture to en-US.
         Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US")
         Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US")
      End If
      DisplayThreadInfo()
      DisplayValues()
          
       Dim worker As New Thread(AddressOf ThreadProc)
       worker.Name = "WorkerThread"
       worker.Start(Thread.CurrentThread.CurrentCulture)
   End Sub
   
   Private Sub DisplayThreadInfo()
      Console.WriteLine()
      Console.WriteLine("Current Thread Name: '{0}'", 
                        Thread.CurrentThread.Name)
      Console.WriteLine("Current Thread Culture/UI Culture: {0}/{1}", 
                        Thread.CurrentThread.CurrentCulture.Name,
                        Thread.CurrentThread.CurrentUICulture.Name)                        
   End Sub
   
   Private Sub DisplayValues()
      ' Create new thread and display three random numbers.
      Console.WriteLine("Some currency values:")
      For ctr As Integer = 0 To 3
         Console.WriteLine("   {0:C2}", rnd.NextDouble() * 10)                        
      Next
   End Sub
   
   Private Sub ThreadProc(obj As Object)
      Thread.CurrentThread.CurrentCulture = CType(obj, CultureInfo)
      Thread.CurrentThread.CurrentUICulture = CType(obj, CultureInfo)
      DisplayThreadInfo()
      DisplayValues()
   End Sub
End Module
' The example displays output similar to the following:
'       Current Thread Name: ''
'       Current Thread Culture/UI Culture: fr-FR/fr-FR
'       Some currency values:
'          6,83 €
'          3,47 €
'          6,07 €
'          1,70 €
'       
'       Current Thread Name: 'WorkerThread'
'       Current Thread Culture/UI Culture: fr-FR/fr-FR
'       Some currency values:
'          9,54 €
'          9,50 €
'          0,58 €
'          6,91 €
' </Snippet2>
