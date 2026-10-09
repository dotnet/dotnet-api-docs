using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace ConsoleApplication3
{
    //<snippet1>
    // Default export infers the type and contract name from the exported type.
    // This is the preferred method.
    [Export]
    public class MyExport1
    {
        public string data { get; } = "Test Data 1.";
    }

    public class MyImporter1
    {
        [Import]
        public MyExport1 importedMember { get; set; }
    }

    public interface MyInterface
    {
    }

    // Specifying the contract type can be important if you want to export a type
    // other than the base type, such as an interface.
    [Export(typeof(MyInterface))]
    public class MyExport2 : MyInterface
    {
        public string data { get; } = "Test Data 2.";
    }

    public class MyImporter2
    {
        // The import must match the contract type.
        [Import(typeof(MyInterface))]
        public MyExport2 importedMember { get; set; }
    }

    // Specifying a contract name should only be needed in rare cases.
    // Usually, using metadata is a better approach.
    [Export("MyContractName", typeof(MyInterface))]
    public class MyExport3 : MyInterface
    {
        public string data { get; } = "Test Data 3.";
    }

    public class MyImporter3
    {
        // Both the contract name and type must match.
        [Import("MyContractName", typeof(MyInterface))]
        public MyExport3 importedMember { get; set; }
    }

    internal class Program
    {
        static void Main()
        {
            AggregateCatalog catalog = new();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(MyExport1).Assembly));
            CompositionContainer container = new(catalog);
            MyImporter1 test1 = new();
            MyImporter2 test2 = new();
            MyImporter3 test3 = new();
            container.SatisfyImportsOnce(test1);
            container.SatisfyImportsOnce(test2);
            container.SatisfyImportsOnce(test3);
            Console.WriteLine(test1.importedMember.data);
            Console.WriteLine(test2.importedMember.data);
            Console.WriteLine(test3.importedMember.data);
            Console.ReadLine();
        }
    }
    //</snippet1>
}
