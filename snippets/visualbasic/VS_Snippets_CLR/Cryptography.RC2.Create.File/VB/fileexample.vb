' <SNIPPET1>
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Module RC2Sample

    Sub Main()
        Try
            Dim key As Byte()
            Dim iv As Byte()

            ' Create a new RC2 object to generate a key
            ' and initialization vector (IV).
            Using rc2 As RC2 = RC2.Create
                key = rc2.Key
                iv = rc2.IV
            End Using

            ' Create a string to encrypt.
            Dim original As String = "Here is some data to encrypt."
            ' The name/path of the file to write.
            Dim filename As String = "CText.enc"

            ' Encrypt the string to a file.
            EncryptTextToFile(original, filename, key, iv)

            ' Decrypt the file back to a string.
            Dim decrypted As String = DecryptTextFromFile(filename, key, iv)

            ' Display the decrypted string to the console.
            Console.WriteLine(decrypted)
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try
    End Sub


    Sub EncryptTextToFile(text As String, path As String, key As Byte(), iv As Byte())
        Try
            ' Create or open the specified file.
            ' Create a new RC2 object,
            ' Create an RC2 encryptor from the key and IV,
            ' Create a CryptoStream using the MemoryStream And encryptor
            Using fStream As FileStream = File.Open(path, FileMode.Create),
                rc2 As RC2 = RC2.Create,
                encryptor As ICryptoTransform = rc2.CreateEncryptor(key, iv),
                cStream = New CryptoStream(fStream, encryptor, CryptoStreamMode.Write)

                ' Convert the passed string to a byte array.
                Dim toEncrypt As Byte() = Encoding.UTF8.GetBytes(text)

                ' Write the byte array to the crypto stream.
                cStream.Write(toEncrypt, 0, toEncrypt.Length)
            End Using

        Catch e As CryptographicException
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message)
            Throw
        End Try
    End Sub


    Function DecryptTextFromFile(path As String, key As Byte(), iv As Byte()) As String
        Try
            ' Open the specified file
            ' Create a new RC2 object.
            ' Create an RC2 decryptor from the key and IV
            ' Create a CryptoStream using the MemoryStream and decryptor
            ' Create a StreamReader to turn the bytes back into text
            Using mStream As FileStream = File.OpenRead(path),
                rc2 As RC2 = RC2.Create,
                decryptor As ICryptoTransform = rc2.CreateDecryptor(key, iv),
                cStream = New CryptoStream(mStream, decryptor, CryptoStreamMode.Read),
                reader = New StreamReader(cStream, Encoding.UTF8)

                ' Read back all of the text from the StreamReader, which receives
                ' the decrypted bytes from the CryptoStream, which receives the
                ' encrypted bytes from the FileStream.
                Return reader.ReadToEnd()
            End Using
        Catch e As CryptographicException
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message)
            Return Nothing
        End Try
    End Function
End Module
' </SNIPPET1>
