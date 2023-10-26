// <Snippet1>
open System.Threading

type BackgroundTest(maxIterations) =
    member _.RunLoop() =
        for i = 0 to maxIterations - 1 do
            printfn
                $"""{if Thread.CurrentThread.IsBackground then
                         "Background Thread"
                     else
                         "Foreground Thread"} count: {i}"""

            Thread.Sleep 250

        printfn
            $"""{if Thread.CurrentThread.IsBackground then
                     "Background Thread"
                 else
                     "Foreground Thread"} finished counting."""

let shortTest = BackgroundTest 10
let foregroundThread = Thread shortTest.RunLoop

let longTest = BackgroundTest 50
let backgroundThread = Thread longTest.RunLoop
backgroundThread.IsBackground <- true

foregroundThread.Start()
backgroundThread.Start()

// The example displays output like the following:
//    Foreground Thread count: 0
//    Background Thread count: 0
//    Background Thread count: 1
//    Foreground Thread count: 1
//    Foreground Thread count: 2
//    Background Thread count: 2
//    Foreground Thread count: 3
//    Background Thread count: 3
//    Background Thread count: 4
//    Foreground Thread count: 4
//    Foreground Thread count: 5
//    Background Thread count: 5
//    Foreground Thread count: 6
//    Background Thread count: 6
//    Background Thread count: 7
//    Foreground Thread count: 7
//    Background Thread count: 8
//    Foreground Thread count: 8
//    Foreground Thread count: 9
//    Background Thread count: 9
//    Background Thread count: 10
//    Foreground Thread count: 10
//    Background Thread count: 11
//    Foreground Thread finished counting.
// </Snippet1>
