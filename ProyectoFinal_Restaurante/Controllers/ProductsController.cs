using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_Restaurante.Models.DTOs.Requests;
using ProyectoFinal_Restaurante.Services.Interfaces;
using System.Security.Claims;

namespace ProyectoFinal_Restaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController (IProductService productService)
        {
            _productService = productService;
        }

        //ENDPOINTS
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                var productoBuscado = _productService.GetProductById(id);
                return Ok(productoBuscado);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("categoria{categoryId}")]
        public IActionResult GetProductsByCategory (int categoryId)
        {
            var listaProductosCategoria = _productService.GetProductsByCategory(categoryId);
            return Ok(listaProductosCategoria);
        }

        [HttpGet("restaurante{restaurantId}")]
        public IActionResult GetProductsByRestaurant (int restaurantId)
        {
            var listaProductosRestaurante = _productService.GetProductsByRestaurant(restaurantId);
            return Ok(listaProductosRestaurante);
        }


        [HttpGet("favoritos")]
        public IActionResult GetProductsFavorite()
        {
            var listaProductosFavoritos = _productService.GetProductsFavorite();
            return Ok(listaProductosFavoritos);
        }

        [HttpGet("happyHour")]
        public IActionResult GetProductsHappyHour()
        {
            var listaProductosHappyHour = _productService.GetProductsHappyHour();
            return Ok(listaProductosHappyHour);
        }

        [HttpGet("descuento")]
        public IActionResult GetProductsDiscount()
        {
            var listaProductosDescuento = _productService.GetProductsWithDiscount();
            return Ok(listaProductosDescuento);
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateProduct([FromBody] CreateProductDto product)
        {
            int restaurantId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0");
            var productoCreado = _productService.CreateProduct(product, restaurantId);
            return Ok(productoCreado);
        }

        [HttpDelete]
        [Authorize]
        public IActionResult DeleteProduct(int id)
        {
            var eliminado = _productService.DeleteProduct(id);
            if (eliminado)
            {
                return NoContent();
            }
            return NotFound("El producto que desea eliminar no existe.");
        }

        [HttpPut("{id}/incrementPrice")]
        [Authorize]
        public IActionResult IncrementPrice (double incrementoPrecio)
        {
            int restaurantId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0");
            _productService.IncrementPriceByRestaurant(incrementoPrecio, restaurantId);
            return NoContent();
        }

        [HttpPut("{id}/happyHour")]
        [Authorize]
        public IActionResult ModificarHappyHour ([FromBody] int productId)
        {
            int restaurantId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0");
            var exitoso = _productService.ModifyHappyHour(productId, restaurantId);
            if (exitoso)
            {
                return NoContent();
            }
            return NotFound("El producto que desea modificar no existe.");
        }

        [HttpPut("{id}/descuento")]
        [Authorize]
        public IActionResult ModificarDescuento([FromBody] int productId, double discount)
        {
            try
            {
                int restaurantId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0");
                var product = _productService.ModifyDiscount(productId, discount, restaurantId);
                return Ok(product);
            }
            catch (Exception ex)                                         ///////////////////////////////////////////////
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        [Authorize]
        public IActionResult ActualizarProducto ([FromBody]UpdateProductDto product)
        {
            try
            {
                int restaurantId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0");
                var productoModificado = _productService.UpdateProduct(product, restaurantId);
                return Ok(productoModificado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
