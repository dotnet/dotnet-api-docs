using namespace System;
using namespace System::Reflection;

// <Snippet1>
public ref class MyType
{
public:
    MyType()
    {
        Console::WriteLine();
        Console::WriteLine("MyType instantiated!");
    }
};

class Test
{
public:
    static void Main()
    {
        AppDomain^ currentDomain = AppDomain::CurrentDomain;

        // This call will fail to create an instance of MyType since the
        // assembly resolver is not set
        InstantiateMyTypeFail(currentDomain);

        currentDomain->AssemblyResolve += gcnew ResolveEventHandler(&Test::MyResolveEventHandler);

        // This call will succeed in creating an instance of MyType since the
        // assembly resolver is now set.
        InstantiateMyTypeFail(currentDomain);

        // This call will succeed in creating an instance of MyType since the
        // assembly name is valid.
        InstantiateMyTypeSucceed(currentDomain);
    }

private:
    static void InstantiateMyTypeFail(AppDomain^ domain)
    {
        // Calling InstantiateMyType will always fail since the assembly info
        // given to CreateInstance is invalid.
        try
        {
            // You must supply a valid fully qualified assembly name here.
            domain->CreateInstance("Assembly text name, Version, Culture, PublicKeyToken", "MyType");
        }
        catch (Exception^ e)
        {
            Console::WriteLine();
            Console::WriteLine(e->Message);
        }
    }

    static void InstantiateMyTypeSucceed(AppDomain^ domain)
    {
        try
        {
            String^ asmname = Assembly::GetCallingAssembly()->FullName;
            domain->CreateInstance(asmname, "MyType");
        }
        catch (Exception^ e)
        {
            Console::WriteLine();
            Console::WriteLine(e->Message);
        }
    }

    static Assembly^ MyResolveEventHandler(Object^ sender, ResolveEventArgs^ args)
    {
        Console::WriteLine("Resolving...");
        return MyType::typeid->Assembly;
    }
};

int main()
{
    Test::Main();
}
// </Snippet1>
