module ProjectEuler.Problems.Common.PrimeNumbers

let primeFactors number =
  let rec loop factors number nextOddNumber =
    match number with
    | number when number <= 1L -> factors
    | number when number % 2L = 0
      -> loop (2L :: factors) (number / 2L) 3L
    | number when number % nextOddNumber = 0
      -> loop (nextOddNumber :: factors) (number / nextOddNumber) 3L
    | _ -> loop factors number (nextOddNumber + 2L)

  loop [] number 3L
