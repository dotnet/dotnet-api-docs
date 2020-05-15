﻿// <Snippet1>
//
// This example signs a file specified by a URI 
// using a detached signature. It then verifies  
// the signed XML.
//

using System;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;

class XMLDSIGDetached
{
	
    [STAThread]
    static void Main(string[] args)
    {
        // The URI to sign.
        string resourceToSign = "http://www.microsoft.com";
		
        // The name of the file to which to save the XML signature.
        string XmlFileName = "xmldsig.xml";

        try
        {

            // Generate a signing key.
            RSACryptoServiceProvider Key = new RSACryptoServiceProvider();

            Console.WriteLine("Signing: {0}", resourceToSign);

            // Sign the detached resourceand save the signature in an XML file.
            SignDetachedResource(resourceToSign, XmlFileName, Key);

            Console.WriteLine("XML Signature was successfully computed and saved to {0}.", XmlFileName);

            // Verify the signature of the signed XML.
            Console.WriteLine("Verifying signature...");

            //Verify the XML signature in the XML file against the key.
            bool result = VerifyDetachedSignature(XmlFileName, Key);

            // Display the results of the signature verification to 
            // the console.
            if(result)
            {
                Console.WriteLine("The XML signature is valid.");
            }
            else
            {
                Console.WriteLine("The XML signature is not valid.");
            }
        }
        catch(CryptographicException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    // Sign an XML file and save the signature in a new file. This method does not  
    // save the public key within the XML file.  This file cannot be verified unless  
    // the verifying code has the key with which it was signed.
    public static void SignDetachedResource(string URIString, string XmlSigFileName, RSA Key)
    {
        // Create a SignedXml object.
        SignedXml signedXml = new SignedXml();

        // Assign the key to the SignedXml object.
        signedXml.SigningKey = Key;

        // Create a reference to be signed.
        Reference reference = new Reference();

        // Add the passed URI to the reference object.
        reference.Uri = URIString;
		
        // Add the reference to the SignedXml object.
        signedXml.AddReference(reference);

        // Compute the signature.
        signedXml.ComputeSignature();

        // Get the XML representation of the signature and save
        // it to an XmlElement object.
        XmlElement xmlDigitalSignature = signedXml.GetXml();

        // Save the signed XML document to a file specified
        // using the passed string.
        XmlTextWriter xmltw = new XmlTextWriter(XmlSigFileName, new UTF8Encoding(false));
        xmlDigitalSignature.WriteTo(xmltw);
        xmltw.Close();
    }

    // Verify the signature of an XML file against an asymmetric 
    // algorithm and return the result.
    public static Boolean VerifyDetachedSignature(string XmlSigFileName, RSA Key)
    {	
        // Create a new XML document.
        XmlDocument xmlDocument = new XmlDocument();

        // Load the passedXML file into the document.
        xmlDocument.Load(XmlSigFileName);
	
        // Create a new SignedXml object.
        SignedXml signedXml = new SignedXml();

        // Find the "Signature" node and create a new
        // XmlNodeList object.
        XmlNodeList nodeList = xmlDocument.GetElementsByTagName("Signature");

        // Load the signature node.
        signedXml.LoadXml((XmlElement)nodeList[0]);

        // Check the signature against the passed asymmetric key
        // and return the result.
        return signedXml.CheckSignature(Key);
    }
}
// </Snippet1>
