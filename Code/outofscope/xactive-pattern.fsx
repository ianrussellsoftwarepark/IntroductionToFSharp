open System

let parseDateTime (input:string) =
    let success, value = DateTime.TryParse input
    if success then Some value else None

let (|IsDateTime|_|) (input:string) =
    let success, value = DateTime.TryParse input
    if success then Some value else None

let parse input =
    match input with
    | IsDateTime dt -> $"DateTime: {dt}"
    | _ -> $"'{input}' is not a valid datetime"
    |> printfn "%s"

parse "2021-09-08 10:00:00"

parse "Hello"


