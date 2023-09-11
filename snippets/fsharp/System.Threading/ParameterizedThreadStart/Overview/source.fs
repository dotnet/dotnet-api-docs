// <Snippet1>
open System.Threading

type Work() =
    static member DoWork(data: obj) =
        printfn $"Static thread procedure. Data='{data}'"

    member _.DoMoreWork(data: obj) =
        printfn $"Instance thread procedure. Data='{data}'"

// Start a thread that calls a parameterized static method.
let newThread = Thread(ParameterizedThreadStart Work.DoWork)
newThread.Start 42

// Start a thread that calls a parameterized instance method.
let w = Work()
let newThread2 = Thread(ParameterizedThreadStart w.DoMoreWork)
newThread.Start "The answer."

// This example displays output like the following:
//       Static thread procedure. Data='42'
//       Instance thread procedure. Data='The answer.'
// </Snippet1>
