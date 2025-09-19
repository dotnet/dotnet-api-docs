// <Snippet1>
open System

let nullInt = Nullable 172
// Convert with int conversion function.
printfn $"{int nullInt}"
// Convert with Convert.ChangeType.
printfn $"{Convert.ChangeType(nullInt, typeof<int>)}"
// The example displays the following output:
//       172
//       172
// </Snippet1>