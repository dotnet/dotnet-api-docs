using System;

namespace CompareTo
{
    class Class1
    {
        static void Main(string[] args)
        {
            // <Snippet1>
            System.DateTime theDay = new(System.DateTime.Today.Year, 7, 28);
            int compareValue;

            try
            {
                compareValue = theDay.CompareTo(DateTime.Today);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Value is not a DateTime");
                return;
            }

            if (compareValue < 0)
                System.Console.WriteLine($"{theDay:d} is in the past.");
            else if (compareValue == 0)
                System.Console.WriteLine($"{theDay:d} is today!");
            else // compareValue > 0
                System.Console.WriteLine($"{theDay:d} has not come yet.");
            // </Snippet1>
        }
    }
}
