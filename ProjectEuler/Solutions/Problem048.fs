// Problem 48: Self Powers
module ProjectEuler.Solutions.Problem048

let private selfPower (n: int) = (bigint n) ** n

let solve () =
    let sum = { 1..1000 } |> Seq.map selfPower |> Seq.sum |> string
    sum[sum.Length - 10 ..]
