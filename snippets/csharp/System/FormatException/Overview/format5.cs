using System;

public class FormatExample5
{
    public static void Main()
    {
        // <Snippet5>
        DateTime date1 = new(2009, 7, 1);
        TimeSpan hiTime = new(14, 17, 32);
        decimal hiTemp = 62.1m;
        TimeSpan loTime = new(3, 16, 10);
        decimal loTemp = 54.8m;

        string result1 = $"Temperature on {date1:d}:\n{hiTime,11}: {hiTemp} degrees (hi)\n{loTime,11}: {loTemp} degrees (lo)";
        Console.WriteLine(result1);
        Console.WriteLine();

        string result2 = string.Format("Temperature on {0:d}:\n{1,11}: {2} degrees (hi)\n{3,11}: {4} degrees (lo)",
                                       new object[] { date1, hiTime, hiTemp, loTime, loTemp });
        Console.WriteLine(result2);
        // The example displays output like the following:
        //       Temperature on 7/1/2009:
        //          14:17:32: 62.1 degrees (hi)
        //          03:16:10: 54.8 degrees (lo)
        //       Temperature on 7/1/2009:
        //          14:17:32: 62.1 degrees (hi)
        //          03:16:10: 54.8 degrees (lo)
        // </Snippet5>
    }
}
