using System;

class DoubleSample
{
    public static void Main()
    {
        //<snippet1>
        double d = 4.55;
        //</snippet1>

        //<snippet2>
        Console.WriteLine($"A double is of type {d.GetType().ToString()}.");
        //</snippet2>

        //<snippet3>
        bool done = false;
        string inp;
        do
        {
            Console.Write("Enter a real number: ");
            inp = Console.ReadLine();
            try
            {
                d = double.Parse(inp);
                Console.WriteLine($"You entered {d.ToString()}.");
                done = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("You did not enter a number.");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("You did not supply any input.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"The value you entered, {inp}, is out of range.");
            }
        } while (!done);
        //</snippet3>

        //<snippet4>
        if (d > double.MaxValue)
            Console.WriteLine("Your number is bigger than a double.");
        //</snippet4>

        //<snippet5>
        if (d < double.MinValue)
            Console.WriteLine("Your number is smaller than a double.");
        //</snippet5>

        //<snippet6>
        Console.WriteLine($"Epsilon, or the permittivity of a vacuum, has value {double.Epsilon.ToString()}");
        //</snippet6>

        //<snippet7>
        double zero = 0;

        // This condition will return false.
        if ((0 / zero) == double.NaN)
            Console.WriteLine("0 / 0 can be tested with Double.NaN.");
        else
            Console.WriteLine("0 / 0 cannot be tested with Double.NaN; use Double.IsNan() instead.");
        //</snippet7>

        //<snippet8>
        // This will return true.
        if (double.IsNaN(0 / zero))
            Console.WriteLine("Double.IsNan() can determine whether a value is not-a-number.");
        //</snippet8>

        //<snippet9>
        // This will equal Infinity.
        Console.WriteLine($"10.0 minus NegativeInfinity equals {(10.0 - double.NegativeInfinity).ToString()}.");
        //</snippet9>

        //<snippet10>
        // This will equal Infinity.
        Console.WriteLine($"PositiveInfinity plus 10.0 equals {(double.PositiveInfinity + 10.0).ToString()}.");
        //</snippet10>

        //<snippet11>
        // This will return "true".
        Console.WriteLine($"IsInfinity(3.0 / 0) == {(double.IsInfinity(3.0 / 0) ? "true" : "false")}.");
        //</snippet11>

        //<snippet12>
        // This will return "true".
        Console.WriteLine($"IsPositiveInfinity(4.0 / 0) == {(double.IsPositiveInfinity(4.0 / 0) ? "true" : "false")}.");
        //</snippet12>

        //<snippet13>
        // This will return "true".
        Console.WriteLine($"IsNegativeInfinity(-5.0 / 0) == {(double.IsNegativeInfinity(-5.0 / 0) ? "true" : "false")}.");
        //</snippet13>

        //<snippet14>
        double a = 500;
        object obj1;
        //</snippet14>

        //<snippet15>
        // The variables point to the same objects.
        object obj2;
        obj1 = a;
        obj2 = obj1;

        if (double.ReferenceEquals(obj1, obj2))
            Console.WriteLine("The variables point to the same double object.");
        else
            Console.WriteLine("The variables point to different double objects.");
        //</snippet15>

        //<snippet16>
        obj1 = (double)450;

        if (a.CompareTo(obj1) < 0)
            Console.WriteLine($"{a.ToString()} is less than {obj1.ToString()}.");

        if (a.CompareTo(obj1) > 0)
            Console.WriteLine($"{a.ToString()} is greater than {obj1.ToString()}.");

        if (a.CompareTo(obj1) == 0)
            Console.WriteLine($"{a.ToString()} equals {obj1.ToString()}.");
        //</snippet16>

        //<snippet17>
        obj1 = (double)500;
        if (a.Equals(obj1))
            Console.WriteLine("The value type and reference type values are equal.");
        //</snippet17>
    }
}
