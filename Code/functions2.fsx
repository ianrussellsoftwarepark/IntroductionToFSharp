// Unit

// Every function has (at least) one input parameter and one output

// What about void and Action?

open System

/// I'm a function definition.
let nowF () = DateTime.UtcNow

/// I'm a value binding. I execute immediately.
let nowV = DateTime.UtcNow

let isnow = nowF ()

let isnotnow = nowV



let myLogger (msg:string) =
    printfn $"{msg}"

// Higher Order function
let log (logger:string -> unit) (msg:string) =
    logger msg
    //()

let result = log myLogger "Hello world!"

// Partial Application (returns a function)
let logToMyLogger = log myLogger

let result2 = logToMyLogger "I was partially applied!"

