
// <Snippet1>
using namespace System;
using namespace System::Text;
int main()
{
   array<Byte>^bytes = {65,83,67,73,73,32,69,110,99,111,100,105,110,103,32,69,120,97,109,112,108,101};
   ASCIIEncoding^ ascii = gcnew ASCIIEncoding;
   int charCount = ascii->GetCharCount( bytes, 6, 8 );
   Console::WriteLine( "{0} characters needed to decode bytes.", charCount );
}

// </Snippet1>
