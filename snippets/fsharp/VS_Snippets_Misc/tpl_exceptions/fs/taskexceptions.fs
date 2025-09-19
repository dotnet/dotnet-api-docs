module taskexceptions
// <snippet12>
open System
open System.IO
open System.Threading.Tasks

let getAllFiles path =
    let task1 =
        Task.Run(fun () -> Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories))

    try
        task1.Result
    with
    | :? AggregateException as ae ->
        ae.Handle (fun x ->
            // Handle an UnauthorizedAccessException
            if x :? UnauthorizedAccessException then
                printfn "You do not have permission to access all folders in this path."
                printfn "See your network administrator or try another path."

            x :? UnauthorizedAccessException)

        Array.empty

// This should throw an UnauthorizedAccessException.
try
    let files = getAllFiles @"C:\"
    
    if not (isNull files) then
        for file in files do
            printfn $"{file}"
with
| :? AggregateException as ae ->
    for ex in ae.InnerExceptions do
        printfn $"{ex.GetType().Name}: {ex.Message}"

printfn ""

// This should throw an ArgumentException.
try
    for s in getAllFiles "" do
        printfn $"{s}"
with
| :? AggregateException as ae ->
    for ex in ae.InnerExceptions do
        printfn $"{ex.GetType().Name}: {ex.Message}"

// The example displays the following output:
//       You do not have permission to access all folders in this path.
//       See your network administrator or try another path.
//
//       ArgumentException: The path is empty. (Parameter 'path')
// </snippet12>
