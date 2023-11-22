// Problem 29: Distinct Powers
module ProjectEuler.Solutions.Problem029

let private distinctPowers n =
    let rec loop powers (a: int) (b: int) =
        let newPowers = bigint.Pow((bigint a), b) :: powers

        match a = n, b = n with
        | true, true -> newPowers
        | true, false -> loop newPowers 2 (b + 1)
        | _ -> loop newPowers (a + 1) b

    List.distinct (loop [] 2 2)

let solve () =
    distinctPowers 100 |> List.length |> string
