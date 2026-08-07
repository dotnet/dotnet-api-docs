//<Snippet4>
using System;
using System.Threading;

namespace Examples.AdvancedProgramming.AsynchronousOperations
{
    public class AsyncMain
    {
        static void Main()
        {
            // The asynchronous method puts the thread id here.
            int threadId;

            // Create an instance of the test class.
            AsyncDemo ad = new();

            // Create the delegate.
            AsyncMethodCaller caller = new(ad.TestMethod);

            // Initiate the asychronous call.
            IAsyncResult result = caller.BeginInvoke(3000,
                out threadId, null, null);

            // Poll while simulating work.
            while (!result.IsCompleted)
            {
                Thread.Sleep(250);
                Console.Write(".");
            }

            // Call EndInvoke to retrieve the results.
            string returnValue = caller.EndInvoke(out threadId, result);

            Console.WriteLine($"\nThe call executed on thread {threadId}, with return value \"{returnValue}\".");
        }
    }
}

/* This example produces output similar to the following:

Test method begins.
.............
The call executed on thread 3, with return value "My call time was 3000.".
 */
//</Snippet4>
