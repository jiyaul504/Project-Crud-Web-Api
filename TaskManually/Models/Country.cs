using System.ComponentModel.DataAnnotations;


namespace Task.Models
{
    public class Country
    {
        [Key]
        public int Code { get; set; }
        public string? Name { get; set; }    
        public string? Continent_name {  get; set; }    
    }
}
