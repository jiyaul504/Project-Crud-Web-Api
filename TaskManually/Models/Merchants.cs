using System.ComponentModel.DataAnnotations;


namespace Task.Models
{
    public class Merchants
    {
        [Key]
        public int Id { get; set; }
        public string Merchant_name { get; set; }
        public DateTime Created_at { get; set; }
        public int CountryCode { get; set; }
        public int UserId { get; set; }
        //Foreign key 
        public Country Country { get; set; }
        public User User { get; set; }
    }
}
