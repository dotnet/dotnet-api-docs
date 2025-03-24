module gettypefromclsid1

// <Snippet1>
open System
open System.Reflection

let [<Literal>] WORD_CLSID = "{000209FF-0000-0000-C000-000000000046}"
   
// Start an instance of the Word application.
let word = Type.GetTypeFromCLSID(Guid.Parse WORD_CLSID)
printfn $"Instantiated Type object from CLSID {WORD_CLSID}"
let wordObj = Activator.CreateInstance word
printfn $"Instantiated {wordObj.GetType().FullName}"

// Close Word.
word.InvokeMember("Quit", BindingFlags.InvokeMethod, null, wordObj, [| box 0; 0; false |]) |> ignore
// The example displays the following output:
//    Instantiated Type object from CLSID {000209FF-0000-0000-C000-000000000046}
//    Instantiated Microsoft.Office.Interop.Word.ApplicationClass
// </Snippet1>