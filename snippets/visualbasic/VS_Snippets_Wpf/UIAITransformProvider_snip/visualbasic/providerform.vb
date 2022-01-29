﻿Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Windows.Automation

Namespace UIAITransformProvider_snip
	Partial Public Class ProviderForm
		Inherits Form
		Private customControl As CustomControl

		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread>
		Shared Sub Main()
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			Application.Run(New ProviderForm())
		End Sub

		Public Sub New()
			InitializeComponent()

			' Create an instance of the custom control.
			customControl = New CustomControl()
			customControl.Name = "CustomControl"

			' Add it to the form's controls. Among other things, this makes it possible for
			' UIAutomation to discover it, as it will become a child of the application window.
			Me.Controls.Add(customControl)

			' Set some properties.
			customControl.Location = New Point(50, 20)
			customControl.TabIndex = 0
		End Sub

		''' <summary>
		''' Handles Exit button clicks.
		''' </summary>
		''' <param name="sender">Object that raised the event.</param>
		''' <param name="e">Event arguments.</param>
		Private Sub Exit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles [Exit].Click
			Application.Exit()
		End Sub

		Private Sub btnResize_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnResize.Click
		End Sub
	End Class
End Namespace