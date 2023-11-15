// Problem 21: Amicable Numbers
module ProjectEuler.Solutions.Problem021

let private sumDivisors number =
    let rec loop sum current =
        match current, number % current = 0 with
        | 1, _ -> sum
        | _, true -> loop (sum + current) (current - 1)
        | _, false -> loop sum (current - 1)

    match (number / 2) with
    | 0 -> 0
    | startNumber -> loop 1 startNumber

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
    allAmicableNumbers 10000 |> List.sum |> int64
