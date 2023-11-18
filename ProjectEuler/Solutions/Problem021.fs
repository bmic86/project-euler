// Problem 21: Amicable Numbers
module ProjectEuler.Solutions.Problem021

open ProjectEuler.Solutions.Common.Numbers

let private isAmicable number =
    let a = sumDivisors number

    match number <> a with
    | true -> number = (sumDivisors a)
    | false -> false

let private allAmicableNumbers limit =
    let rec loop acc n =
        if n > 0 then
            match isAmicable n with
            | true -> loop (n :: acc) (n - 1)
            | false -> loop acc (n - 1)
        else
            acc

    loop [] (limit - 1)

let solve () =
    allAmicableNumbers 10000 |> List.sum |> string
