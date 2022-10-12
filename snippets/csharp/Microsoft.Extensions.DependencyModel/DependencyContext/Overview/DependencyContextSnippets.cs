using System;
using Microsoft.Extensions.DependencyModel;

namespace DependencyContextSnippets
{
    class DependencyContextSnippets
    {
        static void PrintDependencyInformation()
        {
            //<SnippetPrintDependencyInformation>
            Console.WriteLine($"Target framework: {DependencyContext.Default.Target.Framework}");
            Console.WriteLine();
            Console.WriteLine("Runtime libraries:");
            Console.WriteLine();

            foreach (RuntimeLibrary lib in DependencyContext.Default.RuntimeLibraries)
            {
                if (lib.Dependencies.Count > 0)
                {
                    Console.WriteLine($"{lib.Name} depends on: ");

                    foreach (Dependency dep in lib.Dependencies)
                    {
                        Console.WriteLine($"- {dep.Name}, Version {dep.Version}");
                    }
                }
                else
                {
                    Console.WriteLine($"{lib.Name} does not have dependencies");
                }

                Console.WriteLine();
            }
            //</SnippetPrintDependencyInformation>
        }

        public static void Run()
        {
            PrintDependencyInformation();
        }
    }
}
