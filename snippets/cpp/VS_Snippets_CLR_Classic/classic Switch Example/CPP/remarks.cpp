#using <System.dll>

using namespace System;
using namespace System::Diagnostics;

public ref class SomeClass
{
// <Snippet4>
private:
    static BooleanSwitch^ boolSwitch = gcnew BooleanSwitch("mySwitch",
        "Switch in config file");

public:
    static void Main( )
    {
        //...
        Console::WriteLine("Boolean switch {0} configured as {1}",
            boolSwitch->DisplayName, ((Boolean^)boolSwitch->Enabled)->ToString());
        if (boolSwitch->Enabled)
        {
            //...
        }
    }
// </Snippet4>
};

int main()
{
    SomeClass::Main();
}