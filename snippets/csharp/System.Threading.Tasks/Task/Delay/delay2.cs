﻿// <Snippet2>
using System;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      var t = Task.Run(async delegate
              {
                 await Task.Delay(TimeSpan.FromSeconds(1.5));
                 return 42;
              });
      t.Wait();
      Console.WriteLine("Task t Status: {0}, Result: {1}",
                        t.Status, t.Result);
   }
}
// The example displays the following output:
//        Task t Status: RanToCompletion, Result: 42
// </Snippet2>
