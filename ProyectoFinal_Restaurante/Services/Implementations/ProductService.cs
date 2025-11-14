using ProyectoFinal_Restaurante.Entities;
using ProyectoFinal_Restaurante.Models.DTOs.Requests;
using ProyectoFinal_Restaurante.Models.DTOs.Responses;
using ProyectoFinal_Restaurante.Repositories.Interfaces;
using ProyectoFinal_Restaurante.Services.Interfaces;

namespace ProyectoFinal_Restaurante.Services.Implementations
{
    public class ProductService : IProductService
    {
        //INYECCIÓN DE DEPENDENCIAS
        private readonly IProductRepository _productRepository;

        public ProductService (IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        //MÉTODOS
        public ProductDto CreateProduct(CreateProductDto productDto, int loggedRestaurantId)
        {
            Product product = new Product()
            {
                ProductName = productDto.ProductName,
                ProductDescription = productDto.ProductDescription,
                Price = productDto.Price,
                Discount = productDto.Discount,
                HappyHour = productDto.HappyHour,
                CategoryId = productDto.CategoryId,
                RestaurantId = loggedRestaurantId,
            };
            _productRepository.CreateProduct(product);

            ProductDto productResponseDto = new ProductDto()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                Price = product.Price,
                Discount = product.Discount,
                HappyHour = product.HappyHour,
                IsFavorite = product.IsFavorite,
                RestaurantId = product.RestaurantId,
                CategoryId = product.CategoryId,

            };
            return productResponseDto;

        }

        public bool DeleteProduct(int productId)
        {
            var productToDelete = _productRepository.DeleteProduct(productId);
            if (productToDelete == null)
            {
                return false;
            }
            return true;
        }

        public List<ProductDto> GetAllProducts()
        {
            var listaProductsDto = _productRepository.GetAllProducts().Select( product => new ProductDto()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                Price = product.Price,
                Discount = product.Discount,
                HappyHour = product.HappyHour,
                IsFavorite = product.IsFavorite,
                RestaurantId = product.RestaurantId,
                CategoryId = product.CategoryId,
            }).ToList();
            return listaProductsDto;
        }

        public ProductDto GetProductById(int productId)
        {
            Product producto = _productRepository.GetProductById(productId);

            if (producto != null)
            {
                ProductDto productResponse = new ProductDto()
                {
                    ProductId = producto.ProductId,
                    ProductName = producto.ProductName,
                    ProductDescription = producto.ProductDescription,
                    Price = producto.Price,
                    Discount = producto.Discount,
                    HappyHour = producto.HappyHour,
                    IsFavorite = producto.IsFavorite,
                    RestaurantId = producto.RestaurantId,
                    CategoryId = producto.CategoryId,

                };
                return productResponse;
            }
            throw new Exception("Producto no encontrado");
        }

        public List<ProductDto> GetProductsByCategory(int categoryId)
        {
            List<Product> listadoProductosPorCategoria = _productRepository.GetProductsByCategory(categoryId);
            
            if (listadoProductosPorCategoria.Count !=0)   //
            {
                List<ProductDto> listadoProductosDto = listadoProductosPorCategoria.Select(product => new ProductDto()
                 {
                    ProductId=product.ProductId, 
                    ProductName = product.ProductName,
                     ProductDescription = product.ProductDescription,
                     Price = product.Price,
                     Discount = product.Discount,
                     HappyHour = product.HappyHour,
                     IsFavorite = product.IsFavorite,
                     RestaurantId = product.RestaurantId,
                     CategoryId = product.CategoryId,
                 }).ToList();
                return listadoProductosDto;
            }
            throw new Exception("La categoria seleccionada no tiene productos.");
        }

