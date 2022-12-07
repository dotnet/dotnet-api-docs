// <Snippet2>
let sentence = "The dog had a bone, a ball, and other toys."
let charsToTrim = [| ','; '.'; ' ' |]
let words = sentence.Split()
for word in words do
    printfn $"{word.TrimEnd charsToTrim}"

// The example displays the following output:
//       The
//       dog
//       had
//       a
//       bone
//       a
//       ball
//       and
//       other
//       toys
// </Snippet2>