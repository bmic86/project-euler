// Problem 14: Longest Collatz Sequence.
module ProjectEuler.Solutions.Problem014

let private collatzSequenceLenght number =
    let rec loop lenght currentNumber =
        match currentNumber with
        | 1L -> lenght
        | num when num % 2L = 0L -> loop (lenght + 1) (num / 2L)
        | num -> loop (lenght + 1) (3L * num + 1L)

    loop 1 (int64 number)

let private longestCollatzSequenceStartNumber limit =
    let rec loop longestNumber maxLenght currentNumber =
        match currentNumber with
        | num when num <= 0 -> longestNumber
        | num ->
            let lenght = collatzSequenceLenght num

            if lenght > maxLenght then
                loop num lenght (num - 1)
            else
                loop longestNumber maxLenght (num - 1)

    loop 0 0 (limit - 1)

let solve () =
    longestCollatzSequenceStartNumber 1_000_000 |> string
