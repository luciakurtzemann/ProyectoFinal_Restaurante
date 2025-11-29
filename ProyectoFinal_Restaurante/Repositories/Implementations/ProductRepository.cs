using ProyectoFinal_Restaurante.Data;
using ProyectoFinal_Restaurante.Entities;
using ProyectoFinal_Restaurante.Repositories.Interfaces;

namespace ProyectoFinal_Restaurante.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProyectoFinal_RestauranteContext _context;

        public ProductRepository (ProyectoFinal_RestauranteContext context)
        {
            _context = context;
        }

        public Product CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product DeleteProduct(int productId)
        {
            var productAEliminar = _context.Products.FirstOrDefault(p => p.ProductId == productId);
            _context.Products.Remove(productAEliminar);
            _context.SaveChanges();
            return productAEliminar;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int productId)
        {
            var product = _context.Products.FirstOrDefault(x => x.ProductId == productId);
            return product;
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            List<Product> listadoProductsByCategory = _context.Products.Where(x=> x.CategoryId == categoryId).ToList();
            return listadoProductsByCategory;
        }

        public List<Product> GetProductsByRestaurant(int restaurantId)
        {
            List<Product> listadoProductByRestaurant = _context.Products.Where(x => x.RestaurantId == restaurantId).ToList();
            return listadoProductByRestaurant;
        }

        public List<Product> GetProductsFavorite()
        {
            List<Product> listadoProductFavorite = _context.Products.Where( x => x.IsFavorite == true ).ToList();
            return listadoProductFavorite;
        }

        public List<Product> GetProductsHappyHour()
        {
            List<Product> listadoProductHappyHour = _context.Products.Where(x => x.HappyHour == true).ToList();
            return listadoProductHappyHour;
        }

        public List<Product> GetProductsWithDiscount()
        {
            List<Product> listadoProductsWithDiscount = _context.Products.Where( x => x.Discount != 0).ToList();
            return listadoProductsWithDiscount;
        }

        public void IncrementPriceByRestaurant(double increment, int restaurantId)                  //VER SI FUNCIONA!!
        {
            List<Product> listadoProductsByRestaurant = GetProductsByRestaurant(restaurantId);
            for (int i= 0; i<listadoProductsByRestaurant.Count; i++)
            {
                listadoProductsByRestaurant[i].Price += listadoProductsByRestaurant[i].Price * increment;
            }
            _context.SaveChanges();
        }

        public bool ModifyDiscount(int idProducto, double newDiscount)
        {
            var product = GetProductById(idProducto);
            if (product != null)
            {
                product.Discount = newDiscount;
                //_context.Products.Update(product);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool ModifyHappyHour(int productId)
        {
            var product = GetProductById(productId);
            if (product.HappyHour == true)
            {
                product.HappyHour = false;
            }
            else
            {
                product.HappyHour = true;
            }
            _context.SaveChanges();
            return product.HappyHour;
        }

        public Product UpdateProduct(Product product)
        {
            var productToUpdate = _context.Products.FirstOrDefault(x=> x.ProductId == product.ProductId);

            if (productToUpdate != null)
            {
                productToUpdate.ProductName = product.ProductName;
                productToUpdate.ProductDescription = product.ProductDescription;
                productToUpdate.Price = product.Price;
                productToUpdate.Discount = product.Discount;
                productToUpdate.HappyHour = product.HappyHour;
                _context.SaveChanges();
                return productToUpdate;
            }
            return null;
        }

        public int GetRestaurantId (int idProducto)
        {
            var producto = _context.Products.FirstOrDefault(x => x.ProductId == idProducto);
            if (producto != null)
            {
                return producto.RestaurantId;
            }
            return 0;
        }


        public static List<Product> _products = new List<Product>
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
