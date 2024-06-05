// <Snippet1>
let today1 = 
    System.DateTime System.DateTime.Today.Ticks

let today2 =
    System.DateTime System.DateTime.Today.Ticks

let tomorrow =
    System.DateTime.Today.AddDays(1).Ticks
    |> System.DateTime 

// todayEqualsToday gets true.
let todayEqualsToday = System.DateTime.Equals(today1, today2)

// todayEqualsTomorrow gets false.
let todayEqualsTomorrow = System.DateTime.Equals(today1, tomorrow)
// </Snippet1>

printfn $"{todayEqualsToday}"
printfn $"{todayEqualsTomorrow}"