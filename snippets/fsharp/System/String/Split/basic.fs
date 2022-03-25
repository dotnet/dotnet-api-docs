module basic
//<snippet1>
let s = "Today\tI'm going to school"
let subs = s.Split(' ', '\t')

for sub in subs do
    printfn $"Substring: {sub}"

// This example produces the following output:
//
// Substring: Today
// Substring: I'm
// Substring: going
// Substring: to
// Substring: school
//</snippet1>