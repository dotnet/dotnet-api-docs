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
            MinBy.MinByKeySelectorExample();
            MinBy.MinByComparerExample();
        }

        #region MinBy
        static class MinBy
        {
            public static void MinByKeySelectorExample()
            {
                // <Snippet210>
                (string Name, decimal Salary, int Age)[] employees =
                {
                    ("Mahmoud", 1000m, 22),
                    ("John", 1200m, 28),
                    ("Sara", 2000m, 32),
                    ("Hadi", 1750m, 27),
                    ("Lana", 1500m, 24),
                    ("Luna", 1850m, 33)
                };

                // Get the youngest employee in the company.
                var youngestEmployee = employees.MinBy(employee => employee.Age);

                Console.WriteLine($"Name: {youngestEmployee.Name}, Age: {youngestEmployee.Age}, Salary: ${youngestEmployee.Salary}");

                /*
                This code produces the following output:

                Name: Mahmoud, Age: 22, Salary: $1000
                */
                // </Snippet210>
            }

            public static void MinByComparerExample()
            {
                // <Snippet211>
                (string Name, int Quantity)[] inventory =
                {
                    ("apple", 10),
                    ("BANANA", 5),
                    ("Cherry", 20)
                };

                // Find the product with the minimum name alphabetically, ignoring casing differences.
                // 'a' is correctly identified as smaller than 'B' when case is ignored.
                var minIgnoreCase = inventory.MinBy(item => item.Name, StringComparer.OrdinalIgnoreCase);
                Console.WriteLine($"Case-insensitive comparison: {minIgnoreCase.Name}");

                /*
                This code produces the following output:

                Case-insensitive comparison: apple
                */
                // </Snippet211>
            }
        }
        #endregion
    }
}
