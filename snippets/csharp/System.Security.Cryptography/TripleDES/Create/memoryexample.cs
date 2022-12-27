// <SNIPPET1>
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

class TripleDESSample2
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

            // Encrypt the string to an in-memory buffer.
            byte[] encrypted = await EncryptTextToMemory(original, key, iv);

            // Decrypt the buffer back to a string.
            string decrypted = await DecryptTextFromMemory(encrypted, key, iv);

            // Display the decrypted string to the console.
            Console.WriteLine(decrypted);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static async Task<byte[]> EncryptTextToMemory(string text, byte[] key, byte[] iv)
    {
        try
        {
            // Create a MemoryStream.
            using var memoryStream = new MemoryStream();

            // Create a new TripleDES object.
            using (TripleDES tripleDes = TripleDES.Create())
            // Create a TripleDES encryptor from the key and IV
            using (ICryptoTransform encryptor = tripleDes.CreateEncryptor(key, iv))
            // Create a CryptoStream using the MemoryStream and encryptor
            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
            {
                // Convert the provided string to a byte array.
                byte[] toEncrypt = Encoding.UTF8.GetBytes(text);

                // Write the byte array to the crypto stream and flush it.
                await cryptoStream.WriteAsync(toEncrypt);

                // Ending the using statement for the CryptoStream completes the encryption.
            }

            // Get an array of bytes from the MemoryStream that holds the encrypted data.
            byte[] ret = memoryStream.ToArray();

            // Return the encrypted buffer.
            return ret;
        }
        catch (CryptographicException e)
        {
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
            throw;
        }
    }

    public static async Task<string> DecryptTextFromMemory(byte[] encrypted, byte[] key, byte[] iv)
    {
        try
        {
            // Create a buffer to hold the decrypted data.
            // TripleDES-encrypted data will always be slightly bigger than the decrypted data.
            byte[] decrypted = new byte[encrypted.Length];
            Memory<byte> buffer = decrypted;

            // Create a new MemoryStream using the provided array of encrypted data.
            using var memoryStream = new MemoryStream(encrypted);

            // Create a new TripleDES object.
            using (TripleDES tripleDes = TripleDES.Create())
            // Create a TripleDES decryptor from the key and IV
            using (ICryptoTransform decryptor = tripleDes.CreateDecryptor(key, iv))
            // Create a CryptoStream using the MemoryStream and decryptor
            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
            {
                // Keep reading from the CryptoStream until it finishes (returns 0).
                while (await cryptoStream.ReadAsync(buffer) is var read and > 0)
                {
                    buffer = buffer.Slice(read);
                }
            }

            // Convert the buffer into a string and return it.
            return Encoding.UTF8.GetString(decrypted.AsSpan(..^buffer.Length));
        }
        catch (CryptographicException e)
        {
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
            throw;
        }
    }
}
// </SNIPPET1>
