// <snippet1>
open System

/// The following class represents simple functionality of the trapezoid.
type MathTrapezoidSample(longbase, shortbase, leftLeg, rightLeg) =
    member _.GetRightSmallBase() =
        (Math.Pow(rightLeg, 2.) - Math.Pow(leftLeg, 2.) + Math.Pow(longbase, 2.) + Math.Pow(shortbase, 2.) - 2. * shortbase * longbase) / (2. * (longbase - shortbase))

    member this.GetHeight() =
        let x = this.GetRightSmallBase()
        Math.Sqrt(Math.Pow(rightLeg, 2.) - Math.Pow(x, 2.))

    member this.GetSquare() =
        this.GetHeight() * longbase / 2.

    member this.GetLeftBaseRadianAngle() =
        let sinX = this.GetHeight() / leftLeg
        Math.Round(Math.Asin sinX,2)

    member this.GetRightBaseRadianAngle() =
        let x = this.GetRightSmallBase()
        let cosX = (Math.Pow(rightLeg, 2.) + Math.Pow(x, 2.) - Math.Pow(this.GetHeight(), 2.))/(2. * x * rightLeg)
        Math.Round(Math.Acos cosX, 2)

    member this.GetLeftBaseDegreeAngle() =
        let x = this.GetLeftBaseRadianAngle() * 180. / Math.PI
        Math.Round(x, 2)

    member this.GetRightBaseDegreeAngle() =
        let x = this.GetRightBaseRadianAngle() * 180. / Math.PI
        Math.Round(x, 2)

let trpz = MathTrapezoidSample(20., 10., 8., 6.)
printfn "The trapezoid's bases are 20.0 and 10.0, the trapezoid's legs are 8.0 and 6.0"
let h = trpz.GetHeight()
printfn $"Trapezoid height is: {h}"
let dxR = trpz.GetLeftBaseRadianAngle()
printfn $"Trapezoid left base angle is: {dxR} Radians"
let dyR = trpz.GetRightBaseRadianAngle()
printfn $"Trapezoid right base angle is: {dyR} Radians"
let dxD = trpz.GetLeftBaseDegreeAngle()
printfn $"Trapezoid left base angle is: {dxD} Degrees"
let dyD = trpz.GetRightBaseDegreeAngle()
printfn $"Trapezoid left base angle is: {dyD} Degrees"
// </snippet1>