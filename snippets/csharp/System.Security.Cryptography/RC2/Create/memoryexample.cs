// <SNIPPET1>
using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

class RC2Sample2
{
    static void Main()
    {
        try
        {
            byte[] key;
            byte[] iv;

            // Create a new RC2 object to generate a random key
            // and initialization vector (IV).
            using (RC2 rc2 = RC2.Create())
            {
                key = rc2.Key;
                iv = rc2.IV;
            }

            // Create a string to encrypt.
            string original = "Here is some data to encrypt.";

            // Encrypt the string to an in-memory buffer.
            byte[] encrypted = EncryptTextToMemory(original, key, iv);

            // Decrypt the buffer back to a string.
            string decrypted = DecryptTextFromMemory(encrypted, key, iv);

            // Display the decrypted string to the console.
            Console.WriteLine(decrypted);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static byte[] EncryptTextToMemory(string text, byte[] key, byte[] iv)
    {
        try
        {
            // Create a MemoryStream.
            using (MemoryStream mStream = new MemoryStream())
            {
                // Create a new RC2 object.
                using (RC2 rc2 = RC2.Create())
                // Create an RC2 encryptor from the key and IV
                using (ICryptoTransform encryptor = rc2.CreateEncryptor(key, iv))
                // Create a CryptoStream using the MemoryStream and encryptor
                using (var cStream = new CryptoStream(mStream, encryptor, CryptoStreamMode.Write))
                {
                    // Convert the provided string to a byte array.
                    byte[] toEncrypt = Encoding.UTF8.GetBytes(text);

                    // Write the byte array to the crypto stream and flush it.
                    cStream.Write(toEncrypt, 0, toEncrypt.Length);

                    // Ending the using statement for the CryptoStream completes the encryption.
                }

                // Get an array of bytes from the MemoryStream that holds the encrypted data.
                byte[] ret = mStream.ToArray();

                // Return the encrypted buffer.
                return ret;
            }
        }
        catch (CryptographicException e)
        {
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
            throw;
        }
    }

    public static string DecryptTextFromMemory(byte[] encrypted, byte[] key, byte[] iv)
    {
        try
        {
            // Create a buffer to hold the decrypted data.
            // RC2-encrypted data will always be slightly bigger than the decrypted data.
            byte[] decrypted = new byte[encrypted.Length];
            int offset = 0;

            // Create a new MemoryStream using the provided array of encrypted data.
            using (MemoryStream mStream = new MemoryStream(encrypted))
            {
                // Create a new RC2 object.
                using (RC2 rc2 = RC2.Create())
                // Create an RC2 decryptor from the key and IV
                using (ICryptoTransform decryptor = rc2.CreateDecryptor(key, iv))
                // Create a CryptoStream using the MemoryStream and decryptor
                using (var cStream = new CryptoStream(mStream, decryptor, CryptoStreamMode.Read))
                {
                    // Keep reading from the CryptoStream until it finishes (returns 0).
                    int read = 1;

                    while (read > 0)
                    {
                        read = cStream.Read(decrypted, offset, decrypted.Length - offset);
                        offset += read;
                    }
                }
            }

            // Convert the buffer into a string and return it.
            return Encoding.UTF8.GetString(decrypted, 0, offset);
        }
        catch (CryptographicException e)
        {
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
            throw;
        }
    }
}
// </SNIPPET1>
