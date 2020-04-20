using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;

namespace MetadataReaderSnippets
{
    class MetadataReaderSnippets
    {
        public static void Run()
        {
            //<SnippetMetadataReader>
            FileStream fs = new FileStream("Example.dll", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            using (fs)
            {
                PEReader peReader = new PEReader(fs);

                using (peReader)
                {
                    MetadataReader mr = peReader.GetMetadataReader();

                    foreach (TypeDefinitionHandle tdefh in mr.TypeDefinitions)
                    {
                        TypeDefinition tdef = mr.GetTypeDefinition(tdefh);

                        string ns = mr.GetString(tdef.Namespace);
                        string name = mr.GetString(tdef.Name);
                        Console.WriteLine($"{ns}.{name}");
                    }
                }
            }
            //</SnippetMetadataReader>
        }
    }
}
