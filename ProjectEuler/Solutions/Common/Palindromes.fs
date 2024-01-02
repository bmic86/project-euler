module ProjectEuler.Solutions.Common.Palindromes

let isPalindrom (text: string) =
    let rec loop i max =
        match i with
        | i when i = max -> true
        | i when text[i] <> text[text.Length - (i + 1)] -> false
        | i -> loop (i + 1) max

    loop 0 (text.Length / 2)
