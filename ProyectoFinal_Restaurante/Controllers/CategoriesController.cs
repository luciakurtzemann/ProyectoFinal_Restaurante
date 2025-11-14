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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController (ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult GetAllCategoriesByRestaurant(int restaurantId)
        {
            var listaCategoriasRestaurante = _categoryService.GetCategoriesByRestaurant(restaurantId);
            return Ok (listaCategoriasRestaurante);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById (int id)
        {
            try
            {
                var categoria = _categoryService.GetCategory(id);
                return Ok(categoria);
            }
            catch (NotFoundException ex) 
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        public IActionResult UpdateCategory([FromBody]UpdateCategoryDto dto)
        {
            try
            {
                int restaurantId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0");
                var categoriaActualizada = _categoryService.UpdateCategory(dto, restaurantId);
                return Ok(categoriaActualizada);
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult CrearCategoria(CreateCategoryDto dto)
        {
            int restaurantId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0");
            var categoriaCreada = _categoryService.CreateCategory(dto, restaurantId);
            return Ok(categoriaCreada);
        }

        [HttpDelete]
        [Authorize]
        public IActionResult EliminarCategoria ([FromBody] int categoryId)
        {
            var exisoso = _categoryService.DeleteCategory(categoryId);
            if (exisoso)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
