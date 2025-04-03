// <snippet2>
#include <iostream>
#using <System.dll>

using namespace System;
using namespace System::Collections::Generic;
using namespace System::Globalization;

ref class StringSort
{
public:
    static void Main()
    {
        auto wordList = gcnew List<String^> {
            "cant", "bill's", "coop", "cannot", "billet", "can't", "con", "bills", "co-op"
        };

        Console::WriteLine("Before sorting:");
        for each (String^ word in wordList)
        {
            Console::WriteLine(word);
        }

        Console::WriteLine(Environment::NewLine + "After sorting with CompareOptions::None:");
        SortAndDisplay(wordList, CompareOptions::None);

        Console::WriteLine(Environment::NewLine + "After sorting with CompareOptions::StringSort:");
        SortAndDisplay(wordList, CompareOptions::StringSort);
    }

private:
    static void SortAndDisplay(List<String^>^ unsorted, CompareOptions options)
    {
        // Create a copy of the original list to sort.
        auto words = gcnew List<String^>(unsorted);
        // Define the CompareInfo to use to compare strings.
        CompareInfo^ comparer = CultureInfo::InvariantCulture->CompareInfo;

        // Sort the copy with the supplied CompareOptions then display.
        words->Sort(gcnew Comparison<String^>([comparer, options](String^ str1, String^ str2) {
            return comparer->Compare(str1, str2, options);
        }));

        for each (String^ word in words)
        {
            Console::WriteLine(word);
        }
    }
};

int main(array<System::String ^> ^args)
{
    StringSort::Main();
    return 0;
}

/*
CompareOptions.None and CompareOptions.StringSort provide identical ordering by default
in .NET 5 and later, but in prior versions, the output will be the following:

Before sorting:
cant
bill's
coop
cannot
billet
can't
con
bills
co-op

After sorting with CompareOptions.None:
billet
bills
bill's
cannot
cant
can't
con
coop
co-op

After sorting with CompareOptions.StringSort:
bill's
billet
bills
can't
cannot
cant
co-op
con
coop
*/
// </snippet2>
