using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Vashishth_Backened._24.Data;
using Vashishth_Backened._24.Dto;
using Vashishth_Backened._24.Models;
using Vashishth_Backened._24.Services;

namespace Vashishth_Backened._24
{
    public class OrderService: IOrderService
    {
        public readonly FoodDeliveryContext _context;
        public OrderService(FoodDeliveryContext context)
        {
            _context = context;
        }   
         public async Task<Response> AddUserOrder(OrderCreateDto orderCreateDto, string userid)
        {
            Guid uuid = Guid.NewGuid();
            var baskets = await _context.Baskets
                .Where(t => t.UserId == userid && t.OrderId == "").ToListAsync();

            foreach (var item in baskets)
            {
                item.OrderId = uuid.ToString();
            }

            var add = new Orders
            {
                Id = uuid,
                address = orderCreateDto.address,
                deliveryTime = "",
                OrderTime = DateTime.Now.ToString(),
                userId = userid,
                price = (int)baskets.Sum(t => t.TotalPrice),
                status = OrderStatus.InProcess
            };

            await _context.Orders.AddAsync(add);
            await _context.SaveChangesAsync();

            return new Response
            {
                Status = "Success",
                Message = "Order created successfully.",
                data = null
            };
        }
    }
}
