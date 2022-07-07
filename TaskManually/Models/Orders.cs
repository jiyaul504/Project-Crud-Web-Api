using System.ComponentModel.DataAnnotations;

namespace Task.Models
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }
       
        public string? Status { get; set; }
        public DateTime Created_at { get; set; }
        public int UserId { get; set; } 

        //Foreign key User
        public User user { get; set; }
    }
}
