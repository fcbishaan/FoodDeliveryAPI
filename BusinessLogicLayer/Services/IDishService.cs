using Vashishth_Backened._24.Models;
using Vashishth_Backened._24.Dto;
using System.Threading.Tasks;

namespace Vashishth_Backened._24.Services
{
    public interface IDishService
    {
        Task<DishesPages> page(DishCategory? categories, bool vegetarian, DishSorting? Sorting, int page );
        Task<DishDto> GetDishById (Guid id);
        //bool CheckRating(Guid id, string userid);
		//Task<Response> SetRating(Guid id, int rating);
    }
}