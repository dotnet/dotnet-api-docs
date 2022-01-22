﻿using System;

public class Example
{
   public static void Main()
   {
      // <Snippet1>
      // Define an interval of 3 days, 16+ hours.
      TimeSpan interval = new TimeSpan(3, 16, 42, 45, 750); 
      Console.WriteLine("Value of TimeSpan: {0}", interval);
      
      Console.WriteLine("{0:N5} days, as follows:", interval.TotalDays);
      Console.WriteLine("   Days:         {0,3}", interval.Days);
      Console.WriteLine("   Hours:        {0,3}", interval.Hours);
      Console.WriteLine("   Minutes:      {0,3}", interval.Minutes);
      Console.WriteLine("   Seconds:      {0,3}", interval.Seconds);
      Console.WriteLine("   Milliseconds: {0,3}", interval.Milliseconds);

      // The example displays the following output:
      //       Value of TimeSpan: 3.16:42:45.7500000
      //       3.69636 days, as follows:
      //          Days:           3
      //          Hours:         16
      //          Minutes:       42
      //          Seconds:       45
      //          Milliseconds: 750
      // </Snippet1>
   }
}
