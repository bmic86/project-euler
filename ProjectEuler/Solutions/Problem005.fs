// Problem 5: Smallest Multiple.
module ProjectEuler.Solutions.Problem005

open ProjectEuler.Solutions.Common.PrimeNumbers

let private smallestMultiple maxNumber =
    let exponents = Array.zeroCreate maxNumber

    for number = 2 to maxNumber do
        let factors = (primeFactors number) |> List.countBy (fun num -> num)

        // Storing max count for each prime factor number in exponents table.
        for (value, count) in factors do
            let index = int (value - 1L)

            exponents[index] <-
                match exponents[index] with
                | exp when exp < count -> count
                | exp -> exp

    // Calculating final result.
    let mutable result = 1

    for number = 2 to maxNumber do
        let index = number - 1

        result <-
            match exponents[index] with
            | 0 -> result
            | _ -> result * (pown number exponents[index])

    result

let solve () = smallestMultiple 20 |> string
