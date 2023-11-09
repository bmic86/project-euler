// Problem 7: 10001st Prime
module ProjectEuler.Solutions.Problem007

let private isPrime number =
    let rec loop i =
        match i with
        | 0
        | 1 -> true
        | i when number % i = 0 -> false
        | i -> loop (i - 1)

    loop (number - 1)

let private primeByIndex index =
    let rec loop prime i currentNumber =
        match i with
        | _ when i = index -> prime
        | _ ->
            match (isPrime currentNumber) with
            | true -> loop currentNumber (i + 1) (currentNumber + 1)
            | false -> loop prime i (currentNumber + 1)

    loop 0 -1 0

let solve () = primeByIndex 10001 |> int64
