using ProyectoFinal_Restaurante.Entities;
using ProyectoFinal_Restaurante.Repositories.Interfaces;

namespace ProyectoFinal_Restaurante.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        public Product CreateProduct(Product product)
        {
            _products.Add(product);
            return product;
        }

        public Product DeleteProduct(int productId)
        {
            var productAEliminar = _products.FirstOrDefault(p => p.ProductId == productId);
            if (productAEliminar == null)
            {
                throw new Exception("Producto no encontrado");
            }
            else
            {
                _products.Remove(productAEliminar);
                return productAEliminar;
            }
        }

        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public Product GetProductById(int productId)
        {
            var product = _products.FirstOrDefault(x => x.ProductId == productId);
            if (product == null)
            {
                throw new Exception ("Producto no encontrado");
            }
            return product;
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            List<Product> listadoProductsByCategory = _products.Where(x=> x.CategoryId == categoryId).ToList();
            if (listadoProductsByCategory.Count == 0)
            {
                throw new Exception("La categoría seleccionada no tiene productos.");
            }
            return listadoProductsByCategory;
        }

        public List<Product> GetProductsByRestaurant(int restaurantId)
        {
            List<Product> listadoProductByRestaurant = _products.Where(x => x.RestaurantId == restaurantId).ToList();
            if (listadoProductByRestaurant.Count == 0)
            {
                throw new Exception("El restaurante seleccionado no tiene productos.");
            }
            return listadoProductByRestaurant;
        }

        public List<Product> GetProductsFavorite()
        {
            List<Product> listadoProductFavorite = _products.Where( x => x.IsFavorite == true ).ToList();
            if (listadoProductFavorite.Count == 0)
            {
                throw new Exception("Actualmente no hay productos marcados como favoritos.");
            }
            return listadoProductFavorite;
        }

        public List<Product> GetProductsHappyHour()
        {
            List<Product> listadoProductHappyHour = _products.Where(x => x.HappyHour == true).ToList();
            if (listadoProductHappyHour.Count == 0)
            {
                throw new Exception("Actualmente no hay productos con Happy Hour.");
            }
            return listadoProductHappyHour;
        }

        public List<Product> GetProductsWithDiscount()
        {
            List<Product> listadoProductsWithDiscount = _products.Where( x => x.Discount != 0).ToList();
            if (listadoProductsWithDiscount.Count == 0)
            {
                throw new Exception("Actualmente no hay productos con descuento.");
            }
            return listadoProductsWithDiscount;
        }

        public void IncrementPriceByRestaurant(double increment, int restaurantId)
        {
            List<Product> listadoProductsByRestaurant = GetProductsByRestaurant(restaurantId);
            for (int i= 0; i<listadoProductsByRestaurant.Count; i++)
            {
                listadoProductsByRestaurant[i].Price += listadoProductsByRestaurant[i].Price * increment;
                //save changes
            }
        }

        public Product ModifyDiscount(int idProducto, double newDiscount)
        {
            var product = GetProductById(idProducto);
            product.Discount = newDiscount;
            //    _context.Products.Update(product);
            //    _context.SaveChanges();
            return product;

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
            return product.HappyHour;
        }

        public Product UpdateProduct(Product product)
        {
            var productToUpdate = _products.FirstOrDefault(x=> x.ProductId == product.ProductId);

            if (productToUpdate == null)
            {
                throw new Exception("Producto no encontrado");
            }
            else
            {
                productToUpdate.ProductName = product.ProductName;
                productToUpdate.ProductDescription = product.ProductDescription;
                productToUpdate.Price = product.Price;
                productToUpdate.Discount = product.Discount;
                productToUpdate.HappyHour = product.HappyHour; 
                //save changes
                return productToUpdate;
            }
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
