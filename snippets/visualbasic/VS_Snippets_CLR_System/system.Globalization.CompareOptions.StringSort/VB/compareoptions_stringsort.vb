'// <snippet2>
Imports System
Imports System.Collections.Generic
Imports System.Globalization

Public Class StringSort
    Public Shared Sub Main()
        Dim wordList As New List(Of String) From {
            "cant", "bill's", "coop", "cannot", "billet", "can't", "con", "bills", "co-op"
        }

        Console.WriteLine("Before sorting:")
        For Each word In wordList
            Console.WriteLine(word)
        Next

        Console.WriteLine(Environment.NewLine & "After sorting with CompareOptions.None:")
        SortAndDisplay(wordList, CompareOptions.None)

        Console.WriteLine(Environment.NewLine & "After sorting with CompareOptions.StringSort:")
        SortAndDisplay(wordList, CompareOptions.StringSort)
    End Sub

    ' Sort the list of words with the supplied CompareOptions.
    Private Shared Sub SortAndDisplay(unsorted As List(Of String), options As CompareOptions)
        ' Create a copy of the original list to sort.
        Dim words As New List(Of String)(unsorted)

        ' Define the CompareInfo to use to compare strings.
        Dim comparer As CompareInfo = CultureInfo.InvariantCulture.CompareInfo

        ' Sort the copy with the supplied CompareOptions then display.
        words.Sort(Function(str1, str2) comparer.Compare(str1, str2, options))

        For Each word In words
            Console.WriteLine(word)
        Next
    End Sub
End Class

' CompareOptions.None and CompareOptions.StringSort provide identical ordering by default
' in .NET 5 And later, but in prior versions, the output will be the following:
'
'Before sorting
'cant
'bill's
'coop
'cannot
'billet
'can't
'con
'bills
'co-op

'After sorting with CompareOptions.None
'billet
'bills
'bill's
'cannot
'cant
'can't
'con
'coop
'co-op

'After sorting with CompareOptions.StringSort
'bill's
'billet
'bills
'can't
'cannot
'cant
'co-op
'con
'coop

'// </snippet2>
