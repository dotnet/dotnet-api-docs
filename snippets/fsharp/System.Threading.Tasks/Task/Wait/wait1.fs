module wait1
// <Snippet1>
open System
open System.Threading.Tasks

let t =
    Task.Run(fun () ->
        let rnd = Random()
        let mutable sum = 0L
        let n = 1000000

        for _ = 1 to n do
            let number = rnd.Next(0, 101)
            sum <- sum + int64 number

        printfn $"Total:   {sum:N0}"
        printfn $"Mean:    {float sum / float n:N2}"
        printfn $"N:       {n:N0}")

t.Wait()

// The example displays output similar to the following:
//       Total:   50,015,714
//       Mean:    50.02
//       N:       1,000,000
// </Snippet1>
