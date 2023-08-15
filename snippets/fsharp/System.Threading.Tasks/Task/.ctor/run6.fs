module run6
// <Snippet3>
open System.Threading
open System.Threading.Tasks

printfn $"Application thread ID: {Thread.CurrentThread.ManagedThreadId}"
let t = Task.Run(fun () -> printfn $"Task thread ID: {Thread.CurrentThread.ManagedThreadId}")
t.Wait()

// The example displays the following output:
//       Application thread ID: 1
//       Task thread ID: 3
// </Snippet3>
