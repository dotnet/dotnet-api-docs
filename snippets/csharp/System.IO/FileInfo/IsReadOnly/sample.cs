//<SNIPPET1>
using System;
using System.IO;

public class FileExample
{
    public static void Main()
    {
        string fileName = @"c:\test.xml";

        // Get the read-only value for a file.
        bool isReadOnly = IsFileReadOnly(fileName);

        // Display whether the file is read-only.
         Console.WriteLine("The file read-only value for " + fileName + " is: " + isReadOnly);

        // Set the file to read-write.        
        Console.WriteLine("Changing the read-only value for " + fileName + " to false.");
        SetFileReadAccess(fileName, false);

        // Get the read-only value for a file.
        isReadOnly = IsFileReadOnly(fileName);

        // Display that the file is now read-write.
        Console.WriteLine("The file read-only value for " + fileName + " is: " + isReadOnly);
    }

    // Sets the read-only value of a file.
    public static void SetFileReadAccess(string fileName, bool setReadOnly)
    {
        // Create a new FileInfo object.
        FileInfo fInfo = new FileInfo(fileName);

        // Set the IsReadOnly property.
        fInfo.IsReadOnly = setReadOnly;
    }

    // Returns whether a file is read-only.
    public static bool IsFileReadOnly(string fileName)
    {
        // Create a new FileInfo object.
        FileInfo fInfo = new FileInfo(fileName);

        // Return the IsReadOnly property value.
        return fInfo.IsReadOnly;
    }
}

// This code produces output similar to the following,
// though results may vary based on the computer, file structure, etc.:
//
// The file read-only value for c:\test.xml is: True
// Changing the read-only value for c:\test.xml to false.
// The file read-only value for c:\test.xml is: False
//
//</SNIPPET1>
