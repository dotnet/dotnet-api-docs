﻿' The following example uses BaseClear to remove all elements from a NameObjectCollectionBase.
' For an expanded version of this example, see the NameObjectCollectionBase class topic.

' <snippet1>
Imports System.Collections
Imports System.Collections.Specialized

Public Class MyCollection
   Inherits NameObjectCollectionBase

   Private _de As New DictionaryEntry()

   ' Gets a key-and-value pair (DictionaryEntry) using an index.
   Default Public ReadOnly Property Item(index As Integer) As DictionaryEntry
      Get
         _de.Key = Me.BaseGetKey(index)
         _de.Value = Me.BaseGet(index)
         Return _de
      End Get
   End Property

   ' Adds elements from an IDictionary into the new collection.
   Public Sub New(d As IDictionary)
      Dim de As DictionaryEntry
      For Each de In  d
         Me.BaseAdd(CType(de.Key, [String]), de.Value)
      Next de
   End Sub

   ' Clears all the elements in the collection.
   Public Sub Clear()
      Me.BaseClear()
   End Sub

End Class


Public Class SamplesNameObjectCollectionBase   

   Public Shared Sub Main()

      ' Creates and initializes a new MyCollection instance.
      Dim d = New ListDictionary()
      d.Add("red", "apple")
      d.Add("yellow", "banana")
      d.Add("green", "pear")
      Dim myCol As New MyCollection(d)
      Console.WriteLine("Initial state of the collection (Count = {0}):", myCol.Count)
      PrintKeysAndValues(myCol)

      ' Removes all elements from the collection.
      myCol.Clear()
      Console.WriteLine("After clearing the collection (Count = {0}):", myCol.Count)
      PrintKeysAndValues(myCol)

   End Sub

   Public Shared Sub PrintKeysAndValues(myCol As MyCollection)
      Dim i As Integer
      For i = 0 To myCol.Count - 1
         Console.WriteLine("[{0}] : {1}, {2}", i, myCol(i).Key, myCol(i).Value)
      Next i
   End Sub

End Class


'This code produces the following output.
'
'Initial state of the collection (Count = 3):
'[0] : red, apple
'[1] : yellow, banana
'[2] : green, pear
'After clearing the collection (Count = 0):

' </snippet1>
