// <Snippet2>
using System;
using System.Numerics;

public class ExitCodeReturnExample
{
    private const int ERROR_SUCCESS = 0;
    private const int ERROR_BAD_ARGUMENTS = 0xA0;
    private const int ERROR_ARITHMETIC_OVERFLOW = 0x216;
    private const int ERROR_INVALID_COMMAND_LINE = 0x667;

    public static int Run()
    {
        string[] args = Environment.GetCommandLineArgs();
        if (args.Length == 1)
        {
            return ERROR_INVALID_COMMAND_LINE;
        }
        else
        {
            BigInteger value = 0;
            if (BigInteger.TryParse(args[1], out value))
                if (value <= int.MinValue || value >= int.MaxValue)
                    return ERROR_ARITHMETIC_OVERFLOW;
                else
                    Console.WriteLine($"Result: {value * 2}");

            else
                return ERROR_BAD_ARGUMENTS;
        }
        return ERROR_SUCCESS;
    }
}
// </Snippet2>
