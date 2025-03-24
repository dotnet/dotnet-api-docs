open System

// <Snippet1>
let date1 = DateTime(2009, 8, 1, 0, 0, 0)
let date2 = DateTime(2009, 8, 1, 12, 0, 0)
let result = DateTime.Compare(date1, date2)

let relationship =
    if result < 0 then
        "is earlier than"
    elif result = 0 then
        "is the same time as"
    else
        "is later than"

printfn $"{date1} {relationship} {date2}"

// The example displays the following output for en-us culture:
//    8/1/2009 12:00:00 AM is earlier than 8/1/2009 12:00:00 PM
// </Snippet1>