// Problem 27: Quadratic Primes
module ProjectEuler.Solutions.Problem027

open ProjectEuler.Solutions.Common.PrimeNumbers

let private quadrartic n a b = n * n + a * n + b

let private consecutivePrimesCount a b =
    let rec loop n =
        match quadrartic n a b with
        | result when result < 0 -> n
        | result ->
            match isPrime result with
            | false -> n
            | true -> loop (n + 1)

    loop 1

let private maxByPrimesCount values =
    List.maxBy (fun (_, _, primesCount) -> primesCount) values

let private countConsecutivePrimes a bValues =
    List.map (fun b -> (a, b, consecutivePrimesCount a b)) bValues

let solve () =
    let aValues = { -999 .. 999 }

    // Value of an expression: n^2 + a*n + b, for n = 0 is equal to b.
    // So starting b values, have to be prime numbers.
    let bValues = allPrimesBelow 1001

    let (a, b, _) =
        aValues
        |> Seq.fold (fun acc a -> (countConsecutivePrimes a bValues |> maxByPrimesCount) :: acc) []
        |> maxByPrimesCount

    string (a * b)
