using System.Text.Json.Serialization;
using Vashishth_Backened._24.Models;

namespace Vashishth_Backened._24.Dto
{
  public class DishBasketDto
{
    public Guid Id { get; set; } 
    public string Name { get; set; } 
    public double Price { get; set; } 
    public double TotalPrice { get; set; } 
    public int Amount { get; set; } 
    public string Image { get; set; } = "No image available"; 
  
   public string DishesId { get; set; } 
      public string UserId { get; set; } 
    
    public string OrderId { get; set; }
}

}