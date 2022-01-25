
// <snippet1>
using namespace System;
using namespace System::IO;
int main()
{
   
   // Open an existing file, or create a new one.
   FileInfo^ fi = gcnew FileInfo( "temp.txt" );
   
   // Open the file just specified such that no one else can use it.
   FileStream^ fs = fi->Open( FileMode::OpenOrCreate, FileAccess::ReadWrite, FileShare::None );
   
   // Create another reference to the same file.
   FileInfo^ nextfi = gcnew FileInfo( "temp.txt" );
   try
   {
      
      // Try opening the same file, which was locked by the previous process.
      nextfi->Open( FileMode::OpenOrCreate, FileAccess::Read );
      Console::WriteLine( "The file was not locked, and was opened by a second process." );
   }
   catch ( IOException^ ) 
   {
      Console::WriteLine( "The file could not be opened because it was locked by another process." );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( e );
   }

   
   // Close the file so it can be deleted.
   fs->Close();
}
//This code produces output similar to the following; 
//results may vary based on the computer/file structure/etc.:
//
//The file could not be opened because it was locked by another process.
// </snippet1>
