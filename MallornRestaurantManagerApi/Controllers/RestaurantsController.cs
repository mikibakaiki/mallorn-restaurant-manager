using MallornRestaurantManagerApi.Models;
using MallornRestaurantManagerApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MallornRestaurantManagerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantsController : ControllerBase
    {
        private readonly RestaurantsService _restaurantsService;

        public RestaurantsController(RestaurantsService restaurantsService) =>
            _restaurantsService = restaurantsService;

        [HttpGet]
        public async Task<List<Restaurant>> Get() =>
            await _restaurantsService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Restaurant>> Get(string id)
        {
            var restaurant = await _restaurantsService.GetAsync(id);

            if (restaurant is null)
            {
                return NotFound();
            }

            return restaurant;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Restaurant newRestaurant)
        {
            await _restaurantsService.CreateAsync(newRestaurant);

            return CreatedAtAction(nameof(Get), new { id = newRestaurant.Id }, newRestaurant);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Restaurant updatedRestaurant)
        {

            var restaurant = await _restaurantsService.GetAsync(id);

            if (restaurant is null)
            {
                return NotFound();
            }

            updatedRestaurant.Id = restaurant.Id;

            await _restaurantsService.UpdateAsync(id, updatedRestaurant);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var restaurant = await _restaurantsService.GetAsync(id);

            if (restaurant is null)
            {
                return NotFound();
            }

            await _restaurantsService.RemoveAsync(restaurant.Id);

            return NoContent();
        }
    }
}