
// <Snippet1>
using namespace System;
using namespace System::Collections;
using namespace System::Text;
int main()
{
   
   // The encoding.
   ASCIIEncoding^ ascii = gcnew ASCIIEncoding;
   
   // A Unicode string with two characters outside the ASCII code range.
   String^ unicodeString = L"This Unicode String* contains two characters with codes outside the ASCII code range, Pi (\u03a0) and Sigma (\u03a3).";
   Console::WriteLine( "Original String*:" );
   Console::WriteLine( unicodeString );
   
   // Save positions of the special characters for later reference.
   int indexOfPi = unicodeString->IndexOf( L'\u03a0' );
   int indexOfSigma = unicodeString->IndexOf( L'\u03a3' );
   
   // Encode string.
   array<Byte>^encodedBytes = ascii->GetBytes( unicodeString );
   Console::WriteLine();
   Console::WriteLine( "Encoded bytes:" );
   IEnumerator^ myEnum = encodedBytes->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Byte b = safe_cast<Byte>(myEnum->Current);
      Console::Write( "->Item[ {0}]", b );
   }

   Console::WriteLine();
   
   // Notice that the special characters have been replaced with
   // the value 63, which is the ASCII character code for '?'.
   Console::WriteLine();
   Console::WriteLine( "Value at position of Pi character: {0}", encodedBytes[ indexOfPi ] );
   Console::WriteLine( "Value at position of Sigma character: {0}", encodedBytes[ indexOfSigma ] );
   
   // Decode bytes back to string.
   // Notice missing Pi and Sigma characters.
   String^ decodedString = ascii->GetString( encodedBytes );
   Console::WriteLine();
   Console::WriteLine( "Decoded bytes:" );
   Console::WriteLine( decodedString );
}
// The example displays the following output:
//    Original string:
//    This Unicode string contains two characters with codes outside the ASCII code ra
//    nge, Pi (Π) and Sigma (Σ).
//
//    Encoded bytes:
//    [84][104][105][115][32][85][110][105][99][111][100][101][32][115][116][114][105]
//    [110][103][32][99][111][110][116][97][105][110][115][32][116][119][111][32][99][
//    104][97][114][97][99][116][101][114][115][32][119][105][116][104][32][99][111][1
//    00][101][115][32][111][117][116][115][105][100][101][32][116][104][101][32][65][
//    83][67][73][73][32][99][111][100][101][32][114][97][110][103][101][44][32][80][1
//    05][32][40][63][41][32][97][110][100][32][83][105][103][109][97][32][40][63][41]
//    [46]
//
//    Value at position of Pi character: 63
//    Value at position of Sigma character: 63
//
//    Decoded bytes:
//    This Unicode string contains two characters with codes outside the ASCII code ra
//    nge, Pi (?) and Sigma (?).
// </Snippet1>
