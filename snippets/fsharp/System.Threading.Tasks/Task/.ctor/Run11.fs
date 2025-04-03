module Run11
// <Snippet11>
open System.Threading
open System.Threading.Tasks

let showThreadInfo s =
    printfn $"%s{s} thread ID: {Thread.CurrentThread.ManagedThreadId}"

showThreadInfo "Application"

let t = Task.Run(fun () -> showThreadInfo "Task")
t.Wait()

// The example displays the following output:
//       Application thread ID: 1
//       Task thread ID: 3
// </Snippet11>
