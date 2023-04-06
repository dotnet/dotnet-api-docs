
// <Snippet3>
using namespace System;

// Create a TimeSpan object and display its value.
void CreateTimeSpan( int days, int hours, int minutes, int seconds )
{
   TimeSpan elapsedTime = TimeSpan(days,hours,minutes,seconds);
   
   // Format the constructor for display.
   array<Object^>^boxedParams = gcnew array<Object^>(4);
   boxedParams[ 0 ] = days;
   boxedParams[ 1 ] = hours;
   boxedParams[ 2 ] = minutes;
   boxedParams[ 3 ] = seconds;
   String^ ctor = String::Format( "TimeSpan( {0}, {1}, {2}, {3} )", boxedParams );
   
   // Display the constructor and its value.
   Console::WriteLine( "{0,-44}{1,16}", ctor, elapsedTime.ToString() );
}

int main()
{
   Console::WriteLine( "{0,-44}{1,16}", "Constructor", "Value" );
   Console::WriteLine( "{0,-44}{1,16}", "-----------", "-----" );
   CreateTimeSpan( 10, 20, 30, 40 );
   CreateTimeSpan(  -10, 20, 30, 40 );
   CreateTimeSpan( 0, 0, 0, 937840 );
   CreateTimeSpan( 1000, 2000, 3000, 4000 );
   CreateTimeSpan( 1000, -2000, -3000, -4000 );
   CreateTimeSpan( 999999, 999999, 999999, 999999 );
}
// The example displays the following output:
//       Constructor                                            Value
//       -----------                                            -----
//       TimeSpan( 10, 20, 30, 40 )                       10.20:30:40
//       TimeSpan( -10, 20, 30, 40 )                      -9.03:29:20
//       TimeSpan( 0, 0, 0, 937840 )                      10.20:30:40
//       TimeSpan( 1000, 2000, 3000, 4000 )             1085.11:06:40
//       TimeSpan( 1000, -2000, -3000, -4000 )           914.12:53:20
//       TimeSpan( 999999, 999999, 999999, 999999 )  1042371.15:25:39
// </Snippet3>
