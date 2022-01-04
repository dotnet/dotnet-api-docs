// <Snippet23>
using System.IO;

namespace ConsoleApplication
{
    class Program4
    {
        static void Main()
        {
            WriteCharacters();
        }

        static async void WriteCharacters()
        {
            using (StreamWriter writer = File.CreateText("newfile.txt"))
            {
                await writer.WriteLineAsync("First line of example");
                await writer.WriteLineAsync("and second line");
            }
        }
    }
}
// </Snippet23>