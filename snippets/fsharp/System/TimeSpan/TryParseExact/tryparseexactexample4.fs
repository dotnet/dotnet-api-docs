module tryparseexactexample4

// <Snippet4>
open System
open System.Globalization

let inputs = 
    [| "3"; "16:42"; "1:6:52:35.0625" 
       "1:6:52:35,0625" |]
let formats = [| "%h"; "g"; "G" |]
let culture = CultureInfo "fr-FR"

// Parse each string in inputs using formats and the fr-FR culture.
for input in inputs do
    match TimeSpan.TryParseExact(input, formats, culture, TimeSpanStyles.AssumeNegative) with
    | true, interval ->
        printfn $"{input} --> {interval:c}"
    | _ ->
        printfn $"Unable to parse {input}"
// The example displays the following output:
//       3 --> -03:00:00
//       16:42 --> 16:42:00
//       Unable to parse 1:6:52:35.0625
//       1:6:52:35,0625 --> 1.06:52:35.0625000
// </Snippet4>