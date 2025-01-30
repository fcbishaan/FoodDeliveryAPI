using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Vashishth_Backened._24.Data;
using Vashishth_Backened._24.Dto;
using Vashishth_Backened._24.Models;
using Vashishth_Backened._24.Services;

namespace Vashishth_Backened._24
{
    public class DishService: IDishService
    {
        public readonly FoodDeliveryContext _context;
        public DishService(FoodDeliveryContext context)
        {
            _context = context;
        }   
        [AllowAnonymous]
       public async Task<DishesPages> page(DishCategory? categories, bool vegetarian, DishSorting? sorting, int page)
{
    IQueryable<Dish> _query = _context.Dishes; 

    if (categories != null)
    {
        _query = _query.Where(t => t.Category == categories);
    }
    if (vegetarian)
    {
        _query = _query.Where(t => t.Vegetarian.Equals(vegetarian));
    }
    if (sorting != null)
    {
        switch (sorting.Value)
        {
            case DishSorting.NameAsc:
                _query = _query.OrderBy(t => t.Name);
                break;
            case DishSorting.NameDesc:
                _query = _query.OrderByDescending(t => t.Name);
                break;
            case DishSorting.PriceAsc:
                _query = _query.OrderBy(t => t.Price);
                break;
            case DishSorting.PriceDesc:
                _query = _query.OrderByDescending(t => t.Price);
                break;
            case DishSorting.RatingAsc:
                _query = _query.OrderBy(t => t.Rating);
                break;
            case DishSorting.RatingDesc:
                _query = _query.OrderByDescending(t => t.Rating);
                break;
        }
    }

    int pageSize = 5;
    int totalCount = await _query.CountAsync(); // Count should be performed before pagination
    int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

    var items = await _query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

    var pagination = new Pagination()
    {
        count = totalCount,
        current = page,
        size = pageSize
    };

    return new DishesPages
    {
        Dishes = items.Select(i => new DishDto
        {
            Id = i.Id,
            Name = i.Name,
            Description = i.Description,
            Price = i.Price,
            Category = i.Category,
            Vegetarian = i.Vegetarian,
            Rating = i.Rating,
            Image = i.Image
        }).ToList(),
        Pagination = pagination
    };
}

        [AllowAnonymous]
        public async Task<DishDto> GetDishById(Guid id)
        {
            var dish = await _context.Dishes.FindAsync(id);
            if(dish == null)
            {
                return null;
            }
            return new DishDto
            {
                Id = dish.Id,
                Name = dish.Name,
                Description = dish.Description,
                Price = dish.Price,
                Category = dish.Category,
                Vegetarian = dish.Vegetarian,
                Rating = dish.Rating,
                Image = dish.Image
            };
        }
        	public bool CheckRating(Guid id, string userid)
		{

			var entity = _context.Baskets.Where(e => e.DishesId == id.ToString() && e.UserId == userid && e.OrderId != "").ToList();

			return entity.Count() > 0 ? true : false;
		}

		public async Task<Response> SetRating(Guid id, int rating)
		{
			var entity = await _context.Dishes.FirstOrDefaultAsync(e => e.Id == id);
			if (entity != null)
			{
				entity.Rating = rating;
				await _context.SaveChangesAsync();
				return new Response { Status = "Success", Message = "ok" };

			}
			else
			{
				return null;
			}
		}
        public async Task <Response> CreateDish (DishDto dishDto)
        {
            var dish = new Dish
            {
                Id = Guid.NewGuid(),
                Name = dishDto.Name,
                Description = dishDto.Description,
                Price = dishDto.Price,
                Category = dishDto.Category,
                Vegetarian = dishDto.Vegetarian,
                Image = dishDto.Image
            };

            _context.Dishes.Add(dish);
            await _context.SaveChangesAsync();
            return new Response {Status = "success", Message = "Dish Created Successfully"};
        }
        public async Task<Response> UpdateDish(Guid id, DishDto dishDto)
        {
            var dish = await _context.Dishes.FindAsync(id);
            if (dish == null )
            {
                return new Response {Status = "Error" , Message = "Dish not found"};
            }
            dish.Name = dishDto.Name;
            dish.Description = dishDto.Description;
            dish.Price = dishDto.Price;
            dish.Category = dishDto.Category;
            dish.Vegetarian = dishDto.Vegetarian;
            dish.Image = dishDto.Image;

            await _context.SaveChangesAsync();
            return new Response {Status = "success", Message = "Dish Updated Successfully"};

        }
        public async Task<Response> DeleteDish (Guid id)
        {
            var dish = await _context.Dishes.FindAsync(id);
            if(dish == null )
            {
                return new Response { Status = "Error", Message = "Dish Not Found" };
            }
            _context.Dishes.Remove(dish);
            await _context.SaveChangesAsync();
            return new Response { Status = "Success", Message = "Dish Deleted Successfully" };
        }
    }
}