'<snippet1>
' Sample for the Environment.MachineName property
Class Sample
   Public Shared Sub Main()
      Console.WriteLine()
      '  <-- Keep this information secure! -->
      Console.WriteLine("MachineName: {0}", Environment.MachineName)
   End Sub
End Class
'
'This example produces the following results:
'
'MachineName: MyDesktop
'
'</snippet1>