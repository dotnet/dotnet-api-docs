// <Snippet24>
using System.IO;
using System.Text;

namespace ConsoleApplication
{
    class Program5
    {
        static void Main()
        {
            WriteCharacters();
        }

        static async void WriteCharacters()
        {
            UnicodeEncoding ue = new UnicodeEncoding();
            char[] charsToAdd = ue.GetChars(ue.GetBytes("Example string"));
            using (StreamWriter writer = File.CreateText("newfile.txt"))
            {
                await writer.WriteAsync(charsToAdd, 0, charsToAdd.Length);
            }
        }
    }
}
// </Snippet24>