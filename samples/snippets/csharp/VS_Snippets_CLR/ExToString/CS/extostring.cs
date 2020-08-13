﻿//<Snippet1>
using System;

public class TestClass
{}

public class Example
{
   public static void Main()
   {
      var test = new TestClass();
      Object[] objectsToCompare = { test, test.ToString(), 123,
                                    123.ToString(), "some text",
                                    "Some Text" };
      string s = "some text";
      foreach (var objectToCompare in objectsToCompare) {
         try {
            int i = s.CompareTo(objectToCompare);
            Console.WriteLine("Comparing '{0}' with '{1}': {2}",
                              s, objectToCompare, i);
         }
         catch (ArgumentException) {
            Console.WriteLine("Bad argument: {0} (type {1})",
                              objectToCompare,
                              objectToCompare.GetType().Name);
         }
      }
   }
}
// The example displays the following output:
//    Bad argument: TestClass (type TestClass)
//    Comparing 'some text' with 'TestClass': -1
//    Bad argument: 123 (type Int32)
//    Comparing 'some text' with '123': 1
//    Comparing 'some text' with 'some text': 0
//    Comparing 'some text' with 'Some Text': -1
//</Snippet1>