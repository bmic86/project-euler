// Problem 11: Largest Product in a Grid.
module ProjectEuler.Solutions.Problem011

open ProjectEuler.Solutions.Common.FileInput

type private Vector2 = { X: int; Y: int }

let private gridSize = 20
let private adjacentNumbersCount = 4

let private position coords direction step =
    { X = coords.X + direction.X * step
      Y = coords.Y + direction.Y * step }

let private isValidDirection cellCoords direction step =
    let newPosition = position cellCoords direction step

    newPosition.X >= 0
    && newPosition.X < gridSize
    && newPosition.Y >= 0
    && newPosition.Y < gridSize

let private cellPathProduct (grid: int array array) cellCoords direction steps =
    let product accmulator steps =
        let newPosition = position cellCoords direction steps
        accmulator * int64 (grid[newPosition.X][newPosition.Y])

    { 0..steps } |> Seq.fold (product) 1

let private cellProducts (grid: int array array) cellCoords directions steps =
    let rec loop accumulator directionsLeft =
        match directionsLeft with
        | [] -> accumulator
        | currentDirection :: nextDirections ->
            match isValidDirection cellCoords currentDirection steps with
            | false -> loop accumulator nextDirections
            | true ->
                let result = cellPathProduct grid cellCoords currentDirection steps
                loop (result :: accumulator) nextDirections

    loop [] directions

let private gridProducts (grid: int array array) =
    let directions =
        [ { X = 0; Y = 1 }; { X = 1; Y = 0 }; { X = 1; Y = 1 }; { X = 1; Y = -1 } ]

    let steps = adjacentNumbersCount - 1

    let rec loop accumulator x y =
        match (x, y) with
        | (_, y) when y >= gridSize -> accumulator
        | (x, y) when x >= gridSize -> loop accumulator 0 (y + 1)
        | (x, y) ->
            let products = cellProducts grid { X = x; Y = y } directions steps
            loop (products @ accumulator) (x + 1) y

    loop [] 0 0

let solve () =
    readAllLinesAsIntegers ("Problem011.txt") |> gridProducts |> List.max |> string
