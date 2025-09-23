// <Snippet4>
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class Example19
{
    static object s_randLock, s_numericLock;
    static Random s_rand;
    static CancellationTokenSource s_source;
    double _totalValue = 0.0;
    int _totalCount = 0;

    public Example19()
    {
        s_rand = new Random();
        s_randLock = new object();
        s_numericLock = new object();
        s_source = new CancellationTokenSource();
    }

    public static async Task Main()
    {
        Example19 ex = new();
        Thread.CurrentThread.Name = "Main";
        await ex.Execute();
    }

    private async Task Execute()
    {
        List<Task> tasks = [];

        for (int ctr = 0; ctr <= 10; ctr++)
        {
            CancellationToken token = s_source.Token;
            int taskNo = ctr;
            tasks.Add(Task.Run(() =>
               {
                   double previous = 0.0;
                   int taskCtr = 0;
                   double taskTotal = 0.0;
                   double result = 0.0;

                   for (int n = 0; n < 2000000; n++)
                   {
                       // Make sure there's no corruption of Random.
                       token.ThrowIfCancellationRequested();

                       lock (s_randLock)
                       {
                           result = s_rand.NextDouble();
                       }
                       // Check for corruption of Random instance.
                       if ((result == previous) && result == 0)
                       {
                           s_source.Cancel();
                       }
                       else
                       {
                           previous = result;
                       }
                       taskCtr++;
                       taskTotal += result;
                   }

                   // Show result.
                   Console.WriteLine("Task {0} finished execution.", taskNo);
                   Console.WriteLine("Random numbers generated: {0:N0}", taskCtr);
                   Console.WriteLine("Sum of random numbers: {0:N2}", taskTotal);
                   Console.WriteLine("Random number mean: {0:N4}\n", taskTotal / taskCtr);

                   // Update overall totals.
                   lock (s_numericLock)
                   {
                       _totalCount += taskCtr;
                       _totalValue += taskTotal;
                   }
               },
            token));
        }
        try
        {
            await Task.WhenAll(tasks.ToArray());
            Console.WriteLine($"\nTotal random numbers generated: {_totalCount:N0}");
            Console.WriteLine($"Total sum of all random numbers: {_totalValue:N2}");
            Console.WriteLine($"Random number mean: {_totalValue / _totalCount:N4}");
        }
        catch (AggregateException e)
        {
            foreach (Exception inner in e.InnerExceptions)
            {
                if (inner is TaskCanceledException canc)
                    Console.WriteLine("Task #{0} cancelled.", canc.Task.Id);
                else
                    Console.WriteLine("Exception: {0}", inner.GetType().Name);
            }
        }
        finally
        {
            s_source.Dispose();
        }
    }
}

// The example displays output like the following:
//       Task 1 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 1,000,502.47
//       Random number mean: 0.5003
//
//       Task 0 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 1,000,445.63
//       Random number mean: 0.5002
//
//       Task 2 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 1,000,556.04
//       Random number mean: 0.5003
//
//       Task 3 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 1,000,178.87
//       Random number mean: 0.5001
//
//       Task 4 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,819.17
//       Random number mean: 0.4999
//
//       Task 5 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 1,000,190.58
//       Random number mean: 0.5001
//
//       Task 6 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,720.21
//       Random number mean: 0.4999
//
//       Task 7 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,000.96
//       Random number mean: 0.4995
//
//       Task 8 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,499.33
//       Random number mean: 0.4997
//
//       Task 9 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 1,000,193.25
//       Random number mean: 0.5001
//
//       Task 10 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,960.82
//       Random number mean: 0.5000
//
//
//       Total random numbers generated: 22,000,000
//       Total sum of all random numbers: 11,000,067.33
//       Random number mean: 0.5000
// </Snippet4>
