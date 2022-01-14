using System;
using System.IO;
using System.Reflection;

namespace SequencePointSnippets
{
    class Program
    {
        static void Main(string[] args)
        {
            string pdbPath = Path.Combine(Path.GetDirectoryName(typeof(Program).Assembly.Location), "SequencePointSnippets.pdb");
            SequencePointSnippets.ReadSourceLineData(pdbPath, MethodInfo.GetCurrentMethod().MetadataToken);
        }
    }
}
