﻿// <Snippet6>
using System;

public class Example
{
   public static void Main()
   {
      string s1 = "ani\u00ADmal";
      string s2 = "animal";
      
      Console.WriteLine("Culture-sensitive comparison:");
      // Use culture-sensitive comparison to find the soft hyphen.
      Console.WriteLine(s1.IndexOf("\u00AD", StringComparison.CurrentCulture));
      Console.WriteLine(s2.IndexOf("\u00AD", StringComparison.CurrentCulture));
      
      // Use culture-sensitive comparison to find the soft hyphen followed by "n".
      Console.WriteLine(s1.IndexOf("\u00ADn", StringComparison.CurrentCulture));
      Console.WriteLine(s2.IndexOf("\u00ADn", StringComparison.CurrentCulture));
      
      // Use culture-sensitive comparison to find the soft hyphen followed by "m".
      Console.WriteLine(s1.IndexOf("\u00ADm", StringComparison.CurrentCulture));
      Console.WriteLine(s2.IndexOf("\u00ADm", StringComparison.CurrentCulture));
                          
      Console.WriteLine("Ordinal comparison:");
      // Use ordinal comparison to find the soft hyphen.
      Console.WriteLine(s1.IndexOf("\u00AD", StringComparison.Ordinal));
      Console.WriteLine(s2.IndexOf("\u00AD", StringComparison.Ordinal));
      
      // Use ordinal comparison to find the soft hyphen followed by "n".
      Console.WriteLine(s1.IndexOf("\u00ADn", StringComparison.Ordinal));
      Console.WriteLine(s2.IndexOf("\u00ADn", StringComparison.Ordinal));
      
      // Use ordinal comparison to find the soft hyphen followed by "m".
      Console.WriteLine(s1.IndexOf("\u00ADm", StringComparison.Ordinal));
      Console.WriteLine(s2.IndexOf("\u00ADm", StringComparison.Ordinal));
   }
}
// The example displays the following output:
//       Culture-sensitive comparison:
//       0
//       0
//       1
//       1
//       4
//       3
//       Ordinal comparison:
//       3
//       -1
//       -1
//       -1
//       3
//       -1
// </Snippet6>
