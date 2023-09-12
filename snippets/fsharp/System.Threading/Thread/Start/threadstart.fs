//<Snippet1>
open System.Threading

module ThreadWork = 
    let doWork () =
        for _ = 0 to 2 do 
            printfn "Working thread..."
            Thread.Sleep 100

let thread1 = Thread ThreadWork.doWork
thread1.Start()
for _ = 0 to 2 do 
    printfn "In main."
    Thread.Sleep 100

// The example displays output like the following:
//       In main.
//       Working thread...
//       In main.
//       Working thread...
//       In main.
//       Working thread...
//</Snippet1>