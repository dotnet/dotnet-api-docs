// The following code example retrieves the different names for each encoding
// and compares them with the equivalent Encoding names.

// <Snippet1>
using System;
using System.Text;

public class SamplesEncoding  {

   public static void Main()  {

      // Print the header.
      Console.Write( "Info.CodePage      " );
      Console.Write( "Info.Name                    " );
      Console.Write( "Info.DisplayName" );
      Console.WriteLine();

      // Display the EncodingInfo names for every encoding, and compare with the equivalent Encoding names.
      foreach( EncodingInfo ei in Encoding.GetEncodings() )  {
         Encoding e = ei.GetEncoding();

         Console.Write( "{0,-15}", ei.CodePage );
         if ( ei.CodePage == e.CodePage )
            Console.Write( "    " );
         else
            Console.Write( "*** " );

         Console.Write( "{0,-25}", ei.Name );
         if ( ei.CodePage == e.CodePage )
            Console.Write( "    " );
         else
            Console.Write( "*** " );

         Console.Write( "{0,-25}", ei.DisplayName );
         if ( ei.CodePage == e.CodePage )
            Console.Write( "    " );
         else
            Console.Write( "*** " );

         Console.WriteLine();
      }
   }
}

/*
The example produces the following output:

Info.CodePage      Info.Name                    Info.DisplayName
1200               utf-16                       Unicode
1201               utf-16BE                     Unicode (Big-Endian)
12000              utf-32                       Unicode (UTF-32)
12001              utf-32BE                     Unicode (UTF-32 Big-Endian)
20127              us-ascii                     US-ASCII
28591              iso-8859-1                   Western European (ISO)
65000              utf-7                        Unicode (UTF-7)
65001              utf-8                        Unicode (UTF-8)

*/
// </Snippet1>
