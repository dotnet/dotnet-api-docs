module Trim1

// <Snippet1>
let charsToTrim = [| '*'; ' '; '\'' |]
let banner = "*** Much Ado About Nothing ***"
let result = banner.Trim charsToTrim
printfn $"Trimmmed\n   {banner}\nto\n   '{result}'"

// The example displays the following output:
//       Trimmmed
//          *** Much Ado About Nothing ***
//       to
//          'Much Ado About Nothing'
// </Snippet1>