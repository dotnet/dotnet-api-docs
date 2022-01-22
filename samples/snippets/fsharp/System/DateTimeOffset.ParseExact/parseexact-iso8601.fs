module parseexact_iso8601

open System

let dateStrings =
    [ "2018-08-18T12:45:16.0000000Z"
      "2018/08/18T12:45:16.0000000Z"
      "2018-18-08T12:45:16.0000000Z"
      " 2018-08-18T12:45:16.0000000Z "
      "2018-08-18T12:45:16.0000000+02:00"
      "2018-08-18T12:45:16.0000000-07:00" ]

for dateString in dateStrings do
    try
        let date =
            DateTimeOffset.ParseExact(dateString, "O", null)

        printfn $"""{dateString, -35} --> {date.ToString "yyyy-MM-dd HH:mm:ss.FF zzz"}"""
    with :? FormatException -> printfn $"FormatException: Unable to convert '{dateString}'"


// The example displays the following output:
//      2018-08-18T12:45:16.0000000Z        --> 2018-08-18 12:45:16 +00:00
//      FormatException: Unable to convert '2018/08/18T12:45:16.0000000Z'
//      FormatException: Unable to convert '2018-18-08T12:45:16.0000000Z'
//      FormatException: Unable to convert ' 2018-08-18T12:45:16.0000000Z '
//      2018-08-18T12:45:16.0000000+02:00   --> 2018-08-18 12:45:16 +02:00
//      2018-08-18T12:45:16.0000000-07:00   --> 2018-08-18 12:45:16 -07:00
