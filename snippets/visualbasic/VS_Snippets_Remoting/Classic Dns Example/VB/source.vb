﻿Imports System.Data
Imports System.Net
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    
    Protected Sub Method()
        ' <Snippet1>
        Dim hostInfo As IPHostEntry = Dns.GetHostEntry("www.contoso.com")
        ' </Snippet1>
    End Sub
End Class
