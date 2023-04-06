// <Snippet1>
open System

let values = 
    [ null; String.Empty; "True"; "False"
      "true"; "false"; "    true    "; "0"
      "1"; "-1"; "string" ]
for value in values do
    match Boolean.TryParse value with
    | true, flag ->
        printfn $"'{value}' --> {flag}"
    | false, _ ->
        printfn $"""Unable to parse '%s{if value = null then "<null>" else value}'."""

// The example displays the following output:
//       Unable to parse '<null>'.
//       Unable to parse ''.
//       'True' --> True
//       'False' --> False
//       'true' --> True
//       'false' --> False
//       '    true    ' --> True
//       Unable to parse '0'.
//       Unable to parse '1'.
//       Unable to parse '-1'.
//       Unable to parse 'string'.
// </Snippet1>