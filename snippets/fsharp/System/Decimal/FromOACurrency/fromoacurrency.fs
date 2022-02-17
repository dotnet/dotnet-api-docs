module fromoacurrency

//<Snippet2>
// Example of the Decimal.FromOACurrency method.
open System

let dataFmt obj1 obj2 = printfn $"{obj1,21}{obj2,25}"

// Display the Decimal.FromOACurrency parameter and decimal result.
let showDecimalFromOACurrency argument =
    let decCurrency = Decimal.FromOACurrency argument

    dataFmt argument decCurrency

printfn 
    """This example of the Decimal.FromOACurrency() method generates
the following output. It displays the OLE Automation Currency 
value as a long and the result as a decimal.
"""
dataFmt "OA Currency" "Decimal Value"
dataFmt "-----------" "-------------"

// Convert OLE Automation Currency values to decimal objects.
showDecimalFromOACurrency 0L
showDecimalFromOACurrency 1L
showDecimalFromOACurrency 100000L
showDecimalFromOACurrency 100000000000L
showDecimalFromOACurrency 1000000000000000000L
showDecimalFromOACurrency 1000000000000000001L
showDecimalFromOACurrency Int64.MaxValue
showDecimalFromOACurrency Int64.MinValue
showDecimalFromOACurrency 123456789L
showDecimalFromOACurrency 1234567890000L
showDecimalFromOACurrency 1234567890987654321L
showDecimalFromOACurrency 4294967295L


// This example of the Decimal.FromOACurrency() method generates
// the following output. It displays the OLE Automation Currency
// value as a long and the result as a decimal.

//           OA Currency            Decimal Value
//           -----------            -------------
//                     0                        0
//                     1                   0.0001
//                100000                       10
//          100000000000                 10000000
//   1000000000000000000          100000000000000
//   1000000000000000001     100000000000000.0001
//   9223372036854775807     922337203685477.5807
//  -9223372036854775808    -922337203685477.5808
//             123456789               12345.6789
//         1234567890000                123456789
//   1234567890987654321     123456789098765.4321
//            4294967295              429496.7295
//</Snippet2> 