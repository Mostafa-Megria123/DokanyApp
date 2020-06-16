export class CartItemDto{
    Id: Number;
    Name: String;
    Quantity: Number;
    UnitCost: Number;
    Total: Number;
    ShoppingCartId: Number;
    ProductId: Number;
    CustomerId: Number;

    constructor(id: Number,
        name: String,
        quantity: Number,
        unitCost: Number,
        total: Number,
        shoppingCartId: Number,
        productId: Number,
        customerId: Number){
            this.Id = id;
            this.Name = name;
            this.Quantity = quantity;
            this.UnitCost = unitCost;
            this.Total = total;
            this.ShoppingCartId = shoppingCartId;
            this.ProductId = productId;
            this.CustomerId = customerId;
        }
}