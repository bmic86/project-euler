// Problem 26: Reciprocal Cycles
module ProjectEuler.Solutions.Problem026

let private fractionCycleLenght number =
    let rec loop acc current =
        match current * 10 % number with
        | 0 -> 0
        | reminder ->
            match List.tryFindIndex (fun a -> a = reminder) acc with
            | Some index -> List.length acc - index
            | _ -> loop (acc @ [ reminder ]) reminder

    loop [] 1

let solve () =
    let result, _ =
        seq {
            for i = 1 to 999 do
                (i, (fractionCycleLenght i))
        }
        |> Seq.maxBy (fun (_, count) -> count)

    string result
