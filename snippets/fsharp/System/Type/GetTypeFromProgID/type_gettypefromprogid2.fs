module type_gettypefromprogid2

// <Snippet1>
open System

try
    // Use the ProgID HKEY_CLASSES_ROOT\DirControl.DirList.1.
    let myString1 ="DIRECT.ddPalette.3"
    // Use a nonexistent ProgID WrongProgID.
    let myString2 ="WrongProgID"
    // Make a call to the method to get the type information of the given ProgID.
    let myType1 =Type.GetTypeFromProgID(myString1, true)
    printfn $"GUID for ProgID DirControl.DirList.1 is {myType1.GUID}."
    // Throw an exception because the ProgID is invalid and the throwOnError
    // parameter is set to True.
    let myType2 =Type.GetTypeFromProgID(myString2, true)
    ()
with e ->
    printfn "An exception occurred."
    printfn $"Source: {e.Source}"
    printfn $"Message: {e.Message}"
// </Snippet1>