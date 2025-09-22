﻿'<snippet1>
' Sample for String.Compare(String, Int32, String, Int32, Int32)
Class Sample
   Public Shared Sub Main()
      '                       0123456
      Dim str1 As [String] = "machine"
      Dim str2 As [String] = "device"
      Dim str As [String]
      Dim result As Integer
      
      Console.WriteLine()
      Console.WriteLine("str1 = '{0}', str2 = '{1}'", str1, str2)
      result = [String].Compare(str1, 2, str2, 0, 2)
      str = IIf(result < 0, "less than", IIf(result > 0, "greater than", "equal to"))
      Console.Write("Substring '{0}' in '{1}' is ", str1.Substring(2, 2), str1)
      Console.Write("{0} ", str)
      Console.WriteLine("substring '{0}' in '{1}'.", str2.Substring(0, 2), str2)
   End Sub
End Class
'
'This example produces the following results:
'
'str1 = 'machine', str2 = 'device'
'Substring 'ch' in 'machine' is less than substring 'de' in 'device'.
'
'</snippet1>