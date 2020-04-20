﻿using System;

public class Class1
{
    public static void Main()
    {
      // <Snippet1>
      DateTime date1 = new DateTime(2008, 1, 1, 0, 30, 45, 125);
      Console.WriteLine("Milliseconds: {0:fff}",
                        date1);           // displays Milliseconds: 125
      // </Snippet1>

      // <Snippet2>
      DateTime date2 = new DateTime(2008, 1, 1, 0, 30, 45, 125);
      Console.WriteLine("Date: {0:o}",
                        date2);
      // Displays the following output to the console:
      //      Date: 2008-01-01T00:30:45.1250000
      // </Snippet2>

      // <Snippet3>
      DateTime date3 = new DateTime(2008, 1, 1, 0, 30, 45, 125);
      Console.WriteLine("Date with milliseconds: {0:MM/dd/yyy HH:mm:ss.fff}",
                        date3);
      // Displays the following output to the console:
      //       Date with milliseconds: 01/01/2008 00:30:45.125
      // </Snippet3>
    }
}
