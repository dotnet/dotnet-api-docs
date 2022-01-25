﻿' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Module Example
   Public Sub Main()
      Dim number As Decimal = 1079.8d
      Console.WriteLine("Original value:    {0:N}", number)
      Console.WriteLine("Decremented value: {0:N}", Decimal.Subtract(number, 1))
   End Sub
End Module
' The example displays the following output:
'       Original value:    1,079.80
'       Decremented value: 1,078.80
' </Snippet6>
