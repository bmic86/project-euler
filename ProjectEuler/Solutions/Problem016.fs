// Problem 16: Power Digit Sum.
module ProjectEuler.Solutions.Problem016

let solve () =
    let result = pown (bigint 2) 1000 |> string
    result.ToCharArray() |> Array.sumBy (fun digit -> (int64 digit) - (int64 '0'))
