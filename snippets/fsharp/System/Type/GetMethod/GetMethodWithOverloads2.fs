module GetMethodWithOverloads2

// <Snippet3>
open System
open System.Reflection

type Person() =
    member val FirstName = "" with get, set
    member val LastName = "" with get, set

    override this.ToString() =
        (this.FirstName + " " + this.LastName).Trim()

let retrieveMethod (t: Type) name =
    try
        let m = t.GetMethod name
        if m <> null then
            printfn $"""{m.ReflectedType.Name}.{m.Name}: {if m.IsStatic then "Static" else "Instance"} method"""
        else
            printfn $"{t.Name}.ToString method not found"
    with :? AmbiguousMatchException ->
        printfn $"{t.Name}.{name} has multiple public overloads."

let t = typeof<Person>
retrieveMethod t "ToString"

let t2 = typeof<int>
retrieveMethod t2 "ToString"

// The example displays the following output:
//       Person.ToString: Instance method
//       Int32.ToString has multiple public overloads.
// </Snippet3>