module todatetime4

// <Snippet4>
open System
open System.Globalization

type CustomProvider(cultureName: string) =
    interface IFormatProvider with
        member _.GetFormat(formatType) =
            if formatType = typeof<DateTimeFormatInfo> then
                printf "(CustomProvider retrieved.) "
                CultureInfo(cultureName).GetFormat formatType
            else
                null

let cultureNames = [ "en-US"; "hu-HU"; "pt-PT" ]
let objects: obj list =
    [ 12; 17.2; false; DateTime(2010, 1, 1); "today"
      System.Collections.ArrayList(); 'c'
      "05/10/2009 6:13:18 PM"; "September 8, 1899" ]

for cultureName in cultureNames do
    printfn $"{cultureName} culture:"
    let provider = CustomProvider cultureName
    for obj in objects do
        try
            let dateValue = Convert.ToDateTime(obj, provider)
            printfn $"{obj} --> {dateValue.ToString(CultureInfo cultureName)}"
        with
        | :? FormatException ->
            printfn $"{obj} --> Bad Format"
        | :? InvalidCastException ->
            printfn $"{obj} --> Conversion Not Supported"
    printfn ""

// The example displays the following output:
//    en-US culture:
//    12 --> Conversion Not Supported
//    17.2 --> Conversion Not Supported
//    False --> Conversion Not Supported
//    1/1/2010 12:00:00 AM --> 1/1/2010 12:00:00 AM
//    (CustomProvider retrieved.) today --> Bad Format
//    System.Collections.ArrayList --> Conversion Not Supported
//    c --> Conversion Not Supported
//    (CustomProvider retrieved.) 05/10/2009 6:13:18 PM --> 5/10/2009 6:13:18 PM
//    (CustomProvider retrieved.) September 8, 1899 --> 9/8/1899 12:00:00 AM
//
//    hu-HU culture:
//    12 --> Conversion Not Supported
//    17.2 --> Conversion Not Supported
//    False --> Conversion Not Supported
//    1/1/2010 12:00:00 AM --> 2010. 01. 01. 0:00:00
//    (CustomProvider retrieved.) today --> Bad Format
//    System.Collections.ArrayList --> Conversion Not Supported
//    c --> Conversion Not Supported
//    (CustomProvider retrieved.) 05/10/2009 6:13:18 PM --> 2009. 05. 10. 18:13:18
//    (CustomProvider retrieved.) September 8, 1899 --> 1899. 09. 08. 0:00:00
//
//    pt-PT culture:
//    12 --> Conversion Not Supported
//    17.2 --> Conversion Not Supported
//    False --> Conversion Not Supported
//    1/1/2010 12:00:00 AM --> 01-01-2010 0:00:00
//    (CustomProvider retrieved.) today --> Bad Format
//    System.Collections.ArrayList --> Conversion Not Supported
//    c --> Conversion Not Supported
//    (CustomProvider retrieved.) 05/10/2009 6:13:18 PM --> 05-10-2009 18:13:18
//    (CustomProvider retrieved.) September 8, 1899 --> 08-09-1899 0:00:00
// </Snippet4>