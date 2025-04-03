Imports System
Imports System.Globalization

Module CompareOptionsExample
    Sub Main()
        ' Uppercase and lowercase characters are equivalent (according to the culture rules)
        ' when IgnoreCase is used.
        TestStringEquality("ONE two", "one TWO", "Case sensitivity", CompareOptions.IgnoreCase)

        ' Punctuation is ignored with the IgnoreSymbols option.
        TestStringEquality("hello world", "hello, world!", "Punctuation", CompareOptions.IgnoreSymbols)

        ' Whitespace and mathematical symbols are also ignored with IgnoreSymbols.
        TestStringEquality("3 + 5 = 8", "358", "Whitespace and mathematical symbols", CompareOptions.IgnoreSymbols)

        ' Caution: currency symbols and thousands separators are ignored with IgnoreSymbols.
        ' Parse strings containing numbers/currency and compare them numerically instead.
        TestStringEquality("Total $15,000", "Total: £150.00", "Currency symbols, decimals and thousands separators", CompareOptions.IgnoreSymbols)

        ' Full width characters are common in East Asian languages. Use the IgnoreWidth
        ' option to treat full- and half-width characters as equal.
        TestStringEquality("ａｂｃ，－", "abc,-", "Half width and full width characters", CompareOptions.IgnoreWidth)

        ' The same string in Hiragana and Katakana is equal when IgnoreKanaType is used.
        TestStringEquality("ありがとう", "アリガトウ", "Hiragana and Katakana strings", CompareOptions.IgnoreKanaType)

        ' When comparing with the IgnoreNonSpace option, characters like diacritical marks are ignored.
        TestStringEquality("café", "cafe", "Diacritical marks", CompareOptions.IgnoreNonSpace)

        ' Ligature characters and their non-ligature forms compare equal with the IgnoreNonSpace option.
        ' Note: prior to .NET 5, ligature characters were equal to their expanded forms by default.
        TestStringEquality("straße œuvre cæsar", "strasse oeuvre caesar", "Ligature characters", CompareOptions.IgnoreNonSpace)
    End Sub

    Private Sub TestStringEquality(str1 As String, str2 As String, description As String, options As CompareOptions)
        Console.WriteLine(Environment.NewLine & description & ":")
        ' First test with the default CompareOptions then with the provided options
        TestStringEqualityWithOptions(str1, str2, CompareOptions.None)
        TestStringEqualityWithOptions(str1, str2, options)
    End Sub

    Private Sub TestStringEqualityWithOptions(str1 As String, str2 As String, options As CompareOptions)
        Console.Write($"  When using CompareOptions.{options}, ""{str1}"" and ""{str2}"" are ")
        If String.Compare(str1, str2, CultureInfo.InvariantCulture, options) <> 0 Then
            Console.Write("not ")
        End If
        Console.WriteLine("equal.")
    End Sub
End Module

' In .NET 5 and later, the output is the following:
'
'Case sensitivity :
'  When using CompareOptions.None, "ONE two" and "one TWO" are not equal.
'  When using CompareOptions.IgnoreCase, "ONE two" and "one TWO" are equal.
'
'Punctuation:
'  When using CompareOptions.None, "hello world" and "hello, world!" are not equal.
'  When using CompareOptions.IgnoreSymbols, "hello world" and "hello, world!" are equal.
'
'Whitespace And mathematical symbols:
'  When using CompareOptions.None, "3 + 5 = 8" and "358" are not equal.
'  When using CompareOptions.IgnoreSymbols, "3 + 5 = 8" and "358" are equal.
'
'Currency symbols, decimals And thousands separators:
'  When using CompareOptions.None, "Total $15,000" and "Total: £150.00" are not equal.
'  When using CompareOptions.IgnoreSymbols, "Total $15,000" and "Total: £150.00" are equal.
'
'Half width And full width characters:
'  When using CompareOptions.None, "ａｂｃ，－" and "abc,-" are not equal.
'  When using CompareOptions.IgnoreWidth, "ａｂｃ，－" and "abc,-" are equal.
'
'Hiragana And Katakana strings:
'  When using CompareOptions.None, "ありがとう" and "アリガトウ" are not equal.
'  When using CompareOptions.IgnoreKanaType, "ありがとう" and "アリガトウ" are equal.
'
'Diacritical marks :
'  When using CompareOptions.None, "café" and "cafe" are not equal.
'  When using CompareOptions.IgnoreNonSpace, "café" and "cafe" are equal.
'
'Ligature characters :
'  When using CompareOptions.None, "straße œuvre cæsar" and "strasse oeuvre caesar" are not equal.
'  When using CompareOptions.IgnoreNonSpace, "straße œuvre cæsar" and "strasse oeuvre caesar" are equal.
'
' Note: when using .NET versions prior to .NET 5, ligature characters compare as equal to their
' non-ligature counterparts by default, so the last test will output as follows:
'
'Ligature characters :
'  When using CompareOptions.None, "straße œuvre cæsar" and "strasse oeuvre caesar" are equal.
'  When using CompareOptions.IgnoreNonSpace, "straße œuvre cæsar" and "strasse oeuvre caesar" are equal.
