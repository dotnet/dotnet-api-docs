using System;
using System.Data;
using System.Security.Cryptography;
using System.Windows.Forms;

public class Form1: Form
{
   public static void Main()
   {
        // <Snippet1>
        byte[] random = new byte[100];

        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(random); // The array is now filled with cryptographically strong random bytes.
        }
        // </Snippet1>
   }
}
