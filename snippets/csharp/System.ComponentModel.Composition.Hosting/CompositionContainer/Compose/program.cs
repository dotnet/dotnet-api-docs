using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;

namespace ConsoleApplication5
{
    //<snippet1>
    [Export]
    class Part1
    {
        public string data { get; } = "This is the example data!";
    }

    [Export]
    class Part2
    {
        [Import]
        public Part1 data { get; set; }
    }

    [Export]
    class Part3
    {
        [Import]
        public Part2 data { get; set; }
    }

    class Program
    {
        static void Main()
        {
            CompositionContainer container = new();
            CompositionBatch batch = new();
            batch.AddPart(AttributedModelServices.CreatePart(new Part1()));
            batch.AddPart(AttributedModelServices.CreatePart(new Part2()));
            batch.AddPart(AttributedModelServices.CreatePart(new Part3()));
            container.Compose(batch);
            Part3 part = container.GetExportedValue<Part3>();
            Console.WriteLine(part.data.data.data);
            Console.ReadLine();
        }
    }
    //</snippet1>
}
