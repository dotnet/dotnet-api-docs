// The following code example checks the values of the Boolean properties of each encoding.

// <Snippet1>
using System;
using System.Text;

public class SamplesEncoding  {

   public static void Main()  {

      // Print the header.
      Console.Write( "CodePage identifier and name     " );
      Console.Write( "BrDisp   BrSave   " );
      Console.Write( "MNDisp   MNSave   " );
      Console.WriteLine( "1-Byte   ReadOnly " );

      // For every encoding, get the property values.
      foreach( EncodingInfo ei in Encoding.GetEncodings() )  {
         Encoding e = ei.GetEncoding();

         Console.Write( "{0,-6} {1,-25} ", ei.CodePage, ei.Name );
         Console.Write( "{0,-8} {1,-8} ", e.IsBrowserDisplay, e.IsBrowserSave );
         Console.Write( "{0,-8} {1,-8} ", e.IsMailNewsDisplay, e.IsMailNewsSave );
         Console.WriteLine( "{0,-8} {1,-8} ", e.IsSingleByte, e.IsReadOnly );
      }
   }
}


/* 
This code produces the following output.

CodePage identifier and name     BrDisp   BrSave   MNDisp   MNSave   1-Byte   ReadOnly 
1200   utf-16                    False    True     False    False    False    True     
1201   utf-16BE                  False    False    False    False    False    True     
12000  utf-32                    False    False    False    False    False    True     
12001  utf-32BE                  False    False    False    False    False    True     
20127  us-ascii                  False    False    True     True     True     True     
28591  iso-8859-1                True     True     True     True     True     True     
65000  utf-7                     True     True     True     True     False    True     
65001  utf-8                     True     True     True     True     False    True     

*/

// </Snippet1>
