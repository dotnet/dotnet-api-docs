﻿Imports System.Windows
Imports System.Data
Imports System.Xml
Imports System.Configuration

Namespace ThreeDSizeSample
	''' <summary>
	''' Interaction logic for app.xaml
	''' </summary>

	Partial Public Class app
		Inherits Application
		Private Sub AppStartingUp(ByVal sender As Object, ByVal e As StartupEventArgs)
			Dim mainWindow As New Window1()
			mainWindow.Show()

			' displays variables
			mainWindow.ShowVars()


		End Sub

	End Class
End Namespace