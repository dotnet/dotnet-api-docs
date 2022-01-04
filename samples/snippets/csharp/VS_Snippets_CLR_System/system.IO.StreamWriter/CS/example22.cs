// <Snippet22>
using System.IO;

namespace ConsoleApplication
{
    class Program3
    {
        static void Main()
        {
            WriteCharacters();
        }

        static async void WriteCharacters()
        {
            using (StreamWriter writer = File.CreateText("newfile.txt"))
            {
                await writer.WriteLineAsync('a');
                await writer.WriteLineAsync('b');
            }
        }
    }
}
// </Snippet22>