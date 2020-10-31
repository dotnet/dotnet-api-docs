using System;

namespace Split
{
    class Identify
    {
        private static void SplitWithCharAndInt()
        {
            // <Snippet3>
            string phrase = "The quick  brown fox";

            _ = phrase.Split(default(Char[]), 3, StringSplitOptions.RemoveEmptyEntries);

            _ = phrase.Split((char[])null, 3, StringSplitOptions.RemoveEmptyEntries);

            _ = phrase.Split(null as char[], 3, StringSplitOptions.RemoveEmptyEntries);
            // </Snippet3>
        }

        private static void SplitWithStringAndInt()
        {
            // <Snippet4>
            string phrase = "The quick  brown fox";

            _ = phrase.Split(default(string[]), 3, StringSplitOptions.RemoveEmptyEntries);

            _ = phrase.Split((string[])null, 3, StringSplitOptions.RemoveEmptyEntries);

            _ = phrase.Split(null as string[], 3, StringSplitOptions.RemoveEmptyEntries);
            // </Snippet4>
        }

        private static void SplitWithChar()
        {
            // <Snippet5>
            string phrase = "The quick  brown fox";

            _ = phrase.Split(default(Char[]), StringSplitOptions.RemoveEmptyEntries);

            _ = phrase.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);

            _ = phrase.Split(null as char[], StringSplitOptions.RemoveEmptyEntries);
            // </Snippet5>
        }

        private static void SplitWithString()
        {
            // <Snippet6>
            string phrase = "The quick  brown fox";

            _ = phrase.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries);

            _ = phrase.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);

            _ = phrase.Split(null as string[], StringSplitOptions.RemoveEmptyEntries);
            // </Snippet6>
        }
    }
}
