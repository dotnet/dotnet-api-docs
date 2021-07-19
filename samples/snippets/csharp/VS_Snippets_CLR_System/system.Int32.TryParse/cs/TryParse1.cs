// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      string[] values = { null, "160519", "9432.0", "16,667",
                          "   -322   ", "+4302", "(100);", "01FA" };
      foreach (var value in values)
      {
         int number;

         bool success = int.TryParse(value, out number);
         if (success)
         {
            Console.WriteLine($"Converted '{value}' to {number}.");
         }
         else
         {
            Console.WriteLine($"Attempted conversion of '{value ?? "<null>"}' failed.");
         }
      }
   }
}
// The example displays the following output:
//       Attempted conversion of '<null>' failed.
//       Converted '160519' to 160519.
//       Attempted conversion of '9432.0' failed.
//       Attempted conversion of '16,667' failed.
//       Converted '   -322   ' to -322.
//       Converted '+4302' to 4302.
//       Attempted conversion of '(100);' failed.
//       Attempted conversion of '01FA' failed.
// </Snippet1>
