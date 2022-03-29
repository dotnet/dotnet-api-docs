module stringcompareto

//<snippet1>
let strFirst = "Goodbye"
let strSecond = "Hello"
let strThird = "a small string"
let strFourth = "goodbye"

let compareStrings (str1: string) str2 =
    // Compare the values, using the CompareTo method on the first string.
    match str1.CompareTo str2 with
    | 0 -> // The strings are the same.
        "The strings occur in the same position in the sort order."
    | x when x < 0 ->
        "The first string precedes the second in the sort order."
    | _ ->
        "The first string follows the second in the sort order."

// Compare a string to itself.
printfn $"{compareStrings strFirst strFirst}"

printfn $"{compareStrings strFirst strSecond}"
printfn $"{compareStrings strFirst strThird}"

// Compare a string to another string that varies only by case.
printfn $"{compareStrings strFirst strFourth}"
printfn $"{compareStrings strFourth strFirst}"

// The example displays the following output:
//       The strings occur in the same position in the sort order.
//       The first string precedes the second in the sort order.
//       The first string follows the second in the sort order.
//       The first string follows the second in the sort order.
//       The first string precedes the second in the sort order.
//</snippet1>