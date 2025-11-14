using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_Restaurante.Exceptions;
using ProyectoFinal_Restaurante.Models.DTOs.Requests;
using ProyectoFinal_Restaurante.Services.Interfaces;
using System.Security.Claims;

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

        [HttpPost]
        public IActionResult CrearRestaurante (CreateRestaurantDto dto)
        {
            var restauranteCreado = _restaurantService.CreateRestaurant(dto);
            return Ok(restauranteCreado);
        }

        [HttpDelete]
        [Authorize]
        public IActionResult EliminarRestaurante (int id)
        {
            try
            {
                int restaurantId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0");
                var exitoso = _restaurantService.DeleteRestaurant(id, restaurantId);
                if (exitoso)
                {
                    return NoContent();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        public IActionResult ActualizarRestaurante([FromBody]UpdateRestaurantDto dto)
        {
            try
            {
                int restaurantId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0");
                var restauranteActualizado = _restaurantService.UpdateRestaurant(dto, restaurantId);
                return Ok(restauranteActualizado);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        public IActionResult CambiarCredenciales (UpdateCredentialsDto updateCredentialsDto)
        {
            try
            {
                int restaurantId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0");
                var contraseñaCambiada = _restaurantService.ChangePassword(updateCredentialsDto, restaurantId);
                return Ok(contraseñaCambiada);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
