open System
// <Snippet1>
[<AttributeUsage(AttributeTargets.Class ||| AttributeTargets.Method ||| AttributeTargets.Property ||| AttributeTargets.Field, Inherited = true)>]
type InheritedAttribute() =
    inherit Attribute()

[<AttributeUsage(AttributeTargets.Class ||| AttributeTargets.Method ||| AttributeTargets.Property ||| AttributeTargets.Field, Inherited = false)>]
type NotInheritedAttribute() =
    inherit Attribute()
// </Snippet1>

// <Snippet2>
[<Inherited>]
type BaseA() =
    abstract member MethodA: unit -> unit
    [<Inherited>]
    default _.MethodA() = ()

type DerivedA() =
    inherit BaseA()

    override _.MethodA() = ()

[<NotInherited>]
type BaseB() =
    abstract member MethodB: unit -> unit
    [<NotInherited>]
    default _.MethodB() = ()

type DerivedB() =
    inherit BaseB()

    override _.MethodB() = ()

let typeA = typeof<DerivedA>
printfn $"DerivedA has Inherited attribute: {typeA.GetCustomAttributes(typeof<InheritedAttribute>, true).Length > 0}"
let memberA = typeA.GetMethod "MethodA"
printfn $"DerivedA.MemberA has Inherited attribute: {memberA.GetCustomAttributes(typeof<InheritedAttribute>, true).Length > 0}\n"

let typeB = typeof<DerivedB>
printfn $"DerivedB has NotInherited attribute: {typeB.GetCustomAttributes(typeof<NotInheritedAttribute>, true).Length > 0}"
let memberB = typeB.GetMethod "MethodB"
printfn $"DerivedB.MemberB has NotInherited attribute: {memberB.GetCustomAttributes(typeof<NotInheritedAttribute>, true).Length > 0}"


// The example displays the following output:
//       DerivedA has Inherited attribute: True
//       DerivedA.MemberA has Inherited attribute: True
//
//       DerivedB has NotInherited attribute: False
//       DerivedB.MemberB has NotInherited attribute: False
// </Snippet2>
