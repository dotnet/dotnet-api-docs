//<Snippet11>
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.CSharp;

public class CodeDOMSample
{
    public static void Run()
    {
        string sourceFile;
        int dotSpot;

        CodeCompileUnit cu = new CodeCompileUnit();
        sourceFile = GenerateCSharpCode(cu);
        Console.WriteLine($"CS source file: {sourceFile}");
        dotSpot = sourceFile.IndexOf('.');
        CompileCSharpCode(sourceFile, sourceFile.Substring(0, dotSpot) + ".exe");
    }

    // <snippet13>
    public static string GenerateCSharpCode(CodeCompileUnit compileunit)
    {
        // Generate the code with the C# code provider.
        // <snippet12>
        CSharpCodeProvider provider = new CSharpCodeProvider();
        // </snippet12>

        // Build the output file name.
        string sourceFile;
        if (provider.FileExtension[0] == '.')
        {
            sourceFile = "HelloWorld" + provider.FileExtension;
        }
        else
        {
            sourceFile = "HelloWorld." + provider.FileExtension;
        }

        // Create a TextWriter to a StreamWriter to the output file.
        IndentedTextWriter tw = new IndentedTextWriter(
                new StreamWriter(sourceFile, false), "    ");

        // Generate source code using the code provider.
        provider.GenerateCodeFromCompileUnit(compileunit, tw,
               new CodeGeneratorOptions());

        // Close the output file.
        tw.Close();

        return sourceFile;
    }
    // </snippet13>

    // <snippet14>
    public static bool CompileCSharpCode(string sourceFile,
        string exeFile)
    {
        SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(File.ReadAllText(sourceFile));
        string trustedPlatformAssemblies =
            (string)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES");
        MetadataReference[] references = trustedPlatformAssemblies
            .Split(Path.PathSeparator)
            .Select(path => MetadataReference.CreateFromFile(path))
            .ToArray();
        CSharpCompilation compilation = CSharpCompilation.Create(
            Path.GetFileNameWithoutExtension(exeFile),
            [syntaxTree],
            references,
            new CSharpCompilationOptions(OutputKind.ConsoleApplication));

        using FileStream assemblyStream = File.Create(exeFile);
        EmitResult result = compilation.Emit(assemblyStream);

        if (!result.Success)
        {
            // Display compilation errors.
            Console.WriteLine($"Errors building {sourceFile} into {exeFile}");
            foreach (Diagnostic diagnostic in result.Diagnostics)
            {
                Console.WriteLine($"  {diagnostic}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine($"Source {sourceFile} built into {exeFile} successfully.");
        }

        // Return the results of compilation.
        return result.Success;
    }
    // </snippet14>
}
//</Snippet11>
