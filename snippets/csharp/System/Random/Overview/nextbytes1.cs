using System;

public class Example12
{
    public static void Main()
    {
        // <Snippet5>
        Random rnd = new();
        byte[] bytes = new byte[20];
        rnd.NextBytes(bytes);
        for (int ctr = 1; ctr <= bytes.Length; ctr++)
        {
            Console.Write($"{bytes[ctr - 1],3}   ");
            if (ctr % 10 == 0)
                Console.WriteLine();
        }

        // The example displays output like the following:
        //       141    48   189    66   134   212   211    71   161    56
        //       181   166   220   133     9   252   222    57    62    62
        // </Snippet5>
    }
}
