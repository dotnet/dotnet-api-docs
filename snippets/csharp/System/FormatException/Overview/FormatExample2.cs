// <Snippet2>
using System;

public class TestFormatter
{
    public static void Main()
    {
        int acctNumber = 79203159;
        Console.WriteLine($"{acctNumber}");
        Console.WriteLine($"{acctNumber:G}");
        Console.WriteLine($"{acctNumber:S}");
        Console.WriteLine($"{acctNumber:P}");
        try
        {
            Console.WriteLine($"{acctNumber:X}");
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

public class CustomerFormatter : IFormatProvider, ICustomFormatter
{
    public object GetFormat(Type formatType)
    {
        if (formatType == typeof(ICustomFormatter))
            return this;
        else
            return null;
    }

    public string Format(string format,
                          object arg,
                          IFormatProvider formatProvider)
    {
        if (!this.Equals(formatProvider))
        {
            return null;
        }
        else
        {
            if (string.IsNullOrEmpty(format))
                format = "G";

            string customerString = arg.ToString();
            if (customerString.Length < 8)
                customerString = customerString.PadLeft(8, '0');

            format = format.ToUpper();
            return format switch
            {
                "G" => customerString.Substring(0, 1) + "-" +
                                        customerString.Substring(1, 5) + "-" +
                                        customerString.Substring(6),
                "S" => customerString.Substring(0, 1) + "/" +
                                        customerString.Substring(1, 5) + "/" +
                                        customerString.Substring(6),
                "P" => customerString.Substring(0, 1) + "." +
                                        customerString.Substring(1, 5) + "." +
                                        customerString.Substring(6),
                _ => throw new FormatException(
                            $"The '{format}' format specifier is not supported.")
            };
        }
    }
}
// The example displays the following output:
//       7-92031-59
//       7-92031-59
//       7/92031/59
//       7.92031.59
//       The 'X' format specifier is not supported.
// </Snippet2>
