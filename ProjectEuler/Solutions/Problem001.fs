// Problem 1: Multiples of 3 or 5
module ProjectEuler.Solutions.Problem001

let solve () =
    seq { 1..999 }
    |> Seq.where (fun num -> (num % 3 = 0) || (num % 5 = 0))
    |> Seq.sum
    |> int64