        public List<ProductDto> GetProductsByRestaurant(int restaurantId)
        {
            List<Product> listadoProductosPorRestaurante = _productRepository.GetProductsByRestaurant(restaurantId);

            if (listadoProductosPorRestaurante.Count == 0)
            {
                throw new Exception("El restaurante seleccionado no tiene productos.");
            }
            List<ProductDto> listadoProductosDto = listadoProductosPorRestaurante.Select(product => new ProductDto()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                Price = product.Price,
                Discount = product.Discount,
                HappyHour = product.HappyHour,
                IsFavorite = product.IsFavorite,
                RestaurantId = product.RestaurantId,
                CategoryId = product.CategoryId,
            }).ToList();
            return listadoProductosDto;
        }

        public List<ProductDto> GetProductsFavorite()
        {
            List<Product> listadoProductosFavoritos = _productRepository.GetProductsFavorite();
            if (listadoProductosFavoritos.Count == 0)
            {
                throw new Exception("No hay productos seleccionados como favoritos.");
            }
            List<ProductDto> listadoProductosDto = listadoProductosFavoritos.Select(product => new ProductDto()
            {
                ProductId= product.ProductId,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                Price = product.Price,
                Discount = product.Discount,
                HappyHour = product.HappyHour,
                IsFavorite = product.IsFavorite,
                RestaurantId = product.RestaurantId,
                CategoryId = product.CategoryId,
            }).ToList();
            return listadoProductosDto;
        }

        public List<ProductDto> GetProductsHappyHour()
        {
            List<Product> listadoProductosHappyHour = _productRepository.GetProductsHappyHour();

            if(listadoProductosHappyHour.Count == 0)
            {
                throw new Exception("No hay productos con Happy Hour.");
            }
            List<ProductDto> listadoProductosDto = listadoProductosHappyHour.Select(product => new ProductDto()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                Price = product.Price,
                Discount = product.Discount,
                HappyHour = product.HappyHour,
                IsFavorite = product.IsFavorite,
                RestaurantId = product.RestaurantId,
                CategoryId = product.CategoryId,
            }).ToList();
            return listadoProductosDto;
        }

        public List<ProductDto> GetProductsWithDiscount()
        {
            List<Product> listadoProductosDescuento = _productRepository.GetProductsWithDiscount();
            if(listadoProductosDescuento.Count == 0)
            {
                throw new Exception("No hay productos con Descuento.");
            }
            List<ProductDto> listadoProductosDto = listadoProductosDescuento
                .Select(product => new ProductDto()
            {
                ProductId=product.ProductId,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                Price = product.Price,
                Discount = product.Discount,
                HappyHour = product.HappyHour,
                IsFavorite = product.IsFavorite,
                RestaurantId = product.RestaurantId,
                CategoryId = product.CategoryId,
            }).ToList();
            return listadoProductosDto;
        }

        public void IncrementPriceByRestaurant(double increment, int restaurantId)
        {
            _productRepository.IncrementPriceByRestaurant(increment, restaurantId);
        }

        public ProductDto ModifyDiscount(int idProducto, double discount)
        {
            _productRepository.ModifyDiscount(idProducto, discount);
            return GetProductById(idProducto);
        }

        public bool ModifyHappyHour(int productId)
        {
            return _productRepository.ModifyHappyHour(productId);
        }

        public ProductDto UpdateProduct(UpdateProductDto productDto)
        {
            Product product = new Product()
            {
                ProductName = productDto.ProductName,
                ProductDescription = productDto.ProductDescription,
                Price = productDto.Price,
                Discount = productDto.Discount,
                HappyHour = productDto.HappyHour,
            };
            Product productUpdated = _productRepository.UpdateProduct(product);

            if (productUpdated != null)
            {
                ProductDto productResponseDto = new ProductDto()
                {
                    ProductId = productUpdated.ProductId,
                    ProductName = productUpdated.ProductName,
                    ProductDescription = productUpdated.ProductDescription,
                    Price = productUpdated.Price,
                    Discount = productUpdated.Discount,
                    HappyHour = productUpdated.HappyHour,
                    IsFavorite = productUpdated.IsFavorite,
                    RestaurantId = productUpdated.RestaurantId,
                    CategoryId = productUpdated.CategoryId,
                };
                return productResponseDto;
            }
            throw new Exception("El producto que se busca actualizar no existe.");
        }
    }
}
