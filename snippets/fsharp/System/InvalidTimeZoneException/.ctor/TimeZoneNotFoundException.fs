// <Snippet1>
open System

let retrieveTimeZone tzName =
    try
        TimeZoneInfo.FindSystemTimeZoneById tzName
    with 
    | :? TimeZoneNotFoundException as ex1 ->
        raise (TimeZoneNotFoundException($"The time zone '{tzName}' cannot be found.", ex1) )
    | :? InvalidTimeZoneException as ex2 ->
        raise (InvalidTimeZoneException($"The time zone {tzName} contains invalid data.", ex2) )

let handleInnerException () =
    let timeZoneName = "Any Standard Time"
    try
        let tz = retrieveTimeZone timeZoneName
        printfn $"The time zone display name is {tz.DisplayName}."
    with :? TimeZoneNotFoundException as e ->
        printfn $"{e.GetType().Name} thrown by application"
        printfn $"   Message: {e.Message}" 
        if e.InnerException <> null then
            printfn "   Inner Exception Information:"
            let rec printInner (innerEx: exn) =
                if innerEx <> null then
                    printfn $"      {innerEx.GetType().Name}: {innerEx.Message}"
                    printInner innerEx.InnerException
            printInner e
// </Snippet1>