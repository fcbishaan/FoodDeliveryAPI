using Microsoft.EntityFrameworkCore;
using Vashishth_Backened._24.Data;
using Vashishth_Backened._24.Dto;
using Vashishth_Backened._24.Models;
using Vashishth_Backened._24.Services;

public class BasketService : IBasketService
{
    private readonly FoodDeliveryContext _context;

    public BasketService(FoodDeliveryContext context)
    {
        _context = context;
    }

    public async Task<List<DishBasketDto>> GetBasketsByUserId(string userId)
    {
        var baskets = await _context.Baskets
            .Where(b => b.UserId == userId) 
            .ToListAsync();

        return baskets.Select(b => new DishBasketDto
        {
            Id = b.Id,
            Name = b.Name,
            Price = b.Price,
            TotalPrice = b.TotalPrice,
            Amount = b.Amount,
            Image = b.Image
        }).ToList();
    }

    public async Task CreateBasket(Guid dishid, string userid)
{
    var dish = await _context.Dishes.FirstOrDefaultAsync(t => t.Id == dishid);
    if (dish == null) return;

    // Find an existing basket entry for the same user and dish with no associated order
    var basket = await _context.Baskets
        .FirstOrDefaultAsync(t => t.UserId == userid && t.DishesId == dishid.ToString() && t.OrderId == "");

    if (basket == null)
    {
        // Create a new basket entry if it doesn't exist
        var newBasket = new Basket
        {
            Id = Guid.NewGuid(), // Generate a new GUID for the basket
            DishesId = dishid.ToString(),
            UserId = userid,
            Name = dish.Name,
            Price = dish.Price,
            TotalPrice = dish.Price,
            Amount = 1,
            Image = dish.Image,
            OrderId = "" // Empty order ID signifies it's not part of any order yet
        };

        await _context.Baskets.AddAsync(newBasket);
    }
    else
    {
        // Update the existing basket entry
        basket.Amount++;
        basket.TotalPrice = basket.Price * basket.Amount;
    }

    await _context.SaveChangesAsync();
}


public async Task DeleteBaskets(Guid dishid, string userid, bool increase)
{
   if(increase)
   {
       var basket = await _context.Baskets.FirstOrDefaultAsync(t=>t.UserId == userid && t.DishesId == dishid.ToString() && t.OrderId == "");
       if(basket!=null)
       {
          basket.TotalPrice = basket.Price * (basket.Amount - 1);
          basket.Amount = basket.Amount - 1; 
        }
    }
    else
    {
        var modle = await _context.Baskets.FirstOrDefaultAsync(t=>t.UserId == userid && t.DishesId == dishid.ToString() && t.OrderId == "");
         if(modle!=null)
        {
       _context.Baskets.Remove(modle);
       }
    }
    await _context.SaveChangesAsync();
 
}


    public async Task<bool> CheckIfDishExists(Guid dishId)
    {
        var dish = await _context.Dishes.FirstOrDefaultAsync(d => d.Id == dishId);
        return dish != null;
    }

    public async Task<Basket> GetBasketByDishIdAndUserId(Guid dishId, string userId)
    {
        return await _context.Baskets
            .FirstOrDefaultAsync(b => b.DishesId == dishId.ToString() && b.UserId == userId);
    }
}
