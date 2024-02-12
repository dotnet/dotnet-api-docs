namespace global

// <Snippet2>
type A() = class end 

type B() = inherit A()

type C() = inherit B()   

module Example =
    [<EntryPoint>]
    let main _ =
        for t in typeof<A>.Assembly.GetTypes() do
            printfn $"{t.FullName} derived from: "
            let mutable derived = t
            while derived <> null do
                derived <- derived.BaseType
                if derived <> null then 
                    printfn $"   {derived.FullName}"
            printfn ""
        0
// The example displays the following output:
//       Example derived from:
//          System.Object
//       
//       A derived from:
//          System.Object
//       
//       B derived from:
//          A
//          System.Object
//       
//       C derived from:
//          B
//          A
//          System.Object
// </Snippet2>