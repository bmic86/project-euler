module ProjectEuler.Program

[<EntryPoint>]
let main argv =
    match argv with
    | [| "all" |] -> Solver.solveAll ()
    | _ -> Solver.solveLast ()

    0
