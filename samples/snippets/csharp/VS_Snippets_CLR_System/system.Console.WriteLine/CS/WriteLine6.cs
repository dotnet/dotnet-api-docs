using System;

public class Example
{
   public static void Main()
   {
      // <Snippet6>
      Random rnd = new Random();
      // Generate five random Boolean values.
      for (int ctr = 1; ctr <= 5; ctr++) {
         bool bln = rnd.Next(0, 2) == 1;
         Console.WriteLine($"True or False: {bln}");
      }

      // The example displays an output similar to the following:
      //       True or False: False
      //       True or False: True
      //       True or False: False
      //       True or False: False
      //       True or False: True
      // </Snippet6>
   }
}
