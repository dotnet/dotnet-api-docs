// <Snippet4>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      // Create an array of all supported standard date and time format specifiers.
      string[] formats = {"d", "D", "f", "F", "g", "G", "m", "o", "r",
                          "s", "t", "T", "u", "U", "Y"};
      // Create an array of four cultures.
      CultureInfo[] cultures = {CultureInfo.CreateSpecificCulture("de-DE"),
                                CultureInfo.CreateSpecificCulture("en-US"),
                                CultureInfo.CreateSpecificCulture("es-ES"),
                                CultureInfo.CreateSpecificCulture("fr-FR")};
       // Define date to be displayed.
      DateTime dateToDisplay = new DateTime(2008, 10, 31, 17, 4, 32);

      // Iterate each standard format specifier.
      foreach (string formatSpecifier in formats)
      {
         foreach (CultureInfo culture in cultures)
            Console.WriteLine("{0} Format Specifier {1, 10} Culture {2, 40}",
                              formatSpecifier, culture.Name,
                              dateToDisplay.ToString(formatSpecifier, culture));
         Console.WriteLine();
      }
   }
}
// The example displays the following output:
//    d Format Specifier      de-DE Culture                               31.10.2008
//    d Format Specifier      en-US Culture                               10/31/2008
//    d Format Specifier      es-ES Culture                               31/10/2008
//    d Format Specifier      fr-FR Culture                               31/10/2008
//    
//    D Format Specifier      de-DE Culture                Freitag, 31. Oktober 2008
//    D Format Specifier      en-US Culture                 Friday, October 31, 2008
//    D Format Specifier      es-ES Culture           viernes, 31 de octubre de 2008
//    D Format Specifier      fr-FR Culture                 vendredi 31 octobre 2008
//    
//    f Format Specifier      de-DE Culture          Freitag, 31. Oktober 2008 17:04
//    f Format Specifier      en-US Culture         Friday, October 31, 2008 5:04 PM
//    f Format Specifier      es-ES Culture     viernes, 31 de octubre de 2008 17:04
//    f Format Specifier      fr-FR Culture           vendredi 31 octobre 2008 17:04
//    
//    F Format Specifier      de-DE Culture       Freitag, 31. Oktober 2008 17:04:32
//    F Format Specifier      en-US Culture      Friday, October 31, 2008 5:04:32 PM
//    F Format Specifier      es-ES Culture  viernes, 31 de octubre de 2008 17:04:32
//    F Format Specifier      fr-FR Culture        vendredi 31 octobre 2008 17:04:32
//    
//    g Format Specifier      de-DE Culture                         31.10.2008 17:04
//    g Format Specifier      en-US Culture                       10/31/2008 5:04 PM
//    g Format Specifier      es-ES Culture                         31/10/2008 17:04
//    g Format Specifier      fr-FR Culture                         31/10/2008 17:04
//    
//    G Format Specifier      de-DE Culture                      31.10.2008 17:04:32
//    G Format Specifier      en-US Culture                    10/31/2008 5:04:32 PM
//    G Format Specifier      es-ES Culture                      31/10/2008 17:04:32
//    G Format Specifier      fr-FR Culture                      31/10/2008 17:04:32
//    
//    m Format Specifier      de-DE Culture                              31. Oktober
//    m Format Specifier      en-US Culture                               October 31
//    m Format Specifier      es-ES Culture                            31 de octubre
//    m Format Specifier      fr-FR Culture                               31 octobre
//    
//    o Format Specifier      de-DE Culture              2008-10-31T17:04:32.0000000
//    o Format Specifier      en-US Culture              2008-10-31T17:04:32.0000000
//    o Format Specifier      es-ES Culture              2008-10-31T17:04:32.0000000
//    o Format Specifier      fr-FR Culture              2008-10-31T17:04:32.0000000
//    
//    r Format Specifier      de-DE Culture            Fri, 31 Oct 2008 17:04:32 GMT
//    r Format Specifier      en-US Culture            Fri, 31 Oct 2008 17:04:32 GMT
//    r Format Specifier      es-ES Culture            Fri, 31 Oct 2008 17:04:32 GMT
//    r Format Specifier      fr-FR Culture            Fri, 31 Oct 2008 17:04:32 GMT
//    
//    s Format Specifier      de-DE Culture                      2008-10-31T17:04:32
//    s Format Specifier      en-US Culture                      2008-10-31T17:04:32
//    s Format Specifier      es-ES Culture                      2008-10-31T17:04:32
//    s Format Specifier      fr-FR Culture                      2008-10-31T17:04:32
//    
//    t Format Specifier      de-DE Culture                                    17:04
//    t Format Specifier      en-US Culture                                  5:04 PM
//    t Format Specifier      es-ES Culture                                    17:04
//    t Format Specifier      fr-FR Culture                                    17:04
//    
//    T Format Specifier      de-DE Culture                                 17:04:32
//    T Format Specifier      en-US Culture                               5:04:32 PM
//    T Format Specifier      es-ES Culture                                 17:04:32
//    T Format Specifier      fr-FR Culture                                 17:04:32
//    
//    u Format Specifier      de-DE Culture                     2008-10-31 17:04:32Z
//    u Format Specifier      en-US Culture                     2008-10-31 17:04:32Z
//    u Format Specifier      es-ES Culture                     2008-10-31 17:04:32Z
//    u Format Specifier      fr-FR Culture                     2008-10-31 17:04:32Z
//    
//    U Format Specifier      de-DE Culture       Freitag, 31. Oktober 2008 09:04:32
//    U Format Specifier      en-US Culture      Friday, October 31, 2008 9:04:32 AM
//    U Format Specifier      es-ES Culture   viernes, 31 de octubre de 2008 9:04:32
//    U Format Specifier      fr-FR Culture        vendredi 31 octobre 2008 09:04:32
//    
//    Y Format Specifier      de-DE Culture                             Oktober 2008
//    Y Format Specifier      en-US Culture                             October 2008
//    Y Format Specifier      es-ES Culture                          octubre de 2008
//    Y Format Specifier      fr-FR Culture                             octobre 2008
// </Snippet4>
