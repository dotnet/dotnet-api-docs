using namespace System;
using namespace System::Linq;
using namespace System::Collections;
using namespace System::Collections::Generic;

// <Snippet6>
// Declare a delegate
delegate String ^ MyDel(String ^);

// Create wrapper class and function that takes in a string and converts it to uppercase
ref class DelegateWrapper {
public:
    String ^ capitalize(String ^ s) {
        return s->ToUpper();
    }
};

int main() {
    // Declare delegate
    DelegateWrapper ^ delegateWrapper = gcnew DelegateWrapper;
    MyDel ^ DelInst = gcnew MyDel(delegateWrapper, &DelegateWrapper::capitalize);

    // Cast into Func
    Func<String ^, String ^> ^ selector = reinterpret_cast<Func<String ^, String ^> ^>(DelInst);

    // Create an array of strings
    array<String ^> ^ words = { "orange", "apple", "Article", "elephant" };

    // Query the array and select strings according to the selector method
    Generic::IEnumerable<String ^> ^ aWords = Enumerable::Select((Generic::IEnumerable<String^>^)words, selector);

    // Output the results to the console
    for each(String ^ word in aWords)
        Console::WriteLine(word);
    /*
    This code example produces the following output:

    ORANGE
    APPLE
    ARTICLE
    ELEPHANT
    */
}
// </Snippet6>
