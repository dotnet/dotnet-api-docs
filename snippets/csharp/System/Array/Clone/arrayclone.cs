// The following code example clones a CultureInfo array and demonstrates the behavior of a shallow copy.

// <Snippet1>
using System;
using System.Globalization;
public class SamplesArray
{

    public static void Main()
    {

        // Create and initialize a new CultureInfo array.
        CultureInfo ci0 = new("ar-SA", false);
        CultureInfo ci1 = new("en-US", false);
        CultureInfo ci2 = new("fr-FR", false);
        CultureInfo ci3 = new("ja-JP", false);
        CultureInfo[] arrCI = new CultureInfo[] { ci0, ci1, ci2, ci3 };

        // Create a clone of the CultureInfo array.
        CultureInfo[] arrCIClone = (CultureInfo[])arrCI.Clone();

        // Replace an element in the clone array.
        CultureInfo ci4 = new("th-TH", false);
        arrCIClone[0] = ci4;

        // Display the contents of the original array.
        Console.WriteLine("The original array contains the following values:");
        PrintIndexAndValues(arrCI);

        // Display the contents of the clone array.
        Console.WriteLine("The clone array contains the following values:");
        PrintIndexAndValues(arrCIClone);

        // Display the DateTimeFormatInfo.DateSeparator for the fourth element in both arrays.
        Console.WriteLine("Before changes to the clone:");
        Console.WriteLine($"   Original: The DateTimeFormatInfo.DateSeparator for {arrCI[3].Name} is {arrCI[3].DateTimeFormat.DateSeparator}.");
        Console.WriteLine($"      Clone: The DateTimeFormatInfo.DateSeparator for {arrCIClone[3].Name} is {arrCIClone[3].DateTimeFormat.DateSeparator}.");

        // Replace the DateTimeFormatInfo.DateSeparator for the fourth element in the clone array.
        arrCIClone[3].DateTimeFormat.DateSeparator = "-";

        // Display the DateTimeFormatInfo.DateSeparator for the fourth element in both arrays.
        Console.WriteLine("After changes to the clone:");
        Console.WriteLine($"   Original: The DateTimeFormatInfo.DateSeparator for {arrCI[3].Name} is {arrCI[3].DateTimeFormat.DateSeparator}.");
        Console.WriteLine($"      Clone: The DateTimeFormatInfo.DateSeparator for {arrCIClone[3].Name} is {arrCIClone[3].DateTimeFormat.DateSeparator}.");
    }

    public static void PrintIndexAndValues(Array myArray)
    {
        for (int i = myArray.GetLowerBound(0); i <= myArray.GetUpperBound(0); i++)
            Console.WriteLine($"\t[{i}]:\t{myArray.GetValue(i)}");
    }
}


/*
This code produces the following output.

The original array contains the following values:
        [0]:    ar-SA
        [1]:    en-US
        [2]:    fr-FR
        [3]:    ja-JP
The clone array contains the following values:
        [0]:    th-TH
        [1]:    en-US
        [2]:    fr-FR
        [3]:    ja-JP
Before changes to the clone:
   Original: The DateTimeFormatInfo.DateSeparator for ja-JP is /.
      Clone: The DateTimeFormatInfo.DateSeparator for ja-JP is /.
After changes to the clone:
   Original: The DateTimeFormatInfo.DateSeparator for ja-JP is -.
      Clone: The DateTimeFormatInfo.DateSeparator for ja-JP is -.

*/

// </Snippet1>
