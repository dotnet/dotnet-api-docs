﻿using System;

public class Example
{
   public static void Main()
   {
      // <Snippet1>
      TimeSpan baseTimeSpan = new TimeSpan(1, 12, 15, 16);

      // Create an array of timespan intervals.
      TimeSpan[] intervals = { 
         TimeSpan.FromDays(1.5), 
         TimeSpan.FromHours(1.5), 
         TimeSpan.FromMinutes(45), 
         TimeSpan.FromMilliseconds(505),
         new TimeSpan(1, 17, 32, 20), 
         new TimeSpan(-8, 30, 0) 
      };

      // Calculate a new time interval by adding each element to the base interval.
      foreach (var interval in intervals)
         Console.WriteLine(@"{0,-10:g} {3} {1,15:%d\:hh\:mm\:ss\.ffff} = {2:%d\:hh\:mm\:ss\.ffff}", 
                           baseTimeSpan, interval, baseTimeSpan.Add(interval), 
                           interval < TimeSpan.Zero ? "-" : "+");

      // The example displays the following output:
      //       1:12:15:16 + 1:12:00:00.0000 = 3:00:15:16.0000
      //       1:12:15:16 + 0:01:30:00.0000 = 1:13:45:16.0000
      //       1:12:15:16 + 0:00:45:00.0000 = 1:13:00:16.0000
      //       1:12:15:16 + 0:00:00:00.5050 = 1:12:15:16.5050
      //       1:12:15:16 + 1:17:32:20.0000 = 3:05:47:36.0000
      //       1:12:15:16 - 0:07:30:00.0000 = 1:04:45:16.0000
      // </Snippet1>
   }
}
