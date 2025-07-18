﻿' <Snippet1>
Imports System.Collections

Public Class SamplesBitArray    
    
    Public Shared Sub Main()
        
        ' Creates and initializes two BitArrays of the same size.
        Dim myBA1 As New BitArray(4)
        Dim myBA2 As New BitArray(4)
        myBA1(1) = False
        myBA1(0) = False
        myBA1(3) = True
        myBA1(2) = True
        myBA2(2) = False
        myBA2(0) = False
        myBA2(3) = True
        myBA2(1) = True
        
        ' Performs a bitwise AND operation between BitArray instances of the same size.
        Console.WriteLine("Initial values")
        Console.Write("myBA1:")
        PrintValues(myBA1, 8)
        Console.Write("myBA2:")
        PrintValues(myBA2, 8)
        Console.WriteLine()
        
        Console.WriteLine("Result")
        Console.Write("AND:")
        PrintValues(myBA1.And(myBA2), 8)
        Console.WriteLine()
        
        Console.WriteLine("After AND")
        Console.Write("myBA1:")
        PrintValues(myBA1, 8)
        Console.Write("myBA2:")
        PrintValues(myBA2, 8)
        Console.WriteLine()
        
        ' Performing AND between BitArray instances of different sizes returns an exception.
        Try
            Dim myBA3 As New BitArray(8)
            myBA3(0) = False
            myBA3(1) = False
            myBA3(2) = False
            myBA3(3) = False
            myBA3(4) = True
            myBA3(5) = True
            myBA3(6) = True
            myBA3(7) = True
            myBA1.And(myBA3)
        Catch myException As Exception
            Console.WriteLine("Exception: " + myException.ToString())
        End Try
    End Sub

    Public Shared Sub PrintValues(myList As IEnumerable, myWidth As Integer)
        Dim i As Integer = myWidth
        Dim obj As [Object]
        For Each obj In  myList
            If i <= 0 Then
                i = myWidth
                Console.WriteLine()
            End If
            i -= 1
            Console.Write("{0,8}", obj)
        Next obj
        Console.WriteLine()
    End Sub

End Class


' This code produces the following output.
' 
' Initial values
' myBA1:   False   False    True    True
' myBA2:   False    True   False    True
'
' Result
' AND:   False   False   False    True
'
' After AND
' myBA1:   False   False   False    True
' myBA2:   False    True   False    True
'
' Exception: System.ArgumentException: Array lengths must be the same.
'    at System.Collections.BitArray.And(BitArray value)
'    at SamplesBitArray.Main()

' </Snippet1>
