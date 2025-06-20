' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Globalization

Module Example4
    Public Sub Main4()
        Dim cultures() As CultureInfo = {CultureInfo.InvariantCulture,
                                       New CultureInfo("en-us"),
                                       New CultureInfo("fr-fr"),
                                       New CultureInfo("de-DE"),
                                       New CultureInfo("es-ES"),
                                       New CultureInfo("ja-JP")}

        Dim thisDate As Date = #5/1/2009 9:00AM#

        For Each culture As CultureInfo In cultures
            Dim cultureName As String
            If String.IsNullOrEmpty(culture.Name) Then
                cultureName = culture.NativeName
            Else
                cultureName = culture.Name
            End If

            Console.WriteLine("In {0}, {1}",
                           cultureName, thisDate.ToString(culture))
        Next
    End Sub
End Module
' The example produces the following output:
'    In Invariant Language (Invariant Country), 05/01/2009 09:00:00
'    In en-US, 5/1/2009 9:00:00 AM
'    In fr-FR, 01/05/2009 09:00:00
'    In de-DE, 01.05.2009 09:00:00
'    In es-ES, 01/05/2009 9:00:00
'    In ja-JP, 2009/05/01 9:00:00
' </Snippet3>
