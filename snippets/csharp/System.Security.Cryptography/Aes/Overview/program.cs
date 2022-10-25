//<Snippet1>
using System;
using System.IO;
using System.Security.Cryptography;

namespace Aes_Example;

public static class AesExample
{
    public static void Main()
    {
        var original = "Here is some data to encrypt!";

        // Create a new instance of the Aes
        // class.  This generates a new key and initialization
        // vector (IV).
        using var myAes = Aes.Create();
        // Encrypt the string to an array of bytes.
        var encrypted = EncryptStringToBytes(original, myAes.Key, myAes.IV);

        // Decrypt the bytes to a string.
        var roundtrip = DecryptStringFromBytes(encrypted, myAes.Key, myAes.IV);

        //Display the original data and the decrypted data.
        Console.WriteLine("Original:   {0}", original);
        Console.WriteLine("Round Trip: {0}", roundtrip);
    }
    
    //<Snippet2>
    static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
    {
        // Create an Aes object
        // with the specified key and IV.
        using var aesAlg = Aes.Create();
        aesAlg.Key = Key;
        aesAlg.IV = IV;

        // Create an encryptor to perform the stream transform.
        var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

        // Create the streams used for encryption.
        using var msEncrypt = new MemoryStream();
        using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
        using var swEncrypt = new StreamWriter(csEncrypt);
        //Write all data to the stream.
        swEncrypt.Write(plainText);
        
        
        var encrypted = msEncrypt.ToArray();

        // Return the encrypted bytes from the memory stream.
        return encrypted;
    }
    //</Snippet2>

    //<Snippet3>
    static string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
    {
        // Create an Aes object
        // with the specified key and IV.
        using var aesAlg = Aes.Create();
        aesAlg.Key = Key;
        aesAlg.IV = IV;

        // Create a decryptor to perform the stream transform.
        var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

        // Create the streams used for decryption.
        using var msDecrypt = new MemoryStream(cipherText);
        using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
        using var srDecrypt = new StreamReader(csDecrypt);
        
        // Read the decrypted bytes from the decrypting stream
        // and place them in a string.
        var plaintext = srDecrypt.ReadToEnd();

        return plaintext;
    }
    //</Snippet3>
}
//</Snippet1>
