using Microsoft.EntityFrameworkCore;
using Vashishth_Backened._24.Models;

namespace Vashishth_Backened._24.Data
{
    public class FoodDeliveryContext : DbContext
    {
        public FoodDeliveryContext(DbContextOptions<FoodDeliveryContext>options) : base(options)
        {

        }
        public DbSet<Dish> Dishes {get; set;}
        public DbSet<User> Users {get; set;}
        
    }   
}
