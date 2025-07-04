﻿Imports System.Globalization

Module Module1

    Public Sub RunIt()
        ' <snippet1>

        ' Displays several properties of the neutral cultures.
        Console.WriteLine("CULTURE ISO ISO WIN DISPLAYNAME                              ENGLISHNAME")
        Dim ci As CultureInfo
        For Each ci In CultureInfo.GetCultures(CultureTypes.NeutralCultures)
            Console.Write("{0,-7}", ci.Name)
            Console.Write(" {0,-3}", ci.TwoLetterISOLanguageName)
            Console.Write(" {0,-3}", ci.ThreeLetterISOLanguageName)
            Console.Write(" {0,-3}", ci.ThreeLetterWindowsLanguageName)
            Console.Write(" {0,-40}", ci.DisplayName)
            Console.WriteLine(" {0,-40}", ci.EnglishName)
        Next ci

        'This code produces the following output.  This output has been cropped for brevity.
        '
        'CULTURE ISO ISO WIN DISPLAYNAME                              ENGLISHNAME
        'ar      ar  ara ARA Arabic                                   Arabic
        'bg      bg  bul BGR Bulgarian                                Bulgarian
        'ca      ca  cat CAT Catalan                                  Catalan
        'cs      cs  ces CSY Czech                                    Czech
        'da      da  dan DAN Danish                                   Danish
        'de      de  deu DEU German                                   German
        'el      el  ell ELL Greek                                    Greek
        'en      en  eng ENU English                                  English
        'es      es  spa ESP Spanish                                  Spanish
        'fi      fi  fin FIN Finnish                                  Finnish
        'zh      zh  zho CHS Chinese                                  Chinese
        'zh-Hans zh  zho CHS Chinese (Simplified)                     Chinese (Simplified)
        'zh-Hant zh  zho ZHH Chinese (Traditional)                    Chinese (Traditional)
        '
        'Note: zh-Hant returns ZHH when using ICU (default). When NLS mode is enabled, it returns CHT.

        ' </snippet1>
    End Sub

End Module
