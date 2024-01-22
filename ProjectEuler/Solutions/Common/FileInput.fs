module ProjectEuler.Solutions.Common.FileInput

open System
open System.IO

let readAllLinesAsIntegers fileName =
    let parseLine (line: string) =
        let splited = line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
        Array.map Int32.Parse splited

    let lines = File.ReadAllLines($"./Data/{fileName}")
    Array.map parseLine lines

let readAllWords fileName =
    let content = File.ReadAllText($"./Data/{fileName}")
    content.Split([| ','; '"' |], StringSplitOptions.RemoveEmptyEntries)
