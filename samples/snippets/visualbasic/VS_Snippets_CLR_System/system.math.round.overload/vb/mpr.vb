'<snippet1>
' This example demonstrates the Math.Round() method in conjunction 
' with the MidpointRounding enumeration.
Class Sample
    Public Shared Sub Main() 
        Dim result As Decimal = 0D
        Dim posValue As Decimal = 3.45D
        Dim negValue As Decimal = -3.45D
        
        ' Round a positive value using different strategies.
        ' The precision of the result is 1 decimal place.
        result = Math.Round(posValue, 1, MidpointRounding.ToEven)
        Console.WriteLine("{0,4} = Math.Round({1,5}, 1, MidpointRounding.ToEven)", _
                           result, posValue)
        result = Math.Round(posValue, 1, MidpointRounding.AwayFromZero)
        Console.WriteLine("{0,4} = Math.Round({1,5}, 1, MidpointRounding.AwayFromZero)", _
                           result, posValue)
        result = Math.Round(posValue, 1, MidpointRounding.ToZero)
        Console.WriteLine("{0,4} = Math.Round({1,5}, 1, MidpointRounding.ToZero)", _
                           result, posValue)
        Console.WriteLine()
        
        ' Round a negative value using different strategies.
        ' The precision of the result is 1 decimal place.
        result = Math.Round(negValue, 1, MidpointRounding.ToEven)
        Console.WriteLine("{0,4} = Math.Round({1,5}, 1, MidpointRounding.ToEven)", _
                            result, negValue)
        result = Math.Round(negValue, 1, MidpointRounding.AwayFromZero)
        Console.WriteLine("{0,4} = Math.Round({1,5}, 1, MidpointRounding.AwayFromZero)", _
                           result, negValue)
        result = Math.Round(negValue, 1, MidpointRounding.ToZero)
        Console.WriteLine("{0,4} = Math.Round({1,5}, 1, MidpointRounding.ToZero)", _
                           result, negValue)
        Console.WriteLine()
    
    End Sub
End Class

'This code example produces the following results:
'
'        3.4 = Math.Round(3.45, 1, MidpointRounding.ToEven)
'        3.5 = Math.Round(3.45, 1, MidpointRounding.AwayFromZero)
'        3.4 = Math.Round(3.45, 1, MidpointRounding.ToZero)
'
'        -3.4 = Math.Round(-3.45, 1, MidpointRounding.ToEven)
'        -3.5 = Math.Round(-3.45, 1, MidpointRounding.AwayFromZero)
'        -3.4 = Math.Round(-3.45, 1, MidpointRounding.ToZero)
'
'</snippet1>
