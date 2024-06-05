
//<Snippet2>
// Example of the BitConverter::DoubleToInt64Bits method.
using namespace System;

// Reinterpret the double argument as an __int64.
void DoubleToLongBits( double argument )
{
   __int64 longValue;
   longValue = BitConverter::DoubleToInt64Bits( argument );
   
   // Display the resulting __int64 in hexadecimal.
   Console::WriteLine( "{0,25:E16}{1,23:X16}", argument, longValue );
}

int main()
{
   Console::WriteLine( "This example of the BitConverter::DoubleToInt64Bits( "
   "double ) \nmethod generates the following output.\n" );
   Console::WriteLine( "{0,25:E16}{1,23:X16}", "double argument", "hexadecimal value" );
   Console::WriteLine( "{0,25:E16}{1,23:X16}", "---------------", "-----------------" );
   
   // Convert double values and display the results.
   DoubleToLongBits( 1.0 );
   DoubleToLongBits( 15.0 );
   DoubleToLongBits( 255.0 );
   DoubleToLongBits( 4294967295.0 );
   DoubleToLongBits( 0.00390625 );
   DoubleToLongBits( 0.00000000023283064365386962890625 );
   DoubleToLongBits( 1.234567890123E-300 );
   DoubleToLongBits( 1.23456789012345E-150 );
   DoubleToLongBits( 1.2345678901234565 );
   DoubleToLongBits( 1.2345678901234567 );
   DoubleToLongBits( 1.2345678901234569 );
   DoubleToLongBits( 1.23456789012345678E+150 );
   DoubleToLongBits( 1.234567890123456789E+300 );
   DoubleToLongBits( Double::MinValue );
   DoubleToLongBits( Double::MaxValue );
   DoubleToLongBits( Double::Epsilon );
   DoubleToLongBits( Double::NaN );
   DoubleToLongBits( Double::NegativeInfinity );
   DoubleToLongBits( Double::PositiveInfinity );
}

/*
This example of the BitConverter::DoubleToInt64Bits( double )
method generates the following output.

          double argument      hexadecimal value
          ---------------      -----------------
  1.0000000000000000E+000       3FF0000000000000
  1.5000000000000000E+001       402E000000000000
  2.5500000000000000E+002       406FE00000000000
  4.2949672950000000E+009       41EFFFFFFFE00000
  3.9062500000000000E-003       3F70000000000000
  2.3283064365386963E-010       3DF0000000000000
  1.2345678901230000E-300       01AA74FE1C1E7E45
  1.2345678901234500E-150       20D02A36586DB4BB
  1.2345678901234565E+000       3FF3C0CA428C59FA
  1.2345678901234567E+000       3FF3C0CA428C59FB
  1.2345678901234569E+000       3FF3C0CA428C59FC
  1.2345678901234569E+150       5F182344CD3CDF9F
  1.2345678901234569E+300       7E3D7EE8BCBBD352
 -1.7976931348623157E+308       FFEFFFFFFFFFFFFF
  1.7976931348623157E+308       7FEFFFFFFFFFFFFF
  4.9406564584124654E-324       0000000000000001
                      NaN       FFF8000000000000
                -Infinity       FFF0000000000000
                 Infinity       7FF0000000000000
*/
//</Snippet2>
