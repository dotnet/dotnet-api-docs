﻿' The following code example searches for an element in a ListDictionary.

' <snippet1>
Imports System.Collections
Imports System.Collections.Specialized

Public Class SamplesListDictionary   

   Public Shared Sub Main()

      ' Creates and initializes a new ListDictionary.
      Dim myCol As New ListDictionary()
      myCol.Add("Braeburn Apples", "1.49")
      myCol.Add("Fuji Apples", "1.29")
      myCol.Add("Gala Apples", "1.49")
      myCol.Add("Golden Delicious Apples", "1.29")
      myCol.Add("Granny Smith Apples", "0.89")
      myCol.Add("Red Delicious Apples", "0.99")

      ' Displays the values in the ListDictionary in three different ways.
      Console.WriteLine("Initial contents of the ListDictionary:")
      PrintKeysAndValues(myCol)

      ' Searches for a key.
      If myCol.Contains("Kiwis") Then
         Console.WriteLine("The collection contains the key ""Kiwis"".")
      Else
         Console.WriteLine("The collection does not contain the key ""Kiwis"".")
      End If
      Console.WriteLine()

   End Sub

   Public Shared Sub PrintKeysAndValues(myCol As IDictionary)

      Console.WriteLine("   KEY                       VALUE")
      Dim de As DictionaryEntry
      For Each de In  myCol
         Console.WriteLine("   {0,-25} {1}", de.Key, de.Value)
      Next de
      Console.WriteLine()

   End Sub

End Class


'This code produces the following output.
'
'Initial contents of the ListDictionary:
'   KEY                       VALUE
'   Braeburn Apples           1.49
'   Fuji Apples               1.29
'   Gala Apples               1.49
'   Golden Delicious Apples   1.29
'   Granny Smith Apples       0.89
'   Red Delicious Apples      0.99
'
'The collection does not contain the key "Kiwis".

' </snippet1>
