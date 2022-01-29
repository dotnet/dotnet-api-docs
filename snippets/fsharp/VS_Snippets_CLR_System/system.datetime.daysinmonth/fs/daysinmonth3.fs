// <Snippet1>
open System
open System.Globalization

let years = [| 2012; 2014 |]
let dtfi = DateTimeFormatInfo.CurrentInfo
printfn $"""Days in the Month for the {CultureInfo.CurrentCulture.Name} culture using the {dtfi.Calendar.GetType().Name.Replace("Calendar", "")} calendar\n"""
printfn $"""{"Year",-10}{"Month",-15}{"Days",4}\n"""

for year in years do
    for i = 0 to dtfi.MonthNames.Length - 1 do
        if not (String.IsNullOrEmpty dtfi.MonthNames[i]) then
            printfn $"{year,-10}{dtfi.MonthNames[i],-15}{DateTime.DaysInMonth(year, i + 1),4}"
    printfn ""

// The example displays the following output:
//    Days in the Month for the en-US culture using the Gregorian calendar
//
//    Year      Month          Days
//
//    2012      January          31
//    2012      February         29
//    2012      March            31
//    2012      April            30
//    2012      May              31
//    2012      June             30
//    2012      July             31
//    2012      August           31
//    2012      September        30
//    2012      October          31
//    2012      November         30
//    2012      December         31
//
//    2014      January          31
//    2014      February         28
//    2014      March            31
//    2014      April            30
//    2014      May              31
//    2014      June             30
//    2014      July             31
//    2014      August           31
//    2014      September        30
//    2014      October          31
//    2014      November         30
//    2014      December         31
// </Snippet1>