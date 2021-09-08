type Customer = {
    Id : int
    IsVip : bool
    Credit : decimal
}

let getPurchases customer = 
    let purchases = if customer.Id % 2 = 0 then 120M else 80M
    (customer, purchases)

let tryPromoteToVip customerWithPurchases = 
    let (customer, purchases) = customerWithPurchases
    if purchases > 100M then { customer with IsVip = true }
    else customer

let increaseCreditIfVip customer = 
    let increaseBy = if customer.IsVip then 100M else 0M
    { customer with Credit = customer.Credit + increaseBy }




// C# style
let upgradeCustomerNested customer = 
    increaseCreditIfVip(tryPromoteToVip(getPurchases customer))

// Procedural
let upgradeCustomerProcedural customer = 
    let customerWithPurchases = getPurchases customer
    let promotedCustomer = tryPromoteToVip customerWithPurchases
    let increasedCreditCustomer = increaseCreditIfVip promotedCustomer
    increasedCreditCustomer

// Composition operator
let upgradeCustomerComposed = 
    getPurchases >> tryPromoteToVip >> increaseCreditIfVip

// Forward pipe operator
let upgradeCustomerPiped customer = 
    customer 
    |> getPurchases 
    |> tryPromoteToVip 
    |> increaseCreditIfVip


let customerVIP = { Id = 1; IsVip = true; Credit = 0.0M }
let customerSTD = { Id = 2; IsVip = false; Credit = 100.0M }

let ``a VIP customer has their credit increased`` = 
    upgradeCustomerPiped customerVIP = {Id = 1; IsVip = true; Credit = 100.0M }
let ``a standard customer with sufficient credit is upgraded to VIP`` = 
    upgradeCustomerPiped customerSTD = {Id = 2; IsVip = true; Credit = 200.0M }
let ``a standard customer with insufficient credit is not upgraded to VIP`` = 
    upgradeCustomerPiped { customerSTD with Id = 3; Credit = 50.0M } = 
        {Id = 3; IsVip = false; Credit = 50.0M }


