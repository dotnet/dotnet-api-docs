﻿// <Snippet2>
using System;
using System.Text;

public class Example
{
   public static void Main()
   {
      int uppercaseStart = 0x0041;
      int uppercaseEnd = 0x005a;
      int lowercaseStart = 0x0061;
      int lowercaseEnd = 0x007a;
      // Instantiate a UTF8 encoding object with BOM support.
      Encoding utf8 = new UTF8Encoding(true);

      // Populate array with characters.
      char[] chars = new char[lowercaseEnd - lowercaseStart + uppercaseEnd - uppercaseStart + 2];
      int index = 0;
      for (int ctr = uppercaseStart; ctr <= uppercaseEnd; ctr++) {
         chars[index] = (char)ctr;
         index++;
      }
      for (int ctr = lowercaseStart; ctr <= lowercaseEnd; ctr++) {
         chars[index] = (char)ctr;
         index++;
      }

      // Display the bytes needed for the lowercase characters.
      Console.WriteLine("Bytes needed for lowercase Latin characters:");
      Console.WriteLine("   Maximum:         {0,5:N0}",
                        utf8.GetMaxByteCount(lowercaseEnd - lowercaseStart + 1));
      Console.WriteLine("   Actual:          {0,5:N0}",
                        utf8.GetByteCount(chars, uppercaseEnd - uppercaseStart + 1,
                                          lowercaseEnd - lowercaseStart + 1));
      Console.WriteLine("   Actual with BOM: {0,5:N0}",
                        utf8.GetByteCount(chars, uppercaseEnd - uppercaseStart + 1,
                                          lowercaseEnd - lowercaseStart + 1) +
                                          utf8.GetPreamble().Length);
   }
}
// The example displays the following output:
//       Bytes needed for lowercase Latin characters:
//          Maximum:            81
//          Actual:             26
//          Actual with BOM:    29
// </Snippet2>
