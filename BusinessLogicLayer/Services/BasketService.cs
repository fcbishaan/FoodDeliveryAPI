using Microsoft.EntityFrameworkCore;
using Vashishth_Backened._24.Data;
using Vashishth_Backened._24.Dto;
using Vashishth_Backened._24.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vashishth_Backened._24.Services;

public class BasketService : IBasketService
{
    private readonly FoodDeliveryContext _context;

    public BasketService(FoodDeliveryContext context)
    {
        _context = context;
    }

    
    public async Task<List<BasketDto>> GetBasketsByUserId(Guid userId)
    {
        // Fetch baskets for the given user
        var baskets = await _context.Baskets
            .Where(b => b.UserId == userId)
            .ToListAsync();

        // Manually map Basket entities to BasketDto
        var basketDtos = baskets.Select(b => new BasketDto
        {
            Id = b.Id,
            Name = b.Name,
            Price = b.Price,
            TotalPrice = b.TotalPrice,
            Amount = b.Amount,
            Image = b.Image
        }).ToList();

        return basketDtos;
    }

    // Method to create or update a basket entry for a user
    public async Task CreateBasket(Guid dishId, Guid userId)
    {
        // Fetch the dish from the database
        var dish = await _context.Dishes.FindAsync(dishId);
        if (dish == null) return; // If the dish is not found, return early

        // Check if the user already has this dish in their basket
        var basket = await _context.Baskets
            .FirstOrDefaultAsync(b => b.UserId == userId && b.DishesId == dishId);

        if (basket == null)
        {
            // If the basket entry doesn't exist, create a new one
            basket = new Basket
            {
                UserId = userId,
                DishesId = dishId,
                Name = dish.Name,
                Price = dish.Price,
                Amount = 1,  // Initial amount is 1
                TotalPrice = dish.Price,  // Total price is initially the dish price
                Image = dish.Image
            };
            await _context.Baskets.AddAsync(basket);
        }
        else
        {
            // If the basket entry exists, update it
            basket.Amount++;  // Increase the amount
            basket.TotalPrice = basket.Price * basket.Amount;  // Recalculate the total price
        }

        // Save changes to the database
        await _context.SaveChangesAsync();
    }

    // Method to delete or update a basket item
    public async Task DeleteOrUpdateBasket(Guid dishId, Guid userId, bool decrease)
    {
        // Fetch the basket entry for the user and dish
        var basket = await _context.Baskets
            .FirstOrDefaultAsync(b => b.UserId == userId && b.DishesId == dishId);

        if (basket == null) return;  // If no basket is found, return early

        if (decrease)
        {
            // If decreasing the amount, reduce it by 1
            basket.Amount--;
            basket.TotalPrice = basket.Price * basket.Amount;  // Recalculate the total price

            // If the amount reaches zero, remove the basket entry
            if (basket.Amount <= 0)
            {
                _context.Baskets.Remove(basket);
            }
        }
        else
        {
            // If not decreasing, remove the basket entry
            _context.Baskets.Remove(basket);
        }

        // Save changes to the database
        await _context.SaveChangesAsync();
    }
           public async Task<bool> CheckIfDishExists(Guid dishId) 
        {
            var dish = await _context.Dishes.FirstOrDefaultAsync(d => d.Id == dishId);
            return dish != null;
        }
    
}


