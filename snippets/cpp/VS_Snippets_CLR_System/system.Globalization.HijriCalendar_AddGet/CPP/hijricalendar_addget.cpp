
// The following code example displays the values of several components of a DateTime in terms of the Hijri calendar.
// <snippet1>
using namespace System;
using namespace System::Globalization;
void DisplayValues( Calendar^ myCal, DateTime myDT )
{
   Console::WriteLine( "   Era:        {0}", myCal->GetEra( myDT ) );
   Console::WriteLine( "   Year:       {0}", myCal->GetYear( myDT ) );
   Console::WriteLine( "   Month:      {0}", myCal->GetMonth( myDT ) );
   Console::WriteLine( "   DayOfYear:  {0}", myCal->GetDayOfYear( myDT ) );
   Console::WriteLine( "   DayOfMonth: {0}", myCal->GetDayOfMonth( myDT ) );
   Console::WriteLine( "   DayOfWeek:  {0}", myCal->GetDayOfWeek( myDT ) );
   Console::WriteLine();
}

int main()
{
   
   // Sets a DateTime to April 3, 2002 of the Gregorian calendar.
   DateTime myDT = DateTime(2002,4,3,gcnew GregorianCalendar);
   
   // Creates an instance of the HijriCalendar.
   HijriCalendar^ myCal = gcnew HijriCalendar;
   
   // Displays the values of the DateTime.
   Console::WriteLine( "April 3, 2002 of the Gregorian calendar equals the following in the Hijri calendar:" );
   DisplayValues( myCal, myDT );
   
   // Adds two years and ten months.
   myDT = myCal->AddYears( myDT, 2 );
   myDT = myCal->AddMonths( myDT, 10 );
   
   // Displays the values of the DateTime.
   Console::WriteLine( "After adding two years and ten months:" );
   DisplayValues( myCal, myDT );
}

/*
This code produces the following output.

April 3, 2002 of the Gregorian calendar equals the following in the Hijri calendar:
   Era:        1
   Year:       1423
   Month:      1
   DayOfYear:  21
   DayOfMonth: 21
   DayOfWeek:  Wednesday

After adding two years and ten months:
   Era:        1
   Year:       1425
   Month:      11
   DayOfYear:  316
   DayOfMonth: 21
   DayOfWeek:  Saturday

*/
// </snippet1>
