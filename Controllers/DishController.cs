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
    }
}