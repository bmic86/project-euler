// Problem 10: Summation of Primes.
// Solution based on Sieve of Eratosthenes.
module ProjectEuler.Solutions.Problem010

let private allPrimes limit =
    let sqrtLimit = int (ceil (sqrt (float limit)))

    let rec loop (acc: int64 list) (i: int64) =
        match i <= sqrtLimit with
        | true ->
            let newValues = List.filter (fun x -> (x = i) || (x % i <> 0)) acc
            loop newValues (i + 1L)
        | false -> 2L :: acc

    match limit with
    | limit when limit <= 2 -> []
    | _ -> loop [ 3L .. 2L .. int64 (limit - 1) ] 3

let solve () = allPrimes 2_000_000 |> List.sum
