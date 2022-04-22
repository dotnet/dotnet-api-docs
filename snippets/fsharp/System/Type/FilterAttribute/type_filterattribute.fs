// <Snippet1>
open System
open System.Reflection
open System.Security

try
    let myFilter = Type.FilterAttribute
    let myType = typeof<string>
    let myMemberInfoArray = myType.FindMembers(MemberTypes.Constructor ||| MemberTypes.Method, BindingFlags.Public ||| BindingFlags.Static ||| BindingFlags.Instance, myFilter, MethodAttributes.SpecialName)
    for myMemberinfo in myMemberInfoArray do
        printf $"\n{myMemberinfo.Name}"
        printf $" is a {myMemberinfo.MemberType}"
with 
| :? ArgumentNullException as e ->
    printf $"ArgumentNullException: {e.Message}"
| :? SecurityException as e ->
    printf $"SecurityException: {e.Message}"
| e ->
    printf $"Exception: {e.Message}"
// </Snippet1>