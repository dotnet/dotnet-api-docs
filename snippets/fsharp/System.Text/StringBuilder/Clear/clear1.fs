// <Snippet1>
open System.Text

let sb = StringBuilder "This is a string."
printfn $"{sb} ({sb.Length} characters)"

sb.Clear() |> ignore
printfn $"{sb} ({sb.Length} characters)"

sb.Append "This is a second string." |> ignore
printfn $"{sb} ({sb.Length} characters)"

// The example displays the following output:
//       This is a string. (17 characters)
//        (0 characters)
//       This is a second string. (24 characters)
// </Snippet1>