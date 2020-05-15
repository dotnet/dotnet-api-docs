﻿using System;

public class Example
{
   public static void Main()
   {
      // <Snippet3>
      Random rnd = new Random();
      string[] malePetNames = { "Rufus", "Bear", "Dakota", "Fido",
                                "Vanya", "Samuel", "Koani", "Volodya",
                                "Prince", "Yiska" };
      string[] femalePetNames = { "Maggie", "Penny", "Saya", "Princess",
                                  "Abby", "Laila", "Sadie", "Olivia",
                                  "Starlight", "Talla" };

      // Generate random indexes for pet names.
      int mIndex = rnd.Next(malePetNames.Length);
      int fIndex = rnd.Next(femalePetNames.Length);

      // Display the result.
      Console.WriteLine("Suggested pet name of the day: ");
      Console.WriteLine("   For a male:     {0}", malePetNames[mIndex]);
      Console.WriteLine("   For a female:   {0}", femalePetNames[fIndex]);

      // The example displays the following output:
      //       Suggested pet name of the day:
      //          For a male:     Koani
      //          For a female:   Maggie
      // </Snippet3>
   }
}
