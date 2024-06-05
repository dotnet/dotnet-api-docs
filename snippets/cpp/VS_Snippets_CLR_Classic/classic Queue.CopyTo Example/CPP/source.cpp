
// <Snippet1>
using namespace System;
using namespace System::Collections;
void PrintValues( Array^ myArr, char mySeparator );
int main()
{
   // Creates and initializes the source Queue.
   Queue^ mySourceQ = gcnew Queue;
   mySourceQ->Enqueue( "three" );
   mySourceQ->Enqueue( "napping" );
   mySourceQ->Enqueue( "cats" );
   mySourceQ->Enqueue( "in" );
   mySourceQ->Enqueue( "the" );
   mySourceQ->Enqueue( "barn" );

   // Creates and initializes the one-dimensional target Array.
   Array^ myTargetArray = Array::CreateInstance( String::typeid, 15 );
   myTargetArray->SetValue( "The", 0 );
   myTargetArray->SetValue( "quick", 1 );
   myTargetArray->SetValue( "brown", 2 );
   myTargetArray->SetValue( "fox", 3 );
   myTargetArray->SetValue( "jumps", 4 );
   myTargetArray->SetValue( "over", 5 );
   myTargetArray->SetValue( "the", 6 );
   myTargetArray->SetValue( "lazy", 7 );
   myTargetArray->SetValue( "dog", 8 );

   // Displays the values of the target Array.
   Console::WriteLine( "The target Array contains the following (before and after copying):" );
   PrintValues( myTargetArray, ' ' );

   // Copies the entire source Queue to the target Array, starting at index 6.
   mySourceQ->CopyTo( myTargetArray, 6 );

   // Displays the values of the target Array.
   PrintValues( myTargetArray, ' ' );

   // Copies the entire source Queue to a new standard array.
   array<Object^>^myStandardArray = mySourceQ->ToArray();

   // Displays the values of the new standard array.
   Console::WriteLine( "The new standard array contains the following:" );
   PrintValues( myStandardArray, ' ' );
}

void PrintValues( Array^ myArr, char mySeparator )
{
   IEnumerator^ myEnum = myArr->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Object^ myObj = safe_cast<Object^>(myEnum->Current);
      Console::Write( "{0}{1}", mySeparator, myObj );
   }

   Console::WriteLine();
}

/* 
 This code produces the following output.
 
 The target Array contains the following (before and after copying):
  The quick brown fox jumps over the lazy dog
  The quick brown fox jumps over three napping cats in the barn
 The new standard array contains the following:
  three napping cats in the barn

 */
// </Snippet1>
