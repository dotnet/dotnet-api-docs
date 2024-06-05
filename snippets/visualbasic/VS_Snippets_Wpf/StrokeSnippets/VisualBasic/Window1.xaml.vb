﻿
Imports System.IO
Imports System.Reflection
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes


'/ <summary>
'/ Interaction logic for Window1.xaml
'/ </summary>
Namespace StrokeSnippets_VB

    Class Window1
        Inherits Window

        Dim border1 As MyBorder

        Public Sub New()
            InitializeComponent()

            border1 = New MyBorder()
            'border1.Background = Brushes.Green
            root.Children.Add(border1)

        End Sub


        ' Remove touched stroke points
        Private Sub button1Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            border1.state = MyBorder.sMode.clip

        End Sub


        ' Remove touched strokes
        Private Sub button2Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            border1.state = MyBorder.sMode.remove

        End Sub


        ' Remove encircled strokes
        Private Sub button3Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            border1.state = MyBorder.sMode.surround

        End Sub


        ' Add strokes to collection
        Private Sub button4Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            border1.state = MyBorder.sMode.add
            border1.shadow = False

        End Sub


        ' Add shadowed strokes to collection
        Private Sub button5Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            border1.state = MyBorder.sMode.add
            border1.shadow = True

        End Sub


        Private Sub button6Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            border1.FitToCurve = Not border1.FitToCurve

            If border1.FitToCurve Then
                button6.Content = "FtC: on"
            Else
                button6.Content = "FtC: off"
            End If

        End Sub

        Private mode As DrawingMode = DrawingMode.Solid


        Private Sub ToggleDrawingMode_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            If mode = DrawingMode.Solid Then
                border1.ChangeDrawingMode(DrawingMode.StyulusPoints)
                mode = DrawingMode.StyulusPoints
            Else
                border1.ChangeDrawingMode(DrawingMode.Solid)
                mode = DrawingMode.Solid
            End If

        End Sub
    End Class
    '
    'ToDo: Error processing original source shown below
    '}
    '}
    '-^--- expression expected
End Namespace