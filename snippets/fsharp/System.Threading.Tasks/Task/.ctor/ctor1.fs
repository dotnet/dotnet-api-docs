module ctor1
// <Snippet1>
open System.Collections.Concurrent
open System.IO
open System.Threading.Tasks

let main =
    task {
        let list = ConcurrentBag<string>()
        let dirNames = [ "."; ".." ]
        let tasks = ResizeArray()

        for dirName in dirNames do
            let t =
                new Task(fun () ->
                    for path in Directory.GetFiles dirName do
                        list.Add path)

            tasks.Add t
            t.Start()

        do! tasks.ToArray() |> Task.WhenAll

        for t in tasks do
            printfn $"Task {t.Id} Status: {t.Status}"

        printfn $"Number of files read: {list.Count}"
    }

// The example displays output like the following:
//       Task 1 Status: RanToCompletion
//       Task 2 Status: RanToCompletion
//       Number of files read: 23
// </Snippet1>
