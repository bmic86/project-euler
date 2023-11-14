module ProjectEuler.Solutions.Common.MaximumPathSum

type private Node =
    { Id: int
      Value: int
      Children: Node list }

    static member New id value children =
        { Id = id
          Value = value
          Children = children }

let private generateTree (input: int array array) =

    let rec loop acc (previous: Node list) level nextId =
        match level with
        | -1 -> acc
        | _ ->
            let values =
                input[level]
                |> Array.mapi (fun i value -> Node.New (nextId + i) value previous[i .. i + 1])
                |> Array.toList

            loop (values @ acc) values (level - 1) (nextId + Array.length input[level])

    loop [] [] (Array.length input - 1) 0

let private maxValuesPathSum nodes =
    let nodesCount = List.length nodes
    let distances = Array.zeroCreate nodesCount

    let rec loop unvisited =

        match unvisited with
        | [] -> Array.max distances
        | node :: rest ->
            match node.Children with
            | [] -> loop rest
            | children ->
                distances[node.Id] <- max node.Value distances[node.Id]

                for child in children do
                    let newChildDistance = distances[node.Id] + child.Value
                    distances[child.Id] <- max newChildDistance distances[child.Id]

                loop rest

    loop nodes

let maximumPathSum (input: int array array) =
    input |> generateTree |> maxValuesPathSum
