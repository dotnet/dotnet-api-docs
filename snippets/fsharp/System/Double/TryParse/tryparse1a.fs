module tryparse1a

// <Snippet1>
open System

let values =
    [| "1,643.57"; "$1,643.57"; "-1.643e6"
       "-168934617882109132"; "123AE6"
       null; String.Empty; "ABCDEF" |]

for value in values do
    match Double.TryParse value with
    | true, number ->
        printfn $"'{value}' --> {number}"
    | _ ->
        printfn $"Unable to parse '{value}'."
// The example displays the following output:
//       '1,643.57' --> 1643.57
//       Unable to parse '$1,643.57'.
//       '-1.643e6' --> -1643000
//       '-168934617882109132' --> -1.68934617882109E+17
//       Unable to parse '123AE6'.
//       Unable to parse ''.
//       Unable to parse ''.
//       Unable to parse 'ABCDEF'.
// </Snippet1>