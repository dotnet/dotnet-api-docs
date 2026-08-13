using System;


public class Example5
{
    public static void Main()
    {
        // <Snippet21>
        Random rnd = new();
        int[] numbers = new int[4];
        int total = 0;
        for (int ctr = 0; ctr <= 2; ctr++)
        {
            int number = rnd.Next(1001);
            numbers[ctr] = number;
            total += number;
        }
        numbers[3] = total;
        Console.WriteLine($"{numbers} + {1} + {2} = {3}");
        // </Snippet21>
    }
}
