﻿Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Collections.ObjectModel
Imports System.Collections.Specialized

Namespace ListBox_Index
	Partial Public Class Window1
		Inherits Window

		Public ReadOnly Property ScrollIntoViewItems As List(Of String)

		Public Sub New()
			Me.DataContext = Me
			ScrollIntoViewItems = New List(Of String)(Enumerable.Range(0, 20).[Select](Function(i) $"Item {i}"))
			InitializeComponent()
		End Sub

		'<SnippetListBoxSelectAll>
		Private Sub SelectAll(ByVal sender As Object, ByVal e As RoutedEventArgs)
			lb.SelectAll()
		End Sub
		'</SnippetListBoxSelectAll>


		'<SnippetListBoxUnselectAll>
		Private Sub UnselectAll(ByVal sender As Object, ByVal e As RoutedEventArgs)
			lb.UnselectAll()
		End Sub
		'</SnippetListBoxUnselectAll>

		'<SnippetListBoxSelectedItems>
		Private Sub SelectedItems(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If lb.SelectedItem IsNot Nothing Then
				label1.Content = "Has " & (lb.SelectedItems.Count.ToString()) & " item(s) selected."
			End If
		End Sub
		'</SnippetListBoxSelectedItems>

		'<SnippetListBoxItemsEventSelected>   
		Private Sub OnSelected(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim lbi As ListBoxItem = TryCast(e.Source, ListBoxItem)

			If lbi IsNot Nothing Then
				label1.Content = lbi.Content.ToString() & " is selected."
			End If
		End Sub
		'</SnippetListBoxItemsEventSelected>

		'<SnippetListBoxItemsEventUnselected>
		Private Sub OnUnselected(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim lbi As ListBoxItem = TryCast(e.Source, ListBoxItem)

			If lbi IsNot Nothing Then
				label1.Content = lbi.Content.ToString() & " is unselected."
			End If
		End Sub
		'</SnippetListBoxItemsEventUnselected>

		'<SnippetListBoxItemsIsSelected2>
		Private Sub SelectedItem(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If item1.IsSelected = True Then
				label2.Content = "IsSelected."
			End If
		End Sub
		'</SnippetListBoxItemsIsSelected2>

		'<SnippetListBoxScrollIntoView>
        Private Sub ScrollIntoView(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim index = cbScrollIntoView.SelectedIndex
            Dim item = lbScrollIntoView.Items.GetItemAt(index)
            lbScrollIntoView.ScrollIntoView(item)
        End Sub
        '</SnippetListBoxScrollIntoView>
	End Class
End Namespace