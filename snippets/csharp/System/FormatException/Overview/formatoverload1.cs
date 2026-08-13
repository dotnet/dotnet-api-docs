using System;

public class Example2
{
    public static void Main()
    {
        // <Snippet8>
        DateTime dat = new(2012, 1, 17, 9, 30, 0);
        string city = "Chicago";
        int temp = -16;
        string output = $"At {dat} in {city}, the temperature was {temp} degrees.";
        Console.WriteLine(output);
        // The example displays output like the following:
        //    At 1/17/2012 9:30:00 AM in Chicago, the temperature was -16 degrees.
        // </Snippet8>
    }
}
