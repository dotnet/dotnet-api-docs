// <SNIPPET1>
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

class TripleDESSample
{
    static async Task Main()
    {
        try
        {
            byte[] key;
            byte[] iv;

            // Create a new TripleDES object to generate a random key
            // and initialization vector (IV).
            using (TripleDES tripleDes = TripleDES.Create())
            {
                key = tripleDes.Key;
                iv = tripleDes.IV;
            }

            // Create a string to encrypt.
            string original = "Here is some data to encrypt.";
            // The name/path of the file to write.
            string filename = "CText.enc";

            // Encrypt the string to a file.
            await EncryptTextToFile(original, filename, key, iv);

            // Decrypt the file back to a string.
            string decrypted = await DecryptTextFromFile(filename, key, iv);

            // Display the decrypted string to the console.
            Console.WriteLine(decrypted);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static async Task EncryptTextToFile(string text, string path, byte[] key, byte[] iv)
    {
        try
        {
            // Create or open the specified file.
            using FileStream fileStream = File.Open(path, FileMode.Create);
            // Create a new TripleDES object.
            using TripleDES tripleDes = TripleDES.Create();
            // Create a TripleDES encryptor from the key and IV
            using ICryptoTransform encryptor = tripleDes.CreateEncryptor(key, iv);
            // Create a CryptoStream using the FileStream and encryptor
            using var cryptoStream = new CryptoStream(fileStream, encryptor, CryptoStreamMode.Write);

            // Convert the provided string to a byte array.
            byte[] toEncrypt = Encoding.UTF8.GetBytes(text);

            // Write the byte array to the crypto stream.
            await cryptoStream.WriteAsync(toEncrypt);

        }
        catch (CryptographicException e)
        {
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
            throw;
        }
    }

    public static async Task<string> DecryptTextFromFile(string path, byte[] key, byte[] iv)
    {
        try
        {
            // Open the specified file
            using FileStream fileStream = File.OpenRead(path);
            // Create a new TripleDES object.
            using TripleDES tripleDes = TripleDES.Create();
            // Create a TripleDES decryptor from the key and IV
            using ICryptoTransform decryptor = tripleDes.CreateDecryptor(key, iv);
            // Create a CryptoStream using the FileStream and decryptor
            using var cryptoStream = new CryptoStream(fileStream, decryptor, CryptoStreamMode.Read);
            // Create a StreamReader to turn the bytes back into text
            using var reader = new StreamReader(cryptoStream, Encoding.UTF8);

            // Read back all of the text from the StreamReader, which receives
            // the decrypted bytes from the CryptoStream, which receives the
            // encrypted bytes from the FileStream.
            return await reader.ReadToEndAsync();
        }
        catch (CryptographicException e)
        {
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
            throw;
        }
    }
}
// </SNIPPET1>
