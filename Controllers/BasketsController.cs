using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vashishth_Backened._24.Dto;
using Vashishth_Backened._24.Services;
using Vashishth_Backened._24.Models;
using System.Security.Claims;

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

        // GET: api/Basket/{userId}
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                string userid = User?.Claims.FirstOrDefault(c=>c.Type==ClaimTypes.NameIdentifier)?.Value ?? "";
                if(string.IsNullOrEmpty(userid))
                {
                    return Unauthorized("PLease log in the system first");
                }
                var res = await _basketService.GetBasketsByUserId(Guid.Parse(userid));
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }


             [HttpPost("dish/{dishid}")]
        public async Task<IActionResult> CreateBaskets(Guid dishid)
		{
            try
            {
                string userid = User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "";
                if (string.IsNullOrEmpty(userid))
                {

                    return Unauthorized("Please log in to the system first");
                }

                bool dishExists = await _basketService.CheckIfDishExists(dishid);
                if (!dishExists)
                {
                    return NotFound(); 
                }


                await _basketService.CreateBasket(dishid,Guid.Parse(userid));
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

        }
        /*
        [HttpDelete ("dish/{dishid}")]
        public async Task<ActionResult> deleteBaskets (Guid dishid, bool Increase)
        {
            try 
            {
                string userid= User.Claims.FirstOrDefault(c=>c.Type==ClaimTypes.Authentication)?.Value ?? "";
                if(string.IsNullOrEmpty(userid))
                {
                    return Unauthorized("Please log in to the system");

                }
                var basket = await _basketService.GetBasketsByUserId(dishid, userid);
                if(basket == null)
                {
                    return NotFound();
                }
                await _basketService.DeleteOrUpdateBasket(dishid,userid,increase);
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
        }*/

     
        
    }
}
