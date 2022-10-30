' <snippetUsage>
Imports System.Threading
Imports System.Threading.Tasks

Module Example
	Public Async Sub Main()
		' Run asynchronous method and await its result
		Console.WriteLine("Running asynchronous method")
		Await DoSomethingAsync(1)
		Console.WriteLine("Finished waiting for asynchronous method")

		Console.WriteLine()

		' Run something in a separate thread pool thread
		Console.WriteLine("Starting thread pool thread from main thread {0}", Thread.CurrentThread.ManagedThreadId)
		Await Task.Run(Async Function()
						   Console.WriteLine("Running in thread pool thread {0}", Thread.CurrentThread.ManagedThreadId)
						   Await Task.Delay(1000)
					   End Function)
		Console.WriteLine("Thread pool thread completed")

		Console.WriteLine()

		' Run multiple tasks in parallel
		Console.WriteLine("Starting t2")
		Dim t2 As Task = DoSomethingAsync(2)
		Await Task.Delay(500)
		Console.WriteLine("Starting t3")
		Dim t3 As Task = DoSomethingAsync(3)

		Await Task.WhenAll(t2, t3)
		Console.WriteLine("t2 and t3 completed")

		Console.WriteLine()

		' Run blocking/synchronous work on a thread pool in order to keep the main thread unblocked
		Console.WriteLine("Starting blocking work on a different thread")
		Dim t4 As Task = Task.Run(Sub() DoSomethingBlocking())
		Console.WriteLine("Continue doing something else on the main thread")
		Await t4
		Console.WriteLine("Blocking work completed")
	End Sub

	Private Async Function DoSomethingAsync(ByVal number As Integer) As Task
		Console.WriteLine("DoSomethingAsync({0}) started", number)
		Await Task.Delay(2000)
		Console.WriteLine("DoSomethingAsync({0}) completed", number)
	End Function

	Private Sub DoSomethingBlocking()
		Console.WriteLine("DoSomethingBlocking started")
		Thread.Sleep(2000)
		Console.WriteLine("DoSomethingBlocking completed")
	End Sub
End Module
' This example displays output like the following:
'     Running asynchronous method
'     DoSomethingAsync(1) started
'     DoSomethingAsync(1) completed
'     Finished waiting for asynchronous method
'
'     Starting thread pool thread from main thread 17
'     Running in thread pool thread 17
'     Thread pool thread completed
'
'     Starting t2
'     DoSomethingAsync(2) started
'     Starting t3
'     DoSomethingAsync(3) started
'     DoSomethingAsync(2) completed
'     DoSomethingAsync(3) completed
'     t2 and t3 completed
'
'     Starting blocking work on a different thread
'     Continue doing something else on the main thread
'     DoSomethingBlocking started
'     DoSomethingBlocking completed
'     Blocking work completed
' </snippetUsage>
