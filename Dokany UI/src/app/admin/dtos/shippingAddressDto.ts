export class ShippingAddressDto{
    Id: Number;
    FirstName: String;
    LastName: String;
    AddressLine1: String;
    AddressLine2: String;
    ZipCode: String;
    City: String;
    Country: String;
    State: String;
    PhoneNumber: String;
    UserId: Number;

    constructor(id: Number,
        firstNumber: String,
        lastName: String,
        addressLine1: String,
        addressLine2: String,
        zipCode: String,
        city: String,
        country: String,
        state: String,
        phoneNumber: String,
        userId: Number       
        ){
            this.Id = id;
            this.FirstName = firstNumber;
            this.LastName = lastName;
            this.AddressLine1 = addressLine1;
            this.AddressLine2 = addressLine2;
            this.ZipCode = zipCode;
            this.City = city;
            this.Country = country;
            this.State = state;
            this.PhoneNumber = phoneNumber;
            this.UserId = userId;
        }
}