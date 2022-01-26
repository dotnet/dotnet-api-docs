module Parse5

open System
open System.Globalization

// <Snippet5>
let formattedDates = 
    [ "2008-09-15T09:30:41.7752486-07:00"
      "2008-09-15T09:30:41.7752486Z"
      "2008-09-15T09:30:41.7752486"
      "2008-09-15T09:30:41.7752486-04:00"
      "Mon, 15 Sep 2008 09:30:41 GMT" ]

for formattedDate in formattedDates do
    printfn $"{formattedDate}"
    let roundtripDate = DateTime.Parse(formattedDate, null, DateTimeStyles.RoundtripKind)
    printfn $"   With RoundtripKind flag: {roundtripDate} {roundtripDate.Kind} time."

    let noRoundtripDate = DateTime.Parse(formattedDate, null, DateTimeStyles.None)
    printfn $"   Without RoundtripKind flag: {noRoundtripDate} {noRoundtripDate.Kind} time."

// The example displays the following output:
//       2008-09-15T09:30:41.7752486-07:00
//          With RoundtripKind flag: 9/15/2008 9:30:41 AM Local time.
//          Without RoundtripKind flag: 9/15/2008 9:30:41 AM Local time.
//       2008-09-15T09:30:41.7752486Z
//          With RoundtripKind flag: 9/15/2008 9:30:41 AM Utc time.
//          Without RoundtripKind flag: 9/15/2008 2:30:41 AM Local time.
//       2008-09-15T09:30:41.7752486
//          With RoundtripKind flag: 9/15/2008 9:30:41 AM Unspecified time.
//          Without RoundtripKind flag: 9/15/2008 9:30:41 AM Unspecified time.
//       2008-09-15T09:30:41.7752486-04:00
//          With RoundtripKind flag: 9/15/2008 6:30:41 AM Local time.
//          Without RoundtripKind flag: 9/15/2008 6:30:41 AM Local time.
//       Mon, 15 Sep 2008 09:30:41 GMT
//          With RoundtripKind flag: 9/15/2008 9:30:41 AM Utc time.
//          Without RoundtripKind flag: 9/15/2008 2:30:41 AM Local time.
// </Snippet5>