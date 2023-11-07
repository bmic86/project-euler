// Problem 4: Largest Palindrome Product
module ProjectEuler.Problems.Problem004

let private isPalindrom (text: string) =
  let rec loop i max (text: string) =
    match i with
    | i when i = max -> true
    | i when text[i] <> text[text.Length - (i + 1)] -> false
    | _ -> loop (i + 1) max text

  loop 0 (text.Length / 2) text

let palindromProducts max =
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
  palindromProducts 999
  |> List.max
