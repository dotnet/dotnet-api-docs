module ToString.Byte1

// <Snippet3>
open System

let values = 
   [| Byte.MinValue; 12uy; 100uy; 179uy; Byte.MaxValue |]

for value in values do
   printfn $"{value,3} ({value.GetType().Name}) --> {Convert.ToString value}"
                     
// The example displays the following output:
//       0 (Byte) --> 0
//      12 (Byte) --> 12
//     100 (Byte) --> 100
//     179 (Byte) --> 179
//     255 (Byte) --> 255
// </Snippet3>