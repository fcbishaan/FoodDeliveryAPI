using Vashishth_Backened._24.Models;

namespace Vashishth_Backened._24.Dto
{
    public class DishDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public DishCategory Category { get; set; }
    public Boolean Vegetarian { get; set; }
    public double Rating { get; set; }
    public string Image { get; set; }
}


}