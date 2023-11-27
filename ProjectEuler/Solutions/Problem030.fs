// Problem 30: Digit Fifth Powers
module ProjectEuler.Solutions.Problem030

let private sumDigitsFifthPowers number =
    let rec loop sum current =
        match current with
        | 0 -> sum
        | _ ->
            let lastDigit = current % 10
            let power = pown lastDigit 5
            loop (sum + power) (current / 10)

    loop 0 number

let solve () =
    { 22..1_000_000 }
    |> Seq.where (fun number -> sumDigitsFifthPowers number = number)
    |> Seq.sum
    |> string
