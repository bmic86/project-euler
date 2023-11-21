// Problem 28: Number Spiral Diagonals
module ProjectEuler.Solutions.Problem028

let private spiralSum size =

    let rec loop sum current steps edge =
        let newSum = sum + current
        let isLastRectangle = steps + 1 >= size

        match edge, isLastRectangle with
        | 3, true -> newSum
        | 3, _ ->
            let newSteps = steps + 2
            loop newSum (current + newSteps) newSteps 0
        | _ -> loop newSum (current + steps) steps (edge + 1)

    loop 1 3 2 0

let solve () = spiralSum 1001 |> string
