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

/// Record type (Immutable by default)
type Customer = {
    Id : string
    IsRegistered : bool
    IsEligible : bool
}

let mary = { Id = "Mary"; IsRegistered = true; IsEligible = true }
let john = { mary with Id = "John" }
let richard = { mary with Id = "Richard"; IsEligible = false }
let sarah = { Id = "Sarah"; IsRegistered = false; IsEligible = false }

let john2 = { Id = "John"; IsRegistered = true; IsEligible = true }

// Structural equality
john = john2

/// This function uses curried parameters
let calculateTotal customer spend =
    let discount =
        if customer.IsEligible && spend >= 100m then spend * 0.1m else 0.0m
    spend - discount

let assertMary = (calculateTotal mary 99m = 99m)
let assertJohn = (calculateTotal john 100m = 90m)
let assertRichard = (calculateTotal richard 100m = 100m)
let assertSarah = (calculateTotal sarah 100m = 100m)



