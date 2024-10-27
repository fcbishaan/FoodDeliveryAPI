public class BasketDto
{
    public Guid Id { get; set; }  // ID of the basket item
    public string Name { get; set; }  // Name of the dish
    public double Price { get; set; }  // Price per dish
    public int TotalPrice { get; set; }  // Total price for the amount
    public int Amount { get; set; }  // Amount of the dish
    public string Image { get; set; }  // Image URL for the dish
}
