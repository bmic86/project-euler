module ProjectEuler.Solutions.Common.Numbers

let charDigitToNumber (digit: char) = (int64 digit) - (int64 '0')

let sumAllDigits (number: bigint) =
    let str = string number
    str.ToCharArray() |> Array.sumBy charDigitToNumber
