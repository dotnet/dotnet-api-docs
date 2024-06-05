' <SNIPPET1>
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO

Module TripleDESSample

    Sub Main()
        Try
            Dim key As Byte()
            Dim iv As Byte()

            ' Create a new TripleDES object to generate a key
            ' and initialization vector (IV).
            Using tripleDes As TripleDES = TripleDES.Create
                key = tripleDes.Key
                iv = tripleDes.IV
            End Using

            ' Create a string to encrypt.
            Dim original As String = "Here is some data to encrypt."

            ' Encrypt the string to an in-memory buffer.
            Dim encrypted As Byte() = EncryptTextToMemory(original, key, iv)

            ' Decrypt the buffer back to a string.
            Dim decrypted As String = DecryptTextFromMemory(encrypted, key, iv)

            ' Display the decrypted string to the console.
            Console.WriteLine(decrypted)
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try
    End Sub


    Function EncryptTextToMemory(text As String, key As Byte(), iv As Byte()) As Byte()
        Try
            ' Create a MemoryStream.
            Using mStream As New MemoryStream
                ' Create a new TripleDES object,
                ' Create a TripleDES encryptor from the key and IV,
                ' Create a CryptoStream using the MemoryStream And encryptor
                Using tripleDes As TripleDES = TripleDES.Create,
                    encryptor As ICryptoTransform = tripleDes.CreateEncryptor(key, iv),
                    cStream = New CryptoStream(mStream, encryptor, CryptoStreamMode.Write)

                    ' Convert the passed string to a byte array.
                    Dim toEncrypt As Byte() = Encoding.UTF8.GetBytes(text)

                    ' Write the byte array to the crypto stream and flush it.
                    cStream.Write(toEncrypt, 0, toEncrypt.Length)

                    ' Ending the using block for the CryptoStream completes the encryption.
                End Using

                ' Get an array of bytes from the MemoryStream that holds the encrypted data.
                Dim ret As Byte() = mStream.ToArray()

                ' Return the encrypted buffer.
                Return ret
            End Using
        Catch e As CryptographicException
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message)
            Throw
        End Try
    End Function


    Function DecryptTextFromMemory(encrypted As Byte(), key As Byte(), iv As Byte()) As String
        Try
            ' Create a buffer to hold the decrypted data.
            ' TripleDES-encrypted data will always be slightly bigger than the decrypted data.
            Dim decrypted(encrypted.Length - 1) As Byte
            Dim offset As Integer = 0

            ' Create a new MemoryStream using the provided array of encrypted data.
            ' Create a new TripleDES object.
            ' Create a TripleDES decryptor from the key and IV
            ' Create a CryptoStream using the MemoryStream and decryptor
            Using mStream As New MemoryStream(encrypted),
                tripleDes As TripleDES = TripleDES.Create,
                decryptor As ICryptoTransform = tripleDes.CreateDecryptor(key, iv),
                cStream = New CryptoStream(mStream, decryptor, CryptoStreamMode.Read)

                ' Keep reading from the CryptoStream until it finishes (returns 0).
                Dim read As Integer = 1

                While (read > 0)
                    read = cStream.Read(decrypted, offset, decrypted.Length - offset)
                    offset += read
                End While
            End Using

            ' Convert the buffer into a string and return it.
            Return New ASCIIEncoding().GetString(decrypted, 0, offset)
        Catch e As CryptographicException
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message)
            Return Nothing
        End Try
    End Function
End Module
' </SNIPPET1>
