using System.ComponentModel.DataAnnotations;


namespace Task.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

       
        public string? Name { get; set; }
        public int Price { get; set; }
        public string? Status { get; set; }
        public DateTime Created_at { get; set; }
        public int MerchantId { get; set; } 

        // Foreign key
        public Merchants Marchants { get; set; }
    }
}
