// Problem 32: Pandigital Products
module ProjectEuler.Solutions.Problem032

open ProjectEuler.Solutions.Common.Numbers

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

            match hasUniqueDigits, allDigitsMask = (pandigitalNumberMask 9) with
            | true, true -> product
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
