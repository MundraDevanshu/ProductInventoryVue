namespace Business_Layer.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }

        public string Discount { get; set; }
    }
}
