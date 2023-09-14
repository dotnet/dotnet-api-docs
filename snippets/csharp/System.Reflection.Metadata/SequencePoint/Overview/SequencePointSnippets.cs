using System;
using System.IO;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace SequencePointSnippets
{
    static class SequencePointSnippets
    {
        //<SnippetReadSourceLineData>
        public static void ReadSourceLineData(string pdbPath, int methodToken)
        {
            // Determine method row number
            EntityHandle ehMethod = MetadataTokens.EntityHandle(methodToken);

            if (ehMethod.Kind != HandleKind.MethodDefinition)
            {
                Console.WriteLine($"Invalid token kind: {ehMethod.Kind}");
                return;
            }

            int rowNumber = MetadataTokens.GetRowNumber(ehMethod);

            // MethodDebugInformation table is indexed by same row numbers as MethodDefinition table
            MethodDebugInformationHandle hDebug = MetadataTokens.MethodDebugInformationHandle(rowNumber);

            // Open Portable PDB file
            using var fs = new FileStream(pdbPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using MetadataReaderProvider provider = MetadataReaderProvider.FromPortablePdbStream(fs);
            MetadataReader reader = provider.GetMetadataReader();

            if (rowNumber > reader.MethodDebugInformation.Count)
            {
                Console.WriteLine("Error: Method row number is out of range");
                return;
            }

            // Print source line information as console table
            MethodDebugInformation di = reader.GetMethodDebugInformation(hDebug);
            Console.WriteLine("IL offset | Start line | Start col. | End line | End col. |");

            foreach (SequencePoint sp in di.GetSequencePoints())
            {
                if (sp.IsHidden)
                {
                    Console.WriteLine($"{sp.Offset.ToString().PadLeft(9)} | (hidden sequence point)");
                }
                else
                {
                    Console.WriteLine("{0} |{1} |{2} |{3} |{4} |", 
                        sp.Offset.ToString().PadLeft(9), 
                        sp.StartLine.ToString().PadLeft(11),
                        sp.StartColumn.ToString().PadLeft(11),
                        sp.EndLine.ToString().PadLeft(9),
                        sp.EndColumn.ToString().PadLeft(9));
                }
            }
        }
        //</SnippetReadSourceLineData>
    }
}
