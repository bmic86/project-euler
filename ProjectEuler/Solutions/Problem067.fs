// Problem 67: Maximum Path Sum II.
module ProjectEuler.Solutions.Problem067

open ProjectEuler.Solutions.Common.FileInput
open ProjectEuler.Solutions.Common.MaximumPathSum

let solve () =
    readAllLinesAsIntegers ("Problem067.txt") |> maximumPathSum |> int64
