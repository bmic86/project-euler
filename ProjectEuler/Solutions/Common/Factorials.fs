module ProjectEuler.Solutions.Common.Factorials

let partialFactorial until n =
    let rec loop acc current =
        if current > until then
            loop (acc * bigint (int32 current)) (current - 1)
        else
            acc

    loop (bigint 1) n

let factorial = partialFactorial 1
