module Array2

// <Snippet9>
open System

let values = [| "one"; null; "two" |]
for i = 0 to values.GetUpperBound 0 do
    printf $"""{if values[i] <> null then values[i].Trim() else ""}{if i = values.GetUpperBound 0 then "" else ", "}"""
Console.WriteLine()
// The example displays the following output:
//       one, , two
// </Snippet9>
