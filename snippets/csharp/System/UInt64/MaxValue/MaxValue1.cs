using System;

public class ULongRangeExample
{
    public static void Main()
    {
        // <Snippet1>
        double decimalValue = -1.5;
        ulong integerValue;

        // Discard fractional portion of Double value
        double decimalInteger = Math.Floor(decimalValue);

        if (decimalInteger <= ulong.MaxValue &&
            decimalInteger >= ulong.MinValue)
        {
            integerValue = (ulong)decimalValue;
            Console.WriteLine($"Converted {decimalValue} to {integerValue}.");
        }
        else
        {
            ulong rangeLimit;
            string relationship;

            if (decimalInteger > ulong.MaxValue)
            {
                rangeLimit = ulong.MaxValue;
                relationship = "greater";
            }
            else
            {
                rangeLimit = ulong.MinValue;
                relationship = "less";
            }

            Console.WriteLine($"Conversion failure: {decimalInteger} is {relationship} than {rangeLimit}.");
        }
        // </Snippet1>
    }
}
