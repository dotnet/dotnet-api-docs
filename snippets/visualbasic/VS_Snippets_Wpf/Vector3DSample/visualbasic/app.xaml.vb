﻿Imports System.Windows
Imports System.Data
Imports System.Xml
Imports System.Configuration

Namespace Vector3DSample
	''' <summary>
	''' Interaction logic for app.xaml
	''' </summary>

	Partial Public Class app
		Inherits Application
		Private Sub AppStartingUp(ByVal sender As Object, ByVal e As StartupEventArgs)
			Dim mainWindow As New Window1()
			mainWindow.Show()

			'''Displays the values of the variables that will be used
			mainWindow.ShowVars()

		End Sub

	End Class
End Namespace