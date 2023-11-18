// Problem 20: Factorial Digit Sum.
module ProjectEuler.Solutions.Problem020

open ProjectEuler.Solutions.Common.Numbers
open ProjectEuler.Solutions.Common.Factorials

let solve () = factorial 100 |> sumAllDigits |> string
