﻿// <Snippet1>
//
// This example signs an XML file using an
// envelope signature. It then verifies the 
// signed XML.
//
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;

public class SignVerifyEnvelope
{

    public static void Main(String[] args)
    {
        try
        {
           // Generate a signing key.
           RSACryptoServiceProvider Key = new RSACryptoServiceProvider();

           // Create an XML file to sign.
           CreateSomeXml("Example.xml");
           Console.WriteLine("New XML file created."); 

           // Sign the XML that was just created and save it in a 
           // new file.
           SignXmlFile("Example.xml", "signedExample.xml", Key);
           Console.WriteLine("XML file signed."); 

           // Verify the signature of the signed XML.
           Console.WriteLine("Verifying signature...");
           bool result = VerifyXmlFile("SignedExample.xml", Key);

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
    public static void SignXmlFile(string FileName, string SignedFileName, RSA Key)
    {
        // Create a new XML document.
        XmlDocument doc = new XmlDocument();

        // Load the passed XML file using its name.
        doc.Load(new XmlTextReader(FileName));

        // Create a SignedXml object.
        SignedXml signedXml = new SignedXml(doc);

        // Add the key to the SignedXml document. 
        signedXml.SigningKey = Key;

        // Create a reference to be signed.
        Reference reference = new Reference();
        reference.Uri = "";

        // Add an enveloped transformation to the reference.
        XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
        reference.AddTransform(env);

        // Add the reference to the SignedXml object.
        signedXml.AddReference(reference);

        // Compute the signature.
        signedXml.ComputeSignature();

        // Get the XML representation of the signature and save
        // it to an XmlElement object.
        XmlElement xmlDigitalSignature = signedXml.GetXml();

        // Append the element to the XML document.
        doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));
		
        if (doc.FirstChild is XmlDeclaration)  
        {
            doc.RemoveChild(doc.FirstChild);
        }

        // Save the signed XML document to a file specified
        // using the passed string.
        XmlTextWriter xmltw = new XmlTextWriter(SignedFileName, new UTF8Encoding(false));
        doc.WriteTo(xmltw);
        xmltw.Close();
    }

    // Verify the signature of an XML file against an asymmetric 
    // algorithm and return the result.
    public static Boolean VerifyXmlFile(String Name, RSA Key)
    {
        // Create a new XML document.
        XmlDocument xmlDocument = new XmlDocument();

        // Load the passed XML file into the document. 
        xmlDocument.Load(Name);

        // Create a new SignedXml object and pass it
        // the XML document class.
        SignedXml signedXml = new SignedXml(xmlDocument);

        // Find the "Signature" node and create a new
        // XmlNodeList object.
        XmlNodeList nodeList = xmlDocument.GetElementsByTagName("Signature");

        // Load the signature node.
        signedXml.LoadXml((XmlElement)nodeList[0]);

        // Check the signature and return the result.
        return signedXml.CheckSignature(Key);
    }

    // Create example data to sign.
    public static void CreateSomeXml(string FileName)
    {
        // Create a new XmlDocument object.
        XmlDocument document = new XmlDocument();

        // Create a new XmlNode object.
        XmlNode  node = document.CreateNode(XmlNodeType.Element, "", "MyElement", "samples");
		
        // Add some text to the node.
        node.InnerText = "Example text to be signed.";

        // Append the node to the document.
        document.AppendChild(node);

        // Save the XML document to the file name specified.
        XmlTextWriter xmltw = new XmlTextWriter(FileName, new UTF8Encoding(false));
        document.WriteTo(xmltw);
        xmltw.Close();
    }
}
// </Snippet1>