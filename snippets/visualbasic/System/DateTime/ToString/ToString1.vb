' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Module DateToStringExample
    Public Sub Main()
        Dim currentCulture As CultureInfo = CultureInfo.CurrentCulture
        Dim exampleDate As Date = #05/01/2021 6:32:06PM#

        ' Change the current culture to en-US and display the date.
        CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US")
        Console.WriteLine(exampleDate.ToString())

        ' Change the current culture to fr-FR and display the date.
        CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("fr-FR")
        Console.WriteLine(exampleDate.ToString())

        ' Change the current culture to ja-JP and display the date.
        CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("ja-JP")
        Console.WriteLine(exampleDate.ToString())

        ' Restore the original culture
        CultureInfo.CurrentCulture = currentCulture
    End Sub
End Module

' The example displays the following output to the console:
'       5/1/2021 6:32:06 PM
'       01/05/2021 18:32:06
'       2021/05/01 18:32:06
' </Snippet1>
