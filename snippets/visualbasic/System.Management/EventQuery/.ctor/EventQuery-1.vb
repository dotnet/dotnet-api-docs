﻿'<Snippet1>
Imports System.Management

' This example shows synchronous consumption of events. 
' The client is blocked while waiting for events. 

Public Class EventWatcherPolling
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        ' Create event query to be notified within 1 second of 
        ' a change in a service
        Dim query As New EventQuery( _
            "SELECT * FROM" & _
            " __InstanceCreationEvent WITHIN 1 " & _
            "WHERE TargetInstance isa ""Win32_Process""")

        ' Initialize an event watcher and subscribe to events 
        ' that match this query
        Dim watcher As New ManagementEventWatcher(query)
        ' times watcher.WaitForNextEvent in 5 seconds
        watcher.Options.Timeout = New TimeSpan(0, 0, 50)

        ' Block until the next event occurs 
        ' Note: this can be done in a loop
        ' if waiting for more than one occurrence
        Console.WriteLine( _
          "Open an application (notepad.exe) to trigger an event.")
        Dim e As ManagementBaseObject = _
            watcher.WaitForNextEvent()

        'Display information from the event
        Console.WriteLine( _
            "Process {0} has created, path is: {1}", _
            CType(e("TargetInstance"), _
                ManagementBaseObject)("Name"), _
            CType(e("TargetInstance"), _
                ManagementBaseObject)("ExecutablePath"))

        'Cancel the subscription
        watcher.Stop()
        Return 0

    End Function 'Main
End Class
'</Snippet1>