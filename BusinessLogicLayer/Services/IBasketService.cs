using Vashishth_Backened._24.Models;
using Vashishth_Backened._24.Dto;
using System.Threading.Tasks;

namespace Vashishth_Backened._24.Services
{
    public interface IBasketService
    {
        Task<List<BasketDto>> GetBasketsByUserId(int userId);
    }
}