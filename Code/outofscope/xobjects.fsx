// type Maybe<'T> =
//     | Some of 'T
//     | None

[<AbstractClass>]
type Maybe<'T>() = class end

type Some<'T>(value:'T) =
    inherit Maybe<'T>()
    member _.Value = value

type None<'T>() =
    inherit Maybe<'T>()

let none = None<unit>()

let some = Some<int>(10)

some.Value

type SomethingElse<'T>(value:'T, isAllowed:bool) =
    inherit Maybe<'T>()
    member _.Value = value
    member _.IsAllowed = isAllowed

let doSomething (some:Some<int>) =
    2 * some.Value

let doSomethingX (maybe:Maybe<'T>) =
    match maybe with
    | :? Some<'T> as s -> printfn "%A" s.Value
    | :? SomethingElse<'T> as s -> printfn "%A" s.Value
    | :? None<'T> -> printfn "None"
    | _ -> printfn "Unexpected"

