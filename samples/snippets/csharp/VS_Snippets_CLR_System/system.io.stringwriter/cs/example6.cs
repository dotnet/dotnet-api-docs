﻿// <Snippet6>
using System;
using System.Text;
using System.IO;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteCharacters();
        }

        static async void WriteCharacters()
        {
            StringBuilder stringToWrite = new StringBuilder("Characters in StringBuilder");
            stringToWrite.AppendLine();

            using (StringWriter writer = new StringWriter(stringToWrite))
            {
                UnicodeEncoding ue = new UnicodeEncoding();
                char[] charsToAdd = ue.GetChars(ue.GetBytes("and chars to add"));

                await writer.WriteAsync(charsToAdd, 0, charsToAdd.Length);

                Console.WriteLine(stringToWrite.ToString());
            }
        }
    }
}
// The example displays the following output:
//
// Characters in StringBuilder
// and chars to add
//
// </Snippet6>