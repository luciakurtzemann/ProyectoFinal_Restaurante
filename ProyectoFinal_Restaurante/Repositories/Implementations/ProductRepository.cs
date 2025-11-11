using ProyectoFinal_Restaurante.Entities;
using ProyectoFinal_Restaurante.Repositories.Interfaces;

namespace ProyectoFinal_Restaurante.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        public Product CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Product DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByRestaurant(int restaurantId)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsFavorite()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsHappyHour()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsWithDiscount()
        {
            throw new NotImplementedException();
        }

        public int IncrementPriceByRestaurant(double increment, int restaurantId)
        {
            throw new NotImplementedException();
        }

        public int ModifyDiscount(int idProducto, double discount)
        {
            throw new NotImplementedException();
        }

        public bool ModifyHappyHour(int productId)
        {
            throw new NotImplementedException();
        }

        public Product UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }


        public static List<Product> Products = new List<Product>
        {
            new Product
            {
                ProductId = 1,
                ProductName = "Hamburguesa Clásica",
                ProductDescription = "Carne, queso, tomate y lechuga.",
                Price = 3200,
                Discount = 0,
                HappyHour = false,
                IsFavorite = true,
                RestaurantId = 1
            },
            new Product
            {
                ProductId = 2,
                ProductName = "Pizza Margarita",
                ProductDescription = "Salsa de tomate, mozzarella y albahaca fresca.",
                Price = 4500,
                Discount = 10,
                HappyHour = true,
                IsFavorite = false,
                RestaurantId = 1
            },
            new Product
            {
                ProductId = 3,
                ProductName = "Café Latte",
                ProductDescription = "Café con leche espumada.",
                Price = 1500,
                Discount = 0,
                HappyHour = true,
                IsFavorite = true,
                RestaurantId = 2
            },
            new Product
            {
                ProductId = 4,
                ProductName = "Frapuccino Vainilla",
                ProductDescription = "Café frío con vainilla y crema.",
                Price = 2200,
                Discount = 5,
                HappyHour = false,
                IsFavorite = false,
                RestaurantId = 2
            },
            new Product
            {
                ProductId = 5,
                ProductName = "Tacos de Pollo",
                ProductDescription = "Tortillas con pollo marinado, pico de gallo y salsa.",
                Price = 2800,
                Discount = 0,
                HappyHour = false,
                IsFavorite = true,
                RestaurantId = 3
            },
            new Product
            {
                ProductId = 6,
                ProductName = "Ensalada César",
                ProductDescription = "Lechuga, parmesano, croutons y pollo.",
                Price = 2600,
                Discount = 15,
                HappyHour = true,
                IsFavorite = false,
                RestaurantId = 3
            }
        };
    }
}
