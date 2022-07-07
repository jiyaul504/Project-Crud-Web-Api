namespace TaskManually.Data
{
    public class ProductDto
    {
        public string? Name { get; set; }
        public int Price { get; set; }
        public string? Status { get; set; }
        public DateTime Created_at { get; set; }
        public int MerchantId { get; set; }
    }
}
