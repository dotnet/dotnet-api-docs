//<Snippet1>
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;

namespace CodeDomExamples
{
    class CodeDirectiveDemo
    {
        static void Main()
        {
            try
            {
                DemonstrateCodeDirectives("cs", "ChecksumPragma.cs", "ChecksumPragmaCS.exe");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unexpected Exception: {e}");
            }
        }

        // Create and compile code containing code directives.
        static void DemonstrateCodeDirectives(string providerName, string sourceFileName, string assemblyName)
        {
            string tempDirectory = Path.Combine(Path.GetTempPath(), $"CodeDomChecksumPragma_{Guid.NewGuid():N}");
            Directory.CreateDirectory(tempDirectory);

            string sourcePath = Path.Combine(tempDirectory, sourceFileName);
            string assemblyPath = Path.Combine(tempDirectory, assemblyName);
            EmitResult result = default;

            try
            {
                CodeDomProvider provider = CodeDomProvider.CreateProvider(providerName);

                Console.WriteLine("Building the CodeDOM graph...");

                CodeCompileUnit cu = new();

                CreateGraph(cu);

                StringWriter sw = new();

                Console.WriteLine("Generating code...");
                provider.GenerateCodeFromCompileUnit(cu, sw, null);

                string output = sw.ToString();
                output = Regex.Replace(output, "Runtime Version:[^\r\n]*",
                    "Runtime Version omitted for demo");

                Console.WriteLine("Dumping source code...");
                Console.WriteLine(output);

                Console.WriteLine("Writing source code to file...");
                File.WriteAllText(sourcePath, output);

                CompilerParameters opt = new([
                    "System.dll",
                    "System.Xml.dll",
                    "System.Windows.Forms.dll",
                    "System.Data.dll",
                    "System.Drawing.dll"])
                {
                    GenerateExecutable = false,
                    TreatWarningsAsErrors = true,
                    IncludeDebugInformation = true,
                    GenerateInMemory = true
                };

                Console.WriteLine($"Compiling.");

                SyntaxTree[] syntaxTrees =
                [
                    CSharpSyntaxTree.ParseText(File.ReadAllText(sourcePath))
                ];

                MetadataReference[] refs = [.. ((string)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES"))!
                    .Split(Path.PathSeparator)
                    .Select(p => MetadataReference.CreateFromFile(p))];

                CSharpCompilation compilation = CSharpCompilation.Create(
                    assemblyName: "GeneratedAssembly",
                    syntaxTrees: syntaxTrees,
                    references: refs,
                    options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

                using FileStream fs = File.Create(assemblyPath);
                result = compilation.Emit(fs);

                OutputResults(result);
                if (!result.Success)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Compilation failed.");
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Demo complete.");
                }
            }
            finally
            {
                if (Directory.Exists(tempDirectory))
                {
                    Directory.Delete(tempDirectory, recursive: true);
                }
            }
        }

        // This example uses the SHA1 and MD5 algorithms.
        // Due to collision problems with SHA1 and MD5, Microsoft recommends SHA256 or better.
        private static Guid s_hashMD5 = new(0x406ea660, 0x64cf, 0x4c82, 0xb6, 0xf0, 0x42, 0xd4, 0x81, 0x72, 0xa7, 0x99);
        private static Guid s_hashSHA1 = new(0xff1816ec, 0xaa5e, 0x4d10, 0x87, 0xf7, 0x6f, 0x49, 0x63, 0x83, 0x34, 0x60);

        // Create a CodeDOM graph.
        static void CreateGraph(CodeCompileUnit cu)
        {
            //<Snippet2>
            cu.StartDirectives.Add(new CodeRegionDirective(
                CodeRegionMode.Start,
                "Compile Unit Region"));
            //</Snippet2>
            //<Snippet3>
            cu.EndDirectives.Add(new CodeRegionDirective(
                CodeRegionMode.End,
                string.Empty));
            //</Snippet3>
            CodeChecksumPragma pragma1 = new()
            {
                //<Snippet5>
                FileName = "c:\\temp\\test\\OuterLinePragma.txt",
                //</Snippet5>
                //<Snippet6>
                ChecksumAlgorithmId = s_hashMD5,
                //</Snippet6>
                //<Snippet7>
                ChecksumData = [0xAA, 0xAA]
                //</Snippet7>
            };
            cu.StartDirectives.Add(pragma1);
            //<Snippet8>
            CodeChecksumPragma pragma2 = new("test.txt", s_hashSHA1, [0xBB, 0xBB, 0xBB]);
            //</Snippet8>
            cu.StartDirectives.Add(pragma2);

            CodeNamespace ns = new("Namespace1");
            ns.Imports.Add(new CodeNamespaceImport("System"));
            ns.Imports.Add(new CodeNamespaceImport("System.IO"));
            cu.Namespaces.Add(ns);
            ns.Comments.Add(new CodeCommentStatement("Namespace Comment"));
            CodeTypeDeclaration cd = new("Class1");
            ns.Types.Add(cd);

            cd.Comments.Add(new CodeCommentStatement("Outer Type Comment"));
            cd.LinePragma = new CodeLinePragma("c:\\temp\\test\\OuterLinePragma.txt", 300);

            CodeMemberMethod method1 = new()
            {
                Name = "Method1"
            };
            method1.Attributes = (method1.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Public;

            CodeMemberMethod method2 = new()
            {
                Name = "Method2"
            };
            method2.Attributes = (method2.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Public;
            method2.Comments.Add(new CodeCommentStatement("Method 2 Comment"));

            cd.Members.Add(method1);
            cd.Members.Add(method2);

            cd.StartDirectives.Add(new CodeRegionDirective(CodeRegionMode.Start,
                "Outer Type Region"));

            cd.EndDirectives.Add(new CodeRegionDirective(CodeRegionMode.End,
                string.Empty));

            CodeMemberField field1 = new(typeof(string), "field1");
            cd.Members.Add(field1);
            field1.Comments.Add(new CodeCommentStatement("Field 1 Comment"));

            //<Snippet9>
            CodeRegionDirective codeRegionDirective1 = new(CodeRegionMode.Start, "Field Region");
            //</Snippet9>
            //<Snippet10>
            field1.StartDirectives.Add(codeRegionDirective1);
            //</Snippet10>
            CodeRegionDirective codeRegionDirective2 = new(CodeRegionMode.End, "")
            {
                //<Snippet11>
                RegionMode = CodeRegionMode.End,
                //</Snippet11>
                //<Snippet12>
                RegionText = string.Empty
            };
            //</Snippet12>
            //<Snippet13>
            field1.EndDirectives.Add(codeRegionDirective2);
            //</Snippet13>

            //<Snippet16>
            CodeSnippetStatement snippet1 = new()
            {
                Value = "            Console.WriteLine(field1);"
            };

            CodeRegionDirective regionStart = new(CodeRegionMode.End, "")
            {
                RegionText = "Snippet Region",
                RegionMode = CodeRegionMode.Start
            };
            snippet1.StartDirectives.Add(regionStart);
            snippet1.EndDirectives.Add(new CodeRegionDirective(CodeRegionMode.End, string.Empty));
            //</Snippet16>

            // CodeStatement example
            CodeConstructor constructor1 = new();
            constructor1.Attributes = (constructor1.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Public;
            CodeStatement codeAssignStatement1 = new CodeAssignStatement(
                                        new CodeFieldReferenceExpression(
                                            new CodeThisReferenceExpression(),
                                            "field1"),
                                        new CodePrimitiveExpression("value1"));
            //<Snippet14>
            codeAssignStatement1.StartDirectives.Add(new CodeRegionDirective(CodeRegionMode.Start, "Statements Region"));
            //</Snippet14>
            cd.Members.Add(constructor1);
            //<Snippet15>
            codeAssignStatement1.EndDirectives.Add(new CodeRegionDirective(CodeRegionMode.End, string.Empty));
            //</Snippet15>
            method2.Statements.Add(codeAssignStatement1);
            method2.Statements.Add(snippet1);
        }

        static void OutputResults(EmitResult result)
        {
            Console.WriteLine("Compiler output:");
            foreach (Diagnostic d in result.Diagnostics)
            {
                Console.WriteLine(d.ToString());
            }
        }
    }
}
//</Snippet1>
