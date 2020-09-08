
//<SNIPPET1>
using namespace System;
using namespace System::Security::Cryptography;
using namespace System::Text;
array<Byte>^ HashAndSignBytes( array<Byte>^DataToSign, RSAParameters Key )
{
   try
   {
      
      // Create a new instance of RSACryptoServiceProvider using the 
      // key from RSAParameters.  
      RSACryptoServiceProvider^ RSAalg = gcnew RSACryptoServiceProvider;
      RSAalg->ImportParameters( Key );
      
      // Hash and sign the data. Pass a new instance of SHA256
      // to specify the hashing algorithm.
      return RSAalg->SignData( DataToSign, SHA256::Create() );
   }
   catch ( CryptographicException^ e ) 
   {
      Console::WriteLine( e->Message );
      return nullptr;
   }

}

bool VerifySignedHash( array<Byte>^DataToVerify, array<Byte>^SignedData, RSAParameters Key )
{
   try
   {
      
      // Create a new instance of RSACryptoServiceProvider using the 
      // key from RSAParameters.
      RSACryptoServiceProvider^ RSAalg = gcnew RSACryptoServiceProvider;
      RSAalg->ImportParameters( Key );
      
      // Verify the data using the signature.  Pass a new instance of SHA256
      // to specify the hashing algorithm.
      return RSAalg->VerifyData( DataToVerify, SHA256::Create(), SignedData );
   }
   catch ( CryptographicException^ e ) 
   {
      Console::WriteLine( e->Message );
      return false;
   }

}

int main()
{
   try
   {
      
      // Create a UnicodeEncoder to convert between byte array and string.
      ASCIIEncoding^ ByteConverter = gcnew ASCIIEncoding;
      String^ dataString = "Data to Sign";
      
      // Create byte arrays to hold original, encrypted, and decrypted data.
      array<Byte>^originalData = ByteConverter->GetBytes( dataString );
      array<Byte>^signedData;
      
      // Create a new instance of the RSACryptoServiceProvider class 
      // and automatically create a new key-pair.
      RSACryptoServiceProvider^ RSAalg = gcnew RSACryptoServiceProvider;
      
      // Export the key information to an RSAParameters object.
      // You must pass true to export the private key for signing.
      // However, you do not need to export the private key
      // for verification.
      RSAParameters Key = RSAalg->ExportParameters( true );
      
      // Hash and sign the data.
      signedData = HashAndSignBytes( originalData, Key );
      
      // Verify the data and display the result to the 
      // console.
      if ( VerifySignedHash( originalData, signedData, Key ) )
      {
         Console::WriteLine( "The data was verified." );
      }
      else
      {
         Console::WriteLine( "The data does not match the signature." );
      }
   }
   catch ( ArgumentNullException^ ) 
   {
      Console::WriteLine( "The data was not signed or verified" );
   }

}

//</SNIPPET1>
