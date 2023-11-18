module ProjectEuler.Solver

open System
open System.Diagnostics
open ProjectEuler.Solutions

let private problems =
    [ 1, ("Multiples of 3 or 5", Problem001.solve)
      2, ("Even Fibonacci Numbers", Problem002.solve)
      3, ("Largest Prime Factor", Problem003.solve)
      4, ("Largest Palindrome Product", Problem004.solve)
      5, ("Smallest Multiple", Problem005.solve)
      6, ("Sum Square Difference", Problem006.solve)
      7, ("10001st Prime", Problem007.solve)
      8, ("Largest Product in a Series", Problem008.solve)
      9, ("Special Pythagorean Triplet", Problem009.solve)
      10, ("Summation of Primes", Problem010.solve)
      11, ("Largest Product in a Grid", Problem011.solve)
      12, ("Highly Divisible Triangular Number", Problem012.solve)
      13, ("Large Sum", Problem013.solve)
      14, ("Longest Collatz Sequence", Problem014.solve)
      15, ("Lattice Paths", Problem015.solve)
      16, ("Power Digit Sum", Problem016.solve)
      17, ("Number Letter Counts", Problem017.solve)
      18, ("Maximum Path Sum I", Problem018.solve)
      19, ("Counting Sundays", Problem019.solve)
      20, ("Factorial Digit Sum", Problem020.solve)
      21, ("Amicable Numbers", Problem021.solve)
      22, ("Names Scores", Problem022.solve)
      23, ("Non-Abundant Sums", Problem023.solve)
      24, ("Lexicographic Permutations", Problem024.solve)
      25, ("1000-digit Fibonacci Number", Problem025.solve)
      67, ("Maximum Path Sum II", Problem067.solve) ]
    |> Map.ofList

let private calculateResult problemNumber (title, solve) =
    let stopWatch = Stopwatch.StartNew()
    let result = solve ()
    stopWatch.Stop()

    printf "Problem %03d: %-35s | " problemNumber title
    printfn "Result: %15s | Time: %5dms" result stopWatch.ElapsedMilliseconds

    stopWatch.Elapsed

let isValidProblemNumber number = Map.containsKey number problems

let solveAll () =
    printfn "Solving all problems:"
    printfn "---------------------"

    let totalTime =
        problems
        |> Map.fold (fun timeSum key data -> timeSum + (calculateResult key data)) TimeSpan.Zero

    printfn "----------------------------"
    printfn "Total time: %A" totalTime

let solveLast () =
    printfn "Solving last problem:"
    printfn "---------------------"

    let (key, data) = Map.maxKeyValue problems
    calculateResult key data |> ignore

let solveSelected problemNumbers =
    printfn "Solving selected problems:"
    printfn "--------------------------"

    let totalTime =
        problemNumbers
        |> Array.sort
        |> Array.fold (fun timeSum key -> timeSum + (calculateResult key problems[key])) TimeSpan.Zero

    printfn "----------------------------"
    printfn "Total time: %A" totalTime
