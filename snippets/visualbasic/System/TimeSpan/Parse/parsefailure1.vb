' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      ' <Snippet3>
      Dim values() As String = { "000000006", "12.12:12:12.12345678" }
      For Each value As String In values
         Try
            Dim interval As TimeSpan = TimeSpan.Parse(value)
            Console.WriteLine("{0} --> {1}", value, interval)
         Catch e As FormatException
            Console.WriteLine("{0}: Bad Format", value)
         Catch e As OverflowException
            Console.WriteLine("{0}: Overflow", value)
         End Try
      Next
      ' Output:
      '       000000006: Overflow
      '       12.12:12:12.12345678: Overflow
      ' </Snippet3>
   End Sub
End Module

