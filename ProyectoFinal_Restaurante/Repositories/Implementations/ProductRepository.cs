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

        public bool ChangeFavorite (int idProducto)
        {
            var producto = _context.Products.FirstOrDefault(x => x.ProductId == idProducto);
            if (producto != null)
            {
                producto.IsFavorite = !producto.IsFavorite;
                _context.SaveChanges ();
                return producto.IsFavorite;
            }
            return false;
        }

        public bool ChangeDisponibilidad(int idProducto)
        {
            var producto = _context.Products.FirstOrDefault(x => x.ProductId == idProducto);
            if (producto != null)
            {
                producto.Agotado = !producto.Agotado;
                _context.SaveChanges ();
                return producto.Agotado;
            }
            return false;
        }

        public List<Product> GetProductsDisponibles()
        {
            return _context.Products.Where(x=> x.Agotado==false).ToList();
        }
    }
}
