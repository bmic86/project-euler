// Problem 15: Lattice Paths.
module ProjectEuler.Solutions.Problem015

let private partialFactorial until n =
    let rec loop acc current =
        if current > until then
            loop (acc * bigint (int32 current)) (current - 1)
        else
            acc

    loop (bigint 1) n

let private factorial = partialFactorial 1

// Using binomial coefficient formula for (2n, n) = (2n)! / (n! * (2n-n)!)
// simplified to: (2n * (2n−1) * (2n−2) * ... * (n+1)) / n!
let private countLatticePaths n =
    let a = partialFactorial n (n * 2)
    let b = factorial n

    int64 (a / b)

let solve () = countLatticePaths 20
