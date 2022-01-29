﻿// <Snippet9>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = "a*";
      string input = "abaabb";
      
      foreach (Match m in Regex.Matches(input, pattern)) 
         Console.WriteLine("'{0}' found at index {1}.", 
                           m.Value, m.Index);
   }
}
// The example displays the following output:
//       'a' found at index 0.
//       '' found at index 1.
//       'aa' found at index 2.
//       '' found at index 4.
//       '' found at index 5.
//       '' found at index 6.
// </Snippet9>
