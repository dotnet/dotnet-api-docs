// <Snippet1>
open System

// Get the Type and MemberInfo.
let t = Type.GetType "System.IO.File"
let members = t.GetMembers()
// Get and display the DeclaringType method.
printfn $"\nThere are {members.Length} members in {t.FullName}."
printfn $"Is {t.FullName} non-public? {t.IsNotPublic}"
// The example displays output like the following:
//       There are 60 members in System.IO.File.
//       Is System.IO.File non-public? False
// </Snippet1>

// <Snippet2>
module A =
    type B() = class end
    type C() = class end
// </Snippet2>