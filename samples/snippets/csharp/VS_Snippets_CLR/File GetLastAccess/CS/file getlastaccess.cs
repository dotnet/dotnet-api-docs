﻿// <Snippet1>
using System;
using System.IO;

class Test
{
    public static void Main()
    {
        try
        {
            string path = @"c:\Temp\MyTest.txt";

            if (!File.Exists(path))
            {
                File.Create(path);
            }
            File.SetLastAccessTime(path, new DateTime(1985,5,4));

            // Get the creation time of a well-known directory.
            DateTime dt = File.GetLastAccessTime(path);
            Console.WriteLine("The last access time for this file was {0}.", dt);
			
            // Update the last access time.
            File.SetLastAccessTime(path, DateTime.Now);
            dt = File.GetLastAccessTime(path);
            Console.WriteLine("The last access time for this file was {0}.", dt);
        }

        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
    }
}
// </Snippet1>
