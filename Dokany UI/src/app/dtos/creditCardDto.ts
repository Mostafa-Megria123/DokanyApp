export class CreditCardDto{
    Id: Number;
    CardNumber: Number;
    CardName: String;
    Month: Number;
    Year: Number;

    constructor(id: Number,
        cardNumber: Number,
        cardName: String,
        month: Number,
        year: Number){
            this.Id = id;
            this.CardName = cardName;
            this.CardNumber = cardNumber;
            this.Month = month;
            this.Year = year;
        }
}