module cfromchar

//<Snippet1>
// Define a list of Char values.
let values = [ '\000'; ' '; '*'; 'A'; 'a'; '{'; 'Æ' ]

// Convert each Char value to a Decimal.
for value in values do
    let decValue: decimal = value
    printfn $"'{value}' ({value.GetType().Name}) --> {decValue} ({decValue.GetType().Name})"

// The example displays the following output:
//       ' ' (Char) --> 0 (Decimal)
//       ' ' (Char) --> 32 (Decimal)
//       '*' (Char) --> 42 (Decimal)
//       'A' (Char) --> 65 (Decimal)
//       'a' (Char) --> 97 (Decimal)
//       '{' (Char) --> 123 (Decimal)
//       'Æ' (Char) --> 198 (Decimal)
//</Snippet1> 