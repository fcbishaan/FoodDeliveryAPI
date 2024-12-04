public class Basket
{
    public Guid Id { get; set; }
    public string Name { get; set; } 
    public double Price { get; set; } 
    public int Amount { get; set; } 
    public string Image { get; set; }


    public double TotalPrice {get; set;}

    // Foreign keys
    public Guid DishesId { get; set; } // Dish ID
    public Guid UserId { get; set; } // User ID
    public Guid? OrderId { get; set; } // Order ID (nullable for when it's not placed yet)
   
}
