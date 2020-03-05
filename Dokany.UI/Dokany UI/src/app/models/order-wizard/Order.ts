import { ShippingAddress } from './ShippingAddress';
import { Credit } from './Credit';


export class Order {
    _shippingAddress: ShippingAddress;
    _paymentMethod: String;
    _creditInfo: Credit;

    constructor(shippingAddress: ShippingAddress, paymentMethod: String, creditInfo: Credit) {
        this._shippingAddress = shippingAddress;
        this._paymentMethod = paymentMethod;
        this._creditInfo = creditInfo;
    }
}