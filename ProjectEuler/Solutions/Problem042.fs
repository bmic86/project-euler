// Problem 42: Coded Triangle Numbers
module ProjectEuler.Solutions.Problem042

open ProjectEuler.Solutions.Common.FileInput
open ProjectEuler.Solutions.Common.Text

let private triangleNumber n = (n + 1) * n / 2

let private isTriangleNumber number =
    let rec loop n =
        match triangleNumber n with
        | tn when tn = number -> true
        | tn when tn > number -> false
        | _ -> loop (n + 1)

    loop 1

let solve () =
    readAllWords "Problem042.txt"
    |> Array.map wordScore
    |> Array.filter isTriangleNumber
    |> Array.length
    |> string
