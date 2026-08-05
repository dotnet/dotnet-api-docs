using System;
using System.Collections.Generic;
using System.Linq;

namespace SequenceExamples
{
    class Program
    {
        // This part is just for testing the examples
        static void Main(string[] args)
        {
            MaxBy.MaxByKeySelectorExample();
            MaxBy.MaxByComparerExample();
        }

        #region MaxBy
        static class MaxBy
        {
            public static void MaxByKeySelectorExample()
            {
                // <Snippet212>
                (string Name, decimal Salary, int Age)[] employees =
                {
                    ("Mahmoud", 1000m, 22),
                    ("John", 1200m, 28),
                    ("Sara", 2000m, 32),
                    ("Hadi", 1750m, 27),
                    ("Lana", 1500m, 24),
                    ("Luna", 1850m, 33)
                };

                // Get the oldest employee in the company.
                var oldestEmployee = employees.MaxBy(employee => employee.Age);

                Console.WriteLine($"Name: {oldestEmployee.Name}, Age: {oldestEmployee.Age}, Salary: ${oldestEmployee.Salary}");

                /*
                This code produces the following output:

                Name: Luna, Age: 33, Salary: $1850
                */
                // </Snippet212>
            }

            public static void MaxByComparerExample()
            {
                // <Snippet213>
                (string Name, int Quantity)[] inventory =
                {
                    ("apple", 10),
                    ("BANANA", 5),
                    ("Cherry", 20)
                };

                // Find the product with the maximum name alphabetically, ignoring casing differences.
                // 'C' is correctly identified as greater than 'a' and 'B' when case is ignored.
                var maxIgnoreCase = inventory.MaxBy(item => item.Name, StringComparer.OrdinalIgnoreCase);
                Console.WriteLine($"Case-insensitive comparison: {maxIgnoreCase.Name}");

                /*
                This code produces the following output:

                Case-insensitive comparison: Cherry
                */
                // </Snippet213>
            }
        }
        #endregion
    }
}
