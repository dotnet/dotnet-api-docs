using System;

public class Example9
{
    public static void Main()
    {
        // <Snippet5>
        double value1 = 1 / 3.0;
        float sValue2 = 1 / 3.0f;
        double value2 = (double)sValue2;
        Console.WriteLine($"{value1:R} = {value2:R}: {value1.Equals(value2)}");

        // The example displays the following output on .NET:
        //        0.3333333333333333 = 0.3333333432674408: False
        // </Snippet5>
    }
}
