// Problem 2: Even Fibonacci Numbers.
module ProjectEuler.Solutions.Problem002

let private evenFibonacciNumbers max =
    let rec loop numbers previous current =
        match previous + current with
        | next when next > max -> numbers
        | next when next % 2 = 0 -> loop (next :: numbers) current next
        | next -> loop numbers current next

    loop [] 1 1

let solve () =
    evenFibonacciNumbers 4_000_000 |> List.sum |> string
