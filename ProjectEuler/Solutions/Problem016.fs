// Problem 16: Power Digit Sum.
module ProjectEuler.Solutions.Problem016

open ProjectEuler.Solutions.Common.Numbers

let solve () =
    pown (bigint 2) 1000 |> sumAllDigits |> string
