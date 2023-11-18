// Problem 25: 1000-digit Fibonacci Number
module ProjectEuler.Solutions.Problem025

let private findFibonacciIndex digitsCount =
    let rec loop i previous current =
        let n = i + 1

        match previous + current with
        | next when String.length (string next) = digitsCount -> n
        | next -> loop n current next

    match digitsCount with
    | _ when digitsCount < 1 -> 0
    | 1 -> 1
    | _ -> loop 2 (bigint 1) (bigint 1)

let solve () = findFibonacciIndex 1000 |> string
