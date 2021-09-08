(*
Feature: Applying a discount
Scenario: Eligible Registered Customers get 10% discount when they spend £100 or more

Given the following Registered Customers
|Customer Id|Is Eligible|
|John       |true       |
|Mary       |true       |
|Richard    |false      |

When <Customer Id> spends <Spend>
Then their order total will be <Total>

Examples:
|Customer Id|   Spend|   Total|
|Mary       |   99.00|   99.00|
|John       |  100.00|   90.00|
|Richard    |  100.00|  100.00|
|Sarah      |  100.00|  100.00|
*)

type RegisteredCustomer = {
    Id : string
    IsEligible : bool
}

type UnregisteredCustomer = {
    Id : string
}

/// This is a Discriminated Union
type Customer =
    | Registered of RegisteredCustomer
    | Guest of UnregisteredCustomer

let mary = Registered { Id = "Mary"; IsEligible = true }
let john = Registered { Id = "John"; IsEligible = true }
let richard = Registered { Id = "Richard"; IsEligible = false }
let sarah = Guest { Id = "Sarah" }

/// Calculates the total price given a Customer and a Spend
let calculateTotal customer spend =
    let discount =
        match customer with
        | Registered { IsEligible = true } when spend >= 100m -> spend * 0.1m
        | Registered _ -> 0.0m
        | Guest _ -> 0.0m
    spend - discount

let assertMary = (calculateTotal mary 99m = 99m)
let assertJohn = (calculateTotal john 100m = 90m)
let assertRichard = (calculateTotal richard 100m = 100m)
let assertSarah = (calculateTotal sarah 100m = 100m)
