// Problem 22: Names Scores
module ProjectEuler.Solutions.Problem022

open System
open System.IO

let private loadNamesFromFile () =
    let content = File.ReadAllText("./Data/Problem022.txt")
    content.Split([| ','; '"' |], StringSplitOptions.RemoveEmptyEntries)

let private nameScore index (name: string) =
    let chars = name.ToCharArray()
    let sum = Array.sumBy (fun c -> int c - int '@') chars // '@' is the first char before 'A'.

    (index + 1) * sum

let private allNameScores names = Array.mapi nameScore names

let solve () =
    loadNamesFromFile () |> Array.sort |> allNameScores |> Array.sum |> int64
