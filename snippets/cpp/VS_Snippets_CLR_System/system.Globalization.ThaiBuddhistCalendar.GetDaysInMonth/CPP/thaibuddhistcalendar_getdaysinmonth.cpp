
// The following code example calls GetDaysInMonth for the second month in each of 5 
// years in each era.
// <snippet1>
using namespace System;
using namespace System::Globalization;
int main()
{
   
   // Creates and initializes a ThaiBuddhistCalendar.
   ThaiBuddhistCalendar^ myCal = gcnew ThaiBuddhistCalendar;
   
   // Displays the header.
   Console::Write( "YEAR\t" );
   for ( int y = 2544; y <= 2548; y++ )
      Console::Write( "\t {0}", y );
   Console::WriteLine();
   
   // Displays the value of the CurrentEra property.
   Console::Write( "CurrentEra:" );
   for ( int y = 2544; y <= 2548; y++ )
      Console::Write( "\t {0}", myCal->GetDaysInMonth( y, 2, ThaiBuddhistCalendar::CurrentEra ) );
   Console::WriteLine();
   
   // Displays the values in the Eras property.
   for ( int i = 0; i < myCal->Eras->Length; i++ )
   {
      Console::Write( "Era {0}:\t", myCal->Eras[ i ] );
      for ( int y = 2544; y <= 2548; y++ )
         Console::Write( "\t {0}", myCal->GetDaysInMonth( y, 2, myCal->Eras[ i ] ) );
      Console::WriteLine();

   }
}

/*
This code produces the following output.

YEAR            2544    2545    2546    2547    2548
CurrentEra:     28      28      28      29      28
Era 1:          28      28      28      29      28

*/
// </snippet1>
