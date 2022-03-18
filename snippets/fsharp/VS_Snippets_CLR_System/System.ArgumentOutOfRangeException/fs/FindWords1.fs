module FindWords1

// <Snippet19>

let findWords (s: string) =
    let mutable start, end' = 0, 0
    let delimiters = [| ' '; '.'; ','; ';'; ':'; '('; ')' |]
    let words = ResizeArray<string>()
    while end' >= 0 do
        end' <- s.IndexOfAny(delimiters, start)
        if end' >= 0 then
            if end' - start > 0 then
                words.Add(s.Substring(start, end' - start))
            start <- end' + 1
        elif start < s.Length - 1 then
            words.Add(s.Substring start)
    words.ToArray()

let sentence = "This is a simple, short sentence."
printfn $"Words in '{sentence}':"
for word in findWords sentence do
    printfn $"   '{word}'"

// The example displays the following output:
//       Words in 'This is a simple, short sentence.':
//          'This'
//          'is'
//          'a'
//          'simple'
//          'short'
//          'sentence'
// </Snippet19>
