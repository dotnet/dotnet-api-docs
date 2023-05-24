//<SNIPPET1>
using namespace System;
using namespace System::IO;

int main()
{
    // Create a temporary file.
    String^ filePath = Path::GetTempFileName();
    Console::WriteLine("Created a temp file at '{0}.", filePath);

    // Create a new FileInfo object.
    FileInfo^ fInfo = gcnew FileInfo(filePath);
    
    // Get the read-only value for a file.
    bool isReadOnly = fInfo->IsReadOnly;

    // Display whether the file is read-only.
    Console::WriteLine("The file read-only value for '{0}' is {1}.", fInfo->Name, isReadOnly);

    // Set the file to read-only.
    Console::WriteLine("Setting the read-only value for '{0}' to true.", fInfo->Name);
    fInfo->IsReadOnly = true;

    // Get the read-only value for a file.
    isReadOnly = fInfo->IsReadOnly;

    // Display that the file is now read-only.
    Console::WriteLine("The file read-only value for '{0}' is {1}.", fInfo->Name, isReadOnly);

    // Make the file mutable again so it can be deleted.
    fInfo->IsReadOnly = false;

    // Delete the temporary file.
    fInfo->Delete();

    return 0;
};

// This code produces output similar to the following,
// though results may vary based on the computer, file structure, etc.:
//
// Created a temp file at 'C:\Users\UserName\AppData\Local\Temp\tmpB438.tmp'.
// The file read-only value for 'tmpB438.tmp' is False.
// Setting the read-only value for 'tmpB438.tmp' to true.
// The file read-only value for 'tmpB438.tmp' is True.
//
//</SNIPPET1>