using System;
using System.IO;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;

namespace MethodBodyBlockSnippets
{
    class MethodBodyBlockSnippets
    {
        //<SnippetPrintMethods>
        static void PrintMethods(PEReader reader, MetadataReader mr, TypeDefinition tdef)
        {
            MethodDefinitionHandleCollection methods = tdef.GetMethods();

            foreach (MethodDefinitionHandle mdefh in methods)
            {
                MethodDefinition mdef = mr.GetMethodDefinition(mdefh);
                string mname = mr.GetString(mdef.Name);
                Console.WriteLine($"Method: {mname}");

                // Get the relative address of the method body in the executable
                int rva = mdef.RelativeVirtualAddress;

                if (rva == 0)
                {
                    Console.WriteLine("Method body not found");
                    Console.WriteLine();
                    continue;
                }

                // Get method body information
                MethodBodyBlock mb = reader.GetMethodBody(rva);
                Console.WriteLine($"  Maximum stack size: {mb.MaxStack}");
                Console.WriteLine($"  Local variables initialized: {mb.LocalVariablesInitialized}");

                byte[] il = mb.GetILBytes();
                Console.WriteLine($"  Method body size: {il.Length}");
                Console.WriteLine($"  Exception regions: {mb.ExceptionRegions.Length}");
                Console.WriteLine();

                foreach (var region in mb.ExceptionRegions)
                {
                    Console.WriteLine(region.Kind.ToString());
                    Console.WriteLine($"  Try block offset: {region.TryOffset}");
                    Console.WriteLine($"  Try block length: {region.TryLength}");
                    Console.WriteLine($"  Handler offset: {region.HandlerOffset}");
                    Console.WriteLine($"  Handler length: {region.HandlerLength}");
                    Console.WriteLine();
                }
            }
        }
        //</SnippetPrintMethods>

        public static void Run()
        {
            string path = typeof(Program).Assembly.Location;
            using var s = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var reader = new PEReader(s);                
            MetadataReader mr = reader.GetMetadataReader(MetadataReaderOptions.None);

            foreach (TypeDefinitionHandle t in mr.TypeDefinitions)
            {
                TypeDefinition tdef = mr.GetTypeDefinition(t);
                PrintMethods(reader, mr, tdef);
            }
        }
    }
}
