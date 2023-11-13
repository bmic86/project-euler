// Problem 17: Number Letter Counts.
module ProjectEuler.Solutions.Problem017

let private digitToText number =
    match number with
    | 1 -> "One"
    | 2 -> "Two"
    | 3 -> "Three"
    | 4 -> "Four"
    | 5 -> "Five"
    | 6 -> "Six"
    | 7 -> "Seven"
    | 8 -> "Eight"
    | 9 -> "Nine"
    | _ -> ""

let private teenDigitToText number =
    match number with
    | 0 -> "Ten"
    | 1 -> "Eleven"
    | 2 -> "Twelve"
    | 3 -> "Thirteen"
    | 4 -> "Fourteen"
    | 5 -> "Fifteen"
    | 6 -> "Sixteen"
    | 7 -> "Seventeen"
    | 8 -> "Eighteen"
    | 9 -> "Nineteen"
    | _ -> ""

let private secondDigitToText number =
    match number with
    | 2 -> "Twenty"
    | 3 -> "Thirty"
    | 4 -> "Forty"
    | 5 -> "Fifty"
    | 6 -> "Sixty"
    | 7 -> "Seventy"
    | 8 -> "Eighty"
    | 9 -> "Ninety"
    | _ -> ""

let private splitNumberToDigits number =
    let rec loop acc currentNumber =
        match currentNumber with
        | 0 -> acc
        | n -> loop ((n % 10) :: acc) (n / 10)

    loop [] number

let private numberToText number =
    let digits = splitNumberToDigits number

    match digits with
    | [ a ] -> digitToText a
    | [ 1; b ] -> $"{teenDigitToText b}"
    | [ a; b ] -> $"{secondDigitToText a}{digitToText b}"
    | [ a; 0; 0 ] -> $"{digitToText a}Hundred"
    | [ a; 0; c ] -> $"{digitToText a}HundredAnd{digitToText c}"
    | [ a; 1; c ] -> $"{digitToText a}HundredAnd{teenDigitToText c}"
    | [ a; b; c ] -> $"{digitToText a}HundredAnd{secondDigitToText b}{digitToText c}"
    | [ 1; 0; 0; 0 ] -> "OneThousand"
    | _ -> ""

let solve () =
    { 1..1000 } |> Seq.sumBy (fun i -> String.length (numberToText i)) |> int64
