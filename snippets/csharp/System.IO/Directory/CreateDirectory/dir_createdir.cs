// <Snippet1>
using System;
using System.IO;

class Test
{
    public static void Main()
    {
        // Specify the directory you want to manipulate.
        string path = @"c:\MyDir";
        
        // Determine whether the directory exists.
        if (Directory.Exists(path))
        {
            Console.WriteLine("That path exists already.");
            return;
        }
        
        DirectoryInfo di;
        try
        {
            // Try to create the directory.
            di = Directory.CreateDirectory(path);
            Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine("The caller does not have the required permission to create `{0}`", path);
            return;
        }
        
        // Delete the directory.
        di.Delete();
        Console.WriteLine("The directory was deleted successfully.");
    }
}
// </Snippet1>
