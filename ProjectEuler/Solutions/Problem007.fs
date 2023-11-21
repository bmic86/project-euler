// Problem 7: 10001st Prime.
module ProjectEuler.Solutions.Problem007

open ProjectEuler.Solutions.Common.PrimeNumbers

let private primeByIndex index =
    let rec loop prime i currentNumber =
        match i with
        | _ when i = index -> prime
        | _ ->
            match (isPrime currentNumber) with
            | true -> loop currentNumber (i + 1) (currentNumber + 1)
            | false -> loop prime i (currentNumber + 1)

    loop 0 -1 0

let solve () = primeByIndex 10001 |> string
