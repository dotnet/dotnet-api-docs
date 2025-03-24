// <Snippet1>
open System
open System.IO

do
    let words = 
        [| "Tuesday"; "Salı"; "Вторник"; "Mardi" 
           "Τρίτη"; "Martes"; "יום שלישי" 
           "الثلاثاء"; "วันอังคาร" |]
    use sw = new StreamWriter(@".\output.txt")
        
    // Display array in unsorted order.
    for word in words do
        sw.WriteLine word

    sw.WriteLine()

    // Create parallel array of words by calling ToUpperInvariant.
    let upperWords = words |> Array.map (fun x -> x.ToUpperInvariant())
    
    // Sort the words array based on the order of upperWords.
    Array.Sort(upperWords, words, StringComparer.InvariantCulture)
    
    // Display the sorted array.
    for word in words do
        sw.WriteLine word
    sw.Close()      
// The example produces the following output:
//       Tuesday
//       Salı
//       Вторник
//       Mardi
//       Τρίτη
//       Martes
//       יום שלישי
//       الثلاثاء
//       วันอังคาร
//       
//       Mardi
//       Martes
//       Salı
//       Tuesday
//       Τρίτη
//       Вторник
//       יום שלישי
//       الثلاثاء
//       วันอังคาร
// </Snippet1>