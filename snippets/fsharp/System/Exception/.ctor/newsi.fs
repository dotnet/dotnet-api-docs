module NDP_UE_FS_4

//<Snippet3>
// Example for the Exception(string, Exception) constructor.
open System

let overflowMessage = "The log table has overflowed."

// Derive an exception with a specifiable message and inner exception.
type LogTableOverflowException =
    inherit Exception

    new () =  { inherit Exception(overflowMessage) }

    new (auxMessage: string) = 
        { inherit Exception($"{overflowMessage} - {auxMessage}") }

    new (auxMessage: string, inner: Exception) =
        { inherit Exception($"{overflowMessage} - {auxMessage}", inner ) }

type LogTable(numElements: int) =
    let mutable logArea = Array.zeroCreate<string> numElements
    let mutable elemInUse = 0

    // The AddRecord method throws a derived exception
    // if the array bounds exception is caught.
    member _.AddRecord(newRecord: string): int =
        try
            logArea[elemInUse] <- newRecord
            elemInUse <- elemInUse + 1
            elemInUse - 1
        with ex ->
            raise (LogTableOverflowException($"Record \"{newRecord}\" was not logged.", ex ) )

// Create a log table and force an overflow.
let log = LogTable 4

printfn "This example of the Exception(string, Exception)\nconstructor generates the following output."
printfn "\nExample of a derived exception that references an inner exception:\n"
try
    for count = 1 to 1000 do
        log.AddRecord $"Log record number {count}"
        |> ignore
with ex ->
    printfn $"{ex}"


// This example of the Exception(string, Exception)
// constructor generates the following output.
//
// Example of a derived exception that references an inner exception:
//
// NDP_UE_FS_4+LogTableOverflowException: The log table has overflowed. - Record "Lo
// g record number 5" was not logged. ---> System.IndexOutOfRangeException: Index
// was outside the bounds of the array.
//    at NDP_UE_FS_4.LogTable.AddRecord(String newRecord)
//    --- End of inner exception stack trace ---
//    at NDP_UE_FS_4.LogTable.AddRecord(String newRecord)
//    at <StartupCode$fs>.$NDP_UE_FS_4.main@()
//</Snippet3>