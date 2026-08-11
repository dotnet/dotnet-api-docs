using System;
using System.Globalization;

namespace Snippets
{
    class Launcher
    {
        static void Main(string[] args)
        {
            Temperature t1 = Temperature.Parse("20'F", NumberStyles.Float, null);
            Console.WriteLine(t1.ToString("F", null));

            string str1 = t1.ToString("C", null);
            Console.WriteLine(str1);

            Temperature t2 = Temperature.Parse(str1, NumberStyles.Float, null);
            Console.WriteLine(t2.ToString("F", null));

            Console.WriteLine(t1.CompareTo(t2));

            Temperature t3 = Temperature.Parse("20'C", NumberStyles.Float, null);
            Console.WriteLine(t3.ToString("F", null));

            Console.WriteLine(t1.CompareTo(t3));
        }
    }
    //<snippet1>
    // The Temperature class stores the temperature as a Double
    // and delegates most of the functionality to the Double
    // implementation.
    public class Temperature : IComparable, IFormattable
    {
        // IComparable.CompareTo implementation.
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Temperature temp = obj as Temperature;
            if (obj != null)
                return m_value.CompareTo(temp.m_value);
            else
                throw new ArgumentException("object is not a Temperature");
        }

        // IFormattable.ToString implementation.
        public string ToString(string format, IFormatProvider provider)
        {
            if (format != null)
            {
                if (format.Equals("F"))
                {
                    return $"{this.Value.ToString()}'F";
                }
                if (format.Equals("C"))
                {
                    return $"{this.Celsius.ToString()}'C";
                }
            }

            return m_value.ToString(format, provider);
        }

        // Parses the temperature from a string in the form
        // [ws][sign]digits['F|'C][ws]
        public static Temperature Parse(string s, NumberStyles styles, IFormatProvider provider)
        {
            Temperature temp = new();

            if (s.TrimEnd(null).EndsWith("'F"))
            {
                temp.Value = double.Parse(s.Remove(s.LastIndexOf('\''), 2), styles, provider);
            }
            else if (s.TrimEnd(null).EndsWith("'C"))
            {
                temp.Celsius = double.Parse(s.Remove(s.LastIndexOf('\''), 2), styles, provider);
            }
            else
            {
                temp.Value = double.Parse(s, styles, provider);
            }

            return temp;
        }

        // The value holder
        protected double m_value;

        public double Value {
            get => m_value;
            set => m_value = value;
        }

        public double Celsius {
            get => (m_value - 32.0) / 1.8;
            set => m_value = 1.8 * value + 32.0;
        }
    }
    //</snippet1>
}

namespace Snippets2
{
    //<snippet2>
    public class Temperature
    {
        public static double MinValue => double.MinValue;

        public static double MaxValue => double.MaxValue;

        // The value holder
        protected double m_value;

        public double Value {
            get => m_value;
            set => m_value = value;
        }

        public double Celsius {
            get => (m_value - 32.0) / 1.8;
            set => m_value = 1.8 * value + 32.0;
        }
    }
    //</snippet2>
}

namespace Snippets3
{
    //<snippet3>
    public class Temperature : IComparable
    {
        // IComparable.CompareTo implementation.
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Temperature temp = obj as Temperature;
            if (obj != null)
                return m_value.CompareTo(temp.m_value);
            else
                throw new ArgumentException("object is not a Temperature");
        }

        // The value holder
        protected double m_value;

        public double Value {
            get => m_value;
            set => m_value = value;
        }

        public double Celsius {
            get => (m_value - 32.0) / 1.8;
            set => m_value = 1.8 * value + 32.0;
        }
    }
    //</snippet3>
}

namespace Snippets4
{
    //<snippet4>
    public class Temperature : IFormattable
    {
        // IFormattable.ToString implementation.
        public string ToString(string format, IFormatProvider provider)
        {
            if (format != null)
            {
                if (format.Equals("F"))
                {
                    return $"{this.Value.ToString()}'F";
                }
                if (format.Equals("C"))
                {
                    return $"{this.Celsius.ToString()}'C";
                }
            }

            return m_value.ToString(format, provider);
        }

        // The value holder
        protected double m_value;

        public double Value {
            get => m_value;
            set => m_value = value;
        }

