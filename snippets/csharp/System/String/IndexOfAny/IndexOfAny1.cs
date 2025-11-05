using System;

public class Example1
{
   public static void Run()
   {
      // <Snippet1>
      char[] chars = { 'a', 'e', 'i', 'o', 'u', 'y',
                       'A', 'E', 'I', 'O', 'U', 'Y' };
      String s = "The long and winding road...";
      Console.WriteLine($"""
         The first vowel in
         '{s}'
         is found at index {s.IndexOfAny(chars)}
         """);

      // The example displays the following output:
      //       The first vowel in
      //       'The long and winding road...'
      //       is found at index 2
      // </Snippet1>
   }
}
