// <Snippet1>
open System

let computeStatistics (players: Tuple<string, int, int, int, int>[]) = 
    [| for player in players do
        // Create result object containing player name and statistics.
        Tuple.Create(player.Item1,  
                     double player.Item3 / double player.Item2,
                     double player.Item4 / double player.Item2,
                     double player.Item4 / double player.Item3, 
                     double player.Item5 / double player.Item3) |]


// Organization of runningBacks 5-tuple:
//    Component 1: Player name
//    Component 2: Number of games played
//    Component 3: Number of attempts (carries)
//    Component 4: Number of yards gained 
//    Component 5: Number of touchdowns   
let runningBacks =
    [| Tuple.Create("Payton, Walter", 190, 3838, 16726, 110)
       Tuple.Create("Sanders, Barry", 153, 3062, 15269, 99)
       Tuple.Create("Brown, Jim", 118, 2359, 12312, 106)
       Tuple.Create("Dickerson, Eric", 144, 2996, 13259, 90)
       Tuple.Create("Faulk, Marshall", 176, 2836, 12279, 100) |]
// Calculate statistics.
// Organization of runningStats 5-tuple:
//    Component 1: Player name
//    Component 2: Number of attempts per game
//    Component 3: Number of yards per game
//    Component 4: Number of yards per attempt 
//    Component 5: Number of touchdowns per attempt   
let runningStats = computeStatistics runningBacks

// Display the result.          
printfn "%-16s %5s %6s %7s %7s %7s %7s %5s %7s\n" "Name" "Games" "Att" "Att/Gm" "Yards" "Yds/Gm" "Yds/Att" "TD" "TD/Att"
for i = 0 to runningBacks.Length - 1 do
    printfn $"{runningBacks[i].Item1,-16} {runningBacks[i].Item2,5} {runningBacks[i].Item3,6:N0} {runningBacks[i].Item2,7:N1} {runningBacks[i].Item4,7:N0} {runningBacks[i].Item3,7:N1} {runningBacks[i].Item4,7:N2} {runningBacks[i].Item5,5} {runningBacks[i].Item5,7:N3}\n" 

// The example displays the following output:
//    Name             Games    Att  Att/Gm   Yards  Yds/Gm Yds/Att    TD  TD/Att
//    
//    Payton, Walter     190  3,838    20.2  16,726    88.0    4.36   110   0.029
//    
//    Sanders, Barry     153  3,062    20.0  15,269    99.8    4.99    99   0.032
//    
//    Brown, Jim         118  2,359    20.0  12,312   104.3    5.22   106   0.045
//    
//    Dickerson, Eric    144  2,996    20.8  13,259    92.1    4.43    90   0.030
//    
//    Faulk, Marshall    176  2,836    16.1  12,279    69.8    4.33   100   0.035
// </Snippet1>