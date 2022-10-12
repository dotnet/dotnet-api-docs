// <Snippet12>
open System
open System.Globalization

let values = 
    [| "123456789"; "12345.6789"; "12 345,6789"; "123,456.789"
       "123 456,789"; "123,456,789.0123"; "123 456 789,0123" |]
let cultures = 
    [ CultureInfo "en-US"; CultureInfo "fr-FR" ]

for culture in cultures do
    printfn $"String -> Decimal Conversion Using the {culture.Name} Culture"
    for value in values do
        printf $"{value,20}  ->  "
        try
            printfn $"{Convert.ToDecimal(value, culture)}"
        with :? FormatException ->
            printfn "FormatException"
    printfn ""
// The example displays the following output:
//       String -> Decimal Conversion Using the en-US Culture
//                  123456789  ->  123456789
//                 12345.6789  ->  12345.6789
//                12 345,6789  ->  FormatException
//                123,456.789  ->  123456.789
//                123 456,789  ->  FormatException
//           123,456,789.0123  ->  123456789.0123
//           123 456 789,0123  ->  FormatException
//
//       String -> Decimal Conversion Using the fr-FR Culture
//                  123456789  ->  123456789
//                 12345.6789  ->  FormatException
//                12 345,6789  ->  12345.6789
//                123,456.789  ->  FormatException
//                123 456,789  ->  123456.789
//           123,456,789.0123  ->  FormatException
//           123 456 789,0123  ->  123456789.0123
// </Snippet12>
