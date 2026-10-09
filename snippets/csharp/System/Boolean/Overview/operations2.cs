// <Snippet13>
using System;

public class Example6
{
    public static void Main()
    {
        bool[] hasServiceCharges = { true, false };
        decimal subtotal = 120.62m;
        decimal shippingCharge = 2.50m;
        decimal serviceCharge = 5.00m;

        foreach (bool hasServiceCharge in hasServiceCharges)
        {
            decimal total = subtotal + shippingCharge +
                                   (hasServiceCharge ? serviceCharge : 0);
            Console.WriteLine($"hasServiceCharge = {hasServiceCharge}: The total is {total:C2}.");
        }
    }
}
// The example displays output like the following:
//       hasServiceCharge = True: The total is $128.12.
//       hasServiceCharge = False: The total is $123.12.
// </Snippet13>
