//<snippet1>
// This code example demonstrates the
// Nullable.GetUnderlyingType() method.
open System

// Declare a type named Example.
// The MyMethod member of Example returns a Nullable of Int32.

type Example() =
    member _.MyMethod() =
        Nullable 0

(*
   Use reflection to obtain a Type object for the Example type.
   Use the Type object to obtain a MethodInfo object for the MyMethod method.
   Use the MethodInfo object to obtain the type of the return value of
     MyMethod, which is Nullable of Int32.
   Use the GetUnderlyingType method to obtain the type argument of the
     return value type, which is Int32.
*)
let t = typeof<Example>
let mi = t.GetMethod "MyMethod"
let retval = mi.ReturnType
printfn $"Return value type ... {retval}"
let answer = Nullable.GetUnderlyingType retval
printfn $"Underlying type ..... {answer}"

// This code example produces the following results:
//     Return value type ... System.Nullable`1[System.Int32]
//     Underlying type ..... System.Int32
//</snippet1>