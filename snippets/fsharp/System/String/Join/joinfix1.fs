module joinfix1.fs
open System

// <Snippet6>
let values: obj[] = [| null; "Cobb"; 4189; 11434; 0.366 |]
if values[0] = null then 
   values[0] <- String.Empty
printfn $"""{String.Join("|", values)}"""

// The example displays the following output:
//      |Cobb|4189|11434|0.366
// </Snippet6>
