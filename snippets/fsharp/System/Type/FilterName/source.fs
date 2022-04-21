open System
open System.Reflection

type Application = class end
// <Snippet1>
// Get the set of methods associated with the type
let mi = typeof<Application>.FindMembers(MemberTypes.Constructor |||
             MemberTypes.Method,
             BindingFlags.Public ||| BindingFlags.Static ||| BindingFlags.NonPublic |||
             BindingFlags.Instance ||| BindingFlags.DeclaredOnly,
             Type.FilterName, "*")
printfn $"Number of methods (includes constructors): {mi.Length}"
// </Snippet1>