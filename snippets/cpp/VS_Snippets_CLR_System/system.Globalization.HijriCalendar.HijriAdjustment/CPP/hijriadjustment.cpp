
// The following code example shows how HijriAdjustment affects the date.
// <snippet1>
using namespace System;
using namespace System::Globalization;
int main()
{
   
   // Creates and initializes a HijriCalendar.
   HijriCalendar^ myCal = gcnew HijriCalendar;
   
   // Creates a DateTime and initializes it to the second day of the first month of the year 1422.
   DateTime myDT = DateTime(1422,1,2,myCal);
   
   // Displays the current values of the DateTime.
   Console::WriteLine( "HijriAdjustment is {0}.", myCal->HijriAdjustment );
   Console::WriteLine( "   Year is {0}.", myCal->GetYear( myDT ) );
   Console::WriteLine( "   Month is {0}.", myCal->GetMonth( myDT ) );
   Console::WriteLine( "   Day is {0}.", myCal->GetDayOfMonth( myDT ) );
   
   // Sets the HijriAdjustment property to 2.
   myCal->HijriAdjustment = 2;
   Console::WriteLine( "HijriAdjustment is {0}.", myCal->HijriAdjustment );
   Console::WriteLine( "   Year is {0}.", myCal->GetYear( myDT ) );
   Console::WriteLine( "   Month is {0}.", myCal->GetMonth( myDT ) );
   Console::WriteLine( "   Day is {0}.", myCal->GetDayOfMonth( myDT ) );
   
   // Sets the HijriAdjustment property to -2.
   myCal->HijriAdjustment = -2;
   Console::WriteLine( "HijriAdjustment is {0}.", myCal->HijriAdjustment );
   Console::WriteLine( "   Year is {0}.", myCal->GetYear( myDT ) );
   Console::WriteLine( "   Month is {0}.", myCal->GetMonth( myDT ) );
   Console::WriteLine( "   Day is {0}.", myCal->GetDayOfMonth( myDT ) );
}

/*
This code produces the following output.  Results vary depending on the registry settings.

HijriAdjustment is 0.
Year is 1422.
Month is 1.
Day is 2.
HijriAdjustment is 2.
Year is 1422.
Month is 1.
Day is 4.
HijriAdjustment is -2.
Year is 1421.
Month is 12.
Day is 29.

*/
// </snippet1>
