#using <System.dll>
#pragma region^ Using directives

using namespace System;
using namespace System::Collections::Generic;
using namespace System::Text;

#pragma endregion

int main()
{
    // <snippet1>
    UriBuilder^ baseUri = gcnew UriBuilder 
        ("http://www.contoso.com/default.aspx?Param1=7890");
    String^ queryToAppend = "param2=1234";
    if (baseUri->Query != nullptr && baseUri->Query->Length > 1)
    {
		// Note: In .NET Core and .NET 5+, you can simplify by removing
		// the call to Substring(), which removes the leading "?" character.
        baseUri->Query = baseUri->Query->Substring(1)+ "&" + queryToAppend;
    }
    else
    {
        baseUri->Query = queryToAppend;
    }
    // </snippet1>
}
