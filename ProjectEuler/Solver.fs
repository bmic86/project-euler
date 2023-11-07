module ProjectEuler.Solver

open System.Diagnostics
open ProjectEuler.Problems

let private problems = [
  1, "Multiples of 3 or 5", Problem001.solve
  2, "Even Fibonacci Numbers", Problem002.solve
  3, "Largest Prime Factor", Problem003.solve
  4, "Largest Palindrome Product", Problem004.solve
  5, "Smallest Multiple", Problem005.solve
  6, "Sum Square Difference", Problem006.solve
  7, "10001st Prime", Problem007.solve
]

let private calculateResult (number, title, solve) =
  let stopWatch = Stopwatch.StartNew()
  let result = solve()
  stopWatch.Stop()

  printf "Problem %03d: %-28s | " number title
  printfn "Result: %10d | Time: %5dms" result stopWatch.ElapsedMilliseconds

let solveAll () =
  List.iter calculateResult problems

