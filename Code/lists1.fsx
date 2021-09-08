// Lists + Array + Seq

let nums = [1..10]

let evens = 
    nums
    |> List.filter (fun x -> x % 2 = 0)

let oddSquares = 
    nums 
    |> List.filter (fun x -> x % 2 = 1)
    |> List.map (fun x -> x * x)

let odds items = 
    items
    |> List.filter (fun x -> x % 2 = 1)

let odds = List.filter (fun x -> x % 2 = 1)

let squares = List.map (fun x -> x * x)

let oddSquares1 items = 
    items 
    |> odds
    |> squares

let run = oddSquares1 [1..25]

let random = [4;1;6;2;2;3;6;7;9;8;7;4;3;1;2]

let sorted = random |> List.sort

let reverse = random |> List.rev

let grouped = random |> List.groupBy id

let dist = random |> List.distinct

let sum = random |> List.sum

let add items =
    let rec loop xs acc =
        match xs with
        | [] -> acc
        | head::tail -> loop tail (acc + head)
    loop items 0

let sum2 = add random

