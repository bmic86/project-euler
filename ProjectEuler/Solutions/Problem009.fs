// Problem 9: Special Pythagorean Triplet.
module ProjectEuler.Solutions.Problem009

// Generates Pythagorean triplet using Euclid's formula.
let private triplet m n =
    let a = m * m - n * n
    let b = 2L * m * n
    let c = m * m + n * n
    (a, b, c)

let private findTripletBySum sum =
    let max = int64 (floor (sqrt (float sum)))

    let rec loop m n =
        match (triplet m n) with
        | (a, b, c) when a + b + c = sum -> (a, b, c)
        | _ ->
            match (m, n) with
            | (0L, 0L) -> (0L, 0L, 0L) // Triplet not found.
            | (_, 0L) -> loop (m - 1L) max
            | _ -> loop m (n - 1L)

    loop max max

let solve () =
    let (a, b, c) = findTripletBySum 1000
    a * b * c
