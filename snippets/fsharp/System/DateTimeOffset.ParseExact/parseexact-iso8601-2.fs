module parseexact_iso8601_2

open System
open System.Globalization

let dateStrings = 
    [| "2018-08-18T12:45:16.0000000Z"
       "2018/08/18T12:45:16.0000000Z"
       "2018-18-08T12:45:16.0000000Z"
       "2018-08-18T12:45:16.0000000"                               
       " 2018-08-18T12:45:16.0000000Z "
       "2018-08-18T12:45:16.0000000+02:00"
       "2018-08-18T12:45:16.0000000-07:00" |] 

let parseWithISO8601 dateStrings styles =
    printfn $"Parsing with {styles}:"
    for dateString in dateStrings do
        try
            let date = DateTimeOffset.ParseExact(dateString, "O", null, styles)
            printfn $"""   {dateString,-35} --> {date.ToString "yyyy-MM-dd HH:mm:ss.FF zzz"}"""
        with :? FormatException ->
            printfn $"   FormatException: Unable to convert '{dateString}'"

parseWithISO8601 dateStrings DateTimeStyles.None
printfn "\n-----\n"
parseWithISO8601 dateStrings DateTimeStyles.AllowWhiteSpaces
printfn "\n-----\n"
parseWithISO8601 dateStrings DateTimeStyles.AdjustToUniversal
printfn "\n-----\n"
parseWithISO8601 dateStrings DateTimeStyles.AssumeLocal
printfn "\n-----\n"
parseWithISO8601 dateStrings DateTimeStyles.AssumeUniversal


// The example displays the following output:
//      Parsing with None:
//         2018-08-18T12:45:16.0000000Z        --> 2018-08-18 12:45:16 +00:00
//         FormatException: Unable to convert '2018/08/18T12:45:16.0000000Z'
//         FormatException: Unable to convert '2018-18-08T12:45:16.0000000Z'
//         2018-08-18T12:45:16.0000000         --> 2018-08-18 12:45:16 -07:00
//         FormatException: Unable to convert ' 2018-08-18T12:45:16.0000000Z '
//         2018-08-18T12:45:16.0000000+02:00   --> 2018-08-18 12:45:16 +02:00
//         2018-08-18T12:45:16.0000000-07:00   --> 2018-08-18 12:45:16 -07:00
//
//      -----
//
//      Parsing with AllowWhiteSpaces:
//         2018-08-18T12:45:16.0000000Z        --> 2018-08-18 12:45:16 +00:00
//         FormatException: Unable to convert '2018/08/18T12:45:16.0000000Z'
//         FormatException: Unable to convert '2018-18-08T12:45:16.0000000Z'
//         2018-08-18T12:45:16.0000000         --> 2018-08-18 12:45:16 -07:00
//         2018-08-18T12:45:16.0000000Z       --> 2018-08-18 12:45:16 +00:00
//         2018-08-18T12:45:16.0000000+02:00   --> 2018-08-18 12:45:16 +02:00
//         2018-08-18T12:45:16.0000000-07:00   --> 2018-08-18 12:45:16 -07:00
//
//      -----
//
//      Parsing with AdjustToUniversal:
//         2018-08-18T12:45:16.0000000Z        --> 2018-08-18 12:45:16 +00:00
//         FormatException: Unable to convert '2018/08/18T12:45:16.0000000Z'
//         FormatException: Unable to convert '2018-18-08T12:45:16.0000000Z'
//         2018-08-18T12:45:16.0000000         --> 2018-08-18 19:45:16 +00:00
//         FormatException: Unable to convert ' 2018-08-18T12:45:16.0000000Z '
//         2018-08-18T12:45:16.0000000+02:00   --> 2018-08-18 10:45:16 +00:00
//         2018-08-18T12:45:16.0000000-07:00   --> 2018-08-18 19:45:16 +00:00
//
//      -----
//
//      Parsing with AssumeLocal:
//         2018-08-18T12:45:16.0000000Z        --> 2018-08-18 12:45:16 +00:00
//         FormatException: Unable to convert '2018/08/18T12:45:16.0000000Z'
//         FormatException: Unable to convert '2018-18-08T12:45:16.0000000Z'
//         2018-08-18T12:45:16.0000000         --> 2018-08-18 12:45:16 -07:00
//         FormatException: Unable to convert ' 2018-08-18T12:45:16.0000000Z '
//         2018-08-18T12:45:16.0000000+02:00   --> 2018-08-18 12:45:16 +02:00
//         2018-08-18T12:45:16.0000000-07:00   --> 2018-08-18 12:45:16 -07:00
//
//      -----
//
//      Parsing with AssumeUniversal:
//         2018-08-18T12:45:16.0000000Z        --> 2018-08-18 12:45:16 +00:00
//         FormatException: Unable to convert '2018/08/18T12:45:16.0000000Z'
//         FormatException: Unable to convert '2018-18-08T12:45:16.0000000Z'
//         2018-08-18T12:45:16.0000000         --> 2018-08-18 12:45:16 +00:00
//         FormatException: Unable to convert ' 2018-08-18T12:45:16.0000000Z '
//         2018-08-18T12:45:16.0000000+02:00   --> 2018-08-18 12:45:16 +02:00
//         2018-08-18T12:45:16.0000000-07:00   --> 2018-08-18 12:45:16 -07:00