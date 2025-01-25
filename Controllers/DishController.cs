using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Vashishth_Backened._24.Dto;
using Vashishth_Backened._24.Models;
using Vashishth_Backened._24.Services;

namespace Vashishth_Backened._24.Controllers
{
    [Route("api/dish")]
	[ApiController]
    public class DishController : ControllerBase
    {
        private readonly IDishService _dishService;

        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }
    [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
       [HttpGet]
        public async Task<ActionResult<DishesPages>> page(DishCategory? categories, bool vegetarian, DishSorting? Sorting, int page=1 )

        {
            try
            {
                var dishes = await _dishService.page(categories,vegetarian,Sorting,page);
                return Ok(await _dishService.page(categories,vegetarian,Sorting,page));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task <IActionResult> GetDishById(Guid id)
        {
            try 
            {
                var dish = await _dishService.GetDishById(id);
                if(dish == null)
                {
                    return NotFound();
                }
                return Ok(dish);
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
        }
        [HttpPost("{id}/rating")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
		public async Task<IActionResult> AddRating(Guid id, int rating)
		{
            try
            {
                string userid = User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "";
                if (string.IsNullOrEmpty(userid))
                {
                    return Unauthorized("Please log in to the system first");
                }

                var res = await _dishService.SetRating(id, rating);

                if (res == null)
                {
                    return NotFound(); 
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
              [HttpGet("{id}/rating/check")]
                public IActionResult CheckRating(Guid id)
		{
            try
            {
                string userid = User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "";
                if (string.IsNullOrEmpty(userid))
                {
                    return Unauthorized("Please log in to the system first");
                }

                return Ok(_dishService.CheckRating(id, userid));
            }
            catch (ArgumentException ex)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}