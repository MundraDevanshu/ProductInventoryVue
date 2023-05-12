using Data_Layer.Entity;

namespace Business_Layer.Dto
{
    public static class ProductExtensions
    {
        public static ProductDto MapToProductDto(this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category,
                Discount = product.Discount
            };
        }

        public static Product MapToProduct(this ProductDto productDto)
        {
            return new Product
            {
                Id = productDto.Id,
                Title = productDto.Title,
                Description = productDto.Description,
                Price = productDto.Price,
                Category = productDto.Category,
                Discount= productDto.Discount
            };
        }
    }
}
