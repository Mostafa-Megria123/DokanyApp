export class ShippingAddress{
    id: Number;
    firstName: String;
    lastName: String;
    addressLine1: String;
    addressLine2: String;
    zipCode: String;
    city: String;
    country: String;
    state: String;
    phoneNumber: String;

    constructor(
        Id: Number , 
        FirstName: String , 
        LastName: String , 
        PhoneNumber: String,
        AddressLine1: String, 
        AddressLine2: String, 
        ZipCode: String = '', 
        City: String ='',
        Country: String = '',
        State: String = ''
        ){
        this.id = Id;
        this.firstName = FirstName;
        this.lastName = LastName;
        this.addressLine1 = AddressLine1;
        this.addressLine2 = AddressLine2;
        this.zipCode = ZipCode;
        this.city = City;
        this.country = Country;
        this.state = State;
        this.phoneNumber = PhoneNumber;
    }
}