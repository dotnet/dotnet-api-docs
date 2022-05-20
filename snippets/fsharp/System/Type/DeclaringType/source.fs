module source

// <Snippet1>
[<AbstractClass>]
type MyClassA() =
    abstract m: unit -> int

[<AbstractClass>]
type MyClassB() =
    inherit MyClassA()

printfn $"""The declaring type of m is {typeof<MyClassB>.GetMethod("m").DeclaringType}."""
(* The example produces the following output:

The declaring type of m is dtype+MyClassA.
*)
// </Snippet1>
