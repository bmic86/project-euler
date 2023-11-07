// Problem 3: Largest Prime Factor
module ProjectEuler.Problems.Problem003

open ProjectEuler.Problems.Common.PrimeNumbers

let solve() =
  primeFactors 600851475143L
  |> List.max
  |> int32
