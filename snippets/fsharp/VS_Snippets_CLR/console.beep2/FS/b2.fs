//<snippet1>
// This example demonstrates the Console.Beep(Int32, Int32) method
open System
open System.Threading

// Define the frequencies of notes in an octave, as well as
// silence (rest).
type Tone =
    | REST    = 0
    | GbelowC = 196
    | A       = 220
    | Asharp  = 233
    | B       = 247
    | C       = 262
    | Csharp  = 277
    | D       = 294
    | Dsharp  = 311
    | E       = 330
    | F       = 349
    | Fsharp  = 370
    | G       = 392
    | Gsharp  = 415

// Define the duration of a note in units of milliseconds.
type Duration =
    | WHOLE     = 1600
    | HALF      = 800
    | QUARTER   = 400
    | EIGHTH    = 200
    | SIXTEENTH = 100

// Define a note as a frequency (tone) and the amount of
// time (duration) the note plays.
[<Struct>]
type Note =
    { Tone: Tone
      Duration: Duration }

// Play the notes in a song.
let play tune =
    for n in tune do
        if n.Tone = Tone.REST then
            Thread.Sleep(int n.Duration)
        else
            Console.Beep(int n.Tone, int n.Duration)

// Declare the first few notes of the song, "Mary Had A Little Lamb".
let mary =
    [ { Tone = Tone.B; Duration = Duration.QUARTER }
      { Tone = Tone.A; Duration = Duration.QUARTER }
      { Tone = Tone.GbelowC; Duration = Duration.QUARTER }
      { Tone = Tone.A; Duration = Duration.QUARTER }
      { Tone = Tone.B; Duration = Duration.QUARTER }
      { Tone = Tone.B; Duration = Duration.QUARTER }
      { Tone = Tone.B; Duration = Duration.HALF }
      { Tone = Tone.A; Duration = Duration.QUARTER }
      { Tone = Tone.A; Duration = Duration.QUARTER }
      { Tone = Tone.A; Duration = Duration.HALF }
      { Tone = Tone.B; Duration = Duration.QUARTER }
      { Tone = Tone.D; Duration = Duration.QUARTER }
      { Tone = Tone.D; Duration = Duration.HALF } ]

// Play the song
play mary

// This example plays the first few notes of "Mary Had A Little Lamb"
// through the console speaker.
//</snippet1>