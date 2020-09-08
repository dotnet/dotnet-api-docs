﻿// <Snippet1>
 using System;
 using System.Globalization;

public class MainClass {
    public static void Main(string[] args)  {
        DateTime dt = DateTime.Now;
        String[] format = {
            "d", "D",
            "f", "F",
            "g", "G",
            "m",
            "r",
            "s",
            "t", "T",
            "u", "U",
            "y",
            "dddd, MMMM dd yyyy",
            "ddd, MMM d \"'\"yy",
            "dddd, MMMM dd",
            "M/yy",
            "dd-MM-yy",
        };
        String date;
        for (int i = 0; i < format.Length; i++) {
            date = dt.ToString(format[i], DateTimeFormatInfo.InvariantInfo);
            Console.WriteLine(String.Concat(format[i], " :" , date));
        }

   /** Output.
    *
    * d :08/17/2000
    * D :Thursday, August 17, 2000
    * f :Thursday, August 17, 2000 16:32
    * F :Thursday, August 17, 2000 16:32:32
    * g :08/17/2000 16:32
    * G :08/17/2000 16:32:32
    * m :August 17
    * r :Thu, 17 Aug 2000 23:32:32 GMT
    * s :2000-08-17T16:32:32
    * t :16:32
    * T :16:32:32
    * u :2000-08-17 23:32:32Z
    * U :Thursday, August 17, 2000 23:32:32
    * y :August, 2000
    * dddd, MMMM dd yyyy :Thursday, August 17 2000
    * ddd, MMM d "'"yy :Thu, Aug 17 '00
    * dddd, MMMM dd :Thursday, August 17
    * M/yy :8/00
    * dd-MM-yy :17-08-00
    */
    }
}
// </Snippet1>
