﻿// <Snippet1>
using System;

public class StringParsing
{
   public static void Main()
   {
      TryToParse(null);
      TryToParse("160519");
      TryToParse("9432.0");
      TryToParse("16,667");
      TryToParse("   -322   ");
      TryToParse("+4302");
      TryToParse("(100);");
      TryToParse("01FA");
   }

   private static void TryToParse(string value)
   {
      bool success = Int64.TryParse(value, out long number);
      if (success)
      {
         Console.WriteLine("Converted '{0}' to {1}.", value, number);
      }
      else
      {
         if (value == null) value = "";
         Console.WriteLine("Attempted conversion of '{0}' failed.", value);
      }
   }
}
// The example displays the following output to the console:
//       Attempted conversion of '' failed.
//       Converted '160519' to 160519.
//       Attempted conversion of '9432.0' failed.
//       Attempted conversion of '16,667' failed.
//       Converted '   -322   ' to -322.
//       Converted '+4302' to 4302.
//       Attempted conversion of '(100);' failed.
//       Attempted conversion of '01FA' failed.
// </Snippet1>
