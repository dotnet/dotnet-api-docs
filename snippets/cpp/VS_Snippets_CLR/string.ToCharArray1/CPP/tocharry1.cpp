
//<snippet1>
// Sample for String::ToCharArray(Int32, Int32)
using namespace System;
using namespace System::Collections;
int main()
{
   String^ str = "012wxyz789";
   array<Char>^arr;
   arr = str->ToCharArray( 3, 4 );
   Console::Write( "The letters in '{0}' are: '", str );
   Console::Write( arr );
   Console::WriteLine( "'" );
   Console::WriteLine( "Each letter in '{0}' is:", str );
   IEnumerator^ myEnum = arr->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Char c =  safe_cast<Char>(myEnum->Current);
      Console::WriteLine( c );
   }
}

/*
This example produces the following results:
The letters in '012wxyz789' are: 'wxyz'
Each letter in '012wxyz789' is:
w
x
y
z
*/
//</snippet1>
