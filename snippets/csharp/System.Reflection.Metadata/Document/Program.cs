using System;
using System.IO;

namespace DocumentSnippets
{
    class Program
    {
        static void Main(string[] args)
        {
            string? loc = Path.GetDirectoryName(typeof(Program).Assembly.Location);
            if (loc is not null)
            {
                string pdbPath = Path.Combine(loc, "DocumentSnippets.pdb");
                DocumentSnippets.ReadPdbDocuments(pdbPath);
            }
        }
    }
}
