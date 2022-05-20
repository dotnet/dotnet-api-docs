// <Snippet1>
// The following code example creates SortedList instances using different constructors
// and demonstrates the differences in the behavior of the SortedList instances.



using namespace System;
using namespace System::Collections;
using namespace System::Globalization;
void PrintKeysAndValues( SortedList^ myList )
{
   Console::WriteLine( "        Capacity is {0}.", myList->Capacity );
   Console::WriteLine( "        -KEY-   -VALUE-" );
   for ( int i = 0; i < myList->Count; i++ )
   {
      Console::WriteLine( "        {0,-6}: {1}", myList->GetKey( i ), myList->GetByIndex( i ) );

   }
   Console::WriteLine();
}

int main()
{
   
   // Create a SortedList using the default comparer.
   SortedList^ mySL1 = gcnew SortedList( 3 );
   Console::WriteLine( "mySL1 (default):" );
   mySL1->Add( "FIRST", "Hello" );
   mySL1->Add( "SECOND", "World" );
   mySL1->Add( "THIRD", "!" );
   try
   {
      mySL1->Add( "first", "Ola!" );
   }
   catch ( ArgumentException^ e ) 
   {
      Console::WriteLine( e );
   }

   PrintKeysAndValues( mySL1 );
   
   // Create a SortedList using the specified case-insensitive comparer.
   SortedList^ mySL2 = gcnew SortedList( gcnew CaseInsensitiveComparer,3 );
   Console::WriteLine( "mySL2 (case-insensitive comparer):" );
   mySL2->Add( "FIRST", "Hello" );
   mySL2->Add( "SECOND", "World" );
   mySL2->Add( "THIRD", "!" );
   try
   {
      mySL2->Add( "first", "Ola!" );
   }
   catch ( ArgumentException^ e ) 
   {
      Console::WriteLine( e );
   }

   PrintKeysAndValues( mySL2 );
   
    // Create a SortedList using the specified CaseInsensitiveComparer,
    // which is based on the Turkish culture (tr-TR), where "I" is not
    // the uppercase version of "i".
    CultureInfo^ myCul = gcnew CultureInfo("tr-TR");
    SortedList^ mySL3 = gcnew SortedList(gcnew CaseInsensitiveComparer(myCul), 3);

	Console::WriteLine("mySL3 (case-insensitive comparer, Turkish culture):");

    mySL3->Add("FIRST", "Hello");
    mySL3->Add("SECOND", "World");
    mySL3->Add("THIRD", "!");
    try
    {
        mySL3->Add("first", "Ola!");
    }
    catch (ArgumentException^ e)
    {
		Console::WriteLine(e);
    }
    PrintKeysAndValues(mySL3);

    // Create a SortedList using the
    // StringComparer.InvariantCultureIgnoreCase value.
   SortedList^ mySL4 = gcnew SortedList( StringComparer::InvariantCultureIgnoreCase, 3 );
   Console::WriteLine( "mySL4 (InvariantCultureIgnoreCase):" );
   mySL4->Add( "FIRST", "Hello" );
   mySL4->Add( "SECOND", "World" );
   mySL4->Add( "THIRD", "!" );
   try
   {
      mySL4->Add( "first", "Ola!" );
   }
   catch ( ArgumentException^ e ) 
   {
      Console::WriteLine( e );
   }

   PrintKeysAndValues( mySL4 );
}

/* 
This code produces the following output.  Results vary depending on the system's culture settings.

mySL1 (default):
        Capacity is 6.
        -KEY-   -VALUE-
        first : Ola!
        FIRST : Hello
        SECOND: World
        THIRD : !

mySL2 (case-insensitive comparer):
System.ArgumentException: Item has already been added.  Key in dictionary: 'FIRST'  Key being added: 'first'
   at System.Collections.SortedList.Add(Object key, Object value)
   at SamplesSortedList.Main()
        Capacity is 3.
        -KEY-   -VALUE-
        FIRST : Hello
        SECOND: World
        THIRD : !

mySL3 (case-insensitive comparer, Turkish culture):
        Capacity is 6.
        -KEY-   -VALUE-
        FIRST : Hello
        first : Ola!
        SECOND: World
        THIRD : !

mySL4 (InvariantCultureIgnoreCase):
System.ArgumentException: Item has already been added.  Key in dictionary: 'FIRST'  Key being added: 'first'
   at System.Collections.SortedList.Add(Object key, Object value)
   at SamplesSortedList.Main()
        Capacity is 3.
        -KEY-   -VALUE-
        FIRST : Hello
        SECOND: World
        THIRD : !

*/
// </Snippet1>
