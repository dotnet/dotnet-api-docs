using System;
using System.IO;

class Program
{
    static void Main()
    {
        ShowPathInformation("C:/", "users/user1/documents", "letters");
        ShowPathInformation("D:/", "/users/user1/documents", "letters");
        ShowPathInformation("D:/", "users/user1/documents", "C:/users/user1/documents/data");
    }

   private static void ShowPathInformation(string path1, string path2, string path3)
    {
        Console.WriteLine($"Concatenating  '{path1}', '{path2}', and '{path3}'");
        Console.WriteLine($"   Path.Join:     '{Path.Join(path1, path2, path3)}'");
        Console.WriteLine($"   Path.Combine:  '{Path.Combine(path1, path2, path3)}'");
        Console.WriteLine($"   {Path.GetFullPath(Path.Join(path1, path2, path3))}");
    }
}
// The example displays the following output if run on a Windows system:
// Concatenating  'C:/', 'users/user1/documents', and 'letters'
//    Path.Join:     'C:/users/user1/documents\letters'
//    Path.Combine:  'C:/users/user1/documents\letters'
//    C:\users\user1\documents\letters
// Concatenating  'D:/', '/users/user1/documents', and 'letters'
//    Path.Join:     'D://users/user1/documents\letters'
//    Path.Combine:  '/users/user1/documents\letters'
//    D:\users\user1\documents\letters
// Concatenating  'D:/', 'users/user1/documents', and 'C:/users/user1/documents/data'
//    Path.Join:     'D:/users/user1/documents\C:/users/user1/documents/data'
//    Path.Combine:  'C:/users/user1/documents/data'
//    D:\users\user1\documents\C:\users\user1\documents\data
