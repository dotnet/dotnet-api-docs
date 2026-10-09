// <Snippet2>
using System;
using System.Globalization;

public class Example2
{
    public static void Run()
    {
        CultureInfo[] cultures = { CultureInfo.CreateSpecificCulture("en-US"),
                                CultureInfo.InvariantCulture,
                                CultureInfo.CreateSpecificCulture("tr-TR") };
        char[] chars = { 'ä', 'e', 'E', 'i', 'I' };

        Console.WriteLine("Character     en-US     Invariant     tr-TR");
        foreach (char ch in chars)
        {
            Console.Write($"    {ch}");
            foreach (var culture in cultures)
                Console.Write($"{char.ToUpper(ch, culture),12}");

            Console.WriteLine();
        }
    }
}
// The example displays the following output:
//       Character     en-US     Invariant     tr-TR
//           ä           Ä           Ä           Ä
//           e           E           E           E
//           E           E           E           E
//           i           I           I           İ
//           I           I           I           I
// </Snippet2>
