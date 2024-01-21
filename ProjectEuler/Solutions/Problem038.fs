// Problem 38: Pandigital Multiples
module ProjectEuler.Solutions.Problem038

open ProjectEuler.Solutions.Common.Numbers

type private Limit = { Range: int seq; N: int }

// Search in ranges, where all concatenated products has exactly 9 digits.
let private allLimits =
    [ { Range = { 5..9 }; N = 5 }
      { Range = { 25..33 }; N = 4 }
      { Range = { 123..333 }; N = 3 }
      { Range = { 5123..9999 }; N = 2 } ]

let private concatenatedProduct number n =
    seq {
        for i = 1 to n do
            string (i * number)
    }
    |> String.concat ""
    |> int

let private maxPandigitalConcatenatedProduct limit =
    let products =
        limit.Range
        |> Seq.map (fun number -> concatenatedProduct number limit.N)
        |> Seq.where (fun number -> isPandigital 9 number)

    match not (Seq.isEmpty products) with
    | true -> Seq.max products
    | false -> 0

let solve () =
    allLimits |> Seq.map maxPandigitalConcatenatedProduct |> Seq.max |> string
