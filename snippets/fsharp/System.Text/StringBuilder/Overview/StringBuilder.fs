module StringBuilder
//Code Modification: Removed AppendLine and associated comment after the AppendFormat line.
//The CR/LF bytes introduces by AppendLine made the sb.Length appear incorrect.
// Before
//sb.AppendFormat("GHI{0}{1}", 'J', 'k');
////APpend a blank line to the end of the StringBuilder.
//   sb.AppendLine();
// After
//sb.AppendFormat("GHI{0}{1}", 'J', 'k');
//Code Modification: End
//Types:System.Text.StringBuilder
//<snippet1>
open System.Text

//<snippet2>
// Create a StringBuilder that expects to hold 50 characters.
// Initialize the StringBuilder with "ABC".
let sb = StringBuilder("ABC", 50)
//</snippet2>

//<snippet3>
// Append three characters (D, E, and F) to the end of the StringBuilder.
sb.Append [| 'D'; 'E'; 'F' |] |> ignore
//</snippet3>

//<snippet4>
// Append a format string to the end of the StringBuilder.
sb.AppendFormat("GHI{0}{1}", 'J', 'k') |> ignore
//</snippet4>

//<snippet5>
// Display the number of characters in the StringBuilder and its string.
printfn $"{sb.Length} chars: {sb}"
//</snippet5>

//<snippet6>
// Insert a string at the beginning of the StringBuilder.
sb.Insert(0, "Alphabet: ") |> ignore
//</snippet6>

//<snippet7>
// Replace all lowercase k's with uppercase K's.
sb.Replace('k', 'K') |> ignore
//</snippet7>

// Display the number of characters in the StringBuilder and its string.
printfn $"{sb.Length} chars: {sb}"

// This code produces the following output.
//
// 11 chars: ABCDEFGHIJk
// 21 chars: Alphabet: ABCDEFGHIJK
//</snippet1>
