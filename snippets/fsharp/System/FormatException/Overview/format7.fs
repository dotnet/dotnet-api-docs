module format7

open System

// <Snippet7>
let birthdate = DateTime(1993, 7, 28)
let dates = 
    [ DateTime(1993, 8, 16) 
      DateTime(1994, 7, 28)
      DateTime(2000, 10, 16)
      DateTime(2003, 7, 27)
      DateTime(2007, 5, 27) ]

for dateValue in dates do
    let interval = dateValue - birthdate
    // Get the approximate number of years, without accounting for leap years.
    let years = (int interval.TotalDays) / 365
    // See if adding the number of years exceeds dateValue.
    if birthdate.AddYears years <= dateValue then
        String.Format("You are now {0} years old.", years)
    else
        String.Format("You are now {0} years old.", years - 1)
    |> printfn "%s"
// The example displays the following output:
//       You are now 0 years old.
//       You are now 1 years old.
//       You are now 7 years old.
//       You are now 9 years old.
//       You are now 13 years old.
// </Snippet7>