
// The following code example gets the minimum value and the maximum value of the calendar.
// <snippet1>
using namespace System;
using namespace System::Globalization;
int main()
{
   
   // Create an instance of the calendar.
   TaiwanCalendar^ myCal = gcnew TaiwanCalendar;
   Console::WriteLine( myCal );
   
   // Create an instance of the GregorianCalendar.
   GregorianCalendar^ myGre = gcnew GregorianCalendar;
   
   // Display the MinSupportedDateTime and its equivalent in the GregorianCalendar.
   DateTime myMin = myCal->MinSupportedDateTime;
   Console::Write( "MinSupportedDateTime: {0:D2}/{1:D2}/{2:D4}", myCal->GetMonth( myMin ), myCal->GetDayOfMonth( myMin ), myCal->GetYear( myMin ) );
   Console::WriteLine( " (in Gregorian, {0:D2}/{1:D2}/{2:D4})", myGre->GetMonth( myMin ), myGre->GetDayOfMonth( myMin ), myGre->GetYear( myMin ) );
   
   // Display the MaxSupportedDateTime and its equivalent in the GregorianCalendar.
   DateTime myMax = myCal->MaxSupportedDateTime;
   Console::Write( "MaxSupportedDateTime: {0:D2}/{1:D2}/{2:D4}", myCal->GetMonth( myMax ), myCal->GetDayOfMonth( myMax ), myCal->GetYear( myMax ) );
   Console::WriteLine( " (in Gregorian, {0:D2}/{1:D2}/{2:D4})", myGre->GetMonth( myMax ), myGre->GetDayOfMonth( myMax ), myGre->GetYear( myMax ) );
}

/*
This code produces the following output.

System.Globalization.TaiwanCalendar
MinSupportedDateTime: 01/01/0001 (in Gregorian, 01/01/1912)
MaxSupportedDateTime: 12/31/8088 (in Gregorian, 12/31/9999)

*/
// </snippet1>
