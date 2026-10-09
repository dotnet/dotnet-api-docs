//<Snippet1>
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.IO;
using System.Xml;

public class Verify {

    public static void Main(String[] args)
    {

        Console.WriteLine("Verifying " + args[0] + "...");

        RSA trustedKey = RSA.Create();
        // ... load trustedKey from an out-of-band source ...

        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.PreserveWhitespace = true;
        using (XmlReader reader = XmlReader.Create(args[0]))
        {
            xmlDocument.Load(reader);
        }

        SignedXml signedXml = new SignedXml(xmlDocument);
        XmlNodeList nodeList = xmlDocument.GetElementsByTagName("Signature");
        signedXml.LoadXml((XmlElement)nodeList[0]);

        if (signedXml.CheckSignature(trustedKey)) {
            Console.WriteLine("Signature check OK");
        } else {
            Console.WriteLine("Signature check FAILED");
        }
    }
}
//</Snippet1>
