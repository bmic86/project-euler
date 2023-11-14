// Problem 18: Maximum Path Sum I.
module ProjectEuler.Solutions.Problem018

open ProjectEuler.Solutions.Common.FileInput
open ProjectEuler.Solutions.Common.MaximumPathSum

let solve () =
    readAllLinesAsIntegers ("Problem018.txt") |> maximumPathSum |> int64
