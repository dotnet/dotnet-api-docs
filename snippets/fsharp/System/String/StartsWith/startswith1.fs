module startswith1.fs

// <Snippet1>
open System

let strings =
    array2D 
      [ [ "ABCdef"; "abc" ]
        [ "ABCdef"; "abc" ]
        [ "œil"; "oe" ]
        [ "læring}"; "lae" ] ]

for ctr1 = strings.GetLowerBound 0 to strings.GetUpperBound 0 do
    for cmpName in Enum.GetNames typeof<StringComparison> do
        let strCmp = Enum.Parse(typeof<StringComparison>, cmpName) :?> StringComparison
        let instance = strings[ctr1, 0]
        let value = strings[ctr1, 1]
        printfn $"{instance} starts with {value}: {instance.StartsWith(value, strCmp)} ({strCmp} comparison)"
    printfn ""
// The example displays the following output:
//       ABCdef starts with abc: False (CurrentCulture comparison)
//       ABCdef starts with abc: True (CurrentCultureIgnoreCase comparison)
//       ABCdef starts with abc: False (InvariantCulture comparison)
//       ABCdef starts with abc: True (InvariantCultureIgnoreCase comparison)
//       ABCdef starts with abc: False (Ordinal comparison)
//       ABCdef starts with abc: True (OrdinalIgnoreCase comparison)
//
//       ABCdef starts with abc: False (CurrentCulture comparison)
//       ABCdef starts with abc: True (CurrentCultureIgnoreCase comparison)
//       ABCdef starts with abc: False (InvariantCulture comparison)
//       ABCdef starts with abc: True (InvariantCultureIgnoreCase comparison)
//       ABCdef starts with abc: False (Ordinal comparison)
//       ABCdef starts with abc: True (OrdinalIgnoreCase comparison)
//
//       œil starts with oe: True (CurrentCulture comparison)
//       œil starts with oe: True (CurrentCultureIgnoreCase comparison)
//       œil starts with oe: True (InvariantCulture comparison)
//       œil starts with oe: True (InvariantCultureIgnoreCase comparison)
//       œil starts with oe: False (Ordinal comparison)
//       œil starts with oe: False (OrdinalIgnoreCase comparison)
//
//       læring} starts with lae: True (CurrentCulture comparison)
//       læring} starts with lae: True (CurrentCultureIgnoreCase comparison)
//       læring} starts with lae: True (InvariantCulture comparison)
//       læring} starts with lae: True (InvariantCultureIgnoreCase comparison)
//       læring} starts with lae: False (Ordinal comparison)
//       læring} starts with lae: False (OrdinalIgnoreCase comparison)
// </Snippet1>
