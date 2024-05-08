using System;
using System.IO;
using System.Reflection;

namespace SequencePointSnippets
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Path.GetDirectoryName(typeof(Program).Assembly.Location) is string loc)
            {
                string pdbPath = Path.Combine(loc, "SequencePointSnippets.pdb");

                if (MethodInfo.GetCurrentMethod() is MethodBase mbase)
                    SequencePointSnippets.ReadSourceLineData(pdbPath, mbase.MetadataToken);
            }
        }
    }
}
