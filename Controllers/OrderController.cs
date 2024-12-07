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

    }
}