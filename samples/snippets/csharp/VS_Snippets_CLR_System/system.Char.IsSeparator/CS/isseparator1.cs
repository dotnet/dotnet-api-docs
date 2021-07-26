// <Snippet1>
using System;

public class Class1
{
   public static void Main()
   {
      for (int ctr = (int)(char.MinValue); ctr <= (int)(char.MaxValue); ctr++)
      {
         char ch = (char)ctr;
         if (char.IsSeparator(ch))
            Console.WriteLine(@"\u{(int)ch:X4} ({char.GetUnicodeCategory(ch)})");
      }
   }
}
// The example displays the following output:
//       \u0020 (SpaceSeparator)
//       \u00A0 (SpaceSeparator)
//       \u1680 (SpaceSeparator)
//       \u180E (SpaceSeparator)
//       \u2000 (SpaceSeparator)
//       \u2001 (SpaceSeparator)
//       \u2002 (SpaceSeparator)
//       \u2003 (SpaceSeparator)
//       \u2004 (SpaceSeparator)
//       \u2005 (SpaceSeparator)
//       \u2006 (SpaceSeparator)
//       \u2007 (SpaceSeparator)
//       \u2008 (SpaceSeparator)
//       \u2009 (SpaceSeparator)
//       \u200A (SpaceSeparator)
//       \u2028 (LineSeparator)
//       \u2029 (ParagraphSeparator)
//       \u202F (SpaceSeparator)
//       \u205F (SpaceSeparator)
//       \u3000 (SpaceSeparator)
// </Snippet1>
