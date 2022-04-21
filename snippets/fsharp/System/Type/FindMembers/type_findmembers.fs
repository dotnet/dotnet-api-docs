// <Snippet1>
open System.Reflection

let delegateToSearchCriteria (objMemberInfo: MemberInfo) (objSearch: obj) =
    // Compare the name of the member function with the filter criteria.
    string objMemberInfo.Name = string objSearch

let objTest = obj ()
let objType = objTest.GetType ()
try
    //Find all static or public methods in the Object class that match the specified name.
    let arrayMemberInfo = 
        objType.FindMembers(MemberTypes.Method, BindingFlags.Public ||| BindingFlags.Static ||| BindingFlags.Instance, MemberFilter delegateToSearchCriteria, "ReferenceEquals")

    for info in arrayMemberInfo do
        printfn $"Result of FindMembers -\t{info}\n"
with e ->
    printfn $"Exception : {e}"

(* The example produces the following output:

Result of FindMembers - Boolean ReferenceEquals(System.Object, System.Object)
*)
// </Snippet1>