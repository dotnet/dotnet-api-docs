// <Snippet7>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class Example
{
    private static CancellationTokenSource source = new CancellationTokenSource();
    private static volatile int completedIterations = 0;
    public static void Main()
    {
        var tasks = new List<Task<int>>();
        for (int n = 0; n <= 19; n++)
            tasks.Add(Task.Run(() => Counter(source.Token), source.Token));

        Console.WriteLine("Waiting for the first 10 tasks to complete...\n");
        try
        {
            Task.WaitAll(tasks.ToArray());
        }
        catch (AggregateException)
        {
            Console.WriteLine("Status of tasks:\n");
            Console.WriteLine("{0,10} {1,20} {2,14:N0}", "Task Id",
                              "Status", "Iterations");
            foreach (var t in tasks.OrderBy(t => t.Id))
                Console.WriteLine("{0,10} {1,20} {2,14}",
                                  t.Id, t.Status,
                                  t.Status != TaskStatus.Canceled ? t.Result.ToString("N0") : "n/a");

        }
    }

    private static int Counter(CancellationToken token)
    {
        int iterations = 0;
        for (int ctr = 1; ctr <= 2000000; ctr++)
        {
            try
            {
                token.ThrowIfCancellationRequested();
            }
            catch (Exception)
            {
                Console.WriteLine($"[{Task.CurrentId}] Cancelled after computing {ctr}...");
                throw;
            }
            iterations++;
        }

        completedIterations++;
        if (completedIterations >= 10)
        {
            Console.WriteLine($"[{Task.CurrentId}] Calling cancel on the rest and returning...");
            source.Cancel();
        }
        else
        {
            Console.WriteLine($"[{Task.CurrentId}] Returning...");
        }

        return iterations;
    }
}
// The example displays output like the following:
//    Waiting for the first 10 tasks to complete...
//
//    [1] Returning...
//    [5] Returning...
//    [2] Returning...
//    [3] Returning...
//    [4] Returning...
//    [8] Returning...
//    [7] Returning...
//    [6] Returning...
//    [9] Returning...
//    [10] Calling cancel on the rest and returning...
//    [11] Calling cancel on the rest and returning...
//    [13] Calling cancel on the rest and returning...
//    [12] Calling cancel on the rest and returning...
//    [17] Cancelled after computing 11230...
//    [20] Cancelled after computing 109848...
//    [19] Cancelled after computing 92502...
//    [18] Cancelled after computing 1834358...
//    Status of tasks:
//    
//       Task Id               Status     Iterations
//             1      RanToCompletion      2,000,000
//             2      RanToCompletion      2,000,000
//             3      RanToCompletion      2,000,000
//             4      RanToCompletion      2,000,000
//             5      RanToCompletion      2,000,000
//             6      RanToCompletion      2,000,000
//             7      RanToCompletion      2,000,000
//             8      RanToCompletion      2,000,000
//             9      RanToCompletion      2,000,000
//            10      RanToCompletion      2,000,000
//            11      RanToCompletion      2,000,000
//            12      RanToCompletion      2,000,000
//            13      RanToCompletion      2,000,000
//            14             Canceled            n/a
//            15             Canceled            n/a
//            16             Canceled            n/a
//            17             Canceled            n/a
//            18             Canceled            n/a
//            19             Canceled            n/a
//            20             Canceled            n/a
// </Snippet7>
