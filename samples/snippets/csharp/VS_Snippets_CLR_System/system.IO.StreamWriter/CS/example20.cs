// <Snippet20>
using System.IO;

namespace ConsoleApplication
{
    class Program1
    {
        static void Main()
        {
            WriteCharacters();
        }

        static async void WriteCharacters()
        {
            using (StreamWriter writer = File.CreateText("newfile.txt"))
            {
                await writer.WriteAsync('a');
            }
        }
    }
}
// </Snippet20>