﻿module appendformat3
// <Snippet4>
open System
open System.Globalization
open System.Text

let rnd = Random()
let culture = CultureInfo.CreateSpecificCulture "fr-FR"
let sb = StringBuilder()

let formatString =
    "    {0,12:N0} ({0,8:X8})\nAnd {1,12:N0} ({1,8:X8})\n  = {2,12:N0} ({2,8:X8})\n"

for _ = 0 to 2 do
    let value1 = rnd.Next()
    let value2 = rnd.Next()

    sb
        .AppendFormat(culture, formatString, value1, value2, value1 &&& value2)
        .AppendLine()
    |> ignore

printfn $"{sb}"

// The example displays output like the following:
//           1 984 112 195 (76432643)
//       And 1 179 778 511 (4651FDCF)
//         = 1 178 674 243 (46412443)
//
//           2 034 813 710 (7948CB0E)
//       And  569 333 976 (21EF58D8)
//         =  558 385 160 (21484808)
//
//            126 717 735 (078D8F27)
//       And 1 830 715 973 (6D1E8245)
//         =   84 705 797 (050C8205)
// </Snippet4>
