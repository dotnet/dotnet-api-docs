using System;

public class Class1
{
   public static void Main()
   {
      // <Snippet1>
      long[] numbersToConvert = {162345, 32183, -54000};
      short newNumber;
      foreach (long number in numbersToConvert)
      {
         if (number >= Int16.MinValue && number <= Int16.MaxValue)
         {
            newNumber = Convert.ToInt16(number);
            Console.WriteLine($"Successfully converted {newNumber} to an Int16.");
         }
         else
         {
            Console.WriteLine($"Unable to convert {number} to an Int16.");
         }
      }
      // The example displays the following output to the console:
      //       Unable to convert 162345 to an Int16.
      //       Successfully converted 32183 to an Int16.
      //       Unable to convert -54000 to an Int16.
      // </Snippet1>
   }
}
