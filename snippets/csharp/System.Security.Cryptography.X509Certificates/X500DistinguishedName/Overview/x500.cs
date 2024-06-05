//<SNIPPET1>
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

class X500Sample
{
    static void Main()
    {
        try
        {
            X509Store store = new("MY", StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
            X509Certificate2Collection collection = store.Certificates;
            X509Certificate2Collection fcollection = collection.Find(
                X509FindType.FindByTimeValid,
                DateTime.Now, false
                );
            X509Certificate2Collection scollection = X509Certificate2UI.SelectFromCollection(
                fcollection,
                "Test Certificate Select",
                "Select a certificate from the following list to get information on that certificate",
                X509SelectionFlag.MultiSelection
                );
            Console.WriteLine($"Number of certificates: {scollection.Count}{Environment.NewLine}");
            foreach (X509Certificate2 x509 in scollection)
            {
                X500DistinguishedName dname = new(
                    x509.SubjectName.Name,
                    X500DistinguishedNameFlags.Reversed | X500DistinguishedNameFlags.UseSemicolons
                    );
                Console.WriteLine("X500DistinguishedName: {0}{1}", dname.Name, Environment.NewLine);
                x509.Reset();
            }
            store.Close();
        }
        catch (CryptographicException)
        {
            Console.WriteLine("Information could not be written out for this certificate.");
        }
    }
}
//</SNIPPET1>
