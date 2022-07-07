using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        public string? Full_Name { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public string? DOB { get; set; }
        public DateTime Created_at { get; set; }

        public int CountryCode { get; set; }

        //Foreign key 

        public Country Country { get; set; }
        
        

    }
}

