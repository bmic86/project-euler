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

let private updateChildPathSum (maxSums: int array) node child =
    let newSum = maxSums[node.Id] + child.Value
    maxSums[child.Id] <- max newSum maxSums[child.Id]

let private maxPathSum nodes =
    let nodesCount = List.length nodes
    let nodeMaxSums = Array.zeroCreate nodesCount

    let rec loop unvisited =
        match unvisited with
        | [] -> Array.max nodeMaxSums
        | node :: rest ->
            match node.Children with
            | [] -> loop rest
            | children ->
                nodeMaxSums[node.Id] <- max node.Value nodeMaxSums[node.Id]
                List.iter (fun child -> updateChildPathSum nodeMaxSums node child) children
                loop rest

    loop nodes

let maximumPathSum (input: int array array) = input |> generateTree |> maxPathSum
