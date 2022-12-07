open System
open System.Reflection

let func (t: Type) (mi: MemberInfo) =
    // <Snippet1>
    let others = t.GetMember(mi.Name, mi.MemberType, BindingFlags.Public ||| BindingFlags.Static ||| BindingFlags.NonPublic ||| BindingFlags.Instance)
    // </Snippet1>
    ()