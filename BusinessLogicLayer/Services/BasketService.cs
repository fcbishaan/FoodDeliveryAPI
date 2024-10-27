using Microsoft.EntityFrameworkCore;
using Vashishth_Backened._24.Data;
using Vashishth_Backened._24.Services;


public class BasketService : IBasketService
{
    private readonly FoodDeliveryContext _context;

    public BasketService(FoodDeliveryContext context)
    {
        _context = context;
    }
    public async Task<List<BasketDto>> GetBasketsByUserId(int userId)
{
    var baskets = await _context.Baskets
                                .Where(b => b.UserId == userId)
                                .ToListAsync();

    return baskets.Select(b => new BasketDto
    {
        Id = b.Id,
        Name = b.Name,
        Price = b.Price,
        TotalPrice = b.TotalPrice,
        Amount = b.Amount,
        Image = b.Image
    }).ToList();
}

}