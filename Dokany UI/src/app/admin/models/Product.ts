
export class Product {
    Id: Number;
    Name: String;
    BrandName: String;
    Quantity: Number;
    Price: Number;
    Category: String;
    Description: String;
    CreationDate: Date;
    ImagePaths: String[];

    constructor(_id: Number,
        _name: String,
        _brandName: String,
        _qantity: Number,
        _price: Number,
        _category: String,
        _description: String,
        _creationDate: Date,
        _imagePaths: String[]) {
        this.Id = _id;
        this.Name = _name;
        this.BrandName = _brandName;
        this.Quantity = _qantity;
        this.Price = _price;
        this.Category = _category;
        this.Description = _description;
        this.CreationDate = _creationDate;
        this.ImagePaths = _imagePaths
    }
}