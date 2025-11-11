using ProyectoFinal_Restaurante.Entities;

namespace ProyectoFinal_Restaurante.Repositories.Implementations
{
    public class ProductRepository
    {


        public static List<Product> Products = new List<Product>
        {
            new Product
            {
                ProductId = 1,
                ProductName = "Hamburguesa Clásica",
                ProductDescription = "Carne, queso, tomate y lechuga.",
                Price = 3200,
                DiscountPercent = 0,
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
                DiscountPercent = 10,
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
                DiscountPercent = 0,
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
                DiscountPercent = 5,
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
                DiscountPercent = 0,
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
                DiscountPercent = 15,
                HappyHour = true,
                IsFavorite = false,
                RestaurantId = 3
            }
        };
    }
}
