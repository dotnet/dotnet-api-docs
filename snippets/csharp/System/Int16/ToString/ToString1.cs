using System;
using System.Globalization;

public class Class1
{
    public static void Main()
    {
        CallDefaultToString();
        Console.WriteLine("------");
        CallToStringWithProvider();
        Console.WriteLine("------");
        CallToStringWithSpecifiers();
        Console.WriteLine("------");
        CallToStringWithSpecifiersAndProviders();
    }

    private static void CallDefaultToString()
    {
        // <Snippet1>
        short[] numbers = {0, 14624, 13982, short.MaxValue,
                         short.MinValue, -16667};
        foreach (short number in numbers)
        {
            Console.WriteLine(number.ToString());
        }
        // The example displays the following output to the console:
        //       0
        //       14624
        //       13982
        //       32767
        //       -32768
        //       -16667
        // </Snippet1>
    }

    private static void CallToStringWithProvider()
    {
        // <Snippet2>
        short[] numbers = { -23092, 0, 14894, short.MaxValue };
        CultureInfo[] providers = {new CultureInfo("en-us"),
                                 new CultureInfo("fr-fr"),
                                 new CultureInfo("de-de"),
                                 new CultureInfo("es-es")};
        foreach (short int16Value in numbers)
        {
            foreach (CultureInfo provider in providers)
            {
                Console.Write($"{int16Value.ToString(provider),6} ({provider.Name})     ");
            }
            Console.WriteLine();
        }
        // The example displays the following output to the console:
        //       -23092 (en-US)     -23092 (fr-FR)     -23092 (de-DE)     -23092 (es-ES)
        //            0 (en-US)          0 (fr-FR)          0 (de-DE)          0 (es-ES)
        //        14894 (en-US)      14894 (fr-FR)      14894 (de-DE)      14894 (es-ES)
        //        32767 (en-US)      32767 (fr-FR)      32767 (de-DE)      32767 (es-ES)
        // </Snippet2>
    }

    private static void CallToStringWithSpecifiers()
    {
        // <Snippet3>
        short[] values = { -23805, 32194 };
        string[] formats = {"C4", "D6", "e1", "E2", "F1", "G", "N1",
                          "P0", "X4", "000000.0000", "##000.0"};
        foreach (string format in formats)
        {
            Console.WriteLine($"'{format,2}' format specifier: {values[0].ToString(format),17}   {values[1].ToString(format),17}");
        }
        // The example displays the following output to the console:
        //    'C4' format specifier:    ($23,805.0000)        $32,194.0000
        //    'D6' format specifier:           -023805              032194
        //    'e1' format specifier:         -2.4e+004            3.2e+004
        //    'E2' format specifier:        -2.38E+004           3.22E+004
        //    'F1' format specifier:          -23805.0             32194.0
        //    ' G' format specifier:            -23805               32194
        //    'N1' format specifier:         -23,805.0            32,194.0
        //    'P0' format specifier:      -2,380,500 %         3,219,400 %
        //    'X4' format specifier:              A303                7DC2
        //    '000000.0000' format specifier:      -023805.0000         032194.0000
        //    '##000.0' format specifier:          -23805.0             32194.0
        // </Snippet3>
    }

    private static void CallToStringWithSpecifiersAndProviders()
    {
        // <Snippet4>
        short value = 14603;
        string[] formats = {"C", "D6", "e1", "E2", "F1", "G", "N1",
                          "P0", "X4", "000000.0000", "##000.0"};
        CultureInfo[] providers = {new CultureInfo("en-us"),
                                 new CultureInfo("fr-fr"),
                                 new CultureInfo("de-de"),
                                 new CultureInfo("es-es")};
        // Display header.
        Console.WriteLine($"{providers[0],24}{providers[1],14}{providers[2],14}{providers[3],14}");
        Console.WriteLine();
        // Display a value using each format string.
        foreach (string format in formats)
        {
            // Display the value for each provider on the same line.
            Console.Write($"{format,-12}");
            foreach (CultureInfo provider in providers)
            {
                Console.Write($"{value.ToString(format, provider),12}  ");
            }
            Console.WriteLine();
        }
        // The example displays the following output to the console:
        //                       en-US         fr-FR         de-DE         es-ES
        //
        //    C             $14,603.00   14 603,00 €   14.603,00 €   14.603,00 €
        //    D6                014603        014603        014603        014603
        //    e1              1.5e+004      1,5e+004      1,5e+004      1,5e+004
        //    E2             1.46E+004     1,46E+004     1,46E+004     1,46E+004
        //    F1               14603.0       14603,0       14603,0       14603,0
        //    G                  14603         14603         14603         14603
        //    N1              14,603.0      14 603,0      14.603,0      14.603,0
        //    P0           1,460,300 %   1 460 300 %    1.460.300%   1.460.300 %
        //    X4                  390B          390B          390B          390B
        //    000000.0000  014603.0000   014603,0000   014603,0000   014603,0000
        //    ##000.0          14603.0       14603,0       14603,0       14603,0
        // </Snippet4>
    }
}
