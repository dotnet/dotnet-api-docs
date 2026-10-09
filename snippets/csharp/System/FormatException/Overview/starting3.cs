using System;


class Example16
{
    public static void Main()
    {
        // <Snippet33>
        int[] years = { 2013, 2014, 2015 };
        int[] population = { 1025632, 1105967, 1148203 };
        var sb = new System.Text.StringBuilder();
        sb.Append($"{"Year",6} {"Population",15}\n\n");
        for (int index = 0; index < years.Length; index++)
            sb.Append($"{years[index],6} {population[index],15:N0}\n");

        Console.WriteLine(sb);

        // Result:
        //      Year      Population
        //
        //      2013       1,025,632
        //      2014       1,105,967
        //      2015       1,148,203
        // </Snippet33>
    }
}
