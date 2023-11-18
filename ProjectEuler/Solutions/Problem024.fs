// Problem 24: Lexicographic Permutations
module ProjectEuler.Solutions.Problem024

let private toString (data: int list) =
    List.fold (fun acc item -> acc + string item) "" data

let private permutation n data =
    let rec loopFactoradic acc i current =
        match i <= List.length data with
        | false -> acc
        | true -> loopFactoradic ((current % i) :: acc) (i + 1) (current / i)

    let rec loopPermutation acc data factoradic =
        match factoradic with
        | [] -> acc
        | first :: rest ->
            let newData = List.removeAt first data
            loopPermutation (acc @ [ data[first] ]) newData rest

    let factoradic = loopFactoradic [] 1 (n - 1)
    loopPermutation [] data factoradic


let solve () =
    [ 0..9 ] |> permutation 1_000_000 |> toString
