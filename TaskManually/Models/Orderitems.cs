using System.ComponentModel.DataAnnotations;


namespace Task.Models
{
    public class Orderitems
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int OrdersId { get; set; }   

        //Foreign key 
        public Product Product { get; set; }
        public Orders Orders { get; set; }
    }
}
