// Problem 23: Non-Abundant Sums
module ProjectEuler.Solutions.Problem023

open ProjectEuler.Solutions.Common.Numbers

let private limit = 28123

let private isAbundantNumber number = (sumDivisors number) > number

let solve () =
    let allNumbers = [ 1..limit ]
    let abundantNumbers = allNumbers |> List.where isAbundantNumber

    let combineSums accumulator currentNumber =
        (List.map ((+) currentNumber) abundantNumbers) @ accumulator

    let abundantSums = List.fold combineSums [] abundantNumbers

    List.except abundantSums allNumbers |> List.sum |> int64
