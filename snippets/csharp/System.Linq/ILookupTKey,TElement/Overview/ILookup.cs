using System;
using System.Collections.Generic;
using System.Linq;

namespace SequenceExamples
{
    static class ILookup
    {
        static void Main() => ILookupExample();

        // <Snippet1>
        class Package(string company, double weight, long trackingNumber)
        {
            public string Company { get; set; } = company;
            public double Weight { get; set; } = weight;
            public long TrackingNumber { get; set; } = trackingNumber;
        }

        public static void ILookupExample()
        {
            // Create a list of Packages to put into an ILookup data structure.
            List<Package> packages = [
                new Package ("Coho Vineyard", 25.2, 89453312L ),
                new Package ("Lucerne Publishing", 18.7, 89112755L ),
                new Package ("Wingtip Toys", 6.0, 299456122L ),
                new Package ("Contoso Pharmaceuticals", 9.3, 670053128L ),
                new Package ("Wide World Importers", 33.8, 4665518773L ) ];

            // Create a Lookup to organize the packages. Use the first character of Company as the key value.
            // Select Company appended to TrackingNumber for each element value in the ILookup object.
            ILookup<char, string> packageLookup = packages.ToLookup(
                p => p.Company[0],
                p => p.Company + " " + p.TrackingNumber
                );

            // Iterate through each value in the ILookup and output the contents.
            foreach (IGrouping<char, string> packageGroup in packageLookup)
            {
                // Print the key value.
                Console.WriteLine(packageGroup.Key);
                // Iterate through each value in the collection.
                foreach (string str in packageGroup)
                {
                    Console.WriteLine("    {0}", str);
                }
            }

            // This code produces the following output:
            //
            // C
            //     Coho Vineyard 89453312
            //     Contoso Pharmaceuticals 670053128
            // L
            //     Lucerne Publishing 89112755
            // W
            //     Wingtip Toys 299456122
            //     Wide World Importers 4665518773
        }
        // </Snippet1>
    }
}
