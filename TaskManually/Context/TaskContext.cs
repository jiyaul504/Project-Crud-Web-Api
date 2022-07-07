using Microsoft.EntityFrameworkCore;
using Task.Models;

namespace TaskManually.Context
{
    public class TaskContext : DbContext
    {
        //internal IEnumerable<object> countries;

        public TaskContext(DbContextOptions options) : base(options) { }
       
        DbSet<Orderitems>? orderitem { set; get; }
        DbSet<Orders>? orders { set; get; }
        DbSet<Product>? products { set; get; }
        DbSet<User>? users { set; get; }



        public DbSet<Task.Models.Country>? Country { get; set; }
        public DbSet<Task.Models.User>? Users { get; set; }
        public DbSet<Task.Models.Merchants>? Merchants { get; set; }
        public DbSet<Task.Models.Product>? Products { get; set; }
        public DbSet<Task.Models.Orderitems>? Orderitems { get; set; }
        public DbSet<Task.Models.Orders>? Orders { get; set; }
    }
    

}
