// Problem 36: Double-base Palindromes
module ProjectEuler.Solutions.Problem036

open ProjectEuler.Solutions.Common.Palindromes

let private doubleBasePalindrom number =
    match isPalindrom (string number) && isPalindrom (sprintf "%B" number) with
    | true -> number
    | false -> 0

let solve () =
    { 1..999_999 } |> Seq.sumBy doubleBasePalindrom |> string
