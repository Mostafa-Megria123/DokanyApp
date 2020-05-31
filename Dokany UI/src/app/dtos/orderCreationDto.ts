import { ShippingAddressDto } from './shippingAddressDto';
import { CreditCardDto } from './creditCardDto';
import { CartItemDto } from './cartItemDto';

export class OrderCreationDto{
    Id: Number;
    ShippingId: Number;
    Description: String;
    UserId: Number;
    ShippingCost: Number;
    TotalCost: Number;
    PaymentMethod: Number;
    
    ShippingAddressDto: ShippingAddressDto;
    CreditCardDto: CreditCardDto;
    CartItemDto: CartItemDto;

    constructor(id: Number,
        shippingId: Number,
        description: String,
        userId: Number,
        shippingCost: Number,
        totalCost: Number,
        paymentMethod: Number,
        shippingAddressDto: ShippingAddressDto,
        creditCardDto: CreditCardDto,
        cartItemDto: CartItemDto){
            this.Id = id;
            this.ShippingId = shippingId;
            this.Description = description;
            this.UserId = userId;
            this.ShippingCost = shippingCost;
            this.TotalCost = totalCost;
            this.PaymentMethod = paymentMethod;
            this.ShippingAddressDto = shippingAddressDto;
            this.CreditCardDto = creditCardDto;
            this.CartItemDto = cartItemDto;
        }
}