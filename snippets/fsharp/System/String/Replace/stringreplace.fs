module stringreplace
//<snippet1>
open System

let errString = "This docment uses 3 other docments to docment the docmentation"

printfn $"The original string is:{Environment.NewLine}'{errString}'{Environment.NewLine}"

// Correct the spelling of "document".

let correctString = errString.Replace("docment", "document")

printfn $"After correcting the string, the result is:{Environment.NewLine}'{correctString}'"

// This code example produces the following output:
//
// The original string is:
// 'This docment uses 3 other docments to docment the docmentation'
//
// After correcting the string, the result is:
// 'This document uses 3 other documents to document the documentation'
//
//</snippet1>