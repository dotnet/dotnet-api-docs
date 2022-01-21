// <Snippet1>
open System

[ 1994..2014 ]
|> List.filter DateTime.IsLeapYear
|> List.iter (fun year ->
    printfn $"{year} is a leap year."
    let leapDay = DateTime(year, 2, 29)
    let nextYear = leapDay.AddYears 1
    printfn $"   One year from {leapDay:d} is {nextYear:d}.")

// The example produces the following output:
//       1996 is a leap year.
//          One year from 2/29/1996 is 2/28/1997.
//       2000 is a leap year.
//          One year from 2/29/2000 is 2/28/2001.
//       2004 is a leap year.
//          One year from 2/29/2004 is 2/28/2005.
//       2008 is a leap year.
//          One year from 2/29/2008 is 2/28/2009.
//       2012 is a leap year.
//          One year from 2/29/2012 is 2/28/2013.
// </Snippet1>
