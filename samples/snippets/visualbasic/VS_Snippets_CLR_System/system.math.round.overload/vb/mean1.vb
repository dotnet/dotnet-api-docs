' Visual Basic .NET Document
Option Strict On

Module Mean
    Public Sub Example()
        ' <Snippet2>
        Dim values() As Decimal = {1.15D, 1.25D, 1.35D, 1.45D, 1.55D, 1.65D}
        Dim sum As Decimal

        ' Calculate true mean.
        For Each value In values
            sum += value
        Next
        Console.WriteLine("True mean:     {0:N2}", sum / values.Length)

        ' Calculate mean with rounding away from zero.
        sum = 0
        For Each value In values
            sum += Math.Round(value, 1, MidpointRounding.AwayFromZero)
        Next
        Console.WriteLine("AwayFromZero:  {0:N2}", sum / values.Length)

        ' Calculate mean with rounding to nearest.
        sum = 0
        For Each value In values
            sum += Math.Round(value, 1, MidpointRounding.ToEven)
        Next
        Console.WriteLine("ToEven:        {0:N2}", sum / values.Length)

        ' The example displays the following output:
        '       True mean:     1.40
        '       AwayFromZero:  1.45
        '       ToEven:        1.40
        ' </Snippet2>
    End Sub
End Module
