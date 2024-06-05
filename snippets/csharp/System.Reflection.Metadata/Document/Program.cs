using System;
using System.IO;

namespace DocumentSnippets
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Path.GetDirectoryName(typeof(Program).Assembly.Location) is string loc)
            {
                string pdbPath = Path.Combine(loc, "DocumentSnippets.pdb");
                DocumentSnippets.ReadPdbDocuments(pdbPath);
            }
        }
    }
}
