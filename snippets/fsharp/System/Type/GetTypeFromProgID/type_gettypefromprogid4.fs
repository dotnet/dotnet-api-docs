module type_gettypefromprogid4

// <Snippet1>
open System
try
    // Use server localhost.
    let theServer="localhost"
    // Use  ProgID HKEY_CLASSES_ROOT\DirControl.DirList.1.
    let myString1 ="DirControl.DirList.1"
    // Use a wrong ProgID WrongProgID.
    let myString2 ="WrongProgID"
    // Make a call to the method to get the type information for the given ProgID.
    let myType1 =Type.GetTypeFromProgID(myString1, theServer, true)
    printfn $"GUID for ProgID DirControl.DirList.1 is {myType1.GUID}."
    // Throw an exception because the ProgID is invalid and the throwOnError
    // parameter is set to True.
    let myType2 =Type.GetTypeFromProgID(myString2, theServer, true)
    ()
with e ->
    printfn "An exception occurred. The ProgID is wrong."
    printfn $"Source: {e.Source}"
    printfn $"Message: {e.Message}"
// </Snippet1>