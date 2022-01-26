// <Snippet1>
namespace System.Runtime.InteropServices

open System

[<AttributeUsage(AttributeTargets.Method ||| AttributeTargets.Field ||| AttributeTargets.Property)>]
type DispIdAttribute(value: int) =
    inherit Attribute()
      
    // . . .

    member _.Value with get() = 
        // . . .
        0

// </Snippet1>
