// Problem 6: Sum Square Difference.
module ProjectEuler.Solutions.Problem006

let private squareOfSum numbers =
    let sum = Seq.sum numbers
    sum * sum

let private sumOfSquares numbers =
    numbers |> Seq.sumBy (fun num -> num * num)

let solve () =
    let numbers = seq { 1..100 }

    (squareOfSum numbers) - (sumOfSquares numbers) |> string
