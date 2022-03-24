using namespace System;

int main()
{
   // <Snippet1>
   // Calculate what day of the week is 36 days from this instant.
   System::DateTime today = System::DateTime::Now;
   System::TimeSpan duration( 36, 0, 0, 0 );
   System::DateTime answer = today.Add( duration );
   System::Console::WriteLine( " {0:dddd}", answer );
   // </Snippet1>
}
