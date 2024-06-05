open System.IO

// <Snippet1>
for line in File.ReadLines @"d:\data\episodes.txt" do
    if line.Contains "episode" && line.Contains "2006" then
        printfn $"{line}"
// </Snippet1>
