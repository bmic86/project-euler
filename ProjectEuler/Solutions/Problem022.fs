// Problem 22: Names Scores
module ProjectEuler.Solutions.Problem022

open ProjectEuler.Solutions.Common.FileInput
open ProjectEuler.Solutions.Common.Text

let private nameScore index (name: string) =
    let sum = wordScore name
    (index + 1) * sum

let private allNameScores names = Array.mapi nameScore names

let solve () =
    readAllWords "Problem022.txt"
    |> Array.sort
    |> allNameScores
    |> Array.sum
    |> string
