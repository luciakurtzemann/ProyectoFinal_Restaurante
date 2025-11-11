using ProyectoFinal_Restaurante.Entities;
using ProyectoFinal_Restaurante.Models.DTOs.Requests;
using ProyectoFinal_Restaurante.Models.DTOs.Responses;

namespace ProyectoFinal_Restaurante.Services.Interfaces
{
    public interface IProductService
    {
        public List<ProductDto> GetAllProducts();
        public List<ProductDto> GetProductsByRestaurant(int restaurantId);
        public List<ProductDto> GetProductsByCategory(int categoryId);
        public ProductDto GetProductById(int productId);
        public List<ProductDto> GetProductsFavorite();
        public List<ProductDto> GetProductsWithDiscount();
        public List<ProductDto> GetProductsHappyHour();
        public ProductDto CreateProduct(CreateProductDto productDto);
        public ProductDto UpdateProduct(UpdateProductDto productDto);
        public ProductDto DeleteProduct(int productId);
        public ProductDto ModifyDiscount(int idProducto, double discount);
        public void IncrementPriceByRestaurant(double increment, int restaurantId);
        public bool ModifyHappyHour(int productId);
    }
}
