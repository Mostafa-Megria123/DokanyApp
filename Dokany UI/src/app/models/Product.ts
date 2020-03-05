
export class Product{
    Id: Number;
    Name: String;
    Quantity: Number;
    Price: Number;
    Category: String;
    Detail: String;
    CreationDate: Date;
    ImagePaths: String[];

    constructor(_id: Number,
         _name: String ,
        _qantity: Number , 
        _price: Number, 
        _category: String , 
        _detail: String, 
        _creationDate: Date,
        _imagePaths: String[]){
        this.Id =_id;
        this.Name = _name;
        this.Quantity = _qantity;
        this.Price = _price;
        this.Category = _category;
        this.Detail = _detail;
        this.CreationDate = _creationDate;
        this.ImagePaths = _imagePaths
    }
}