        public double Celsius {
            get => (m_value - 32.0) / 1.8;
            set => m_value = 1.8 * value + 32.0;
        }
    }
    //</snippet4>
}

namespace Snippets5
{
    //<snippet5>
    public class Temperature
    {
        // Parses the temperature from a string in form
        // [ws][sign]digits['F|'C][ws]
        public static Temperature Parse(string s)
        {
            Temperature temp = new();

            if (s.TrimEnd(null).EndsWith("'F"))
            {
                temp.Value = double.Parse(s.Remove(s.LastIndexOf('\''), 2));
            }
            else if (s.TrimEnd(null).EndsWith("'C"))
            {
                temp.Celsius = double.Parse(s.Remove(s.LastIndexOf('\''), 2));
            }
            else
            {
                temp.Value = double.Parse(s);
            }

            return temp;
        }

        // The value holder
        protected double m_value;

        public double Value {
            get => m_value;
            set => m_value = value;
        }

        public double Celsius {
            get => (m_value - 32.0) / 1.8;
            set => m_value = 1.8 * value + 32.0;
        }
    }
    //</snippet5>
}

namespace Snippets6
{
    //<snippet6>
    public class Temperature
    {
        // Parses the temperature from a string in form
        // [ws][sign]digits['F|'C][ws]
        public static Temperature Parse(string s, IFormatProvider provider)
        {
            Temperature temp = new();

            if (s.TrimEnd(null).EndsWith("'F"))
            {
                temp.Value = double.Parse(s.Remove(s.LastIndexOf('\''), 2), provider);
            }
            else if (s.TrimEnd(null).EndsWith("'C"))
            {
                temp.Celsius = double.Parse(s.Remove(s.LastIndexOf('\''), 2), provider);
            }
            else
            {
                temp.Value = double.Parse(s, provider);
            }

            return temp;
        }

        // The value holder
        protected double m_value;

        public double Value {
            get => m_value;
            set => m_value = value;
        }

        public double Celsius {
            get => (m_value - 32.0) / 1.8;
            set => m_value = 1.8 * value + 32.0;
        }
    }
    //</snippet6>
}

namespace Snippets7
{
    //<snippet7>
    public class Temperature
    {
        // Parses the temperature from a string in form
        // [ws][sign]digits['F|'C][ws]
        public static Temperature Parse(string s, NumberStyles styles)
        {
            Temperature temp = new();

            if (s.TrimEnd(null).EndsWith("'F"))
            {
                temp.Value = double.Parse(s.Remove(s.LastIndexOf('\''), 2), styles);
            }
            else if (s.TrimEnd(null).EndsWith("'C"))
            {
                temp.Celsius = double.Parse(s.Remove(s.LastIndexOf('\''), 2), styles);
            }
            else
            {
                temp.Value = double.Parse(s, styles);
            }

            return temp;
        }

        // The value holder
        protected double m_value;

        public double Value {
            get => m_value;
            set => m_value = value;
        }

        public double Celsius {
            get => (m_value - 32.0) / 1.8;
            set => m_value = 1.8 * value + 32.0;
        }
    }
    //</snippet7>
}

namespace Snippets8
{
    //<snippet8>
    public class Temperature
    {
        // Parses the temperature from a string in form
        // [ws][sign]digits['F|'C][ws]
        public static Temperature Parse(string s, NumberStyles styles, IFormatProvider provider)
        {
            Temperature temp = new();

            if (s.TrimEnd(null).EndsWith("'F"))
            {
                temp.Value = double.Parse(s.Remove(s.LastIndexOf('\''), 2), styles, provider);
            }
            else if (s.TrimEnd(null).EndsWith("'C"))
            {
                temp.Celsius = double.Parse(s.Remove(s.LastIndexOf('\''), 2), styles, provider);
            }
            else
            {
                temp.Value = double.Parse(s, styles, provider);
            }

            return temp;
        }

        // The value holder
        protected double m_value;

        public double Value {
            get => m_value;
            set => m_value = value;
        }

        public double Celsius {
            get => (m_value - 32.0) / 1.8;
            set => m_value = 1.8 * value + 32.0;
        }
    }
    //</snippet8>
}
