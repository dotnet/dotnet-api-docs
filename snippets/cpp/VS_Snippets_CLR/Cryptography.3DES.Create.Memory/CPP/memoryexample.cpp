
// <SNIPPET1>
using namespace System;
using namespace System::Security::Cryptography;
using namespace System::Text;
using namespace System::IO;

array<Byte>^ EncryptTextToMemory(String^ text, array<Byte>^ key, array<Byte>^ iv);
String^ DecryptTextFromMemory(array<Byte>^ encrypted, array<Byte>^ key, array<Byte>^ iv);

int main()
{
    try
    {
        array<Byte>^ key;
        array<Byte>^ iv;

        // Create a new TripleDES object to generate a random key
        // and initialization vector (IV).
        {
            TripleDES^ tripleDes;

            try
            {
                tripleDes = TripleDES::Create();
                key = tripleDes->Key;
                iv = tripleDes->IV;
            }
            finally
            {
                delete tripleDes;
            }
        }

        // Create a string to encrypt.
        String^ original = "Here is some data to encrypt.";

        // Encrypt the string to an in-memory buffer.
        array<Byte>^ encrypted = EncryptTextToMemory(original, key, iv);

        // Decrypt the buffer back to a string.
        String^ decrypted = DecryptTextFromMemory(encrypted, key, iv);

        // Display the decrypted string to the console.
        Console::WriteLine(decrypted);
    }
    catch (Exception^ e)
    {
        Console::WriteLine(e->Message);
    }
}

array<Byte>^ EncryptTextToMemory(String^ text, array<Byte>^ key, array<Byte>^ iv)
{
    MemoryStream^ mStream = nullptr;

    try
    {
        // Create a MemoryStream.
        mStream = gcnew MemoryStream;

        TripleDES^ tripleDes = nullptr;
        ICryptoTransform^ encryptor = nullptr;
        CryptoStream^ cStream = nullptr;

        try
        {
            // Create a new TripleDES object.
            tripleDes = TripleDES::Create();
            // Create a TripleDES encryptor from the key and IV
            encryptor = tripleDes->CreateEncryptor(key, iv);
            // Create a CryptoStream using the MemoryStream and encryptor
            cStream = gcnew CryptoStream(mStream, encryptor, CryptoStreamMode::Write);

            // Convert the provided string to a byte array.
            array<Byte>^ toEncrypt = Encoding::UTF8->GetBytes(text);

            // Write the byte array to the crypto stream.
            cStream->Write(toEncrypt, 0, toEncrypt->Length);

            // Disposing the CryptoStream completes the encryption and flushes the stream.
            delete cStream;

            // Get an array of bytes from the MemoryStream that holds the encrypted data.
            array<Byte>^ ret = mStream->ToArray();

            // Return the encrypted buffer.
            return ret;
        }
        finally
        {
            if (cStream != nullptr)
                delete cStream;

            if (encryptor != nullptr)
                delete encryptor;

            if (tripleDes != nullptr)
                delete tripleDes;
        }
    }
    catch (CryptographicException^ e)
    {
        Console::WriteLine("A Cryptographic error occurred: {0}", e->Message);
        throw;
    }
    finally
    {
        if (mStream != nullptr)
            delete mStream;
    }
}

String^ DecryptTextFromMemory(array<Byte>^ encrypted, array<Byte>^ key, array<Byte>^ iv)
{
    MemoryStream^ mStream = nullptr;
    TripleDES^ tripleDes = nullptr;
    ICryptoTransform^ decryptor = nullptr;
    CryptoStream^ cStream = nullptr;

    try
    {
        // Create buffer to hold the decrypted data.
        // TripleDES-encrypted data will always be slightly bigger than the decrypted data.
        array<Byte>^ decrypted = gcnew array<Byte>(encrypted->Length);
        Int32 offset = 0;

        // Create a new MemoryStream using the provided array of encrypted data.
        mStream = gcnew MemoryStream(encrypted);
        // Create a new TripleDES object.
        tripleDes = TripleDES::Create();
        // Create a TripleDES decryptor from the key and IV
        decryptor = tripleDes->CreateDecryptor(key, iv);
        // Create a CryptoStream using the MemoryStream and decryptor
        cStream = gcnew CryptoStream(mStream, decryptor, CryptoStreamMode::Read);

        // Keep reading from the CryptoStream until it finishes (returns 0).
        Int32 read = 1;

        while (read > 0)
        {
            read = cStream->Read(decrypted, offset, decrypted->Length - offset);
            offset += read;
        }

        // Convert the buffer into a string and return it.
        return Encoding::UTF8->GetString(decrypted, 0, offset);
    }
    catch (CryptographicException^ e)
    {
        Console::WriteLine("A Cryptographic error occurred: {0}", e->Message);
        throw;
    }
    finally
    {
        if (cStream != nullptr)
            delete cStream;

        if (decryptor != nullptr)
            delete decryptor;

        if (tripleDes != nullptr)
            delete tripleDes;

        if (mStream != nullptr)
            delete mStream;
    }
}

// </SNIPPET1>
