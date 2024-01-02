// Problem 4: Largest Palindrome Product.
module ProjectEuler.Solutions.Problem004

open ProjectEuler.Solutions.Common.Palindromes

let private palindromProducts max =
    let rec loop acc a b =
        let product = a * b

        let results =
            match isPalindrom (string product) with
            | true -> (product :: acc)
            | false -> acc

        match (a, b) with
        | (1, 1) -> results
        | (a, 1) -> loop results (a - 1) max
        | (a, b) -> loop results a (b - 1)

    loop [] max max

let solve () =
    palindromProducts 999 |> List.max |> string
