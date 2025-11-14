using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_Restaurante.Services.Interfaces;

namespace ProyectoFinal_Restaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantsController (IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

    }
}
