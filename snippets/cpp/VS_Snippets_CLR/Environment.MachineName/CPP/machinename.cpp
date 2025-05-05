
//<snippet1>
// Sample for the Environment::MachineName property
using namespace System;
int main()
{
   Console::WriteLine();
   
   //  <-- Keep this information secure! -->
   Console::WriteLine( "MachineName: {0}", Environment::MachineName );
}

/*
This example produces the following results:

MachineName: MyDesktop
*/
//</snippet1>
