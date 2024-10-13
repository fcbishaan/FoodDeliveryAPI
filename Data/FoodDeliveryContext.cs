using Microsoft.EntityFrameworkCore;
using Vashishth_Backened._24.Models;

namespace Vashishth_Backened._24
{
    public class FoodDeliveryContext : DbContext
    {
        public FoodDeliveryContext(DbContextOptions<FoodDeliveryContext>options) : base(options)
        {

        }
        public DbSet<Dish> Dishes {get; set;}
        public DbSet<User> Users {get; set;}
        //public DbSet<Order> Orders {get; set;}
    }   
}
