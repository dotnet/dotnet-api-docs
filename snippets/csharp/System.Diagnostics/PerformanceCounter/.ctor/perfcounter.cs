using System;
using System.Diagnostics;

// <snippet1>
using PerformanceCounter performanceCounter = new PerformanceCounter();
performanceCounter.CategoryName = "Process";
performanceCounter.CounterName = "Private Bytes";
performanceCounter.InstanceName = "Explorer";
Console.WriteLine(performanceCounter.NextValue());
// </snippet1>

// <snippet2>
PerformanceCounterCategory[] performanceCounterCategories = PerformanceCounterCategory.GetCategories();
Console.WriteLine($"The number of performance counter categories on the local computer is {performanceCounterCategories.Length}");
// </snippet2>
