﻿// <Snippet1>
using System;
using System.Security.Cryptography;

class RSASample
{

    static void Main()
    {
        try
        {
            //Create a new instance of RSA.
            using (RSA rsa = RSA.Create())
            {
                //The hash to sign.
                byte[] hash;
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] data = new byte[] { 59, 4, 248, 102, 77, 97, 142, 201, 210, 12, 224, 93, 25, 41, 100, 197, 213, 134, 130, 135 };
                    hash = sha256.ComputeHash(data);
                }

                //Create an RSASignatureFormatter object and pass it the 
                //RSA instance to transfer the key information.
                RSAPKCS1SignatureFormatter RSAFormatter = new RSAPKCS1SignatureFormatter(rsa);

                //Set the hash algorithm to SHA256.
                RSAFormatter.SetHashAlgorithm("SHA256");

                //Create a signature for HashValue and return it.
                byte[] SignedHash = RSAFormatter.CreateSignature(hash);
            }
        }
        catch (CryptographicException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
// </Snippet1>