using System;

public class Example14
{
    public static void Main()
    {
        // <Snippet6>
        Random rnd = new();
        for (int ctr = 0; ctr < 10; ctr++)
        {
            Console.Write($"{rnd.Next(-10, 11),3}   ");
        }

        // The example displays output like the following:
        //    2     9    -3     2     4    -7    -3    -8    -8     5
        // </Snippet6>
    }
}
