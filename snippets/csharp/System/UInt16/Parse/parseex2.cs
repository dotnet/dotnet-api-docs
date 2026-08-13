// <Snippet6>
using System;
using System.Globalization;

public class UInt16ParseExample2
{
    public static void Run()
    {
        string[] values = { " 214 ", "1,064", "(0)", "1241+", " + 214 ", " +214 ", "2153.0", "1e03", "1300.0e-2" };
        NumberStyles whitespace = NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite;
        NumberStyles[] styles = { NumberStyles.None, whitespace,
                                NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign | whitespace,
                                NumberStyles.AllowThousands | NumberStyles.AllowCurrencySymbol,
                                NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint };

        // Attempt to convert each number using each style combination.
        foreach (string value in values)
        {
            Console.WriteLine($"Attempting to convert '{value}':");
            foreach (NumberStyles style in styles)
            {
                try
                {
                    ushort number = ushort.Parse(value, style);
                    Console.WriteLine($"   {style}: {number}");
                }
                catch (FormatException)
                {
                    Console.WriteLine($"   {style}: Bad Format");
                }
            }
            Console.WriteLine();
        }
    }
}
// The example display the following output:
//    Attempting to convert ' 214 ':
//       None: Bad Format
//       AllowLeadingWhite, AllowTrailingWhite: 214
//       Integer, AllowTrailingSign: 214
//       AllowThousands, AllowCurrencySymbol: Bad Format
//       AllowDecimalPoint, AllowExponent: Bad Format
//
//    Attempting to convert '1,064':
//       None: Bad Format
//       AllowLeadingWhite, AllowTrailingWhite: Bad Format
//       Integer, AllowTrailingSign: Bad Format
//       AllowThousands, AllowCurrencySymbol: 1064
//       AllowDecimalPoint, AllowExponent: Bad Format
//
//    Attempting to convert '(0)':
//       None: Bad Format
//       AllowLeadingWhite, AllowTrailingWhite: Bad Format
//       Integer, AllowTrailingSign: Bad Format
//       AllowThousands, AllowCurrencySymbol: Bad Format
//       AllowDecimalPoint, AllowExponent: Bad Format
//
//    Attempting to convert '1241+':
//       None: Bad Format
//       AllowLeadingWhite, AllowTrailingWhite: Bad Format
//       Integer, AllowTrailingSign: 1241
//       AllowThousands, AllowCurrencySymbol: Bad Format
//       AllowDecimalPoint, AllowExponent: Bad Format
//
//    Attempting to convert ' + 214 ':
//       None: Bad Format
//       AllowLeadingWhite, AllowTrailingWhite: Bad Format
//       Integer, AllowTrailingSign: Bad Format
//       AllowThousands, AllowCurrencySymbol: Bad Format
//       AllowDecimalPoint, AllowExponent: Bad Format
//
//    Attempting to convert ' +214 ':
//       None: Bad Format
//       AllowLeadingWhite, AllowTrailingWhite: Bad Format
//       Integer, AllowTrailingSign: 214
//       AllowThousands, AllowCurrencySymbol: Bad Format
//       AllowDecimalPoint, AllowExponent: Bad Format
//
//    Attempting to convert '2153.0':
//       None: Bad Format
//       AllowLeadingWhite, AllowTrailingWhite: Bad Format
//       Integer, AllowTrailingSign: Bad Format
//       AllowThousands, AllowCurrencySymbol: Bad Format
//       AllowDecimalPoint, AllowExponent: 2153
//
//    Attempting to convert '1e03':
//       None: Bad Format
//       AllowLeadingWhite, AllowTrailingWhite: Bad Format
//       Integer, AllowTrailingSign: Bad Format
//       AllowThousands, AllowCurrencySymbol: Bad Format
//       AllowDecimalPoint, AllowExponent: 1000
//
//    Attempting to convert '1300.0e-2':
//       None: Bad Format
//       AllowLeadingWhite, AllowTrailingWhite: Bad Format
//       Integer, AllowTrailingSign: Bad Format
//       AllowThousands, AllowCurrencySymbol: Bad Format
//       AllowDecimalPoint, AllowExponent: 13
// </Snippet6>
