type Maybe<'T> =
    | Some of 'T
    | None

let none = None

let some = Some 10

let someWord = Some "Hello"

// Compiler warning 
// DO NOT DO THIS!
let (Some x) = some

let doProcess maybe =
    match maybe with
    | Some x -> printfn "Some: %A" x
    | None -> printfn "None"

let result1 = doProcess some
let result2 = doProcess none

open Microsoft.FSharp.Core.LanguagePrimitives

type MyEnum =
    | First = 1
    | Second = 2

let myEnum = MyEnum.First

let getValue (enum:MyEnum) =
    match enum with
    | MyEnum.First -> printfn "First"
    | MyEnum.Second -> printfn "Second"
    | _ -> printfn "Unexpected"

let z = getValue myEnum

let badValue = EnumOfValue<int, MyEnum> 13

let value = EnumToValue badValue

getValue badValue
