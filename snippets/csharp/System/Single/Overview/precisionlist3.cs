// <Snippet6>
using System;

public class PrecisionList3Example
{
    public static void Main()
    {
        float[] values = { 10.01f, 2.88f, 2.88f, 2.88f, 9.0f };
        float result = 27.65f;
        float total = 0f;
        foreach (float value in values)
            total += value;

        if (total.Equals(result))
            Console.WriteLine("The sum of the values equals the total.");
        else
            Console.WriteLine($"The sum of the values ({total}) does not equal the total ({result}).");
    }
}

// The example displays the following output on modern .NET:
//      The sum of the values (27.650002) does not equal the total (27.65).

// </Snippet6>
