﻿using System;
using System.Xml;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;

//<SNIPPET1>
static void Decrypt(XmlDocument Doc, RSA Alg, string KeyName)
{
    // Check the arguments.
    if (Doc == null)
        throw new ArgumentNullException("Doc");
    if (Alg == null)
        throw new ArgumentNullException("Alg");
    if (KeyName == null)
        throw new ArgumentNullException("KeyName");

    // Create a new EncryptedXml object.
    var exml = new EncryptedXml(Doc);

    // Add a key-name mapping.
    // This method can only decrypt documents
    // that present the specified key name.
    exml.AddKeyNameMapping(KeyName, Alg);

    while (Doc.GetElementsByTagName("EncryptedData", EncryptedXml.XmlEncNamespaceUrl).Count > 0)
    {
        // Decrypt the element.
        exml.DecryptDocument();
    }
}
//</SNIPPET1>
