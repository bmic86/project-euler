// Problem 34: Digit Factorials
module ProjectEuler.Solutions.Problem034

open ProjectEuler.Solutions.Common.Factorials
open ProjectEuler.Solutions.Common.Numbers

let private factorialDigitsSum digitsLimit =
    let digitFactorials = { 0..9 } |> Seq.map (factorial >> int) |> Array.ofSeq

    let rec loop sum number =
        let digits = string number

        match digits.Length with
        | digitsCount when digitsCount >= digitsLimit -> sum
        | _ ->
            let factorialSum =
                Seq.fold (fun acc c -> acc + digitFactorials[(charDigitToInt32 c)]) 0 digits

            match factorialSum = number with
            | true -> loop (sum + factorialSum) (number + 1)
            | false -> loop sum (number + 1)

    match digitsLimit < 2 with
    | false -> loop 0 10
    | true -> 0

let solve () = factorialDigitsSum 6 |> string
