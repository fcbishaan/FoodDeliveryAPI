using Microsoft.EntityFrameworkCore;
using Vashishth_Backened._24.Models;

namespace Vashishth_Backened._24.Data
{
    public class FoodDeliveryContext : DbContext
    {
        public FoodDeliveryContext(DbContextOptions<FoodDeliveryContext> options) : base(options)
        {
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Basket> Baskets {get; set;}
        public DbSet<Orders> Orders {get; set;}
        public DbSet<StorageToken> StorageTokens {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure DishCategory to be saved as a string in the database
            modelBuilder.Entity<Dish>()
                .Property(d => d.Category)
                .HasConversion<string>();

            // Seeding Dishes data
            modelBuilder.Entity<Dish>().HasData(
                new Dish
                {
                    Id = Guid.NewGuid(),
                    Name = "4 сыра",
                    Description = "4 сыра: «Моцарелла», «Гауда», «Фета», «Дор-блю», сливочно-сырный соус, пряные травы",
                    Price = 360,
                    Image = "https://mistertako.ru/uploads/products/77888c7e-8327-11ec-8575-0050569dbef0.",
                    Vegetarian = true,
                    Rating = 4,
                    Category = DishCategory.Pizza
                },
                new Dish
                {
                    Id = Guid.NewGuid(),
                    Name = "Party BBQ",
                    Description = "Бекон, соленый огурчик, брусника, сыр «Моцарелла», сыр «Гауда», соус BBQ",
                    Price = 480,
                    Image = "https://mistertako.ru/uploads/products/839d0250-8327-11ec-8575-0050569dbef0.",
                    Vegetarian = false,
                    Rating = 0,
                    Category = DishCategory.Pizza
                },
                new Dish
                {
                    Id = Guid.NewGuid(),
                    Name = "Wok а-ля Диаблo",
                    Description = "Пшеничная лапша обжаренная на воке с колбасками пепперони, маслинами, сладким перцем и перцем халапеньо в томатном соусе с добавлением петрушки.",
                    Price = 330,
                    Image = "https://mistertako.ru/uploads/products/663ab868-85ec-11ea-a9ab-86b1f8341741.jpg",
                    Vegetarian = false,
                    Rating = 5,
                    Category = DishCategory.Wok
                },
                new Dish
                {
                    Id = Guid.NewGuid(),
                    Name = "Wok болоньезе",
                    Description = "Пшеничная лапша обжаренная на воке с фаршем (Говядина/свинина) и овощами.",
                    Price = 290,
                    Image = "https://mistertako.ru/uploads/products/663ab866-85ec-11ea-a9ab-86b1f8341741.jpg",
                    Vegetarian = false,
                    Rating = 0,
                    Category = DishCategory.Wok
                },
                new Dish
                {
                    Id = Guid.NewGuid(),
                    Name = "Wok том ям с курицей",
                    Description = "Лапша пшеничная, куриное филе, шампиньоны, лук красный, заправка Том Ям.",
                    Price = 280,
                    Image = "https://mistertako.ru/uploads/products/a41bd9fd-54ed-11ed-8575-0050569dbef0.jpg",
                    Vegetarian = false,
                    Rating = 0,
                    Category = DishCategory.Wok
                }
            );

            // Call base method
            base.OnModelCreating(modelBuilder);
        }
    }
}