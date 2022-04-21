// <Snippet1>
[<AbstractClass>]
type AbstractClass() = class end

type DerivedClass() =  inherit AbstractClass()

[<Sealed>]
type SingleClass() = class end

type ITypeInfo =
   abstract GetName: unit -> string

type ImplementingClass() =
    interface ITypeInfo with
        member this.GetName() =
            this.GetType().FullName

type DiscriminatedUnion = 
    | Yes 
    | No of string

type Record = 
  { Name: string
    Age: int }

type InputOutput = delegate of inp: string -> string

let types = 
    [ typeof<AbstractClass>
      typeof<DerivedClass>
      typeof<ITypeInfo>
      typeof<SingleClass>
      typeof<ImplementingClass>
      typeof<DiscriminatedUnion>
      typeof<Record>
      typeof<InputOutput> ]
for typ in types do
    printfn $"{typ.Name} is abstract: {typ.IsAbstract}"

// The example displays the following output:
//       AbstractClass is abstract: True     
//       DerivedClass is abstract: False     
//       ITypeInfo is abstract: True
//       SingleClass is abstract: False      
//       ImplementingClass is abstract: False
//       DiscriminatedUnion is abstract: True
//       Record is abstract: False
//       InputOutput is abstract: False
// </Snippet1>