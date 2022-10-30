' Visual Basic .NET Document
Option Strict On

Imports System.Threading
Imports System.Threading.Tasks

Module Example
    Public Async Sub Main()
        Await SnippetAwait()
        Await SnippetWaitAsync()
        Await SnippetAwaitMultiple()
    End Sub

    Public Async Function SnippetAwait() As Task
        ' <SnippetAwait>
        ' Wait on a single task with no timeout specified.
        Dim taskA = Task.Run(Sub() Thread.Sleep(2000))
        Console.WriteLine("taskA Status: {0}", taskA.Status)

        Await taskA
        Console.WriteLine("taskA Status: {0}", taskA.Status)

        ' This example displays output like the following:
        '     taskA Status: WaitingToRun
        '     taskA Status: RanToCompletion
        ' </SnippetAwait>

    End Function

    Public Async Function SnippetWaitAsync() As Task
        ' <SnippetWaitAsync>
        ' Wait on a single task with no timeout specified.
        Dim taskA = Task.Run(Sub() Thread.Sleep(2000))
        Console.WriteLine("taskA Status: {0}", taskA.Status)

        Try
            Await taskA.WaitAsync(TimeSpan.FromSeconds(1))
        Catch e As TimeoutException
            Console.WriteLine("taskA timed out after a second")
        End Try

        Console.WriteLine("taskA Status: {0}", taskA.Status)

        ' task Is still running
        Await taskA
        Console.WriteLine("taskA Status: {0}", taskA.Status)

        ' This example displays output like the following:
        '     taskA Status: WaitingToRun
        '     taskA timed out after a second
        '     taskA Status: Running
        '     taskA Status: RanToCompletion
        ' </SnippetWaitAsync>
    End Function

    Public Async Function SnippetAwaitMultiple() As Task
        ' <SnippetAwaitMultiple>
        ' Wait on multiple tasks
        Dim task0 = Task.Run(Sub() Thread.Sleep(2000))
        Dim task1 = Task.Run(Sub() Thread.Sleep(500))
        Dim task2 = Task.Run(Sub() Thread.Sleep(1000))

        Dim tasks() As Task = {task0, task1, task2}


        ' wait for the first task to complete
        Await Task.WhenAny(tasks)

        Console.WriteLine("First task completed. Status of all tasks:")
        For i = 0 To tasks.Length - 1
            Console.WriteLine("- Task {0}: {1}", i, tasks(i).Status)
        Next

        ' wait for all tasks to complete
        Await Task.WhenAll(tasks)

        Console.WriteLine("All tasks completed. Status of all tasks:")
        For i = 0 To tasks.Length - 1
            Console.WriteLine("- Task {0}: {1}", i, tasks(i).Status)
        Next

        ' This example displays output like the following:
        '     First task completed. Status of all tasks:
        '     - Task 0: Running
        '     - Task 1: RanToCompletion
        '     - Task 2: Running
        '     All tasks completed. Status of all tasks:
        '     - Task 0: RanToCompletion
        '     - Task 1: RanToCompletion
        '     - Task 2: RanToCompletion
        ' </SnippetAwaitMultiple>
    End Function
End Module
