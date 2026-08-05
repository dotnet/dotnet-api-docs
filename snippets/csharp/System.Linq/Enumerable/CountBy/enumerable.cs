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
            CountBy.CountByDepartmentExample();
        }

        #region CountBy
        static class CountBy
        {

            public static void CountByDepartmentExample()
            {
                // <Snippet209>
                (string Name, int Age, string Department)[] employees =
                {
                    ("Saly", 23, "IT"),
                    ("David", 25, "Sales"),
                    ("Mahmoud", 22, "IT"),
                    ("Qamar", 22, "HR"),
                    ("Sara", 25, "IT"),
                    ("John", 26, "HR"),
                    ("Jaffar", 32, "Sales")
                };

                // Count the number of employees per department
                var countPerDepartment = employees.CountBy(employee => employee.Department);

                foreach (var item in countPerDepartment)
                {
                    Console.WriteLine($"Department: {item.Key} - Employees Count: {item.Value}");
                }

                /*
                This code produces the following output:

                Department: IT - Employees Count: 3
                Department: Sales - Employees Count: 2
                Department: HR - Employees Count: 2
                */
                // </Snippet209>
            }

        }
        #endregion
    }
}
