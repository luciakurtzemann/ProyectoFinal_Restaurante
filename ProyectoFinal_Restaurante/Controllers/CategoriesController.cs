using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_Restaurante.Services.Interfaces;

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
    }
}
