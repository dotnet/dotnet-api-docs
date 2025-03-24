// <snippet2>
open System.IO

let di = DirectoryInfo @"C:\Users\tomfitz\Documents\ExampleDir"
printfn "No search pattern returns:"
for fi in di.GetFiles() do
    printfn $"{fi.Name}"

printfn "\nSearch pattern *2* returns:"
for fi in di.GetFiles "*2*" do
    printfn $"{fi.Name}"

printfn "\nSearch pattern test?.txt returns:"
for fi in di.GetFiles "test?.txt" do
    printfn $"{fi.Name}"

printfn "\nSearch pattern AllDirectories returns:"
for fi in di.GetFiles("*", SearchOption.AllDirectories) do
    printfn $"{fi.Name}"
(*
This code produces output similar to the following:

No search pattern returns:
log1.txt
log2.txt
test1.txt
test2.txt
test3.txt

Search pattern *2* returns:
log2.txt
test2.txt

Search pattern test?.txt returns:
test1.txt
test2.txt
test3.txt

Search pattern AllDirectories returns:
log1.txt
log2.txt
test1.txt
test2.txt
test3.txt
SubFile.txt
Press any key to continue . . .
*)
// </snippet2>