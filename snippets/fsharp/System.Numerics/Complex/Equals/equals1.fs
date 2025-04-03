module equals1

open System.Numerics

type Complex2 =
    val Real: float
    val Imaginary: float

    member this.Equals(value: Complex2) =
        // <Snippet1>
        this.Real.Equals value && this.Imaginary.Equals value
    // </Snippet1>

    override this.Equals(value: obj) =
        // <Snippet2>
        this.Real.Equals((value :?> Complex).Real)
        && this.Imaginary.Equals((value :?> Complex).Imaginary)
    // </Snippet2>

    member this.opEquality(value: Complex2) =
        // <Snippet3>
        this.Real = value.Real && this.Imaginary = value.Imaginary
// </Snippet3>
