namespace TaskManually.Data
{
    public class MerchantDto
    {
        public int Id { get; set; }
        public string Merchant_name { get; set; }
        public DateTime Created_at { get; set; }
        public int CountryCode { get; set; }
        public int UserId { get; set; }
    }
}
