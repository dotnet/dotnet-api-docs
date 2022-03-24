using System;
using System.IO;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace DocumentSnippets
{
    static class DocumentSnippets
    {
        //<SnippetReadPdb>
        static string ReadDocumentPath(MetadataReader reader, Document doc)
        {
            BlobReader blob = reader.GetBlobReader(doc.Name);

            // Read path separator character
            var separator = (char)blob.ReadByte();
            var sb = new StringBuilder(blob.Length * 2);

            // Read path segments
            while (true)
            {
                BlobHandle bh = blob.ReadBlobHandle();

                if (!bh.IsNil)
                {
                    byte[] nameBytes = reader.GetBlobBytes(bh);
                    sb.Append(Encoding.UTF8.GetString(nameBytes));
                }

                if (blob.Offset >= blob.Length) break;

                sb.Append(separator);
            }

            return sb.ToString();
        }

        public static void ReadPdbDocuments(string pdbPath)
        {
            // Open Portable PDB file
            using var fs = new FileStream(pdbPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using MetadataReaderProvider provider = MetadataReaderProvider.FromPortablePdbStream(fs);
            
            MetadataReader reader = provider.GetMetadataReader();

            // Display information about documents in each MethodDebugInformation table entry
            foreach (MethodDebugInformationHandle h in reader.MethodDebugInformation)
            {
                MethodDebugInformation mdi = reader.GetMethodDebugInformation(h);

                if (mdi.Document.IsNil) continue;

                int token = MetadataTokens.GetToken(h);
                Console.WriteLine($"MethodDebugInformation 0x{token.ToString("X")}");

                Document doc = reader.GetDocument(mdi.Document);
                Console.WriteLine($"File: {ReadDocumentPath(reader, doc)}");
                Guid guidLang = reader.GetGuid(doc.Language);
                Console.WriteLine($"Language: {guidLang}");
                Guid guidHashAlg = reader.GetGuid(doc.HashAlgorithm);
                Console.WriteLine($"Hash algorithm: {guidHashAlg}");
                Console.WriteLine();
            }
        }
        //</SnippetReadPdb>
    }
}
