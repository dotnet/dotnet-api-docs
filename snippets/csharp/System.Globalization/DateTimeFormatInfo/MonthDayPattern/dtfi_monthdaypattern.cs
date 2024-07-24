// The following code example displays the value of MonthDayPattern for selected cultures.

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
      Console.WriteLine( "  {0}     {1}", myCulture, myDTFI.MonthDayPattern );
   }
}

/*
This code produces the following output. Note that the exact output format depends on the OS, the OS version, and the native globalization library used by the OS.

 CULTURE    PROPERTY VALUE
  en-US     MMMM d
  ja-JP     M月d日
  fr-FR     d MMMM

*/
// </snippet1>
