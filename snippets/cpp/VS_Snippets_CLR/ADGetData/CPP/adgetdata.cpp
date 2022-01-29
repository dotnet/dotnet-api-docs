
//<Snippet1>
using namespace System;
using namespace System::Reflection;

int main()
{
   // appdomain setup information
   AppDomain^ currentDomain = AppDomain::CurrentDomain;
   
   //Create a new value pair for the appdomain
   currentDomain->SetData( "ADVALUE", "Example value" );
   
   //get the value specified in the setdata method
   Console::WriteLine( "ADVALUE is: {0}", currentDomain->GetData( "ADVALUE" ) );
   
   //get a system value specified at appdomainsetup
   Console::WriteLine( "System value for loader optimization: {0}", 
      currentDomain->GetData( "LOADER_OPTIMIZATION" ) );
}

/* This code example produces the following output:

ADVALUE is: Example value
System value for loader optimization: NotSpecified
 */

//</Snippet1>
