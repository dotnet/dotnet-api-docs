
// The following example shows how to sort the values in an array using the default comparer
// and a custom comparer that reverses the sort order.

// <Snippet1>
using namespace System;
using namespace System::Collections;

public ref class ReverseComparer : IComparer
{
public:
   // Call CaseInsensitiveComparer::Compare with the parameters reversed.
   virtual int Compare(Object^ x, Object^ y) = IComparer::Compare
   {
      return ((gcnew CaseInsensitiveComparer)->Compare(y, x));
   }
};

void DisplayValues(array<String^>^ arr)
{
   for (int i = arr->GetLowerBound(0); i <= arr->GetUpperBound(0); i++)
      Console::WriteLine( "   [{0}] : {1}", i, arr[ i ] );

   Console::WriteLine();
}

int main()
{
   // Create and initialize a new array. and a new custom comparer.
   array<String^>^ words = { "The","QUICK","BROWN","FOX","jumps",
                             "over","the","lazy","dog" };
   // Instantiate the reverse comparer.
   IComparer^ revComparer = gcnew ReverseComparer();
   
   // Display the values of the Array.
   Console::WriteLine( "The original order of elements in the array:" );
   DisplayValues(words);

   // Sort a section of the array using the default comparer.
   Array::Sort(words, 1, 3);
   Console::WriteLine( "After sorting elements 1-3 by using the default comparer:");
   DisplayValues(words);

   // Sort a section of the array using the reverse case-insensitive comparer.
   Array::Sort(words, 1, 3, revComparer);
   Console::WriteLine( "After sorting elements 1-3 by using the reverse case-insensitive comparer:");
   DisplayValues(words);

   // Sort the entire array using the default comparer.
   Array::Sort(words);
   Console::WriteLine( "After sorting the entire array by using the default comparer:");
   DisplayValues(words);

   // Sort the entire array by using the reverse case-insensitive comparer.
   Array::Sort(words, revComparer);
   Console::WriteLine( "After sorting the entire array using the reverse case-insensitive comparer:");
   DisplayValues(words);
}

/* 
This code produces the following output.

The Array initially contains the following values:
   [0] : The
   [1] : QUICK
   [2] : BROWN
   [3] : FOX
   [4] : jumps
   [5] : over
   [6] : the
   [7] : lazy
   [8] : dog

After sorting a section of the Array using the default comparer:
   [0] : The
   [1] : BROWN
   [2] : FOX
   [3] : QUICK
   [4] : jumps
   [5] : over
   [6] : the
   [7] : lazy
   [8] : dog

After sorting a section of the Array using the reverse case-insensitive comparer:
   [0] : The
   [1] : QUICK
   [2] : FOX
   [3] : BROWN
   [4] : jumps
   [5] : over
   [6] : the
   [7] : lazy
   [8] : dog

After sorting the entire Array using the default comparer:
   [0] : BROWN
   [1] : dog
   [2] : FOX
   [3] : jumps
   [4] : lazy
   [5] : over
   [6] : QUICK
   [7] : the
   [8] : The

After sorting the entire Array using the reverse case-insensitive comparer:
   [0] : the
   [1] : The
   [2] : QUICK
   [3] : over
   [4] : lazy
   [5] : jumps
   [6] : FOX
   [7] : dog
   [8] : BROWN

*/
// </Snippet1>
