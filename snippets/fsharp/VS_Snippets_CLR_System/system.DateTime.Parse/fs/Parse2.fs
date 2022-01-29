module Parse2

// <Snippet2>
open System

let dateStrings = 
    [ "2008-05-01T07:34:42-5:00"
      "2008-05-01 7:34:42Z"
      "Thu, 01 May 2008 07:34:42 GMT" ]

for dateString in dateStrings do
    let convertedDate = DateTime.Parse dateString
    printfn $"Converted {dateString} to {convertedDate.Kind} time {convertedDate}"

// These calls to the DateTime.Parse method display the following output:
//  Converted 2008-05-01T07:34:42-5:00 to Local time 5/1/2008 5:34:42 AM
//  Converted 2008-05-01 7:34:42Z to Local time 5/1/2008 12:34:42 AM
//  Converted Thu, 01 May 2008 07:34:42 GMT to Local time 5/1/2008 12:34:42 AM
// </Snippet2>