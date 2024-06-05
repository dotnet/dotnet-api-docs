module handlemethod2
// <Snippet16>
open System
open System.Threading.Tasks

type CustomException(message) =
    inherit Exception(message)

let task1 =
    Task.Run(fun () -> raise (CustomException "This exception is expected!"))

try
    task1.Wait()
with
| :? AggregateException as ae ->
    // Call the Handle method to handle the custom exception,
    // otherwise rethrow the exception.
    ae.Handle (fun ex ->
        if ex :? CustomException then
            printfn $"{ex.Message}"

        ex :? CustomException)

// The example displays the following output:
//        This exception is expected!
// </Snippet16>
