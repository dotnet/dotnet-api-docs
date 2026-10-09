using System;
using System.Collections.Generic;
using System.CodeDom.Compiler;

ProviderOptions.ProviderOptionsSample.Run();
CodeDomCompilerInfoSample.CompilerInfoSample.Run(args);

//<Snippet1>
namespace ProviderOptions
{
    class ProviderOptionsSample
    {
        public static void Run()
        {
            DisplayCSharpCompilerInfo();
            DisplayVBCompilerInfo();
            Console.WriteLine("Press Enter key to exit.");
            Console.ReadLine();
        }
        static void DisplayCSharpCompilerInfo()
        {
            Dictionary<string, string> provOptions = new()
            {
                ["CompilerVersion"] = "v4"
            };

            // Get the provider for Microsoft.CSharp.
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp", provOptions);

            // Display the C# language provider information.
            Console.WriteLine($"CSharp provider is {provider}");
            Console.WriteLine($"  Provider hash code:     {provider.GetHashCode()}");
            Console.WriteLine($"  Default file extension: {provider.FileExtension}");

            Console.WriteLine();
        }

        static void DisplayVBCompilerInfo()
        {
            Dictionary<string, string> provOptions = new()
            {
                ["CompilerVersion"] = "v3.5"
            };

            // Get the provider for Microsoft.VisualBasic.
            CodeDomProvider provider = CodeDomProvider.CreateProvider("VisualBasic", provOptions);

            // Display the Visual Basic language provider information.
            Console.WriteLine($"Visual Basic provider is {provider}");
            Console.WriteLine($"  Provider hash code:     {provider.GetHashCode()}");
            Console.WriteLine($"  Default file extension: {provider.FileExtension}");

            Console.WriteLine();
        }
    }
}
//</Snippet1>
