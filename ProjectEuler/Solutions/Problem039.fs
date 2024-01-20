// Problem 39: Integer Right Triangles
module ProjectEuler.Solutions.Problem039

open System

let private allRightIntegralTrianglePerimeters perimetersLimit =
    let sideLimit = perimetersLimit / 2

    [ for a = 1 to sideLimit do
          for b = a to sideLimit do
              let c = sqrt (float (a * a + b * b))

              if Double.IsInteger c then
                  let perimeter = a + b + int c

                  if perimeter <= perimetersLimit then
                      perimeter ]

let solve () =
    let (perimeter, _) =
        allRightIntegralTrianglePerimeters 1000
        |> List.countBy (fun perimeter -> perimeter)
        |> List.maxBy (fun (_, count) -> count)

    string perimeter
