using Vashishth_Backened._24.Models;

namespace Vashishth_Backened._24.Dto
{
  public class DishBasketDto
{
    public Guid Id { get; set; } 
    public string Name { get; set; } 
    public double Price { get; set; } // Matches the model
    public double TotalPrice { get; set; } // Matches the model
    public int Amount { get; set; } // Matches the model
    public string Image { get; set; } // Matches the model
    public string DishesId { get; set; } // Matches the model
    public string UserId { get; set; } // Matches the model
    public string OrderId { get; set; } // Matches the model
}

}