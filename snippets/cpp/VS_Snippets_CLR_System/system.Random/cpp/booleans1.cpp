// <Snippet8>
using namespace System;

public ref class BooleanGenerator
{
   private:
      Random^ rnd;

   public:
      BooleanGenerator()
      {
         rnd = gcnew Random();
      }

      bool NextBoolean()
      {
         return Convert::ToBoolean(rnd->Next(0, 2));
      }
};

void main()
{
   // Instantiate the Boolean generator.
   BooleanGenerator^ boolGen = gcnew BooleanGenerator();
   int totalTrue = 0, totalFalse = 0;
   
   // Generate 1,0000 random Booleans, and keep a running total.
   for (int ctr = 0; ctr < 1000000; ctr++) {
       bool value = boolGen->NextBoolean();
       if (value)
          totalTrue++;
       else
          totalFalse++;
   }
   Console::WriteLine("Number of true values:  {0,7:N0} ({1:P3})",
                      totalTrue,
                      ((double) totalTrue)/(totalTrue + totalFalse));
   Console::WriteLine("Number of false values: {0,7:N0} ({1:P3})",
                     totalFalse, 
                     ((double) totalFalse)/(totalTrue + totalFalse));
}

// The example displays output like the following:
//       Number of true values:  500,004 (50.000 %)
//       Number of false values: 499,996 (50.000 %)
// </Snippet8>

