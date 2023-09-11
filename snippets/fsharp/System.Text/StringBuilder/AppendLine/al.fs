//<snippet1>
// This example demonstrates the StringBuilder.AppendLine()
// method.

open System.Text

let sb = StringBuilder()
let line = "A line of text."
let number = 123

// Append two lines of text.
sb.AppendLine "The first line of text." |> ignore
sb.AppendLine line |> ignore

// Append a new line, an empty string, and a null cast as a string.
sb.AppendLine() |> ignore
sb.AppendLine "" |> ignore
sb.AppendLine Unchecked.defaultof<string> |> ignore

// Append the non-string value, 123, and two new lines.
sb.Append(number).AppendLine().AppendLine() |> ignore

// Append two lines of text.
sb.AppendLine line |> ignore
sb.AppendLine "The last line of text." |> ignore

// Convert the value of the StringBuilder to a string and display the string.
printfn $"{sb}"

// This example produces the following results:
//       The first line of text.
//       A line of text.
//
//
//
//       123
//
//       A line of text.
//       The last line of text.
//</snippet1>
