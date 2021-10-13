using StringExamples.Compare;
using StringSamples.Concat;
using StringSamples.Contains;
using StringSamples.Equals;
using StringSamples.GetTypeCode;
using StringSamples.IndexOf;
using StringExamples.Remove;

namespace StringExamples
{
    public static class Program
    {
        public static void Main()
        {
            StringCompareSamples.RunSamples();
            StringConcatSamples.RunSamples();
            StringContainsSamples.RunSamples();
            StringEqualsSamples.RunSamples();
            StringGetTypeCodeSamples.RunSamples();
            StringIndexOfSamples.RunSamples();
            StringRemoveSamples.RunSamples();
        }
    }
}
