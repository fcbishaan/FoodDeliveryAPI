using Microsoft.EntityFrameworkCore;
using Vashishth_Backened._24.Data;
using Vashishth_Backened._24.Dto;
using Vashishth_Backened._24.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vashishth_Backened._24.Services
{
    public class OrderService : IOrderService
    {
        private readonly FoodDeliveryContext _context;

        public OrderService(FoodDeliveryContext context)
        {
            _context = context;
        }

        public async Task<Response> AddUserOrder(OrderCreateDto orderCreateDto, string userId)
        {
            Guid uuid = Guid.NewGuid();
            var baskets = await _context.Baskets
                .Where(t => t.UserId == userId && string.IsNullOrEmpty(t.OrderId))
                .ToListAsync();

            foreach (var item in baskets)
            {
                item.OrderId = uuid.ToString();
            }

            var order = new Orders
            {
                Id = uuid,
                address = orderCreateDto.address,
                deliveryTime = "",
                OrderTime = DateTime.Now.ToString(),
                userId = userId,
                price = (int)baskets.Sum(t => t.TotalPrice),
                status = OrderStatus.InProcess
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return new Response
            {
                Status = "Success",
                Message = "Order created successfully.",
                data = null
            };
        }

        public async Task<List<OrderInfoDto>> GetOrderByUserId(string userId)
        {
            var orders = await _context.Orders
                .Where(order => order.userId == userId)
                .ToListAsync();

            if (orders == null || !orders.Any())
            {
                return null;
            }

            // Manually map orders to OrderInfoDto
            var orderDtos = orders.Select(order => new OrderInfoDto
            {
                Id = order.Id,
                deliveryTime = order.deliveryTime,
                orderTime = order.OrderTime,
                price = order.price,
                status = order.status
            }).ToList();

            return orderDtos;
        }

        public async Task<Response> ConfirmOrder(Guid orderId)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(t => t.Id == orderId);

            if (order == null)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Order not found.",
                    data = null
                };
            }

            order.status = OrderStatus.Delivered;
            order.deliveryTime = DateTime.Now.ToString();

            await _context.SaveChangesAsync();

            return new Response
            {
                Status = "Success",
                Message = "Order confirmed successfully.",
                data = null
            };
        }

        public async Task<OrderDto> GetOrder(Guid id, string userId)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(t => t.Id == id);

            if (order == null)
            {
                return null;
            }

            var baskets = await _context.Baskets
                .Where(t => t.UserId == userId && t.OrderId == id.ToString())
                .ToListAsync();

            
            var orderDto = new OrderDto
            {
                Id = order.Id,
                address = order.address,
                deliveryTime = order.deliveryTime,
                orderTime = order.OrderTime,
                price = order.price,
                status = order.status,
                dishes = baskets.Select(basket => new DishBasketDto
                {
                    DishesId = basket.DishesId,
                    Amount = basket.Amount,
                    TotalPrice = basket.TotalPrice,
                    
                }).ToList()
            };

            return orderDto;
        }
    }
}
