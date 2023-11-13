// Problem 19: Counting Sundays.
module ProjectEuler.Solutions.Problem019

open System

let countSundaysOnFirstMonthDay startYear endYear =
    let endDate = DateTime(endYear, 12, 31)

    let rec loop counter date =
        match date > endDate with
        | true -> counter
        | false ->
            match date.DayOfWeek with
            | DayOfWeek.Sunday -> loop (counter + 1) (date.AddMonths(1))
            | _ -> loop counter (date.AddMonths(1))

    loop 0 (DateTime(startYear, 1, 1))

let solve () =
    countSundaysOnFirstMonthDay 1901 2000 |> int64
