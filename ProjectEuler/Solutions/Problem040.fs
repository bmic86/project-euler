// Problem 40: Champernowne's Constant
module ProjectEuler.Solutions.Problem040

open ProjectEuler.Solutions.Common.Numbers

let private champernowneFractionalDigit n =

    let rec loop i value multipler digitsCount =
        let offset = min (multipler * digitsCount) (n - i)
        let value = value + offset / digitsCount
        let nextPosition = i + offset

        match nextPosition < n with
        | true -> loop nextPosition value (multipler * 10) (digitsCount + 1)
        | false ->
            let digits = string value
            charDigitToInt32 digits[offset % digitsCount]

    match n > 0, n < 10 with
    | true, true -> n
    | true, false -> loop 10 10 90 2
    | _ -> 0

let solve () =
    { 0..6 }
    |> Seq.fold (fun acc power -> acc * champernowneFractionalDigit (pown 10 power)) 1
    |> string
