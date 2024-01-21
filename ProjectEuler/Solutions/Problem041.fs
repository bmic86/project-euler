// Problem 41: Pandigital Prime
module ProjectEuler.Solutions.Problem041

open ProjectEuler.Solutions.Common.PrimeNumbers
open ProjectEuler.Solutions.Common.Numbers

type private Limit = { Range: int seq; N: int }

// 1.) When sum of all digits is divisible by 3, then the number itself is also divisible by 3 (and cannot be prime).
//     Which implies, that checks for N = 9,8,6,5,3 and 2 can be ignored.
// 2.) Even numbers are skipped in ranges, because they are divisible by 2 (and cannot be prime).
let private allLimits =
    [ { Range = { 7654321..-2..1234567 }
        N = 7 }
      { Range = { 4321..-2..1234 }; N = 4 } ]

let private findPandigitalPrime (limit: Limit) =
    limit.Range
    |> Seq.tryFind (fun number -> (isPandigital limit.N number) && (isPrime number))

let private formatResult result =
    match result with
    | Some number -> string number
    | None -> "Not found"

let solve () =
    allLimits |> Seq.tryPick findPandigitalPrime |> formatResult
