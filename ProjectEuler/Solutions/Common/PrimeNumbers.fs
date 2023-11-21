module ProjectEuler.Solutions.Common.PrimeNumbers

let primeFactors number =
    let rec loop factors number nextOddNumber =
        match number with
        | number when number <= 1L -> factors
        | number when number % 2L = 0 -> loop (2L :: factors) (number / 2L) 3L
        | number when number % nextOddNumber = 0 -> loop (nextOddNumber :: factors) (number / nextOddNumber) 3L
        | _ -> loop factors number (nextOddNumber + 2L)

    loop [] number 3L

// Solution based on Sieve of Eratosthenes.
let allPrimesBelow limit =
    let sqrtLimit = int (ceil (sqrt (float limit)))

    let rec loop acc i =
        match i <= sqrtLimit with
        | true ->
            let newValues = List.filter (fun x -> (x = i) || (x % i <> 0)) acc
            loop newValues (i + 1)
        | false -> 2 :: acc

    match limit with
    | limit when limit <= 2 -> []
    | _ -> loop [ 3..2 .. (limit - 1) ] 3

let isPrime number =
    let rec loop i =
        match i with
        | 0
        | 1 -> true
        | i when number % i = 0 -> false
        | i -> loop (i - 1)

    loop (number - 1)
