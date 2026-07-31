// <Snippet1>
open System

let objType = typeof<Array>

// Print the assembly full name.
printfn $"Assembly full name:\n   {objType.Assembly.FullName}."

// Print the assembly qualified name.
printfn $"Assembly qualified name:\n   {objType.AssemblyQualifiedName}."

// The example displays output similar to the following:
//
//    Assembly full name:
//       System.Private.CoreLib, Version = 10.0.0.0, Culture = neutral, PublicKeyToken = 7cec85d7bea7798e.
//    Assembly qualified name:
//       System.Array, System.Private.CoreLib, Version = 10.0.0.0, Culture = neutral, PublicKeyToken = 7cec85d7bea7798e.

// </Snippet1>
