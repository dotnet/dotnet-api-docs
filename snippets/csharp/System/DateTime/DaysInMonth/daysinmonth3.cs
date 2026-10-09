// <Snippet1>
using System;
using System.Globalization;

public class Example
{
    public static void Main()
    {
        int[] years = { 2012, 2014 };
        DateTimeFormatInfo dtfi = DateTimeFormatInfo.CurrentInfo;
        Console.WriteLine("Days in the Month for the {0} culture " +
                          "using the {1} calendar\n",
                          CultureInfo.CurrentCulture.Name,
                          dtfi.Calendar.GetType().Name.Replace("Calendar", ""));
        Console.WriteLine($"{"Year",-10}{"Month",-15}{"Days",4}\n");

        foreach (int year in years)
        {
            for (int ctr = 0; ctr <= dtfi.MonthNames.Length - 1; ctr++)
            {
                if (string.IsNullOrEmpty(dtfi.MonthNames[ctr]))
                    continue;

                Console.WriteLine($"{year,-10}{dtfi.MonthNames[ctr],-15}{DateTime.DaysInMonth(year, ctr + 1),4}");
            }
            Console.WriteLine();
        }
    }
}
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
