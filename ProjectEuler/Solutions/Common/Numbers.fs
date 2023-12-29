module ProjectEuler.Solutions.Common.Numbers

let charDigitToInt32 (digit: char) = (int32 digit) - (int32 '0')

let charDigitToInt64 (digit: char) = (int64 digit) - (int64 '0')

let sumAllDigits (number: bigint) =
    let str = string number
    str.ToCharArray() |> Array.sumBy charDigitToInt64

let sumDivisors number =
    let rec loop sum current =
        match current, number % current = 0 with
        | 1, _ -> sum
        | _, true -> loop (sum + current) (current - 1)
        | _, false -> loop sum (current - 1)

    match (number / 2) with
    | 0 -> 0
    | startNumber -> loop 1 startNumber
