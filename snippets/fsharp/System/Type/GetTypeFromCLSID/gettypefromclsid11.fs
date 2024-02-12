module gettypefromclsid11

// <Snippet11>
open System
open System.Runtime.InteropServices

[<assembly: ComVisible true>]
do ()

// Define two classes, and assign one an explicit GUID.
[<Guid "d055cba3-1f83-4bd7-ba19-e22b1b8ec3c4">]
type ExplicitGuid() = class end

type NoExplicitGuid() = class end

let explicitType = typeof<ExplicitGuid>
let explicitGuid = explicitType.GUID

// Get type of ExplicitGuid from its GUID.
let explicitCOM = Type.GetTypeFromCLSID explicitGuid
printfn $"Created {explicitCOM.Name} type from CLSID {explicitGuid}"
                
// Compare the two type objects.
printfn $"{explicitType.Name} and {explicitCOM.Name} equal: {explicitType.Equals explicitCOM}"       

// Instantiate an ExplicitGuid object.
try
    let obj = Activator.CreateInstance explicitCOM
    printfn $"Instantiated a {obj.GetType().Name} object"
with :? COMException as e ->
    printfn $"COM Exception:\n{e.Message}\n"

let notExplicit = typeof<NoExplicitGuid>
let notExplicitGuid = notExplicit.GUID

// Get type of ExplicitGuid from its GUID.
let notExplicitCOM = Type.GetTypeFromCLSID(notExplicitGuid)
printfn $"Created {notExplicitCOM.Name} type from CLSID {notExplicitGuid}"
                
// Compare the two type objects.
printfn $"{notExplicit.Name} and {notExplicitCOM.Name} equal: {notExplicit.Equals notExplicitCOM}"       

// Instantiate an ExplicitGuid object.
try
    let obj = Activator.CreateInstance notExplicitCOM
    printfn $"Instantiated a {obj.GetType().Name} object"
with :? COMException as e ->
    printfn $"COM Exception:\n{e.Message}\n"   
// The example displays the following output:
//       Created __ComObject type from CLSID d055cba3-1f83-4bd7-ba19-e22b1b8ec3c4
//       ExplicitGuid and __ComObject equal: False
//       COM Exception:
//       Retrieving the COM class factory for component with CLSID 
//       {D055CBA3-1F83-4BD7-BA19-E22B1B8EC3C4} failed due to the following error: 
//       80040154 Class not registered 
//       (Exception from HRESULT: 0x80040154 (REGDB_E_CLASSNOTREG)).
//       
//       Created __ComObject type from CLSID 74f03346-a718-3516-ac78-f351c7459ffb
//       NoExplicitGuid and __ComObject equal: False
//       COM Exception:
//       Retrieving the COM class factory for component with CLSID 
//       {74F03346-A718-3516-AC78-F351C7459FFB} failed due to the following error: 
//       80040154 Class not registered 
//       (Exception from HRESULT: 0x80040154 (REGDB_E_CLASSNOTREG)).
// </Snippet11>