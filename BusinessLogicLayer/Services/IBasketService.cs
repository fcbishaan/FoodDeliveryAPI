using Vashishth_Backened._24.Models;
using Vashishth_Backened._24.Dto;
using System.Threading.Tasks;

namespace Vashishth_Backened._24.Services
{
    public interface IBasketService
    {
        Task<List<BasketDto>> GetBasketsByUserId(Guid userId);
        Task CreateBasket(Guid dishId, Guid userId);
        Task DeleteOrUpdateBasket(Guid dishId, Guid userId, bool decrease);
        Task<bool> CheckIfDishExists(Guid dishId); 
    }
}