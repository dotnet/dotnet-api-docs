'<SNIPPET1>
Imports System.Security.Cryptography.X509Certificates

Class X500Sample
    Shared s_msg As String
    Shared Sub Main()

        Try
            Dim store As New X509Store("MY", StoreLocation.CurrentUser)
            store.Open(OpenFlags.ReadOnly Or OpenFlags.OpenExistingOnly)
            Dim collection As X509Certificate2Collection = store.Certificates
            Dim fcollection As X509Certificate2Collection = collection.Find(X509FindType.FindByTimeValid, Date.Now, False)
            Dim scollection As X509Certificate2Collection = X509Certificate2UI.SelectFromCollection(
                fcollection,
                "Test Certificate Select",
                "Select a certificate from the following list to get information on that certificate",
                X509SelectionFlag.MultiSelection
                )
            s_msg = "Number of certificates: " & scollection.Count & Environment.NewLine
            Console.WriteLine(s_msg)
            Dim x509 As X509Certificate2
            For Each x509 In scollection
                Dim dname As New X500DistinguishedName(
                x509.SubjectName.Name,
                X500DistinguishedNameFlags.Reversed Or X500DistinguishedNameFlags.UseSemicolons
                )
                s_msg = "X500DistinguishedName: " & dname.Name & Environment.NewLine
                Console.WriteLine(s_msg)
                x509.Reset()
            Next x509
            store.Close()
        Catch e As Exception
            s_msg = "Error: Information could not be written out for this certificate."
            Console.WriteLine(s_msg)
        End Try
    End Sub
End Class
'</SNIPPET1>
