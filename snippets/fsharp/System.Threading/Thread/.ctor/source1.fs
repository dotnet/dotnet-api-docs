module source1
// <Snippet1>
open System.Threading

type Work() =
    member _.DoWork() = ()

let threadWork = Work()
let newThread = Thread(ThreadStart threadWork.DoWork)
newThread.Start()
// </Snippet1>
