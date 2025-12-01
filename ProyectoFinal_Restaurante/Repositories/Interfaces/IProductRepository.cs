using ProyectoFinal_Restaurante.Entities;
using ProyectoFinal_Restaurante.Models.DTOs.Requests;

namespace ProyectoFinal_Restaurante.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public List<Product> GetAllProducts();
        public List<Product> GetProductsByRestaurant(int restaurantId);
        public List<Product> GetProductsByCategory (int categoryId);
        public Product GetProductById (int productId);
        public List<Product> GetProductsFavorite();
        public List<Product> GetProductsWithDiscount();
        public List<Product> GetProductsHappyHour();
        public Product CreateProduct(Product product);
        public Product UpdateProduct(Product product);
        public Product DeleteProduct(int productId);
        public bool ModifyDiscount (int idProducto,  double discount);
        public void IncrementPriceByRestaurant(double increment, int restaurantId);
        public bool ModifyHappyHour (int productId);
        public int GetRestaurantId(int idProducto);
        public bool ChangeFavorite(int idProducto);
    }
}
