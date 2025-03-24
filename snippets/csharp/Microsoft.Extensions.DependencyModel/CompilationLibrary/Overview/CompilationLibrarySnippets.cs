using System;
using Microsoft.Extensions.DependencyModel;

namespace CompilationLibrarySnippets
{
    static class CompilationLibrarySnippets
    {
        public static void SnippetPrintLibraries()
        {
            //<SnippetPrintLibraries>
            foreach (CompilationLibrary lib in DependencyContext.Default.CompileLibraries)
            {
                Console.WriteLine($"Library: {lib.Name} {lib.Version}");
                Console.WriteLine($"Type:    {lib.Type}");
                Console.WriteLine("Reference paths:");

                foreach (string path in lib.ResolveReferencePaths())
                {
                    Console.WriteLine(path);
                }
            }
            //</SnippetPrintLibraries>
        }
    }
}
