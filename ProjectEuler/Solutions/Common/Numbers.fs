module ProjectEuler.Solutions.Common.Numbers

let charDigitToNumber (digit: char) = (int64 digit) - (int64 '0')

let sumAllDigits (number: bigint) =
    let str = string number
    str.ToCharArray() |> Array.sumBy charDigitToNumber

let sumDivisors number =
    let rec loop sum current =
        match current, number % current = 0 with
        | 1, _ -> sum
        | _, true -> loop (sum + current) (current - 1)
        | _, false -> loop sum (current - 1)

    match (number / 2) with
    | 0 -> 0
    | startNumber -> loop 1 startNumber
