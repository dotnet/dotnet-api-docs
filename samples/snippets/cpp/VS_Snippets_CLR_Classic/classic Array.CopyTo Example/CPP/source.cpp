
// <Snippet1>
using namespace System;

void main()
{
   // Creates and initializes two new Array instances.
   Array^ mySourceArray = Array::CreateInstance(String::typeid, 6);
   mySourceArray->SetValue("three", 0);
   mySourceArray->SetValue("napping", 1);
   mySourceArray->SetValue("cats", 2);
   mySourceArray->SetValue("in", 3);
   mySourceArray->SetValue("the", 4);
   mySourceArray->SetValue("barn", 5);
   Array^ myTargetArray = Array::CreateInstance(String::typeid, 15);
   myTargetArray->SetValue("The", 0);
   myTargetArray->SetValue("quick", 1);
   myTargetArray->SetValue("brown", 2);
   myTargetArray->SetValue("fox", 3);
   myTargetArray->SetValue("jumps", 4);
   myTargetArray->SetValue("over", 5);
   myTargetArray->SetValue("the", 6);
   myTargetArray->SetValue("lazy", 7);
   myTargetArray->SetValue("dog", 8);

   // Displays the values of the Array.
   Console::WriteLine( "The target Array instance contains the following (before and after copying):");
   PrintValues(myTargetArray);

   // Copies the source Array to the target Array, starting at index 6.
   mySourceArray->CopyTo(myTargetArray, 6);

   // Displays the values of the Array.
   PrintValues(myTargetArray);
}

void PrintValues(Array^ myArr)
{
   System::Collections::IEnumerator^ myEnumerator = myArr->GetEnumerator();
   int i = 0;
   int cols = myArr->GetLength(myArr->Rank - 1);
   while (myEnumerator->MoveNext())
   {
      if (i < cols)
      {
         i++;
      }
      else
      {
         Console::WriteLine();
         i = 1;
      }

      Console::Write( " {0}", myEnumerator->Current);
   }

   Console::WriteLine();
}

/*
 This code produces the following output.
 
  The target Array instance contains the following (before and after copying):
  The quick brown fox jumps over the lazy dog      
  The quick brown fox jumps over three napping cats in the barn
 */
// </Snippet1>
