﻿// <Snippet4>
using System;
using System.Collections.Generic;

public class Example4
{
   public static void Main()
   {
      var list = new List<string>();
      Console.WriteLine("Number of items: {0}", list.Count);
      try {
         Console.WriteLine("The first item: '{0}'", list[0]);
      }
      catch (ArgumentOutOfRangeException e) {
         Console.WriteLine(e.Message);
      }
   }
}
// The example displays the following output:
//   Number of items: 0
//   Index was out of range. Must be non-negative and less than the size of the collection.
//   Parameter name: index
// </Snippet4>

public class Example5
{
   public static void Test()
   {
      var list = new List<string>();
      Console.WriteLine("Number of items: {0}", list.Count);
      // <Snippet5>
      if (list.Count > 0)
         Console.WriteLine("The first item: '{0}'", list[0]);
      // </Snippet5>
   }
}
