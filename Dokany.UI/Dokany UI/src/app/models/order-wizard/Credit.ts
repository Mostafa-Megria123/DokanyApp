export class Credit{
    _cardName: String;
    _cardNumber: String;
    _month: String;
    _year: Number;

    constructor(cardName: String, cardNumber: String , month: String, year: Number){
        this._cardName = cardName;
        this._cardNumber = cardNumber;
        this._month = month;
        this._year = year;
    }
}