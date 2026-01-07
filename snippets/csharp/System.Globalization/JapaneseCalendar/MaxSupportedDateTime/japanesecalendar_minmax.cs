// The following code example gets the minimum date and the maximum date of the calendar.

using System;
using System.Globalization;

// <snippet1>
// Create an instance of the calendar.
JapaneseCalendar myCal = new();
Console.WriteLine(myCal.ToString());

// Create an instance of the GregorianCalendar.
GregorianCalendar myGre = new();

// Display the MinSupportedDateTime and its equivalent in the GregorianCalendar.
DateTime myMin = myCal.MinSupportedDateTime;
Console.Write(
    "MinSupportedDateTime: {0:D2}/{1:D2}/{2:D4}",
    myCal.GetMonth(myMin),
    myCal.GetDayOfMonth(myMin),
    myCal.GetYear(myMin));
Console.WriteLine(
    " (in Gregorian, {0:D2}/{1:D2}/{2:D4})",
    myGre.GetMonth(myMin),
    myGre.GetDayOfMonth(myMin),
    myGre.GetYear(myMin));

// Display the MaxSupportedDateTime and its equivalent in the GregorianCalendar.
DateTime myMax = myCal.MaxSupportedDateTime;
Console.Write(
    "MaxSupportedDateTime: {0:D2}/{1:D2}/{2:D4}",
    myCal.GetMonth(myMax),
    myCal.GetDayOfMonth(myMax),
    myCal.GetYear(myMax));
Console.WriteLine(
    " (in Gregorian, {0:D2}/{1:D2}/{2:D4})",
    myGre.GetMonth(myMax),
    myGre.GetDayOfMonth(myMax),
    myGre.GetYear(myMax));

/*
This code produces the following output on .NET 11.

System.Globalization.JapaneseCalendar
MinSupportedDateTime: 10/23/0001 (in Gregorian, 10/23/1868)
MaxSupportedDateTime: 12/31/7981 (in Gregorian, 12/31/9999)

*/
// </snippet1>
