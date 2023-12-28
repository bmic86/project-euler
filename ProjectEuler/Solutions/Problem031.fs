// Problem 31: Coin Sums
module ProjectEuler.Solutions.Problem031

let private coins = [ 2; 5; 10; 20; 50; 100; 200 ]

let private coinSums target =
    let results = Array.create (target + 1) 1

    let rec loop coins =
        match coins with
        | [] -> results[target]
        | coin :: remainingCoins ->
            for i = coin to target do
                results[i] <- results[i] + results[i - coin]

            loop remainingCoins

    loop coins

let solve () = coinSums 200 |> string
