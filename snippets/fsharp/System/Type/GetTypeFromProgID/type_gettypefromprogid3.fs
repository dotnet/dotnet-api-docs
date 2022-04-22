module type_gettypefromprogid3

// <Snippet1>
open System

try
    // Use the ProgID localhost\HKEY_CLASSES_ROOT\DirControl.DirList.1.
    let theProgramID ="DirControl.DirList.1"
    // Use the server name localhost.
    let theServer="localhost"
    // Make a call to the method to get the type information for the given ProgID.
    let myType =Type.GetTypeFromProgID(theProgramID, theServer)
    if myType = null then
        raise (Exception "Invalid ProgID or Server.")
    printfn $"GUID for ProgID DirControl.DirList.1 is {myType.GUID}."
with e ->
    printfn "An exception occurred."
    printfn $"Source: {e.Source}"
    printfn $"Message: {e.Message}"
// </Snippet1>