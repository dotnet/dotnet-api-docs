module gettypefromclsid_ex2

// <Snippet2>
open System
open System.Reflection

let [<Literal>] WORD_CLSID = "{000209FF-0000-0000-C000-000000000046}"

try
    // Start an instance of the Word application.
    let word = Type.GetTypeFromCLSID(Guid.Parse WORD_CLSID, true)
    printfn $"Instantiated Type object from CLSID {WORD_CLSID}"
    let wordObj = Activator.CreateInstance word
    printfn $"Instantiated {wordObj.GetType().FullName} from CLSID {WORD_CLSID}" 
    
    // Close Word.
    word.InvokeMember("Quit", BindingFlags.InvokeMethod, null, wordObj, [| box 0; 0; false |] ) |> ignore
with _ ->
    printfn $"Unable to instantiate an object for {WORD_CLSID}"
// The example displays the following output:
//    Instantiated Type object from CLSID {000209FF-0000-0000-C000-000000000046}
//    Instantiated Microsoft.Office.Interop.Word.ApplicationClass
// </Snippet2>