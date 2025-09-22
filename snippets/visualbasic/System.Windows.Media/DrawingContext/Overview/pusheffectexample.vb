' <SnippetPushEffectExampleWholePage>
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Effects

Namespace SDKSample

	Public Class PushEffectExample
		Inherits Page

		Public Sub New()
			Dim shapeOutlinePen As New Pen(Brushes.Black, 2)
			shapeOutlinePen.Freeze()

			' Create a DrawingGroup
			Dim dGroup As New DrawingGroup()

			' Obtain a DrawingContext from
			' the DrawingGroup.
			Using dc As DrawingContext = dGroup.Open()
				' Draw a rectangle at full opacity.
				dc.DrawRectangle(Brushes.Blue, shapeOutlinePen, New Rect(0, 0, 25, 25))

				' Push an opacity change of 0.5.
				' The opacity of each subsequent drawing will
				' will be multiplied by 0.5.
				dc.PushOpacity(0.5)

				' This rectangle is drawn at 50% opacity.
				dc.DrawRectangle(Brushes.Blue, shapeOutlinePen, New Rect(25, 25, 25, 25))
			End Using

			' Display the drawing using an image control.
			Dim theImage As New Image()
			Dim dImageSource As New DrawingImage(dGroup)
			theImage.Source = dImageSource

			Me.Content = theImage

		End Sub

	End Class

End Namespace
' </SnippetPushEffectExampleWholePage>
