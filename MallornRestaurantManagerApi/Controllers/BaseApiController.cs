using Microsoft.AspNetCore.Mvc;

namespace MallornRestaurantManagerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController<T> : ControllerBase
    {
        private readonly T _service;

        public BaseApiController(T service) =>
            _service = service;

    }
}