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
        public async Task<DishesPages> page(DishCategory? categories, bool vegetarian, DishSorting? sorting, int page )
        {
            var _query = await _context.Dishes.ToListAsync();
            if(categories != null)
            {
                _query = _query.Where(t=>t.category == categories).ToList();
            }
            if(vegetarian)
            {
                _query = _query.Where(t=>t.vegetarian.Equals(vegetarian)).ToList();

            }
            if(sorting != null)
            {
                if(sorting.Value.Equals(DishSorting.NameAsc))
                {
                    _query.OrderBy(t=>t.Name);
                }
                if(sorting.Value.Equals(DishSorting.NameDesc))
                {
                    _query.OrderByDescending(t=>t.Name);
                }
                if(sorting.Value.Equals(DishSorting.PriceAsc))
                {
                    _query.OrderBy(t=>t.Price);
                }
                if(sorting.Value.Equals(DishSorting.PriceDesc))
                {
                    _query.OrderByDescending(t=> t.Price);
                }
                if(sorting.Value.Equals(DishSorting.RatingAsc))
                {
                    _query.OrderBy(t=>t.Rating);
                }
                if(sorting.Value.Equals(DishSorting.RatingDesc))
                {
                    _query.OrderByDescending(t => t.Rating);
                }
            }
                int pageSize = 5; 
                int totalCount = _context.Dishes.Count();
                int totalPages = (int)Math.Ceiling(totalCount/(double)pageSize);
                var items = _query.Skip((page-1) * pageSize).Take(pageSize).ToList();

                var pagination = new pagination()
                {
                    count = totalCount,
                    current = page,
                    size = pageSize

                };
                return new DishesPages
                {
                    Dishes = items,
                    Pagination = pagination
                };
        } 
    }
}