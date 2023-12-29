// Problem 33: Digit Cancelling Fractions
module ProjectEuler.Solutions.Problem033

open ProjectEuler.Solutions.Common.Numbers

let private isCuriousFraction (numerator, denominator) =

    match (string numerator).ToCharArray(), (string denominator).ToCharArray() with
    | [| n1; n2 |], [| d1; d2 |] when n2 = d1 && n1 <> d2 ->

        let fract1 = (double numerator) / (double denominator)
        let fract2 = (double (charDigitToNumber n1)) / (double (charDigitToNumber d2))

        fract1 = fract2

    | _ -> false

let private fractionsProduct fractions =
    Seq.fold (fun (accNum, accDen) (num, den) -> (accNum * num, accDen * den)) (1, 1) fractions

let private simplifyDenominator (numerator, denominator) = denominator / numerator

let solve () =

    let allFractions =
        seq {
            for num = 10 to 98 do
                for den = num + 1 to 99 do
                    (num, den)
        }

    allFractions
    |> Seq.filter isCuriousFraction
    |> fractionsProduct
    |> simplifyDenominator
    |> string
