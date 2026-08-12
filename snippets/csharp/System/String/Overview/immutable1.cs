// <Snippet16>
using System;
using System.IO;
using System.Text;

public class Example
{
    public static void Main()
    {
        Random rnd = new();
        StringBuilder sb = new();
        StreamWriter sw = new(@".\StringFile.txt",
                                           false, Encoding.Unicode);

        for (int ctr = 0; ctr <= 1000; ctr++)
        {
            sb.Append((char)rnd.Next(1, 0x0530));
            if (sb.Length % 60 == 0)
                sb.AppendLine();
        }
        sw.Write(sb);
        sw.Close();
    }
}
// </Snippet16>
