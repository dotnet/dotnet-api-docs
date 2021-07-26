// <Snippet17>
using System;

public class Example
{
   public static void Main()
   {
      String[] phrases = { "ocean blue", "concerned citizen",
                           "runOnPhrase" };
      foreach (var phrase in phrases)
         Console.WriteLine("Second word is {0}", GetSecondWord(phrase));
   }

   static string GetSecondWord(string s)
   {
      int pos = s.IndexOf(" ");
      return s.Substring(pos).Trim();
   }
}
// The example displays the following output:
//    Second word is blue
//    Second word is citizen
//
//    Unhandled Exception: System.ArgumentOutOfRangeException: StartIndex cannot be less than zero.
//    Parameter name: startIndex
//       at System.String.Substring(int startIndex, int length)
//       at Example.GetSecondWord(string s)
//       at Example.Main()
// </Snippet17>
