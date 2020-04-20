// <Snippet1>
//
// This example signs a file specified by a URI 
// using a detached signature. It then verifies  
// the signed XML.
//
#using <System.dll>
#using <System.Security.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Security::Cryptography;
using namespace System::Security::Cryptography::Xml;
using namespace System::Net;
using namespace System::IO;
using namespace System::Text;
using namespace System::Xml;

// <Snippet2>
// Sign an XML file and save the signature in a new file.
void SignDetachedResource( String^ URIString, String^ XmlSigFileName, DSA^ DSAKey )
{

	// Create a SignedXml Object*.
	SignedXml^ signedXml = gcnew SignedXml;

	// Assign the DSA key to the SignedXml object.
	signedXml->SigningKey = DSAKey;

	// Create a reference to be signed.
	Reference^ reference = gcnew Reference;

	// Add the passed URI to the reference object.
	reference->Uri = URIString;

	// Add the reference to the SignedXml object.
	signedXml->AddReference( reference );

	// Add a DSAKeyValue to the KeyInfo (optional; helps recipient find key to validate).
	KeyInfo^ keyInfo = gcnew KeyInfo;
	keyInfo->AddClause( gcnew DSAKeyValue( safe_cast<DSA^>(DSAKey) ) );
	signedXml->KeyInfo = keyInfo;

	// Compute the signature.
	signedXml->ComputeSignature();

	// Get the XML representation of the signature and save
	// it to an XmlElement object.
	XmlElement^ xmlDigitalSignature = signedXml->GetXml();

	// Save the signed XML document to a file specified
	// using the passed string.
	XmlTextWriter^ xmltw = gcnew XmlTextWriter( XmlSigFileName,gcnew UTF8Encoding( false ) );
	xmlDigitalSignature->WriteTo( xmltw );
	xmltw->Close();

}


// </Snippet2>
// <Snippet3>
// Verify the signature of an XML file and return the result.
Boolean VerifyDetachedSignature( String^ XmlSigFileName )
{

	// Create a new XML document.
	XmlDocument^ xmlDocument = gcnew XmlDocument;

	// Load the passed XML file into the document.
	xmlDocument->Load( XmlSigFileName );

	// Create a new SignedXMl object.
	SignedXml^ signedXml = gcnew SignedXml;

	// Find the "Signature" node and create a new
	// XmlNodeList object.
	XmlNodeList^ nodeList = xmlDocument->GetElementsByTagName( "Signature" );

	// Load the signature node.
	signedXml->LoadXml( safe_cast<XmlElement^>(nodeList->Item( 0 )) );

	// Check the signature and return the result.
	return signedXml->CheckSignature();
}


// </Snippet3>
int main()
{
	// Create a request for the URL.   
	WebRequest^ request = WebRequest::Create( "http://www.contoso.com/default.html" );

	// If required by the server, set the credentials.
	request->Credentials = CredentialCache::DefaultCredentials;

	// Get the response.
	HttpWebResponse^ response = dynamic_cast<HttpWebResponse^>(request->GetResponse());

	// Display the status.
	Console::WriteLine( response->StatusDescription );

	// Get the stream containing content returned by the server.
	Stream^ dataStream = response->GetResponseStream();

	// Open the stream using a StreamReader for easy access.
	StreamReader^ reader = gcnew StreamReader( dataStream );

	// Read the content.
	String^ responseFromServer = reader->ReadToEnd();

	StreamWriter^ sw = File::CreateText( "C:\\temp\\mscom.htm" );
	sw->Write(responseFromServer);
	sw->Close();
	// The URI to sign.

	String^ resourceToSign = "file://C:/temp/mscom.htm";

	// The name of the file to which to save the XML signature.
	String^ XmlFileName = "xmldsig.xml";
	try
	{

		// Generate a DSA signing key.
		DSACryptoServiceProvider^ DSAKey = gcnew DSACryptoServiceProvider;
		Console::WriteLine( "Signing: {0}", resourceToSign );

		// Sign the detached resourceand save the signature in an XML file.
		SignDetachedResource( resourceToSign, XmlFileName, DSAKey );
		Console::WriteLine( "XML signature was successfully computed and saved to {0}.", XmlFileName );

		// Verify the signature of the signed XML.
		Console::WriteLine( "Verifying signature..." );

		//Verify the XML signature in the XML file.
		bool result = VerifyDetachedSignature( XmlFileName );

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