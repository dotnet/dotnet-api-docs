// <Snippet1>
open System
open System.Globalization

let showTypeInfo (t: Type) =
    printfn $"Name: {t.Name}"
    printfn $"Full Name: {t.FullName}"
    printfn $"ToString:  {t}"
    printfn $"Assembly Qualified Name: {t.AssemblyQualifiedName}\n"

typeof<String>
|> showTypeInfo

(typeof<ResizeArray<_>>).GetGenericTypeDefinition()
|> showTypeInfo

let list = ResizeArray<String>()
list.GetType()
|> showTypeInfo

let v: obj = 12
v.GetType()
|> showTypeInfo

typeof<IFormatProvider>
|> showTypeInfo

let ifmt = NumberFormatInfo.CurrentInfo
ifmt.GetType()
|> showTypeInfo

let o = Some 3
o.GetType()
|> showTypeInfo

// The example displays output like the following:
//    Name: String
//    Full Name: System.String
//    ToString:  System.String
//    Assembly Qualified Name: System.String, mscorlib, Version=4.0.0.0, Culture=neutr
//    al, PublicKeyToken=b77a5c561934e089
//
//    Name: List`1
//    Full Name: System.Collections.Generic.List`1
//    ToString:  System.Collections.Generic.List`1[T]
//    Assembly Qualified Name: System.Collections.Generic.List`1, mscorlib, Version=4.
//    0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
//
//    Name: List`1
//    Full Name: System.Collections.Generic.List`1[[System.String, mscorlib, Version=4
//    .0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]
//    ToString:  System.Collections.Generic.List`1[System.String]
//    Assembly Qualified Name: System.Collections.Generic.List`1[[System.String, mscor
//    lib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorl
//    ib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
//
//    Name: Int32
//    Full Name: System.Int32
//    ToString:  System.Int32
//    Assembly Qualified Name: System.Int32, mscorlib, Version=4.0.0.0, Culture=neutra
//    l, PublicKeyToken=b77a5c561934e089
//
//    Name: IFormatProvider
//    Full Name: System.IFormatProvider
//    ToString:  System.IFormatProvider
//    Assembly Qualified Name: System.IFormatProvider, mscorlib, Version=4.0.0.0, Cult
//    ure=neutral, PublicKeyToken=b77a5c561934e089
//
//    Name: NumberFormatInfo
//    Full Name: System.Globalization.NumberFormatInfo
//    ToString:  System.Globalization.NumberFormatInfo
//    Assembly Qualified Name: System.Globalization.NumberFormatInfo, mscorlib, Versio
//    n=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
//
//    Name: FSharpOption`1
//    Full Name: Microsoft.FSharp.Core.FSharpOption`1[[System.Int32, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
//    ToString:  Microsoft.FSharp.Core.FSharpOption`1[System.Int32]
//    Assembly Qualified Name: Microsoft.FSharp.Core.FSharpOption`1[[System.Int32, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]], FSharp.Core, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// </Snippet1>