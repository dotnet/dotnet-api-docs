'<Snippet1>
Imports System.IO
Imports System.Security.Cryptography

Class AesExample

    Public Shared Sub Main()
        Try
            Dim original As String = "Here is some data to encrypt!"

            ' Create a new instance of the Aes class.
            ' This generates a new key and initialization vector (IV).
            Using myAes = Aes.Create()

                ' Encrypt the string to an array of bytes.
                Dim encrypted As Byte() = EncryptStringToBytes(original, myAes.Key, myAes.IV)

                ' Decrypt the bytes to a string.
                Dim roundtrip As String = DecryptStringFromBytes(encrypted, myAes.Key, myAes.IV)

                'Display the original data and the decrypted data.
                Console.WriteLine("Original:   {0}", original)
                Console.WriteLine("Round Trip: {0}", roundtrip)
            End Using
        Catch e As Exception
            Console.WriteLine("Error: {0}", e.Message)
        End Try
    End Sub

    '<Snippet2>
    Shared Function EncryptStringToBytes(ByVal plainText As String, ByVal Key() As Byte, ByVal IV() As Byte) As Byte()
        ' Check arguments.
        If plainText Is Nothing OrElse plainText.Length <= 0 Then
            Throw New ArgumentNullException(NameOf(plainText))
        End If
        If Key Is Nothing OrElse Key.Length <= 0 Then
            Throw New ArgumentNullException(NameOf(Key))
        End If
        If IV Is Nothing OrElse IV.Length <= 0 Then
            Throw New ArgumentNullException(NameOf(IV))
        End If
        Dim encrypted() As Byte

        ' Create an Aes object with the specified key and IV.
        Using aesAlg = Aes.Create()

            aesAlg.Key = Key
            aesAlg.IV = IV

            ' Create an encryptor to perform the stream transform.
            Dim encryptor As ICryptoTransform = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV)
            ' Create the streams used for encryption.
            Using msEncrypt As New MemoryStream()
                Using csEncrypt As New CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)
                    Using swEncrypt As New StreamWriter(csEncrypt)

                        ' Write all data to the stream.
                        swEncrypt.Write(plainText)
                    End Using
                    encrypted = msEncrypt.ToArray()
                End Using
            End Using
        End Using

        ' Return the encrypted bytes from the memory stream.
        Return encrypted

    End Function 'EncryptStringToBytes
    '</Snippet2>

    '<Snippet3>
    Shared Function DecryptStringFromBytes(
        ByVal cipherText() As Byte,
        ByVal Key() As Byte,
        ByVal IV() As Byte) As String
        ' Check arguments.
        If cipherText Is Nothing OrElse cipherText.Length <= 0 Then
            Throw New ArgumentNullException(NameOf(cipherText))
        End If
        If Key Is Nothing OrElse Key.Length <= 0 Then
            Throw New ArgumentNullException(NameOf(Key))
        End If
        If IV Is Nothing OrElse IV.Length <= 0 Then
            Throw New ArgumentNullException(NameOf(IV))
        End If

        ' Declare the string used to hold the decrypted text.
        Dim plaintext As String = Nothing

        ' Create an Aes object with the specified key and IV.
        Using aesAlg = Aes.Create()
            aesAlg.Key = Key
            aesAlg.IV = IV

            ' Create a decryptor to perform the stream transform.
            Dim decryptor As ICryptoTransform = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV)

            ' Create the streams used for decryption.
            Using msDecrypt As New MemoryStream(cipherText)
                Using csDecrypt As New CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)
                    Using srDecrypt As New StreamReader(csDecrypt)
                        ' Read the decrypted bytes from the decrypting stream
                        ' and place them in a string.
                        plaintext = srDecrypt.ReadToEnd()
                    End Using
                End Using
            End Using
        End Using

        Return plaintext

    End Function 'DecryptStringFromBytes 
    '</Snippet3>
End Class
'</Snippet1>
