using System.Diagnostics;

public class Snippet
{
    public static void Run()
    {
        // <Snippet1>
        if (!PerformanceCounterCategory.Exists("Orders"))
        {
            CounterCreationData milk = new()
            {
                CounterName = "milk",
                CounterType = PerformanceCounterType.NumberOfItems32
            };
            CounterCreationData milkPerSecond = new()
            {
                CounterName = "milk orders/second",
                CounterType = PerformanceCounterType.RateOfCountsPerSecond32
            };
            CounterCreationDataCollection counterData = new()
            {
                milkPerSecond,
                milk
            };

            PerformanceCounterCategory.Create(
                "Orders",
                "Number of processed orders",
                PerformanceCounterCategoryType.SingleInstance,
                counterData);
        }
        // </Snippet1>
    }
}
