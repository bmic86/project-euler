// Problem 12: Highly Divisible Triangular Number.
module ProjectEuler.Solutions.Problem012

open ProjectEuler.Solutions.Common

let private countDivisors number =
    PrimeNumbers.primeFactors number
    |> List.countBy (fun num -> num)
    |> List.fold (fun acc (_, count) -> acc * (count + 1)) 1

let private triangleNumberWithDivisorsOver limit =
    let rec loop previousNumber (i: int) =
        let currentNumber = previousNumber + i

        match countDivisors currentNumber with
        | count when count > limit -> currentNumber
        | _ -> loop currentNumber (i + 1)

    loop 0 1

let solve () =
    triangleNumberWithDivisorsOver 500 |> int64
