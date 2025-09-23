using System;
using System.IO;
using System.Reflection.PortableExecutable;

namespace PEHeaderSnippets
{
    class PEHeaderSnippets
    {
        static void ExampleReadPEHeader()
        {
            //<SnippetReadPEHeader>
            // Open the Portable Executable (PE) file
            using var fs = new FileStream(@"Example.dll", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var peReader = new PEReader(fs);

            // Display PE header information
            if (peReader.PEHeaders.PEHeader is PEHeader header)
            {
                Console.WriteLine($"Image size, bytes:   {header.SizeOfImage}");
                Console.WriteLine($"Image base:          0x{header.ImageBase:X}");
                Console.WriteLine($"File alignment:      0x{header.FileAlignment:X}");
                Console.WriteLine($"Section alignment:   0x{header.SectionAlignment:X}");
                Console.WriteLine($"Subsystem:           {header.Subsystem}");
                Console.WriteLine($"Dll characteristics: {header.DllCharacteristics}");
                Console.WriteLine($"Linker version:      {header.MajorLinkerVersion}.{header.MinorLinkerVersion}");
                Console.WriteLine($"OS version:          {header.MajorOperatingSystemVersion}.{header.MinorOperatingSystemVersion}");
            }
            //</SnippetReadPEHeader>
        }

        public static void Run()
        {
            ExampleReadPEHeader();
        }
    }
}
