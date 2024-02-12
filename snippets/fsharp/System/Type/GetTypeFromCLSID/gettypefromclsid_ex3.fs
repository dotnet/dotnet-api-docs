module gettypefromclsid_ex3

// <Snippet3>
open System
open System.Reflection
open System.Runtime.InteropServices

let [<Literal>] WORD_CLSID = "{000209FF-0000-0000-C000-000000000046}"

// Start an instance of the Word application.
let word = Type.GetTypeFromCLSID(Guid.Parse WORD_CLSID, "computer17.central.contoso.com")
printfn $"Instantiated Type object from CLSID {WORD_CLSID}"
try
    let wordObj = Activator.CreateInstance word
    printfn $"Instantiated {wordObj.GetType().FullName} from CLSID {WORD_CLSID}" 
    
    // Close Word.
    word.InvokeMember("Quit", BindingFlags.InvokeMethod, null, wordObj, [| box 0; 0; false |] ) |> ignore
with :? COMException ->
    printfn "Unable to instantiate object."   
// The example displays the following output:
//    Instantiated Type object from CLSID {000209FF-0000-0000-C000-000000000046}
//    Instantiated Microsoft.Office.Interop.Word.ApplicationClass
// </Snippet3>