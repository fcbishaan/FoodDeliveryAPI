using Vashishth_Backened._24.Models;
using Vashishth_Backened._24.Dto;
using System.Threading.Tasks;

namespace Vashishth_Backened._24.Services
{
    public interface IBasketService
    {
        Task<List<DishBasketDto>> GetBasketsByUserId( string userid);
        Task CreateBasket(Guid dishid, string userid);
         Task DeleteBaskets(Guid dishid, string userid, bool increase);
        Task<bool> CheckIfDishExists(Guid dishId); 
       Task<Basket> GetBasketByDishIdAndUserId(Guid dishid, string userid);
    }
}
