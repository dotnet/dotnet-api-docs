module delay2
// <Snippet2>
open System
open System.Threading.Tasks

let t =
    Task.Run<int>(fun () ->
        task {
            do! Task.Delay(TimeSpan.FromSeconds 1.5)
            return 42
        })

t.Wait()
printfn $"Task t Status: {t.Status}, Result: {t.Result}"

// The example displays the following output:
//        Task t Status: RanToCompletion, Result: 42
// </Snippet2>
