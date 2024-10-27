using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vashishth_Backened._24.Dto; // Make sure you have this namespace for BasketDto
using Vashishth_Backened._24.Services; // Import your service namespace

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

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<BasketDto>>> GetBasketsByUserId(int userId)
        {
            // Call the service to get the baskets for the specified user ID
            var baskets = await _basketService.GetBasketsByUserId(userId);

            if (baskets == null || baskets.Count == 0)
            {
                return NotFound("No baskets found for the user.");
            }

            return Ok(baskets); // Return the list of baskets
        }
    }
}
