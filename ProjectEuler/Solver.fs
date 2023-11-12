module ProjectEuler.Solver

open System.Diagnostics
open ProjectEuler.Solutions

let private problems =
    [ 1, "Multiples of 3 or 5", Problem001.solve
      2, "Even Fibonacci Numbers", Problem002.solve
      3, "Largest Prime Factor", Problem003.solve
      4, "Largest Palindrome Product", Problem004.solve
      5, "Smallest Multiple", Problem005.solve
      6, "Sum Square Difference", Problem006.solve
      7, "10001st Prime", Problem007.solve
      8, "Largest Product in a Series", Problem008.solve
      9, "Special Pythagorean Triplet", Problem009.solve
      10, "Summation of Primes", Problem010.solve
      11, "Largest Product in a Grid", Problem011.solve
      12, "Highly Divisible Triangular Number", Problem012.solve
      13, "Large Sum", Problem013.solve ]

let private calculateResult (number, title, solve) =
    let stopWatch = Stopwatch.StartNew()
    let result = solve ()
    stopWatch.Stop()

    printf "Problem %03d: %-35s | " number title
    printfn "Result: %15d | Time: %5dms" result stopWatch.ElapsedMilliseconds

let solveAll () = List.iter calculateResult problems

let solveLast () = calculateResult (List.last problems)
