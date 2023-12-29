// Problem 32: Pandigital Products
module ProjectEuler.Solutions.Problem032

// For number with unique digits: return bitmask representing digits in a number.
// For number with non-unique digits: return None.
let private uniqueDigitsMask number =
    let rec loop result n =
        match n, n % 10 with
        | 0, _ -> Some result
        | n, digit ->
            let digitMask = 1 <<< digit

            // Checks, if digits in a number are unique.
            match digitMask &&& result = 0 with
            | true -> loop (result ||| digitMask) (n / 10)
            | false -> None

    loop 0 number

// If all numbers (a, b and product) combined together are pandigital, then return the product.
// Otherwise return 0
let private pandigitalProduct a b =

    match uniqueDigitsMask a, uniqueDigitsMask b with
    | Some maskA, Some maskB when maskA &&& maskB = 0 ->

        let product = a * b

        match uniqueDigitsMask product with
        | Some maskProduct ->

            let hasUniqueDigits = (maskA &&& maskProduct) = 0 && (maskB &&& maskProduct) = 0
            let allDigitsMask = maskA ||| maskB ||| maskProduct

            match hasUniqueDigits, allDigitsMask with
            | true, 0b1111111110 -> product
            | _ -> 0

        | None -> 0

    | _ -> 0


let solve () =
    let input =
        seq {
            for a = 1 to 9 do
                for b = 1234 to 9876 do
                    (a, b)

            for a = 12 to 98 do
                for b = 123 to 987 do
                    (a, b)
        }

    input
    |> Seq.map (fun (a, b) -> pandigitalProduct a b)
    |> Seq.distinct
    |> Seq.sum
    |> string
