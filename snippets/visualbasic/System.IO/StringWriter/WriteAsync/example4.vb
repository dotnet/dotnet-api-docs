﻿' <Snippet4>
Imports System.IO
Imports System.Text

Module Module1

    Sub Main()
        WriteCharacters()
    End Sub

    Async Sub WriteCharacters()
        Dim stringToWrite As StringBuilder = New StringBuilder("Characters in StringBuilder")
        stringToWrite.AppendLine()

        Using writer As StringWriter = New StringWriter(stringToWrite)
            Await writer.WriteAsync("and add characters through StringWriter")
            Console.WriteLine(stringToWrite.ToString())
        End Using
    End Sub
End Module
' The example displays the following output:
'
' Characters in StringBuilder
' and add characters through StringWriter
'
' </Snippet4>
