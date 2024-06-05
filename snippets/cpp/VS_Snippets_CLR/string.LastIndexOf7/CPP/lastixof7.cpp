
//<snippet1>
// Sample for String::LastIndexOf(String, Int32)
using namespace System;
int main()
{
   String^ br1 = "0----+----1----+----2----+----3----+----4----+----5----+----6----+-";
   String^ br2 = "0123456789012345678901234567890123456789012345678901234567890123456";
   String^ str = "Now is the time for all good men to come to the aid of their party.";
   int start;
   int at;
   start = str->Length - 1;
   Console::WriteLine( "All occurrences of 'he' from position {0} to 0.", start );
   Console::WriteLine( "{0}\n{1}\n{2}\n", br1, br2, str );
   Console::Write( "The string 'he' occurs at position(s): " );
   at = 0;
   while ( (start > -1) && (at > -1) )
   {
      at = str->LastIndexOf( "he", start );
      if ( at > -1 )
      {
         Console::Write( " {0} ", at );
         start = at - 1;
      }
   }

   Console::WriteLine();
}

/*
This example produces the following results:
All occurrences of 'he' from position 66 to 0.
0----+----1----+----2----+----3----+----4----+----5----+----6----+-
0123456789012345678901234567890123456789012345678901234567890123456
Now is the time for all good men to come to the aid of their party.

The string 'he' occurs at position(s):  56  45  8
*/
//</snippet1>
