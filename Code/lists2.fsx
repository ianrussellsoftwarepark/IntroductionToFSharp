open System
open System.IO

type Customer = {
    CustomerId : string
    Email : string
    IsEligible : string
    IsRegistered : string
    DateRegistered : string
    Discount : string
}

// Result type
let parse (line:string) =
    match line.Split('|') with
    | [| customerId; email; eligible; registered; dateRegistered; discount |] -> 
        Ok { 
            CustomerId = customerId
            Email = email
            IsEligible = eligible
            IsRegistered = registered
            DateRegistered = dateRegistered
            Discount = discount
        }
    | data -> Error data

let import path =
    [
        use reader = new StreamReader(File.OpenRead(path))
        while not reader.EndOfStream do
            reader.ReadLine() 
    ]

let main =
    Path.Combine(__SOURCE_DIRECTORY__, "resources", "customers.csv")
    |> import
    |> List.skip 1
    |> List.map parse
