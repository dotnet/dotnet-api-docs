﻿// <Snippet13>
using System;

public class Example
{
   public static void Main()
   {
      int position = 0;

      string s1 = "ani\u00ADmal";
      string s2 = "animal";
      
      // All the following comparisons are culture-sensitive.
      Console.WriteLine("Culture-sensitive comparisons:"); 
      // Find the index of the soft hyphen.
      position = s1.IndexOf("n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(s1.IndexOf("\u00AD", position, 
                           s1.Length - position, StringComparison.CurrentCulture));

      position = s2.IndexOf("n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(s2.IndexOf("\u00AD", position, 
                           s2.Length - position, StringComparison.CurrentCulture));
      
      // Find the index of the soft hyphen followed by "n".
      position = s1.IndexOf("n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(s1.IndexOf("\u00ADn", position, 
                           s1.Length - position, StringComparison.CurrentCultureIgnoreCase));

      position = s2.IndexOf("n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(s2.IndexOf("\u00ADn", position, 
                           s2.Length - position, StringComparison.CurrentCultureIgnoreCase));
      
      // Find the index of the soft hyphen followed by "m".
      position = s1.IndexOf("n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(s1.IndexOf("\u00ADm", position, 
                           s1.Length - position, StringComparison.CurrentCultureIgnoreCase));

      position = s2.IndexOf("n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(s2.IndexOf("\u00ADm", position, 
                           s2.Length - position, StringComparison.CurrentCultureIgnoreCase));

      // All the following comparisons are ordinal.
      Console.WriteLine("\nOrdinal comparisons:"); 
      // Find the index of the soft hyphen.
      position = s1.IndexOf("n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(s1.IndexOf("\u00AD", position, 
                           s1.Length - position, StringComparison.Ordinal));

      position = s2.IndexOf("n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(s2.IndexOf("\u00AD", position, 
                           s2.Length - position, StringComparison.Ordinal));
      
      // Find the index of the soft hyphen followed by "n".
      position = s1.IndexOf("n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(s1.IndexOf("\u00ADn", position, 
                           s1.Length - position, StringComparison.Ordinal));

      position = s2.IndexOf("n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(s2.IndexOf("\u00ADn", position, 
                           s2.Length - position, StringComparison.Ordinal));
      
      // Find the index of the soft hyphen followed by "m".
      position = s1.IndexOf("n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(s1.IndexOf("\u00ADm", position, 
                           s1.Length - position, StringComparison.Ordinal));

      position = s2.IndexOf("n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(s2.IndexOf("\u00ADm", position, 
                           s2.Length - position, StringComparison.Ordinal));
   }
}
// The example displays the following output:
//       Culture-sensitive comparisons:
//       'n' at position 1
//       1
//       'n' at position 1
//       1
//       'n' at position 1
//       1
//       'n' at position 1
//       1
//       'n' at position 1
//       4
//       'n' at position 1
//       3
//
//       Ordinal comparisons:
//       'n' at position 1
//       3
//       'n' at position 1
//       -1
//       'n' at position 1
//       -1
//       'n' at position 1
//       -1
//       'n' at position 1
//       3
//       'n' at position 1
//       -1
// </Snippet13>
