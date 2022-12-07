open System.Collections

// <Snippet1>
// <Snippet2>
// <Snippet3>
let hashtableObj = Hashtable()
let objType = hashtableObj.GetType()
try
    // Get the methods implemented in 'IDeserializationCallback' interface.
    let arrayMethodInfo = objType.GetInterface("IDeserializationCallback").GetMethods()
    printfn "\nMethods of 'IDeserializationCallback' Interface :"
    for methodInfo in arrayMethodInfo do
        printfn $"{methodInfo}"

    // Get FullName for interface by using Ignore case search.
    printfn "\nMethods of 'IEnumerable' Interface"
    let arrayMethodInfo = objType.GetInterface("ienumerable",true).GetMethods()
    for methodInfo in arrayMethodInfo do
        printfn $"{methodInfo}"

    //Get the Interface methods for 'IDictionary' interface
    let interfaceMappingObj = objType.GetInterfaceMap typeof<IDictionary>
    let arrayMemberInfo = interfaceMappingObj.InterfaceMethods
    printfn "\nHashtable class Implements the following IDictionary Interface methods :"
    for memberInfo in arrayMemberInfo do
        printfn $"{memberInfo}"
with e ->
    printfn $"Exception : {e}"
// </Snippet3>
// </Snippet2>
// </Snippet1>