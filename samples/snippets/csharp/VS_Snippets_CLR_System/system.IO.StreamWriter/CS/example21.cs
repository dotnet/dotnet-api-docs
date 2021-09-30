// <Snippet21>
using System.IO;

namespace ConsoleApplication
{
    class Program2
    {
        static void Main()
        {
            WriteCharacters();
        }

        static async void WriteCharacters()
        {
            using (StreamWriter writer = File.CreateText("newfile.txt"))
            {
                await writer.WriteAsync("Example text as string");
            }
        }
    }
}
// </Snippet21>