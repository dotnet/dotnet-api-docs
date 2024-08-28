// <Snippet1>
open System
open System.Threading

type PriorityTest() =
    [<VolatileField>]
    static let mutable loopSwitch: bool = true

    [<ThreadStatic; DefaultValue>]
    static val mutable private threadCount: int

    member _.ThreadMethod() =
        while loopSwitch do
            PriorityTest.threadCount <- PriorityTest.threadCount + 1

        printfn
            $"""{Thread.CurrentThread.Name, -11} with {Thread.CurrentThread.Priority, 11} priority has a count = {PriorityTest.threadCount.ToString "N0", 13}"""

    do loopSwitch <- true

    member _.LoopSwitch
        with set (value) = loopSwitch <- value

let priorityTest = PriorityTest()

let thread1 = Thread priorityTest.ThreadMethod
thread1.Name <- "ThreadOne"
let thread2 = Thread priorityTest.ThreadMethod
thread2.Name <- "ThreadTwo"
thread2.Priority <- ThreadPriority.BelowNormal
let thread3 = Thread priorityTest.ThreadMethod
thread3.Name <- "ThreadThree"
thread3.Priority <- ThreadPriority.AboveNormal

thread1.Start()
thread2.Start()
thread3.Start()
// Allow counting for 10 seconds.
Thread.Sleep 10000
priorityTest.LoopSwitch <- false

// The example displays output like the following:
//    ThreadOne   with      Normal priority has a count =   755,897,581
//    ThreadThree with AboveNormal priority has a count =   778,099,094
//    ThreadTwo   with BelowNormal priority has a count =     7,840,984
// </Snippet1>
