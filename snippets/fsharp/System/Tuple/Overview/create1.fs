module create1

open System

let create1Tuple () =
    // <Snippet1>
    let tuple1 = Tuple.Create 12
    printfn $"{tuple1.Item1}" // Displays 12
    // </Snippet1>  

let new1Tuple () =
    // <Snippet2>
    let tuple1 = Tuple<int> 12
    printfn $"{tuple1.Item1}" // Displays 12
    // </Snippet2>  

let create2Tuple () =
    // <Snippet3>
    let tuple2 = Tuple.Create("New York", 32.68)
    printfn $"{tuple2.Item1}: {tuple2.Item2}"
    // Displays New York: 32.68
    // </Snippet3>

let new2Tuple () =
    // <Snippet4>
    let tuple2 = Tuple<string, double>("New York", 32.68)
    printfn $"{tuple2.Item1}: {tuple2.Item2}"
    // Displays New York: 32.68
    // </Snippet4>

let create3Tuple () =
    // <Snippet5>
    let tuple3 = Tuple.Create("New York", 32.68, 51.87)
    printfn $"{tuple3.Item1}: lo {tuple3.Item2}, hi {tuple3.Item3}"
    // Displays New York: lo 32.68, hi 51.87
    // </Snippet5>

let new3Tuple () =
    // <Snippet6>
    let tuple3 =
        Tuple<string, double, double>("New York", 32.68, 51.87)

    printfn $"{tuple3.Item1}: lo {tuple3.Item2}, hi {tuple3.Item3}"
    // Displays New York: lo 32.68, hi 51.87
    // </Snippet6>

let create4Tuple () =
    // <Snippet7>
    let tuple4 =
        Tuple.Create("New York", 32.68, 51.87, 76.3)

    printfn $"{tuple4.Item1}: Hi {tuple4.Item4}, Lo {tuple4.Item2}, Ave {tuple4.Item3}"
    // Displays New York: Hi 76.3, Lo 32.68, Ave 51.87
    // </Snippet7>

let new4Tuple () =
    // <Snippet8>
    let tuple4 =
        Tuple<string, double, double, double>("New York", 32.68, 51.87, 76.3)

    printfn $"{tuple4.Item1}: Hi {tuple4.Item4}, Lo {tuple4.Item2}, Ave {tuple4.Item3}"
    // Displays New York: Hi 76.3, Lo 32.68, Ave 51.87
    // </Snippet8>

let create5Tuple () =
    // <Snippet9>
    let tuple5 =
        Tuple.Create("New York", 1990, 7322564, 2000, 8008278)

    printfn $"{tuple5.Item1}: {tuple5.Item3:N0} in {tuple5.Item2}, {tuple5.Item5:N0} in {tuple5.Item4}"
    // Displays New York: 7,322,564 in 1990, 8,008,278 in 2000
    // </Snippet9>

let new5Tuple () =
    // <Snippet10>
    let tuple5 =
        Tuple<string, int, int, int, int>("New York", 1990, 7322564, 2000, 8008278)

    printfn $"{tuple5.Item1}: {tuple5.Item3:N0} in {tuple5.Item2}, {tuple5.Item5:N0} in {tuple5.Item4}"
    // Displays New York: 7,322,564 in 1990, 8,008,278 in 2000
    // </Snippet10>

let create6Tuple () =
    // <Snippet11>
    let tuple6 =
        Tuple.Create("Jane", 90, 87, 93, 67, 100)

    printfn
        $"Test scores for {tuple6.Item1}: {tuple6.Item2}, {tuple6.Item3}, {tuple6.Item4}, {tuple6.Item5}, {tuple6.Item6}"
    // Displays Test scores for Jane: 90, 87, 93, 67, 100
    // </Snippet11>

let new6Tuple () =
    // <Snippet12>
    let tuple6 =
        Tuple<string, int, int, int, int, int>("Jane", 90, 87, 93, 67, 100)

    printfn
        $"Test scores for {tuple6.Item1}: {tuple6.Item2}, {tuple6.Item3}, {tuple6.Item4}, {tuple6.Item5}, {tuple6.Item6}"
    // Displays Test scores for Jane: 90, 87, 93, 67, 100
    // </Snippet12>

let create7Tuple () =
    // <Snippet13>
    let tuple7 =
        Tuple.Create("Jane", 90, 87, 93, 67, 100, 92)

    printfn
        $"Test scores for {tuple7.Item1}: {tuple7.Item2}, {tuple7.Item3}, {tuple7.Item4}, {tuple7.Item5}, {tuple7.Item6}, {tuple7.Item7}"
    // Displays Test scores for Jane: 90, 87, 93, 67, 100, 92
    // </Snippet13>

let new7Tuple () =
    // <Snippet14>
    let tuple7 =
        Tuple<string, int, int, int, int, int, int>("Jane", 90, 87, 93, 67, 100, 92)

    printfn
        $"Test scores for {tuple7.Item1}: {tuple7.Item2}, {tuple7.Item3}, {tuple7.Item4}, {tuple7.Item5}, {tuple7.Item6}, {tuple7.Item7}"
    // Displays Test scores for Jane: 90, 87, 93, 67, 100, 92
    // </Snippet14>

create1Tuple ()
new1Tuple ()
create2Tuple ()
new2Tuple ()
create3Tuple ()
new3Tuple ()
create4Tuple ()
new4Tuple ()
create5Tuple ()
new5Tuple ()
create6Tuple ()
new6Tuple ()
create7Tuple ()
new7Tuple ()
