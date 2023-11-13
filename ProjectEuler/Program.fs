module ProjectEuler.Program

open System

let private parseProblemNumber (str: string) =
    match Int32.TryParse(str) with
    | (true, value) -> value
    | _ -> 0

[<EntryPoint>]
let main argv =
    if Array.contains ("all") argv then
        Solver.solveAll ()
    else
        let validProblemNumbers =
            argv |> Array.map parseProblemNumber |> Array.filter Solver.isValidProblemNumber

        if Array.isEmpty validProblemNumbers then
            Solver.solveLast ()
        else
            Solver.solveSelected validProblemNumbers

    0
