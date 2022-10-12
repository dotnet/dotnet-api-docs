module format4

// <Snippet4>
open System

let formatString = 
    "    {0,10} ({0,8:X8})\nAnd {1,10} ({1,8:X8})\n  = {2,10} ({2,8:X8})"

let value1 = 16932
let value2 = 15421
String.Format(formatString, value1, value2, value1 &&& value2)
|> printfn "%s"
// The example displays the following output:
//                16932 (00004224)
//       And      15421 (00003C3D)
//         =         36 (00000024)
// </Snippet4>