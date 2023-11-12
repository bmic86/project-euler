// Problem 13: Large Sum.
module ProjectEuler.Solutions.Problem013

open System.IO

let private sliceTo i (str: string) = str[0..i]

let private loadData () =
    File.ReadAllLines("./Data/Problem013.txt") |> Array.map bigint.Parse

let solve () =
    loadData () |> Array.sum |> string |> sliceTo 9 |> int64
