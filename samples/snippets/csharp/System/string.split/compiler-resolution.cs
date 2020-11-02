using System;

namespace Split
{
    class CompilerResolution
    {
        public static void Main6()
        {
            // <Snippet1>
            string value = "This is a short string.";
            Char delimiter = 's';
            string[] substrings = value.Split(delimiter);
            foreach (var substring in substrings)
                Console.WriteLine(substring);

            // The example displays the following output:
            //     Thi
            //      i
            //      a
            //     hort
            //     tring.
            // </Snippet1>
        }
    }
}
