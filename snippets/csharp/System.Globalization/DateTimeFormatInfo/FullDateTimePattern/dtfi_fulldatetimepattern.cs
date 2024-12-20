﻿// The following code example displays the value of FullDateTimePattern for selected cultures.

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
      Console.WriteLine( "  {0}     {1}", myCulture, myDTFI.FullDateTimePattern );
   }
}

/*
This code produces the following output. Note that the exact output format depends on the OS, the OS version, and the native globalization library used by the OS.

 CULTURE    PROPERTY VALUE
  en-US     dddd, MMMM d, yyyy h:mm:ss tt
  ja-JP     yyyy年M月d日dddd H:mm:ss
  fr-FR     dddd d MMMM yyyy HH:mm:ss

*/
// </snippet1>
