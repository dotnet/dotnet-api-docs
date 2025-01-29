using System;
using System.Data;
using System.ComponentModel;
using System.Security.Cryptography;

public class Sample
{
 protected int DATA_SIZE = 1024;

 protected void Method()
 {
// <Snippet1>
byte[] data = new byte[DATA_SIZE];
byte[] result;

using (SHA512 sha512 = SHA512.Create())
{
    result = sha512.ComputeHash(data);
}
// </Snippet1>
 }
}
