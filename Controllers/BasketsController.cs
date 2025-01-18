using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Vashishth_Backened._24.Dto;
using Vashishth_Backened._24.Services;

namespace Vashishth_Backened._24.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

       
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                string userId = User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "";
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("Please log in to the system first.");
                }

                var baskets = await _basketService.GetBasketsByUserId(userId);
                return Ok(baskets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An error occurred while processing your request.", details = ex.Message });
            }
        }

        
        [HttpPost("dish/{dishid}")]
        public async Task<IActionResult> CreateBasket(Guid dishid)
        {
            try
            {
                string userId = User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "";
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("Please log in to the system first.");
                }

                bool dishExists = await _basketService.CheckIfDishExists(dishid);
                if (!dishExists)
                {
                    return NotFound("Dish not found.");
                }

                await _basketService.CreateBasket(dishid, userId);
                return Ok(new { message = "Dish added to the basket." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An error occurred while processing your request.", details = ex.Message });
            }
        }

        ///<param name="dishid">Dish ID.</param>
        /// <param name="increase">Whether to increase or decrease quantity.</param>
        /// <returns>Success message.</returns>
        [HttpDelete("dish/{dishid}")]
        public async Task<IActionResult> DeleteBasket(Guid dishid, bool increase)
        {
            try
            {
                string userId = User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "";
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("Please log in to the system first.");
                }

                var basket = await _basketService.GetBasketByDishIdAndUserId(dishid, userId);
                if (basket == null)
                {
                    return NotFound("Basket entry not found.");
                }

                await _basketService.DeleteBaskets(dishid, userId, increase);
                return Ok(new { message = "Basket updated successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An error occurred while processing your request.", details = ex.Message });
            }
        }
    }
}
