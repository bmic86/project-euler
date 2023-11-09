// Problem 8: Largest Product in a Series.
module ProjectEuler.Solutions.Problem008

open System.IO

let private productsInSeries numOfDigits (series: string) =
    let calculateProduct firstIndex lastIndex =
        series[firstIndex..lastIndex].ToCharArray()
        |> Array.fold (fun acc digit -> acc * ((int64 digit) - (int64 '0'))) 1L

    let rec loop products firstIndex =
        match firstIndex + numOfDigits - 1 with
        | lastIndex when lastIndex >= series.Length -> products
        | lastIndex ->
            let product = calculateProduct firstIndex lastIndex
            loop (product :: products) (firstIndex + 1)

    loop [] 0

let solve () =
    File.ReadAllText("./Data/Problem008.txt") |> productsInSeries 13 |> List.max
