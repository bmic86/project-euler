// Problem 15: Lattice Paths.
module ProjectEuler.Solutions.Problem015

open ProjectEuler.Solutions.Common.Factorials

// Using binomial coefficient formula for (2n, n) = (2n)! / (n! * (2n-n)!)
// simplified to: (2n * (2n−1) * (2n−2) * ... * (n+1)) / n!
let private countLatticePaths n =
    let a = partialFactorial n (n * 2)
    let b = factorial n

    int64 (a / b)

let solve () = countLatticePaths 20
