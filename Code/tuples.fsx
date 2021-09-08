// Tuples

open System

type MyTuple = string * bool * int

let example = "Fred", true, 10

let example2 : MyTuple = "Fred", true, 10

example = example2

let name, isEligible, spend = example

let name1, _, spend1 = example

// Out parameters converted to tuples
let parseDateTime (input:string) =
    let success, value = DateTime.TryParse input
    if success then Some value else None

let parseDateTimePM (input:string) =
    match DateTime.TryParse input with
    | true, value -> Some value
    | _ -> None

(*
type Option<'T> =
    | Some of 'T
    | None
*)