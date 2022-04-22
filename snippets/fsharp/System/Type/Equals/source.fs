module source

// <Snippet1>
open System

type Example() = class end

do
    let a = typeof<string>
    let b = typeof<int>

    printfn $"{a} == {b}: {a.Equals b}"

    // The Type objects in a and b are not equal,
    // because they represent different types.

    let a = typeof<Example>
    let b = Example().GetType()

    printfn $"{a} is equal to {b}: {a.Equals b}"

    // The Type objects in a and b are equal,
    // because they both represent type Example.

    let b = typeof<Type>

    printfn $"typeof({a}).Equals(typeof({b})): {a.Equals b}"

// The Type objects in a and b are not equal,
// because variable a represents type Example
// and variable b represents type Type.

(* This code example produces the following output:
    System.String == System.Int32: False
    Example is equal to Example: True
    typeof(Example).Equals(typeof(System.Type)): False
*)
// </Snippet1>