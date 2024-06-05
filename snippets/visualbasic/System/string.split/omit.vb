' This example demonstrates the String() methods that use
' the StringSplitOptions enumeration.
Class Sample
    '<snippet1>
    Public Shared Sub StringSplitOptionsExamples()
        ' This example demonstrates the String.Split() methods that use
        ' the StringSplitOptions enumeration.

        ' Example 1: Split a string delimited by characters
        Console.WriteLine("1) Split a string delimited by characters:" & vbCrLf)

        Dim s1 As String = ",ONE,, TWO,, , THREE,,"
        Dim charSeparators() As Char = {","c}
        Dim result() As String

        Console.WriteLine("The original string is: ""{0}"".", s1)
        Console.WriteLine("The delimiter character is: '{0}'." & vbCrLf, charSeparators(0))

        ' Split the string and return all elements
        Console.WriteLine("1a) Return all elements:")
        result = s1.Split(charSeparators, StringSplitOptions.None)
        Show(result)

        ' Split the string and return all elements with whitespace trimmed
        Console.WriteLine("1b) Return all elements with whitespace trimmed:")
        result = s1.Split(charSeparators, StringSplitOptions.TrimEntries)
        Show(result)

        ' Split the string and return all non-empty elements
        Console.WriteLine("1c) Return all non-empty elements:")
        result = s1.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries)
        Show(result)

        ' Split the string and return all non-whitespace elements with whitespace trimmed
        Console.WriteLine("1d) Return all non-whitespace elements with whitespace trimmed:")
        result = s1.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries Or StringSplitOptions.TrimEntries)
        Show(result)


        ' Split the string into only two elements, keeping the remainder in the last match
        Console.WriteLine("1e) Split into only two elements:")
        result = s1.Split(charSeparators, 2, StringSplitOptions.None)
        Show(result)

        ' Split the string into only two elements with whitespace trimmed, keeping the remainder in the last match
        Console.WriteLine("1f) Split into only two elements with whitespace trimmed:")
        result = s1.Split(charSeparators, 2, StringSplitOptions.TrimEntries)
        Show(result)

        ' Split the string into only two non-empty elements, keeping the remainder in the last match
        Console.WriteLine("1g) Split into only two non-empty elements:")
        result = s1.Split(charSeparators, 2, StringSplitOptions.RemoveEmptyEntries)
        Show(result)

        ' Split the string into only two non-whitespace elements with whitespace trimmed, keeping the remainder in the last match
        Console.WriteLine("1h) Split into only two non-whitespace elements with whitespace trimmed:")
        result = s1.Split(charSeparators, 2, StringSplitOptions.RemoveEmptyEntries Or StringSplitOptions.TrimEntries)
        Show(result)


        ' Example 2: Split a string delimited by another string
        Console.WriteLine("2) Split a string delimited by another string:" & vbCrLf)

        Dim s2 As String = "[stop]" +
                    "ONE[stop] [stop]" +
                    "TWO  [stop][stop]  [stop]" +
                    "THREE[stop][stop]  "
        Dim stringSeparators() As String = {"[stop]"}


        Console.WriteLine("The original string is: ""{0}"".", s2)
        Console.WriteLine("The delimiter string is: ""{0}""." & vbCrLf, stringSeparators(0))

        ' Split the string and return all elements
        Console.WriteLine("2a) Return all elements:")
        result = s2.Split(stringSeparators, StringSplitOptions.None)
        Show(result)

        ' Split the string and return all elements with whitespace trimmed
        Console.WriteLine("2b) Return all elements with whitespace trimmed:")
        result = s2.Split(stringSeparators, StringSplitOptions.TrimEntries)
        Show(result)

        ' Split the string and return all non-empty elements
        Console.WriteLine("2c) Return all non-empty elements:")
        result = s2.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries)
        Show(result)

        ' Split the string and return all non-whitespace elements with whitespace trimmed
        Console.WriteLine("2d) Return all non-whitespace elements with whitespace trimmed:")
        result = s2.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries Or StringSplitOptions.TrimEntries)
        Show(result)


        ' Split the string into only two elements, keeping the remainder in the last match
        Console.WriteLine("2e) Split into only two elements:")
        result = s2.Split(stringSeparators, 2, StringSplitOptions.None)
        Show(result)

        ' Split the string into only two elements with whitespace trimmed, keeping the remainder in the last match
        Console.WriteLine("2f) Split into only two elements with whitespace trimmed:")
        result = s2.Split(stringSeparators, 2, StringSplitOptions.TrimEntries)
        Show(result)

        ' Split the string into only two non-empty elements, keeping the remainder in the last match
        Console.WriteLine("2g) Split into only two non-empty elements:")
        result = s2.Split(stringSeparators, 2, StringSplitOptions.RemoveEmptyEntries)
        Show(result)

        ' Split the string into only two non-whitespace elements with whitespace trimmed, keeping the remainder in the last match
        Console.WriteLine("2h) Split into only two non-whitespace elements with whitespace trimmed:")
        result = s2.Split(stringSeparators, 2, StringSplitOptions.RemoveEmptyEntries Or StringSplitOptions.TrimEntries)
        Show(result)

    End Sub

    ' Display the array of separated strings.
    Public Shared Sub Show(ByVal entries() As String)
        Console.WriteLine("The return value contains these {0} elements:", entries.Length)
        Dim entry As String
        For Each entry In entries
            Console.Write("<{0}>", entry)
        Next entry
        Console.Write(vbCrLf & vbCrLf)

    End Sub

    'This example produces the following results:
    '
    ' 1) Split a string delimited by characters:
    '
    ' The original string is: ",ONE,, TWO,, , THREE,,".
    ' The delimiter character is: ','.
    '
    ' 1a) Return all elements:
    ' The return value contains these 9 elements:
    ' <><ONE><>< TWO><>< >< THREE><><>
    '
    ' 1b) Return all elements with whitespace trimmed:
    ' The return value contains these 9 elements:
    ' <><ONE><><TWO><><><THREE><><>
    '
    ' 1c) Return all non-empty elements:
    ' The return value contains these 4 elements:
    ' <ONE>< TWO>< >< THREE>
    '
    ' 1d) Return all non-whitespace elements with whitespace trimmed:
    ' The return value contains these 3 elements:
    ' <ONE><TWO><THREE>
    '
    ' 1e) Split into only two elements:
    ' The return value contains these 2 elements:
    ' <><ONE,, TWO,, , THREE,,>
    '
    ' 1f) Split into only two elements with whitespace trimmed:
    ' The return value contains these 2 elements:
    ' <><ONE,, TWO,, , THREE,,>
    '
    ' 1g) Split into only two non-empty elements:
    ' The return value contains these 2 elements:
    ' <ONE>< TWO,, , THREE,,>
    '
    ' 1h) Split into only two non-whitespace elements with whitespace trimmed:
    ' The return value contains these 2 elements:
    ' <ONE><TWO,, , THREE,,>
    '
    ' 2) Split a string delimited by another string:
    '
    ' The original string is: "[stop]ONE[stop] [stop]TWO  [stop][stop]  [stop]THREE[stop][stop]  ".
    ' The delimiter string is: "[stop]".
    '
    ' 2a) Return all elements:
    ' The return value contains these 9 elements:
    ' <><ONE>< ><TWO  ><><  ><THREE><><  >
    '
    ' 2b) Return all elements with whitespace trimmed:
    ' The return value contains these 9 elements:
    ' <><ONE><><TWO><><><THREE><><>
    '
    ' 2c) Return all non-empty elements:
    ' The return value contains these 6 elements:
    ' <ONE>< ><TWO  ><  ><THREE><  >
    '
    ' 2d) Return all non-whitespace elements with whitespace trimmed:
    ' The return value contains these 3 elements:
    ' <ONE><TWO><THREE>
    '
    ' 2e) Split into only two elements:
    ' The return value contains these 2 elements:
    ' <><ONE[stop] [stop]TWO  [stop][stop]  [stop]THREE[stop][stop]  >
    '
    ' 2f) Split into only two elements with whitespace trimmed:
    ' The return value contains these 2 elements:
    ' <><ONE[stop] [stop]TWO  [stop][stop]  [stop]THREE[stop][stop]>
    '
    ' 2g) Split into only two non-empty elements:
    ' The return value contains these 2 elements:
    ' <ONE>< [stop]TWO  [stop][stop]  [stop]THREE[stop][stop]  >
    '
    ' 2h) Split into only two non-whitespace elements with whitespace trimmed:
    ' The return value contains these 2 elements:
    ' <ONE><TWO  [stop][stop]  [stop]THREE[stop][stop]>
    '
    '</snippet1>
End Class
