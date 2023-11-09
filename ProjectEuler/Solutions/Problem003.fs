// Problem 3: Largest Prime Factor.
module ProjectEuler.Solutions.Problem003

open ProjectEuler.Solutions.Common.PrimeNumbers

let solve () = primeFactors 600851475143L |> List.max
