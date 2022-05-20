using System;
using System.IO;

namespace DocumentSnippets
{
    class Program
    {
        static void Main(string[] args)
        {
            string pdbPath = Path.Combine(Path.GetDirectoryName(typeof(Program).Assembly.Location),"DocumentSnippets.pdb");
            DocumentSnippets.ReadPdbDocuments(pdbPath);
        }
    }
}
