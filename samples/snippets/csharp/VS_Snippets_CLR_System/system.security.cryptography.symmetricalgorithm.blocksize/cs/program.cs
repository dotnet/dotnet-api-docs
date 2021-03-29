//<Snippet1>
using System;
using System.Security.Cryptography;
namespace SymmetricAlgo
{
    class Program
    {
        static void Main(string[] args)
        {
            Aes aes = Aes.Create();
            Console.WriteLine("Aes ");
            KeySizes[] ks = aes.LegalKeySizes;
            foreach (KeySizes k in ks)
            {
                Console.WriteLine("\tLegal min key size = " + k.MinSize);
                Console.WriteLine("\tLegal max key size = " + k.MaxSize);
            }
            ks = aes.LegalBlockSizes;
            foreach (KeySizes k in ks)
            {
                Console.WriteLine("\tLegal min block size = " + k.MinSize);
                Console.WriteLine("\tLegal max block size = " + k.MaxSize);
            }
        }
    }
}
//This sample produces the following output:
//Aes
//        Legal min key size = 128
//        Legal max key size = 256
//        Legal min block size = 128
//        Legal max block size = 128
//</Snippet1>
