#using <System.dll>

using namespace System;
using namespace System::Collections::Generic;

public ref class Example
{
public:
    static void Main()
    {
        // Create a new sorted list of strings, with string
        // keys.
        SortedList<int, String^>^ mySortedList =
            gcnew SortedList<int, String^>();

        // Add some elements to the list. There are no
        // duplicate keys, but some of the values are duplicates.
        mySortedList->Add(0, "notepad.exe");
        mySortedList->Add(1, "paint.exe");
        mySortedList->Add(2, "paint.exe");
        mySortedList->Add(3, "wordpad.exe");

        //<Snippet11>
        String^ v = mySortedList->Values[3];
        //</Snippet11>

        Console::WriteLine("Value at index 3: {0}", v);

        //<Snippet12>
        for each( KeyValuePair<int, String^> kvp in mySortedList )
        {
            Console::WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
        }
        //</Snippet12>
    }
};

int main()
{
    Example::Main();
}