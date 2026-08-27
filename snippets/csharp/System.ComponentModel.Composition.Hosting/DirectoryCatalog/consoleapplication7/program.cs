using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using ClassLibrary1;

namespace ConsoleApplication7
{
    //<snippet1>
    public class Test2
    {
        [Import]
        public Test1 data { get; set; }
    }

    class Program
    {
        static void Main()
        {
            DirectoryCatalog catalog = new(".");
            CompositionContainer container = new(catalog);
            Test2 test = new();
            container.SatisfyImportsOnce(test);
            Console.WriteLine(test.data.data);
            Console.ReadLine();
        }
    }
    //</snippet1>
}
