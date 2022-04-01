module equals

//<snippet1>
// Sample for String.Equals(Object)
//            String.Equals(String)
//            String.Equals(String, String)
open System
open System.Text

let sb = StringBuilder "abcd"
let str1 = "abcd"
let str2 = string sb
let o2: obj = str2

printfn $"""
*  The value of String str1 is '{str1}'.
*  The value of StringBuilder sb is '{sb}'.

1a) String.Equals(Object). Object is a StringBuilder, not a String.
Is str1 equal to sb?: {str1.Equals sb}"

1b) String.Equals(Object). Object is a String.
*  The value of Object o2 is '{o2}'.
Is str1 equal to o2?: {str1.Equals o2}

2) String.Equals(String)
*  The value of String str2 is '{str2}'.
Is str1 equal to str2?: {str1.Equals str2}

3) String.Equals(String, String)
Is str1 equal to str2?: {String.Equals(str1, str2)}"""
(*
This example produces the following results:

 *  The value of String str1 is 'abcd'.
 *  The value of StringBuilder sb is 'abcd'.

1a) String.Equals(Object). Object is a StringBuilder, not a String.
    Is str1 equal to sb?: False

1b) String.Equals(Object). Object is a String.
 *  The value of Object o2 is 'abcd'.
    Is str1 equal to o2?: True

 2) String.Equals(String)
 *  The value of String str2 is 'abcd'.
    Is str1 equal to str2?: True

 3) String.Equals(String, String)
    Is str1 equal to str2?: True
*)
//</snippet1>