module taskexceptions2
// <snippet13>
open System
open System.IO
open System.Threading.Tasks

let executeTasks () =
    // Assume this is a user-entered String.
    let path = @"C:\"

    let tasks =
        [| Task.Run (fun () ->
               // This should throw an UnauthorizedAccessException.
               Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories))
           :> Task
           Task.Run (fun () ->
               if path = @"C:\" then
                   raise (ArgumentException "The system root is not a valid path.")

               [| ".txt"; ".dll"; ".exe"; ".bin"; ".dat" |])
           :> Task
           Task.Run(fun () -> raise (NotImplementedException "This operation has not been implemented")) |]

    try
        Task.WaitAll(tasks)
    with
    | :? AggregateException as ae -> raise (ae.Flatten())

try
    executeTasks ()
with 
| :? AggregateException as ae ->
    for e in ae.InnerExceptions do
        printfn $"{e.GetType().Name}:\n   {e.Message}"

// The example displays the following output:
//       UnauthorizedAccessException:
//          Access to the path 'C:\Documents and Settings' is denied.
//       ArgumentException:
//          The system root is not a valid path.
//       NotImplementedException:
//          This operation has not been implemented.
// </Snippet13>
