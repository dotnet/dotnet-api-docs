﻿// <Snippet17>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      CompareInfo ci = CultureInfo.CurrentCulture.CompareInfo;

      string searchString = "\u00ADm";
      string s1 = "ani\u00ADmal" ;
      string s2 = "animal";

      Console.WriteLine(ci.IndexOf(s1, searchString, 2, 4));
      Console.WriteLine(ci.IndexOf(s2, searchString, 2, 4));
   }
}
// The example displays the following output:
//       4
//       3
// </Snippet17>
