// <Snippet1>
open System
open System.Reflection
open System.Security

try
    let myFilter = Type.FilterNameIgnoreCase
    let myType = typeof<string>
    let myMemberinfo1 = 
        myType.FindMembers(MemberTypes.Constructor ||| MemberTypes.Method, BindingFlags.Public ||| BindingFlags.Static ||| BindingFlags.Instance, myFilter, "C*")
    for myMemberinfo2 in myMemberinfo1 do
        printf "\n{myMemberinfo2.Name}"
        myMemberinfo2.MemberType
        |> printfn " is a %O"
with
| :? ArgumentNullException as e ->
    printf $"ArgumentNullException : {e.Message}"
| :? SecurityException as e ->
    printf $"SecurityException : {e.Message}"
| e ->
    printf $"Exception : {e.Message}"
// </Snippet1>