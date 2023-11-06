open Problems

let printResults (number, title, solve) =
  printfn "Problem %03d: %-25s | Result: %d" number title (solve())

let problems = [
  1, "Multiples of 3 or 5", Problem001.solve;
  2, "Even Fibonacci Numbers", Problem002.solve;
  3, "Largest Prime Factor", Problem003.solve;
]

List.iter printResults problems