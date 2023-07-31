module WhenAll4

// <Snippet4>
open System
open System.Net.NetworkInformation
open System.Threading
open System.Threading.Tasks

let mutable failed = 0

let urls =
    [ "www.adatum.com"
      "www.cohovineyard.com"
      "www.cohowinery.com"
      "www.northwindtraders.com"
      "www.contoso.com" ]

let tasks =
    urls
    |> List.map (fun url ->
        Task.Run(fun () ->
            let png = new Ping()

            try
                let reply = png.Send url

                if reply.Status <> IPStatus.Success then
                    Interlocked.Increment &failed |> ignore
                    raise (TimeoutException $"Unable to reach {url}.")
            with :? PingException ->
                Interlocked.Increment &failed |> ignore
                reraise ()))

let t = Task.WhenAll tasks

try
    t.Wait()
with _ ->
    ()

if t.Status = TaskStatus.RanToCompletion then
    printfn "All ping attempts succeeded."
elif t.Status = TaskStatus.Faulted then
    printfn $"{failed} ping attempts failed"

// The example displays output like the following:
//       5 ping attempts failed
// </Snippet4>
