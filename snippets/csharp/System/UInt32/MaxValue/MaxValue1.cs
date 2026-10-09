using System;

public class ULongRangeExample
{
    public static void Main()
    {
        // <Snippet1>
        long longValue = long.MaxValue / 2;
        uint integerValue;

        if (longValue <= uint.MaxValue &&
            longValue >= uint.MinValue)
        {
            integerValue = (uint)longValue;
            Console.WriteLine($"Converted long integer value to {integerValue:n0}.");
        }
        else
        {
            uint rangeLimit;
            string relationship;

            if (longValue > uint.MaxValue)
            {
                rangeLimit = uint.MaxValue;
                relationship = "greater";
            }
            else
            {
                rangeLimit = uint.MinValue;
                relationship = "less";
            }

            Console.WriteLine($"Conversion failure: {longValue:n0} is {relationship} than {rangeLimit:n0}");
        }
        // </Snippet1>
    }
}
