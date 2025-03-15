' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System
Imports System.Threading

Module Program

    <ThreadStatic>
    Private _requestId As String

    Sub Main()
        Dim thread1 As New Thread(AddressOf ProcessRequest)
        Dim thread2 As New Thread(AddressOf ProcessRequest)

        thread1.Start("REQ-001")
        thread2.Start("REQ-002")

        thread1.Join()
        thread2.Join()

        Console.WriteLine("Main thread execution completed.")
    End Sub

    Sub ProcessRequest(ByVal requestId As Object)
        ' Assign the request ID to the thread-static field
        _requestId = requestId.ToString()

        ' Simulate request processing across multiple method calls
        PerformDatabaseOperation()
        PerformLogging()
    End Sub

    Sub PerformDatabaseOperation()
        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}: Processing DB operation for request {_requestId}")
    End Sub

    Sub PerformLogging()
        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}: Logging request {_requestId}")
    End Sub

End Module
' </Snippet1>
