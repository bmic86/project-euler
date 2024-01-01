// Problem 35: Circular Primes
module ProjectEuler.Solutions.Problem035

open ProjectEuler.Solutions.Common.PrimeNumbers

let private countCircularPrimes limit =

    let rec loop count (primes: string Set) =

        match Set.isEmpty primes with
        | true -> count
        | false ->
            let currentPrime = primes.MinimumElement
            let allDigitsAreSame = Seq.length (Seq.distinct currentPrime) = 1

            match allDigitsAreSame with
            | true -> loop (count + 1) (Set.remove currentPrime primes) // Number with all the same digits is circular.
            | false ->
                let circulars =
                    seq {
                        for i = 0 to currentPrime.Length - 1 do
                            $"{currentPrime[i..]}{currentPrime[0 .. i - 1]}"
                    }

                let isCircularPrime =
                    circulars |> Seq.forall (fun circular -> Set.contains circular primes)

                match isCircularPrime with
                | true -> loop (count + currentPrime.Length) (Set.difference primes (circulars |> Set.ofSeq))
                | false -> loop count (Set.remove currentPrime primes)

    let allPrimes = allPrimesBelow limit |> List.map string |> Set.ofList
    loop 0 allPrimes

let solve () = countCircularPrimes 1_000_000 |> string
