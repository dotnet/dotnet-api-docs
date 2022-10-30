// <Snippet6>
using System;
using System.Threading.Tasks;

public class Example
{
    public static async Task Main()
    {
        await Task.Run(() =>
        {
            // Just loop.
            int counter = 0;
            for (counter = 0; counter <= 1000000; counter++)
            { }
            Console.WriteLine("Finished {0} loop iterations", counter);
        });
    }
}
// This example displays the following output:
//     Finished 1000001 loop iterations
// </Snippet6>
