using System;
using System.Security.Cryptography.X509Certificates;

public class ChainElementsOrdering
{
    public static void DemonstrateChainElementsOrdering(X509Certificate2 certificate)
    {
//<SNIPPET6>
        using var chain = new X509Chain();
        chain.Build(certificate);

        // chain.ChainElements[0] is the leaf (end-entity) certificate
        // chain.ChainElements[^1] is the root (trust anchor) certificate

        Console.WriteLine("Certificate chain from leaf to root:");
        for (int i = 0; i < chain.ChainElements.Count; i++)
        {
            var cert = chain.ChainElements[i].Certificate;
            var role = i == 0 ? "Leaf" : 
                       i == chain.ChainElements.Count - 1 ? "Root" : "Intermediate";
            Console.WriteLine($"[{i}] {role}: {cert.Subject}");
        }
//</SNIPPET6>
    }
}