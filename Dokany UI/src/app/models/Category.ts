export class Category{
    Id: Number;
    Name: String;
    Description: String;
    ImagePath: String

    constructor(_id: Number , _name: String , _description:String ,  _imagePath: String){
        this.Id = _id;
        this.Name = _name;
        this.Description = _description;
        this.ImagePath = _imagePath;
    }
}