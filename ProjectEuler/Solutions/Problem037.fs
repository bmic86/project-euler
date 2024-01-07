// Problem 37: Truncatable Primes
module ProjectEuler.Solutions.Problem037

open ProjectEuler.Solutions.Common.PrimeNumbers

let private allTruncatables (input: string) =
    seq {
        input

        for i = 1 to input.Length - 1 do
            input[i..]

        for i = input.Length - 2 downto 0 do
            input[..i]
    }

let private containsAllTruncatables value set =
    allTruncatables value |> Seq.forall (fun trunc -> Set.contains trunc set)

let findTruncatablePrimesSum valueLimit expectedCount =
    let primes = allPrimesBelow valueLimit
    let lookupSet = primes |> List.map string |> Set.ofList

    let rec loop sum count values =
        match values, expectedCount = count with
        | [], false -> -1 // Number of expected truncatable primes was not found in a range.
        | _, true -> sum
        | currentValue :: rest, _ ->
            let current = string currentValue

            match (current.Length > 1) && (containsAllTruncatables current lookupSet) with
            | true -> loop (sum + currentValue) (count + 1) rest
            | false -> loop sum count rest

    loop 0 0 primes

let solve () =
    findTruncatablePrimesSum 1_000_000 11 |> string
