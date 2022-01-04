
' This example demonstrates the Math.Round() method in conjunction 
' with the MidpointRounding enumeration.
Class MPR
    Public Shared Sub DecimalExample()
        '<snippet1>
        Dim result As Decimal = 0D
        Dim posValue As Decimal = 3.45D
        Dim negValue As Decimal = -3.45D

        ' Round a positive value using different strategies.
        ' The precision of the result is 1 decimal place.
        result = Math.Round(posValue, 1, MidpointRounding.ToEven)
        Console.WriteLine("{0,4} = Math.Round({1,5}, 1, MidpointRounding.ToEven)",
                           result, posValue)
        result = Math.Round(posValue, 1, MidpointRounding.AwayFromZero)
        Console.WriteLine("{0,4} = Math.Round({1,5}, 1, MidpointRounding.AwayFromZero)",
                           result, posValue)
        result = Math.Round(posValue, 1, MidpointRounding.ToZero)
        Console.WriteLine("{0,4} = Math.Round({1,5}, 1, MidpointRounding.ToZero)",
                           result, posValue)
        Console.WriteLine()

        ' Round a negative value using different strategies.
        ' The precision of the result is 1 decimal place.
        result = Math.Round(negValue, 1, MidpointRounding.ToEven)
        Console.WriteLine("{0,4} = Math.Round({1,5}, 1, MidpointRounding.ToEven)",
                            result, negValue)
        result = Math.Round(negValue, 1, MidpointRounding.AwayFromZero)
        Console.WriteLine("{0,4} = Math.Round({1,5}, 1, MidpointRounding.AwayFromZero)",
                           result, negValue)
        result = Math.Round(negValue, 1, MidpointRounding.ToZero)
        Console.WriteLine("{0,4} = Math.Round({1,5}, 1, MidpointRounding.ToZero)",
                           result, negValue)
        Console.WriteLine()

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
    End Sub

    Public Shared Sub DoubleExample()
        ' <snippet4>
        Dim posValue As Double = 3.45
        Dim negValue As Double = -3.45

        ' Round a positive and a negative value using the default.  
        Dim result As Double = Math.Round(posValue, 1)
        Console.WriteLine("{0,4} = Math.Round({1,5}, 1)", result, posValue)
        result = Math.Round(negValue, 1)
        Console.WriteLine("{0,4} = Math.Round({1,5}, 1)", result, negValue)
        Console.WriteLine()

        ' Round a positive value using a MidpointRounding value. 
        result = Math.Round(posValue, 1, MidpointRounding.ToEven)
        Console.WriteLine("{0,4} = Math.Round({1,5}, 1, MidpointRounding.ToEven)",
                           result, posValue)
        result = Math.Round(posValue, 1, MidpointRounding.AwayFromZero)
        Console.WriteLine("{0,4} = Math.Round({1,5}, 1, MidpointRounding.AwayFromZero)",
                           result, posValue)
        Console.WriteLine()

        ' Round a positive value using a MidpointRounding value. 
        result = Math.Round(negValue, 1, MidpointRounding.ToEven)
        Console.WriteLine("{0,4} = Math.Round({1,5}, 1, MidpointRounding.ToEven)",
                            result, negValue)
        result = Math.Round(negValue, 1, MidpointRounding.AwayFromZero)
        Console.WriteLine("{0,4} = Math.Round({1,5}, 1, MidpointRounding.AwayFromZero)",
                           result, negValue)
        Console.WriteLine()

        'This code example produces the following results:

        '  3.4 = Math.Round( 3.45, 1)
        ' -3.4 = Math.Round(-3.45, 1)

        ' 3.4 = Math.Round( 3.45, 1, MidpointRounding.ToEven)
        ' 3.5 = Math.Round( 3.45, 1, MidpointRounding.AwayFromZero)

        ' -3.4 = Math.Round(-3.45, 1, MidpointRounding.ToEven)
        ' -3.5 = Math.Round(-3.45, 1, MidpointRounding.AwayFromZero)

        ' </snippet4>
    End Sub
End Class
