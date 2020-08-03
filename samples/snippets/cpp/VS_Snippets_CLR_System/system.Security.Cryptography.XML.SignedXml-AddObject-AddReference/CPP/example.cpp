

// <Snippet1>
// This example signs an XML file using an
// envelope signature. It then verifies the 
// signed XML.
#using <System.Security.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Security::Cryptography;
using namespace System::Security::Cryptography::Xml;
using namespace System::Text;
using namespace System::Xml;

// <Snippet2>
// Sign an XML file and save the signature in a new file.
void SignXmlFile( String^ FileName, String^ SignedFileName, RSA^ RSAKey )
{
   
   // Create a new XML document.
   XmlDocument^ doc = gcnew XmlDocument;
   
   // Format the document to ignore white spaces.
   doc->PreserveWhitespace = false;
   
   // Load the passed XML file using its name.
   doc->Load( gcnew XmlTextReader( FileName ) );
   
   // Create a SignedXml object.
   SignedXml^ signedXml = gcnew SignedXml( doc );
   
   // Add the RSA key to the SignedXml document. 
   signedXml->SigningKey = RSAKey;
   
   // Create a reference to be signed.
   Reference^ reference = gcnew Reference;
   reference->Uri = "";
   
   // Add a transformation to the reference.
   Transform^ trns = gcnew XmlDsigC14NTransform;
   reference->AddTransform( trns );
   
   // Add an enveloped transformation to the reference.
   XmlDsigEnvelopedSignatureTransform^ env = gcnew XmlDsigEnvelopedSignatureTransform;
   reference->AddTransform( env );
   
   // Add the reference to the SignedXml object.
   signedXml->AddReference( reference );
   
   // Add an RSAKeyValue to the KeyInfo (optional; helps recipient find key to validate).
   KeyInfo^ keyInfo = gcnew KeyInfo;
   keyInfo->AddClause( gcnew RSAKeyValue( safe_cast<RSA^>(RSAKey) ) );
   signedXml->KeyInfo = keyInfo;
   
   // Compute the signature.
   signedXml->ComputeSignature();
   
   // Get the XML representation of the signature and save
   // it to an XmlElement object.
   XmlElement^ xmlDigitalSignature = signedXml->GetXml();
   
   // Append the element to the XML document.
   doc->DocumentElement->AppendChild( doc->ImportNode( xmlDigitalSignature, true ) );
   if ( (doc->FirstChild)->GetType() == XmlDeclaration::typeid )
   {
      doc->RemoveChild( doc->FirstChild );
   }

   
   // Save the signed XML document to a file specified
   // using the passed string.
   XmlTextWriter^ xmltw = gcnew XmlTextWriter( SignedFileName,gcnew UTF8Encoding( false ) );
   doc->WriteTo( xmltw );
   xmltw->Close();
}


// </Snippet2>
// <Snippet3>
// Verify the signature of an XML file and return the result.
Boolean VerifyXmlFile( String^ Name )
{
   
   // Create a new XML document.
   XmlDocument^ xmlDocument = gcnew XmlDocument;
   
   // Format using white spaces.
   xmlDocument->PreserveWhitespace = true;
   
   // Load the passed XML file into the document. 
   xmlDocument->Load( Name );
   
   // Create a new SignedXml object and pass it
   // the XML document class.
   SignedXml^ signedXml = gcnew SignedXml( xmlDocument );
   
   // Find the "Signature" node and create a new
   // XmlNodeList object.
   XmlNodeList^ nodeList = xmlDocument->GetElementsByTagName( "Signature" );
   
   // Load the signature node.
   signedXml->LoadXml( safe_cast<XmlElement^>(nodeList->Item( 0 )) );
   
   // Check the signature and return the result.
   return signedXml->CheckSignature();
}


// </Snippet3>
// Create example data to sign.
void CreateSomeXml( String^ FileName )
{
   
   // Create a new XmlDocument object.
   XmlDocument^ document = gcnew XmlDocument;
   
   // Create a new XmlNode object.
   XmlNode^ node = document->CreateNode( XmlNodeType::Element, "", "MyElement", "samples" );
   
   // Add some text to the node.
   node->InnerText = "Example text to be signed.";
   
   // Append the node to the document.
   document->AppendChild( node );
   
   // Save the XML document to the file name specified.
   XmlTextWriter^ xmltw = gcnew XmlTextWriter( FileName,gcnew UTF8Encoding( false ) );
   document->WriteTo( xmltw );
   xmltw->Close();
}

int main()
{
   try
   {
      
      // Generate an RSA signing key.
      RSA^ RSAKey = RSA::Create();
      
      // Create an XML file to sign.
      CreateSomeXml( "Example.xml" );
      Console::WriteLine( "New XML file created." );
      
      // Sign the XML that was just created and save it in a 
      // new file.
      SignXmlFile( "Example.xml", "SignedExample.xml", RSAKey );
      Console::WriteLine( "XML file signed." );
      
      // Verify the signature of the signed XML.
      Console::WriteLine( "Verifying signature..." );
      bool result = VerifyXmlFile( "SignedExample.xml" );
      
      // Display the results of the signature verification to
      // the console.
      if ( result )
      {
         Console::WriteLine( "The XML signature is valid." );
      }
      else
      {
         Console::WriteLine( "The XML signature is not valid." );
      }
   }
   catch ( CryptographicException^ e ) 
   {
      Console::WriteLine( e->Message );
   }

}

// </Snippet1>
