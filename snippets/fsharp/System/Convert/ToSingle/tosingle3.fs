module tosingle3

// <Snippet16>
open System
open System.Globalization

let values =
    [| "123456789"; "12345.6789"; "12 345,6789"
       "123,456.789"; "123 456,789"; "123,456,789.0123"
       "123 456 789,0123"; "1.235e12"; "1.03221e-05"
       string Double.MaxValue |]
let cultures =
    [| CultureInfo "en-US"; CultureInfo "fr-FR" |]

for culture in cultures do
    printfn $"String -> Single Conversion Using the {culture.Name} Culture"
    for value in values do
        printf $"{value,22}  ->  "
        try
            printfn $"{Convert.ToSingle(value, culture)}"
        with
        | :? FormatException ->
            printfn "FormatException"
        | :? OverflowException ->
            printfn "OverflowException"
    printfn ""
// The example displays the following output:
//    String -> Single Conversion Using the en-US Culture
//                 123456789  ->  1.234568E+08
//                12345.6789  ->  12345.68
//               12 345,6789  ->  FormatException
//               123,456.789  ->  123456.8
//               123 456,789  ->  FormatException
//          123,456,789.0123  ->  1.234568E+08
//          123 456 789,0123  ->  FormatException
//                  1.235e12  ->  1.235E+12
//               1.03221e-05  ->  1.03221E-05
//     1.79769313486232E+308  ->  Overflow
//
//    String -> Single Conversion Using the fr-FR Culture
//                 123456789  ->  1.234568E+08
//                12345.6789  ->  FormatException
//               12 345,6789  ->  12345.68
//               123,456.789  ->  FormatException
//               123 456,789  ->  123456.8
//          123,456,789.0123  ->  FormatException
//          123 456 789,0123  ->  1.234568E+08
//                  1.235e12  ->  FormatException
//               1.03221e-05  ->  FormatException
//     1.79769313486232E+308  ->  FormatException
// </Snippet16>
