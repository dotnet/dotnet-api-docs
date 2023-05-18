using System;
using System.IO;
using System.Reflection;

namespace SequencePointSnippets
{
    class Program
    {
        static void Main(string[] args)
        {
            string? loc = Path.GetDirectoryName(typeof(Program).Assembly.Location);
            if (loc is not null)
            {
                string pdbPath = Path.Combine(loc, "SequencePointSnippets.pdb");

                MethodBase? mbase = MethodInfo.GetCurrentMethod();
                if (mbase is not null)
                    SequencePointSnippets.ReadSourceLineData(pdbPath, mbase.MetadataToken);
            }
        }
    }
}
