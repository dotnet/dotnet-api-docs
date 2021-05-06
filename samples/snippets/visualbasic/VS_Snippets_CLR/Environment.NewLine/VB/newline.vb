'<snippet1>
' Sample for the Environment.NewLine property
Class Sample
   Public Shared Sub Main()
      Console.WriteLine()
      Console.WriteLine($"NewLine:{Environment.NewLine}  first line{Environment.NewLine}  second line")
   End Sub
End Class

'This example produces the following results:
'
'NewLine:
'  first line
'  second line
'
'</snippet1>
