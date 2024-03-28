using System;

public class Example
{
    public static void Main()
    {
        // <Snippet5>
        Console.Write("Number of random numbers to generate: ");

        string? line = Console.ReadLine();
        Random rnd = new Random();

        if (!int.TryParse(line, out int numbers) || numbers <= 0)
        {
            numbers = 10;
        }

        for (uint ctr = 1; ctr <= numbers; ctr++)
            Console.WriteLine($"{rnd.Next(),15:N0}");

        // The example displays output like the following when asked to generate
        // 15 random numbers:
        // Number of random numbers to generate: 15
        //     367 920 603
        //   1 143 790 667
        //   1 360 963 275
        //   1 851 697 775
        //     248 956 796
        //   1 009 615 458
        //   1 617 743 155
        //   1 821 609 652
        //   1 661 761 949
        //     477 300 794
        //     288 418 129
        //     425 371 492
        //   1 558 147 880
        //   1 473 704 017
        //     777 507 489
        // </Snippet5>
    }
}
