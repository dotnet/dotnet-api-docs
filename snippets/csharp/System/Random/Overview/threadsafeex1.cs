// <Snippet3>
using System;
using System.Threading;

public class Example18
{
    [ThreadStatic] static double s_previous;
    [ThreadStatic] static int s_perThreadCtr;
    [ThreadStatic] static double s_perThreadTotal;
    static CancellationTokenSource s_source;
    static CountdownEvent s_countdown;
    static object s_randLock, s_numericLock;
    static Random s_rand;
    double _totalValue = 0.0;
    int _totalCount = 0;

    public Example18()
    {
        s_rand = new Random();
        s_randLock = new object();
        s_numericLock = new object();
        s_countdown = new CountdownEvent(1);
        s_source = new CancellationTokenSource();
    }

    public static void Main()
    {
        Example18 ex = new();
        Thread.CurrentThread.Name = "Main";
        ex.Execute();
    }

    private void Execute()
    {
        CancellationToken token = s_source.Token;

        for (int threads = 1; threads <= 10; threads++)
        {
            Thread newThread = new(GetRandomNumbers)
            {
                Name = threads.ToString()
            };
            newThread.Start(token);
        }
        GetRandomNumbers(token);

        s_countdown.Signal();
        // Make sure all threads have finished.
        s_countdown.Wait();
        s_source.Dispose();

        Console.WriteLine($"\nTotal random numbers generated: {_totalCount:N0}");
        Console.WriteLine($"Total sum of all random numbers: {_totalValue:N2}");
        Console.WriteLine($"Random number mean: {_totalValue / _totalCount:N4}");
    }

    private void GetRandomNumbers(object o)
    {
        CancellationToken token = (CancellationToken)o;
        double result = 0.0;
        s_countdown.AddCount(1);

        try
        {
            s_previous = 0.0;
            s_perThreadCtr = 0;
            s_perThreadTotal = 0.0;

            for (int ctr = 0; ctr < 2000000; ctr++)
            {
                // Make sure there's no corruption of Random.
                token.ThrowIfCancellationRequested();

                lock (s_randLock)
                {
                    result = s_rand.NextDouble();
                }
                // Check for corruption of Random instance.
                if ((result == s_previous) && result == 0)
                {
                    s_source.Cancel();
                }
                else
                {
                    s_previous = result;
                }
                s_perThreadCtr++;
                s_perThreadTotal += result;
            }

            Console.WriteLine($"Thread {Thread.CurrentThread.Name} finished execution.");
            Console.WriteLine($"Random numbers generated: {s_perThreadCtr:N0}");
            Console.WriteLine($"Sum of random numbers: {s_perThreadTotal:N2}");
            Console.WriteLine($"Random number mean: {s_perThreadTotal / s_perThreadCtr:N4}\n");

            // Update overall totals.
            lock (s_numericLock)
            {
                _totalCount += s_perThreadCtr;
                _totalValue += s_perThreadTotal;
            }
        }
        catch (OperationCanceledException e)
        {
            Console.WriteLine($"Corruption in Thread {Thread.CurrentThread.Name}");
        }
        finally
        {
            s_countdown.Signal();
        }
    }
}

// The example displays output like the following:
//       Thread 6 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 1,000,491.05
//       Random number mean: 0.5002
//
//       Thread 10 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,329.64
//       Random number mean: 0.4997
//
//       Thread 4 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 1,000,166.89
//       Random number mean: 0.5001
//
//       Thread 8 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,628.37
//       Random number mean: 0.4998
//
//       Thread Main finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,920.89
//       Random number mean: 0.5000
//
//       Thread 3 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,370.45
//       Random number mean: 0.4997
//
//       Thread 7 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,330.92
//       Random number mean: 0.4997
//
//       Thread 9 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 1,000,172.79
//       Random number mean: 0.5001
//
//       Thread 5 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 1,000,079.43
//       Random number mean: 0.5000
//
//       Thread 1 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,817.91
//       Random number mean: 0.4999
//
//       Thread 2 finished execution.
//       Random numbers generated: 2,000,000
//       Sum of random numbers: 999,930.63
//       Random number mean: 0.5000
//
//
//       Total random numbers generated: 22,000,000
//       Total sum of all random numbers: 10,998,238.98
//       Random number mean: 0.4999
// </Snippet3>
