// <SNIPPET1>
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class DESSample
{
    static void Main()
    {
        try
        {
            byte[] key;
            byte[] iv;

            // Create a new DES object to generate a random key
            // and initialization vector (IV).
            using (DES des = DES.Create())
            {
                key = des.Key;
                iv = des.IV;
            }

            // Create a string to encrypt.
            string original = "Here is some data to encrypt.";
            // The name/path of the file to write.
            string filename = "CText.enc";

            // Encrypt the string to a file.
            EncryptTextToFile(original, filename, key, iv);

            // Decrypt the file back to a string.
            string decrypted = DecryptTextFromFile(filename, key, iv);

            // Display the decrypted string to the console.
            Console.WriteLine(decrypted);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static void EncryptTextToFile(string text, string path, byte[] key, byte[] iv)
    {
        try
        {
            // Create or open the specified file.
            using (FileStream fStream = File.Open(path, FileMode.Create))
            // Create a new DES object.
            using (DES des = DES.Create())
            // Create a DES encryptor from the key and IV
            using (ICryptoTransform encryptor = des.CreateEncryptor(key, iv))
            // Create a CryptoStream using the FileStream and encryptor
            using (var cStream = new CryptoStream(fStream, encryptor, CryptoStreamMode.Write))
            {
                // Convert the provided string to a byte array.
                byte[] toEncrypt = Encoding.UTF8.GetBytes(text);

                // Write the byte array to the crypto stream.
                cStream.Write(toEncrypt, 0, toEncrypt.Length);
            }
        }
        catch (CryptographicException e)
        {
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
            throw;
        }
    }

    public static string DecryptTextFromFile(string path, byte[] key, byte[] iv)
    {
        try
        {
            // Open the specified file
            using (FileStream fStream = File.OpenRead(path))
            // Create a new DES object.
            using (DES des = DES.Create())
            // Create a DES decryptor from the key and IV
            using (ICryptoTransform decryptor = des.CreateDecryptor(key, iv))
            // Create a CryptoStream using the FileStream and decryptor
            using (var cStream = new CryptoStream(fStream, decryptor, CryptoStreamMode.Read)) 
            // Create a StreamReader to turn the bytes back into text
            using (StreamReader reader = new StreamReader(cStream, Encoding.UTF8))
            {
                // Read back all of the text from the StreamReader, which receives
                // the decrypted bytes from the CryptoStream, which receives the
                // encrypted bytes from the FileStream.
                return reader.ReadToEnd();
            }
        }
        catch (CryptographicException e)
        {
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
            throw;
        }
    }
}
// </SNIPPET1>
