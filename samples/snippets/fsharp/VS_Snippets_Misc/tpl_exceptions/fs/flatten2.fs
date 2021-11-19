module flatten2
// <Snippet22>
open System
open System.Threading.Tasks

type CustomException(message) =
    inherit Exception(message)

let task1 =
    Task.Factory.StartNew (fun () ->
        let child1 =
            Task.Factory.StartNew(
                (fun () ->
                    let child2 =
                        Task.Factory.StartNew(
                            (fun () -> raise (CustomException "Attached child2 faulted,")),
                            TaskCreationOptions.AttachedToParent
                        )
                    raise (CustomException "Attached child1 faulted.")),
                TaskCreationOptions.AttachedToParent
            )
        ()
    )

try
    task1.Wait()
with
| :? AggregateException as ae ->
    for e in ae.Flatten().InnerExceptions do
        if e :? CustomException then
            printfn "%s" e.Message
        else
            reraise()
        
// The example displays the following output:
//    Attached child1 faulted.
//    Attached child2 faulted.
// </Snippet22>
