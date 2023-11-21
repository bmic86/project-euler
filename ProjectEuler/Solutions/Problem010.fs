// Problem 10: Summation of Primes.
module ProjectEuler.Solutions.Problem010

open ProjectEuler.Solutions.Common.PrimeNumbers

let solve () =
    allPrimesBelow 2_000_000 |> List.sumBy int64 |> string
