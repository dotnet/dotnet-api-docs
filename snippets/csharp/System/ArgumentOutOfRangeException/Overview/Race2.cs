﻿// <Snippet12>
using System;
using System.Collections.Concurrent;
using System.Threading;

public class ContinentD
{
   public string Name { get; set; }
   public int Population { get; set; }
   public Decimal Area { get; set; }
}

public class Example12
{
   static ConcurrentBag<ContinentD> ContinentDs = new ConcurrentBag<ContinentD>();
   static CountdownEvent gate;
   static string msg = string.Empty;

   public static void Main()
   {
      String[] names = { "Africa", "Antarctica", "Asia",
                         "Australia", "Europe", "North America",
                         "South America" };
      gate = new CountdownEvent(names.Length);

      // Populate the list.
      foreach (var name in names) {
         var th = new Thread(PopulateContinentDs);
         th.Start(name);
      }

      // Display the list.
      gate.Wait();
      Console.WriteLine(msg);
      Console.WriteLine();

      var arr = ContinentDs.ToArray();
      for (int ctr = 0; ctr < names.Length; ctr++) {
         var ContinentD = arr[ctr];
         Console.WriteLine("{0}: Area: {1}, Population {2}",
                           ContinentD.Name, ContinentD.Population,
                           ContinentD.Area);
      }
   }

   private static void PopulateContinentDs(Object obj)
   {
      string name = obj.ToString();
      lock(msg) {
         msg += string.Format("Adding '{0}' to the list.\n", name);
      }
      var ContinentD = new ContinentD();
      ContinentD.Name = name;
      // Sleep to simulate retrieving remaining data.
      Thread.Sleep(25);
      ContinentDs.Add(ContinentD);
      gate.Signal();
   }
}
// The example displays output like the following:
//       Adding 'Africa' to the list.
//       Adding 'Antarctica' to the list.
//       Adding 'Asia' to the list.
//       Adding 'Australia' to the list.
//       Adding 'Europe' to the list.
//       Adding 'North America' to the list.
//       Adding 'South America' to the list.
//
//
//       Africa: Area: 0, Population 0
//       Antarctica: Area: 0, Population 0
//       Asia: Area: 0, Population 0
//       Australia: Area: 0, Population 0
//       Europe: Area: 0, Population 0
//       North America: Area: 0, Population 0
//       South America: Area: 0, Population 0
// </Snippet12>
