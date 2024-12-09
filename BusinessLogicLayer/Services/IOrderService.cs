using Vashishth_Backened._24.Models;
using Vashishth_Backened._24.Dto;
using System.Threading.Tasks;

namespace Vashishth_Backened._24.Services
{
    public interface IOrderService
    {
       	Task<Response> AddUserOrder(OrderCreateDto orderCreateDto, string userid);
        Task<List<OrderInfoDto>> GetOrderByUserId (string userid);
        Task<Response> ConfirmOrder(Guid orderId);
         Task<OrderDto> GetOrder(Guid id, string userId);

    }
}