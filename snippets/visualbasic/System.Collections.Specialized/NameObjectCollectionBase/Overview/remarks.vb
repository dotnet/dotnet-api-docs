﻿
Imports System.Collections
Imports System.Collections.Specialized

Public Class DerivedCollection
   Inherits NameObjectCollectionBase

   ' Creates an empty collection.
   Public Sub New()
   End Sub

   ' Adds elements from an IDictionary into the new collection.
   Public Sub New(d As IDictionary, bReadOnly As Boolean)
      Dim de As DictionaryEntry
      For Each de In  d
         Me.BaseAdd(CType(de.Key, String), de.Value)
      Next de
      Me.IsReadOnly = bReadOnly
   End Sub

   ' Gets a key-and-value pair (DictionaryEntry) using an index.
   Default Public ReadOnly Property Item(index As Integer) As DictionaryEntry
      Get
            return new DictionaryEntry( _
                me.BaseGetKey(index), me.BaseGet(index) )
      End Get
   End Property

   ' Gets or sets the value associated with the specified key.
   Default Public Property Item(key As String) As Object
      Get
         Return Me.BaseGet(key)
      End Get
      Set
         Me.BaseSet(key, value)
      End Set
   End Property

   ' Gets a String array that contains all the keys in the collection.
   Public ReadOnly Property AllKeys() As String()
      Get
         Return Me.BaseGetAllKeys()
      End Get
   End Property

   ' Gets an Object array that contains all the values in the collection.
   Public ReadOnly Property AllValues() As Array
      Get
         Return Me.BaseGetAllValues()
      End Get
   End Property

   ' Gets a String array that contains all the values in the collection.
   Public ReadOnly Property AllStringValues() As String()
      Get
         Return CType(Me.BaseGetAllValues(GetType(String)), String())
      End Get
   End Property

   ' Gets a value indicating if the collection contains keys that are not null.
   Public ReadOnly Property HasKeys() As Boolean
      Get
         Return Me.BaseHasKeys()
      End Get
   End Property

   ' Adds an entry to the collection.
   Public Sub Add(key As String, value As Object)
      Me.BaseAdd(key, value)
   End Sub

   ' Removes an entry with the specified key from the collection.
   Overloads Public Sub Remove(key As String)
      Me.BaseRemove(key)
   End Sub

   ' Removes an entry in the specified index from the collection.
   Overloads Public Sub Remove(index As Integer)
      Me.BaseRemoveAt(index)
   End Sub

   ' Clears all the elements in the collection.
   Public Sub Clear()
      Me.BaseClear()
   End Sub

End Class


Public Class SamplesNameObjectCollectionBase
    Public Shared Sub Main()
        ' <Snippet2>
        ' Create a collection derived from NameObjectCollectionBase
        Dim myCollection As ICollection = New DerivedCollection()
        SyncLock myCollection.SyncRoot
            For Each item As Object In myCollection
                ' Insert your code here.
            Next item
        End SyncLock
        ' </Snippet2>
    End Sub
End Class

