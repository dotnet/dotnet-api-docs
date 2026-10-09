using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace CompositionContainerExample
{
    //<snippet1>
    [Export]
    class MyAddin
    {
        public string myData => "The data!";
    }

    class MyProgram
    {
        [Import]
        public MyAddin myAddin { get; set; }
    }

    class Program
    {
        static void Main()
        {
            AggregateCatalog catalog = new();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(MyAddin).Assembly));
            CompositionContainer container = new(catalog);
            MyProgram myProgram = new();
            container.SatisfyImportsOnce(myProgram);
            Console.WriteLine(myProgram.myAddin.myData);
            Console.ReadLine();

            container.Dispose();
        }
    }
    //</snippet1>
}
