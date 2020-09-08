// The following code example displays the value of LongDatePattern for selected cultures.

// <snippet1>
using System;
using System.Globalization;

public class SamplesDTFI  {

   public static void Main()  {

      // Displays the values of the pattern properties.
      Console.WriteLine( " CULTURE    PROPERTY VALUE" );
      PrintPattern( "en-US" );
      PrintPattern( "ja-JP" );
      PrintPattern( "fr-FR" );
   }

   public static void PrintPattern( String myCulture )  {

      DateTimeFormatInfo myDTFI = new CultureInfo( myCulture, false ).DateTimeFormat;
      Console.WriteLine( "  {0}     {1}", myCulture, myDTFI.LongDatePattern );
   }
}

/*
This code produces the following output:

 CULTURE    PROPERTY VALUE
  en-US     dddd, MMMM d, yyyy
  ja-JP     yyyy'年'M'月'd'日'
  fr-FR     dddd d MMMM yyyy

*/
// </snippet1>
