// <Snippet1>
open System
open System.Security
open System.Reflection

type MyMemberSample() =
    member _.GetMemberInfo() =
        let myString = "GetMember_String"

        let myType = myString.GetType()
        // Get the members for myString starting with the letter C.
        let myMembers = myType.GetMember "C*"
        if myMembers.Length > 0 then
            printfn $"\nThe member(s) starting with the letter C for type {myType}:"
            for index = 0 to myMembers.Length - 1 do
                printfn $"Member {index + 1}: {myMembers[index]}"
        else
            printfn "No members match the search criteria."

    // <Snippet2>
    member _.GetPublicStaticMemberInfo() =
        let myString = "GetMember_String_BindingFlag"
        let myType = myString.GetType()
        // Get the public static members for the class myString starting with the letter C.
        let myMembers = myType.GetMember("C*", BindingFlags.Public ||| BindingFlags.Static)
        if myMembers.Length > 0 then
            printfn $"\nThe public static member(s) starting with the letter C for type {myType}:"
            for index = 0 to myMembers.Length - 1 do
                printfn $"Member {index + 1}: {myMembers[index]}"
        else
            printfn "No members match the search criteria."
    // </Snippet2>

    // <Snippet3>
    member _.GetPublicInstanceMethodMemberInfo() =
        let myString = "GetMember_String_MemberType_BindingFlag"
        let myType = myString.GetType()
        // Get the public instance methods for myString starting with the letter C.
        let myMembers = myType.GetMember("C*", MemberTypes.Method, BindingFlags.Public ||| BindingFlags.Instance)
        if myMembers.Length > 0 then
            printfn $"\nThe public instance method(s) starting with the letter C for type {myType}:"
            for index = 0 to myMembers.Length - 1 do
                printfn $"Member {index + 1}: {myMembers[index]}"
        else
            printfn "No members match the search criteria."
    // </Snippet3>

let myClass = MyMemberSample()
try
    myClass.GetMemberInfo()
    myClass.GetPublicStaticMemberInfo()
    myClass.GetPublicInstanceMethodMemberInfo()
with
| :? ArgumentNullException as e ->
    printfn "ArgumentNullException occurred."
    printfn $"Source: {e.Source}"
    printfn $"Message: {e.Message}"
| :? NotSupportedException as e ->
    printfn $"NotSupportedException occurred."
    printfn $"Source: {e.Source}"
    printfn $"Message: {e.Message}"
| :? SecurityException as e ->
    printfn "SecurityException occurred."
    printfn $"Source: {e.Source}"
    printfn $"Message: {e.Message}"
| e ->
    printfn "Exception occurred."
    printfn $"Source: {e.Source}"
    printfn $"Message: {e.Message}"
// </Snippet1>

