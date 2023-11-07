// Problem 5: Smallest Multiple
module ProjectEuler.Problems.Problem005

open ProjectEuler.Problems.Common.PrimeNumbers

let private smallestMultiple maxNumber =
  let exponents = Array.zeroCreate maxNumber

  for number = 2 to maxNumber do
    let factors =
      (primeFactors number)
      |> List.countBy (fun num -> num)

    for (value, count) in factors do
      let index = int (value - 1L)
      exponents[index] <- match exponents[index] with
                          | exp when exp < count -> count
                          | exp -> exp

  let mutable result = 1 
  for number = 2 to maxNumber do
    let index = number - 1
    result <- match exponents[index] with
              | 0 -> result
              | _ -> result * (pown number exponents[index])

  result

let solve () =
  smallestMultiple 20