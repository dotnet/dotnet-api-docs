// <Snippet1>
using System;

class Class1
{
    static void Main()
    {
        DateTime today = DateTime.Now;
        DateTime answer = today.AddDays(36);
        Console.WriteLine($"Today: {today:dddd}");
        Console.WriteLine($"36 days from today: {answer:dddd}");
    }
}
// The example displays output like the following:
//       Today: Wednesday
//       36 days from today: Thursday
// </Snippet1>
