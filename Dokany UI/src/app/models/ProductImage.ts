
export class ProductImage {
    Id: Number;
    ProductId: Number;
    ImagePath: String[];

    constructor(_id: Number,
        _productId: Number,
        _imagePaths: String[]) {
        this.Id = _id;
        this.ProductId = _productId;
        this.ImagePath = _imagePaths
    }
}