// <Snippet1>
open System
open System.Security.Permissions

let myHandler _ (args: UnhandledExceptionEventArgs) =
    let e = args.ExceptionObject :?> Exception
    printfn $"MyHandler caught : {e.Message}"
    printfn $"Runtime terminating: {args.IsTerminating}"

[<EntryPoint>]
let main _ =
    let currentDomain = AppDomain.CurrentDomain
    currentDomain.UnhandledException.AddHandler(UnhandledExceptionEventHandler myHandler)

    try
        failwith "1"
    with e ->
        printfn $"Catch clause caught : {e.Message} \n"

    failwith "2"

// The example displays the following output:
//       Catch clause caught : 1
//
//       MyHandler caught : 2
//       Runtime terminating: True
//
//       Unhandled Exception: System.Exception: 2
//          at Example.main()
// </Snippet1>
