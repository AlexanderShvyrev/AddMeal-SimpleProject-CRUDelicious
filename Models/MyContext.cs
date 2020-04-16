using Microsoft.EntityFrameworkCore;


namespace DojoCrudelicious.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options){}

        public DbSet<User> Users {get; set;}
        public DbSet<Dish> Dishes {get; set;}
    }
}