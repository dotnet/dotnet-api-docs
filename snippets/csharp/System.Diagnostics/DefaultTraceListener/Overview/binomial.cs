// <Snippet1>
// <Snippet11>
using System;
using System.Diagnostics;

class Binomial
{

    // args(0) is the number of possibilities for binomial coefficients.
    // args(1) is the file specification for the trace log file.
    public static void Main(string[] args)
    {

        // <Snippet2>
        decimal possibilities;
        decimal i;
        // </Snippet2>

        // <Snippet3>
        // Remove the original default trace listener.
        Trace.Listeners.RemoveAt(0);

        // <Snippet4>
        // Create and add a new default trace listener.
        // <Snippet5>
        DefaultTraceListener defaultListener;
        // </Snippet5>
        defaultListener = new DefaultTraceListener();
        Trace.Listeners.Add(defaultListener);

        // Assign the log file specification from the command line, if entered.
        if (args.Length >= 2)
        {
            defaultListener.LogFileName = args[1];
        }
        // </Snippet4>
        // </Snippet3>

        // Validate the number of possibilities argument.
        if (args.Length >= 1)

        // Verify that the argument is a number within the correct range.
        {
            try
            {
                const decimal MaxPossibilities = 99;
                possibilities = Decimal.Parse(args[0]);
                if (possibilities < 0 || possibilities > MaxPossibilities)
                {
                    throw new Exception(
                        $"The number of possibilities must be in the range 0..{MaxPossibilities}.");
                }
            }
            catch (Exception ex)
            {
                string failMessage = $"\"{args[0]}\" is not a valid number of possibilities.";
                defaultListener.Fail(failMessage, ex.Message);
                if (!defaultListener.AssertUiEnabled)
                {
                    Console.WriteLine($"{failMessage}\n{ex.Message}");
                }
                return;
            }
        }
        else
        {
            // <Snippet6>
            // Report that the required argument is not present.
            const string ENTER_PARAM = "Enter the number of " +
                      "possibilities as a command line argument.";
            defaultListener.Fail(ENTER_PARAM);
            if (!defaultListener.AssertUiEnabled)
            {
                Console.WriteLine(ENTER_PARAM);
            }
            // </Snippet6>
            return;
        }

        for (i = 0; i <= possibilities; i++)
        {
            // <Snippet7>
            decimal result;
            string binomial;

            // </Snippet7>
            // <Snippet8>
            // Compute the next binomial coefficient and handle all exceptions.
            try
            {
                // <Snippet9>
                result = CalcBinomial(possibilities, i);
                // </Snippet9>
            }
            catch (Exception ex)
            {
                string failMessage =
                    $"An exception was raised when calculating Binomial( {possibilities}, {i} ).";
                defaultListener.Fail(failMessage, ex.Message);
                if (!defaultListener.AssertUiEnabled)
                {
                    Console.WriteLine($"{failMessage}\n{ex.Message}");
                }
                return;
            }
            // </Snippet8>
            // <Snippet10>

            // Format the trace and console output.
            binomial = $"Binomial( {possibilities}, {i} ) = ";
            defaultListener.Write(binomial);
            defaultListener.WriteLine(result);
            Console.WriteLine($"{binomial} {result}");
            // </Snippet10>
        }
    }

    public static decimal CalcBinomial(decimal possibilities, decimal outcomes)
    {

        // Calculate a binomial coefficient, and minimize the chance of overflow.
        decimal result = 1;
        decimal i;
        for (i = 1; i <= possibilities - outcomes; i++)
        {
            result *= outcomes + i;
            result /= i;
        }
        return result;
    }
}
// </Snippet11>
// </Snippet1>
