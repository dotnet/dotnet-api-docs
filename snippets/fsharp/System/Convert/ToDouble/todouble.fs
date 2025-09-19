module todouble

// <Snippet2>
open System
open System.Globalization

// Create a NumberFormatInfo object and set some of its properties.
let provider =
    NumberFormatInfo(NumberDecimalSeparator = ",", NumberGroupSeparator = ".", NumberGroupSizes = [| 3 |])

// Define an array of numeric strings to convert.
let values =
    [| "123456789"
       "12345.6789"
       "12345,6789"
       "123,456.789"
       "123.456,789"
       "123,456,789.0123"
       "123.456.789,0123" |]

printfn $"Default Culture: {CultureInfo.CurrentCulture.Name}\n"
printfn $"""{"String to Convert", -22} {"Default/Exception", -20} {"Provider/Exception", -20}\n"""

// Convert each string to a Double with and without the provider.
for value in values do
    printf $"{value, -22} "

    try
        printf $"{Convert.ToDouble value, -20} "
    with :? FormatException as e -> printf $"{e.GetType().Name, -20} "

    try
        printfn $"{Convert.ToDouble(value, provider), -20} "
    with :? FormatException as e -> printfn $"{e.GetType().Name, -20} "
// The example displays the following output:
//       Default Culture: en-US
//
//       String to Convert      Default/Exception    Provider/Exception
//
//       123456789              123456789            123456789
//       12345.6789             12345.6789           123456789
//       12345,6789             123456789            12345.6789
//       123,456.789            123456.789           FormatException
//       123.456,789            FormatException      123456.789
//       123,456,789.0123       123456789.0123       FormatException
//       123.456.789,0123       FormatException      123456789.0123
// </Snippet2>
