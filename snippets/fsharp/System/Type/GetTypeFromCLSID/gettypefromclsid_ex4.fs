module gettypefromclsid_ex4

// <Snippet4>
open System
open System.Reflection

let [<Literal>] WORD_CLSID = "{000209FF-0000-0000-C000-000000000046}"

try
    // Start an instance of the Word application.
    let word = Type.GetTypeFromCLSID(Guid.Parse WORD_CLSID, "computer17.central.contoso.com", true)
    printfn $"Instantiated Type object from CLSID {WORD_CLSID}"
    let wordObj = Activator.CreateInstance word
    printfn $"Instantiated {wordObj.GetType().FullName} from CLSID {WORD_CLSID}" 
    
    // Close Word.
    word.InvokeMember("Quit", BindingFlags.InvokeMethod, null, wordObj, [| box 0; 0; false |] ) |> ignore
// The method can throw any of a variety of exceptions.
with e ->
    printfn $"{e.GetType().Name}: Unable to instantiate an object for {WORD_CLSID}" 
// The example displays the following output:
//    Instantiated Type object from CLSID {000209FF-0000-0000-C000-000000000046}
//    Instantiated Microsoft.Office.Interop.Word.ApplicationClass
// </Snippet4>