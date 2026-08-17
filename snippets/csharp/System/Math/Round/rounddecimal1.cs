using System;

class MathRoundExample5
{
    public static void Run()
    {
        //  <Snippet6>
        for (decimal value = 4.2m; value <= 4.8m; value += .1m)
            Console.WriteLine($"{value} --> {Math.Round(value)}");
        // The example displays the following output:
        //       4.2 --> 4
        //       4.3 --> 4
        //       4.4 --> 4
        //       4.5 --> 4
        //       4.6 --> 5
        //       4.7 --> 5
        //       4.8 --> 5
        // </Snippet6>
    }
}
