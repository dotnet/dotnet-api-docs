﻿
' compile with: -r:system.dll -r:system.windows.forms.dll -r:system.drawing.dll
Imports System.Windows.Forms
Imports System.Drawing

Public Class [MyClass]
   Inherits Form
   
   <STAThread()> Public Shared Sub Main()
      Application.Run(New [MyClass]())
   End Sub
' <snippet1>   
   Public Sub New()
      Dim dateTimePicker1 As New DateTimePicker()
      Controls.AddRange(New Control() {dateTimePicker1})
      dateTimePicker1.CalendarMonthBackground = Color.Aqua
   End Sub 
' </snippet1>
End Class
