// <Snippet1>
open System.Net.Http

// HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
let client = new HttpClient()

let main =
    task {
        // Call asynchronous network methods in a try/catch block to handle exceptions.
        try
            use! response = client.GetAsync "http://www.contoso.com/"
            response.EnsureSuccessStatusCode() |> ignore
            let! responseBody = response.Content.ReadAsStringAsync()
            // Above three lines can be replaced with new helper method below
            // let! responseBody = client.GetStringAsync uri

            printfn $"{responseBody}"
        with
        | :? HttpRequestException as e ->
            printfn "\nException Caught!"
            printfn $"Message :{e.Message} "
    }

main.Wait()
// </Snippet1>
