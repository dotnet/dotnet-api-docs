module source
// <Snippet1>
open System.Threading

module Work =
    let doWork () = ()

let newThread = Thread(ThreadStart Work.doWork)
newThread.Start()
// </Snippet1>
