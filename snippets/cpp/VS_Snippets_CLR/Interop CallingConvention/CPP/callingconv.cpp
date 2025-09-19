// <Snippet1>
using namespace System;
using namespace System::Runtime::InteropServices;

private ref class NativeMethods
{
public:

    // CallingConvention.Cdecl must be used since the stack is 
    // cleaned up by the caller.
    // int printf( const char *format [, argument]... )

    [DllImport("msvcrt.dll", CharSet = CharSet::Unicode, CallingConvention = CallingConvention::Cdecl)]
    static int printf(String^ format, int i, double d);

    [DllImport("msvcrt.dll", CharSet = CharSet::Unicode, CallingConvention = CallingConvention::Cdecl)]
    static int printf(String^ format, int i, String^ s);
};

int main()
{
    NativeMethods::printf("\nPrint params: %i %f", 99, 99.99);
    NativeMethods::printf("\nPrint params: %i %s", 99, "abcd");
}
// </Snippet1>
