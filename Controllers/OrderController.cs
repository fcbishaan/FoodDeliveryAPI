using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using Vashishth_Backened._24.Dto;
using Vashishth_Backened._24.Models;
using Vashishth_Backened._24.Services;

namespace Vashishth_Backened._24.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Get a list of orders for the authenticated user.
        /// </summary>
        /// <returns>A list of orders.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<OrderInfoDto>), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(Response), 500)]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                string userId = User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "";
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("Please log in to the system first.");
                }

                var orders = await _orderService.GetOrderByUserId(userId);

                if (orders == null || !orders.Any())
                {
                    return NotFound();
                }

                return Ok(JsonConvert.SerializeObject(orders));
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        /// <summary>
        /// Create a new order for the authenticated user.
        /// </summary>
        /// <param name="orderCreateDto">The details of the order to be created.</param>
        /// <returns>A response indicating success or failure.</returns>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(Response), 500)]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCreateDto orderCreateDto)
        {
            try
            {
                string userId = User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "";
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("Please log in to the system first.");
                }

                var response = await _orderService.AddUserOrder(orderCreateDto, userId);
                return Ok(response);
            }
            catch (ArgumentException)
            {
                return BadRequest("Invalid order details provided.");
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        /// <summary>
        /// Get details of a specific order.
        /// </summary>
        /// <param name="orderId">The ID of the order to retrieve.</param>
        /// <returns>The details of the order.</returns>
        [HttpGet("{orderId}")]
        [ProducesResponseType(typeof(OrderDto), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(Response), 500)]
        public async Task<IActionResult> GetOrderById(Guid orderId)
        {
            try
            {
                string userId = User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "";
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("Please log in to the system first.");
                }

                var order = await _orderService.GetOrder(orderId, userId);
                if (order == null)
                {
                    return NotFound();
                }

                return Ok(JsonConvert.SerializeObject(order));
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        /// <summary>
        /// Confirm an order.
        /// </summary>
        /// <param name="orderId">The ID of the order to confirm.</param>
        /// <returns>A response indicating success or failure.</returns>
        [HttpPost("{orderId}/confirm")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(Response), 500)]
        public async Task<IActionResult> ConfirmOrder(Guid orderId)
        {
            try
            {
                var response = await _orderService.ConfirmOrder(orderId);

                if (response.Status == "Error")
                {
                    return NotFound(response.Message);
                }

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }
    }
}
