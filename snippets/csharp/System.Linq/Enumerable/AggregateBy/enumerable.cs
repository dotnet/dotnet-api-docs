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
            AggregateBy.AggregateBySeedExample();
        }

        #region AggregateBy
        static class AggregateBy
        {
            
            public static void AggregateBySeedSelectorExample()
            {
                // <Snippet205>
                (string Name, string Department, decimal Salary)[] employees =
                {
                    ("Ali", "HR", 45000),
                    ("Samer", "Technology", 50000),
                    ("Hamed", "Sales", 75000),
                    ("Lina", "Technology", 65000),
                    ("Omar", "HR", 40000)
                };

                var result =
                    employees.AggregateBy(
                        e => e.Department,
                        dept => (Total: 0m, Count: 0),
                        (acc, e) => (acc.Total + e.Salary, acc.Count + 1)
                    );

                foreach (var item in result)
                {
                    Console.WriteLine($"{item.Key}: Total={item.Value.Total}, Count={item.Value.Count}");
                }

                /*
                 This code produces the following output:

                 HR: Total=85000, Count=2
                 Technology: Total=115000, Count=2
                 Sales: Total=75000, Count=1
                */
                // </Snippet205>
            }


           
            public static void AggregateBySeedExample()
            {
                // <Snippet206>
                (string Name, string Department, decimal Salary)[] employees =
                {
                    ("Ali", "HR", 45000),
                    ("Samer", "Technology", 50000),
                    ("Hamed", "Sales", 75000),
                    ("Lina", "Technology", 65000),
                    ("Omar", "HR", 40000)
                };

                var totals =
                    employees.AggregateBy(
                        e => e.Department,
                        0m,
                        (total, e) => total + e.Salary
                    );

                foreach (var item in totals)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }

                /*
                 This code produces the following output:

                 HR: 85000
                 Technology: 115000
                 Sales: 75000
                */
                // </Snippet206>
            }

        }
        #endregion
    }
}
