// <Snippet6>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = "(-)";
      string input = "apple-apricot-plum-pear-pomegranate-pineapple-peach";

      // Split on hyphens from 15th character on
      Regex regex = new Regex(pattern);    
      // Split on hyphens from 15th character on
      string[] substrings = regex.Split(input, 4, 15);
      foreach (string match in substrings)
      {
         Console.WriteLine("'{0}'", match);
      }
   }
}
// The method writes the following to the console:
//    'apple-apricot-plum'
//    '-'
//    'pear'
//    '-'
//    'pomegranate'
//    '-'
//    'pineapple-peach'
// </Snippet6>