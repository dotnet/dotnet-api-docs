﻿// <Snippet1>
using System;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      BigInteger[] values = { 2, 100, BigInteger.Pow(1000, 100), 
                              BigInteger.Pow(2, 64) };
      foreach (var value in values)                                    
         Console.WriteLine("The square root of {0} is {1}", value, 
                           Math.Exp(BigInteger.Log(value) / 2));
   }
}
// The example displays the following output:
//    The square root of 2 is 1.41421356237309
//    The square root of 100 is 10
//    The square root of 1000000000000000000000000000000000000000000000000000000000000
//    00000000000000000000000000000000000000000000000000000000000000000000000000000000
//    00000000000000000000000000000000000000000000000000000000000000000000000000000000
//    00000000000000000000000000000000000000000000000000000000000000000000000000000000
//     is 9.99999999999988E+149
//    The square root of 18446744073709551616 is 4294967296
// </Snippet1>