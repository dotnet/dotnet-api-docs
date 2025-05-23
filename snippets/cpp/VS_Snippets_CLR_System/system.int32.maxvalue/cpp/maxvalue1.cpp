// <Snippet1>
using namespace System;

void main()
{
   array<Int64>^ numbersToConvert = gcnew array<Int64> { 162345, 32183, -54000, 
                                                         Int64::MaxValue/2 };
   Int32 newNumber;
   for each (Int64 number in numbersToConvert)
   {
      if ((number >= Int32::MinValue) && (number <= Int32::MaxValue))
      {
         newNumber = Convert::ToInt32(number);
         Console::WriteLine("Successfully converted {0} to an Int32.", 
                           newNumber);
      }
      else
      {
         Console::WriteLine("Unable to convert {0} to an Int32.", number);
      }
   }
}
// The example displays the following output to the console:
//    Successfully converted 162345 to an Int32.
//    Successfully converted 32183 to an Int32.
//    Successfully converted -54000 to an Int32.
//    Unable to convert 4611686018427387903 to an Int32.
// </Snippet1>

