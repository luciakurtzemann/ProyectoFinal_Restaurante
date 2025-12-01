using ProyectoFinal_Restaurante.Entities;
using ProyectoFinal_Restaurante.Exceptions;
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
        private readonly ICategoryRepository _categoryRepository;
        private readonly IRestaurantRepository _restaurantRepository;

        public ProductService (IProductRepository productRepository, ICategoryRepository categoryRepository, IRestaurantRepository restaurantRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _restaurantRepository = restaurantRepository;
        }

        //MÉTODOS
        public ProductDto CreateProduct(CreateProductDto productDto, int loggedRestaurantId)
        {
            var idCategoriaPedida = productDto.CategoryId;
            var restauranteCorrespondiente = _categoryRepository.GetRestaurantId(idCategoriaPedida);

            if (restauranteCorrespondiente == 0)
            {
                throw new NotFoundException("La categoría indicada no existe.");
            }

            if (loggedRestaurantId == restauranteCorrespondiente)
            {
                Product product = new Product()
                {
                    ProductName = productDto.ProductName,
                    ProductDescription = productDto.ProductDescription,
                    Price = productDto.Price,
                    Discount = productDto.Discount,
                    HappyHour = productDto.HappyHour,
                    CategoryId = productDto.CategoryId,
                    Agotado = productDto.Agotado,
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
                    Agotado = product.Agotado,
                    RestaurantId = product.RestaurantId,
                    CategoryId = product.CategoryId,

                };
                return productResponseDto;
            }
            else
            {
                throw new Exception("No puede crear un producto en una categoría de otro restaurante.");
            }
            

        }

        public bool DeleteProduct(int productId, int loggedRestaurantId)
        {
            var product = GetProductById(productId);
            int ownerId = _productRepository.GetRestaurantId(productId);
            if (ownerId == 0)
            {
                return false;
            }
            if (ownerId != loggedRestaurantId)
            {
                throw new Exception("No puedes borrar productos ajenos.");
            }
            var productToDelete = _productRepository.DeleteProduct(productId);
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
                Agotado = product.Agotado,
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
                    Agotado= producto.Agotado,
                    IsFavorite = producto.IsFavorite,
                    RestaurantId = producto.RestaurantId,
                    CategoryId = producto.CategoryId,

                };
                return productResponse;
            }
            throw new NotFoundException("Producto no encontrado");
        }

        public List<ProductDto> GetProductsByCategory(int categoryId)
        {
            var categoriaExiste = _categoryRepository.GetCategory(categoryId);
            if (categoriaExiste != null)
            {
                List<ProductDto> listadoProductosPorCategoria = _productRepository.GetProductsByCategory(categoryId).Select(product => new ProductDto()
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    Price = product.Price,
                    Discount = product.Discount,
                    HappyHour = product.HappyHour,
                    Agotado= product.Agotado,
                    IsFavorite = product.IsFavorite,
                    RestaurantId = product.RestaurantId,
                    CategoryId = product.CategoryId,
                }).ToList();
                return listadoProductosPorCategoria;
            }
            throw new Exception("La categoría buscada no existe");
        }

        public List<ProductDto> GetProductsByRestaurant(int restaurantId)
        {
            var restauranteExiste = _restaurantRepository.GetRestaurantsList().FirstOrDefault(x => x.RestaurantId == restaurantId);
            if (restauranteExiste != null)
            {
                List<ProductDto> listadoProductosPorRestaurante = _productRepository.GetProductsByRestaurant(restaurantId).Select(product => new ProductDto()
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    Price = product.Price,
                    Discount = product.Discount,
                    HappyHour = product.HappyHour,
                    IsFavorite = product.IsFavorite,
                    Agotado = product.Agotado,
                    RestaurantId = product.RestaurantId,
                    CategoryId = product.CategoryId,
                }).ToList();
                return listadoProductosPorRestaurante;
            }
            else
            {
                throw new Exception("El restaurante buscado no existe.");
            }
        }

        public List<ProductDto> GetProductsFavorite()
        {
            List<ProductDto> listadoProductosFavoritos = _productRepository.GetProductsFavorite().Select(product => new ProductDto()
            {
                ProductId= product.ProductId,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                Price = product.Price,
                Discount = product.Discount,
                HappyHour = product.HappyHour,
                IsFavorite = product.IsFavorite,
                Agotado = product.Agotado,
                RestaurantId = product.RestaurantId,
                CategoryId = product.CategoryId,
            }).ToList();
            return listadoProductosFavoritos;
        }

        public List<ProductDto> GetProductsHappyHour()
        {
            List<ProductDto> listadoProductosHappyHour = _productRepository.GetProductsHappyHour().Select(product => new ProductDto()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                Price = product.Price,
                Discount = product.Discount,
                HappyHour = product.HappyHour,
                IsFavorite = product.IsFavorite,
                Agotado = product.Agotado,
                RestaurantId = product.RestaurantId,
                CategoryId = product.CategoryId,
            }).ToList();
            return listadoProductosHappyHour;
        }

        public List<ProductDto> GetProductsWithDiscount()
        {
            List<ProductDto> listadoProductosDescuento = _productRepository.GetProductsWithDiscount().Select(product => new ProductDto()
            {
                ProductId=product.ProductId,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                Price = product.Price,
                Discount = product.Discount,
                HappyHour = product.HappyHour,
                IsFavorite = product.IsFavorite,
                Agotado = product.Agotado,
                RestaurantId = product.RestaurantId,
                CategoryId = product.CategoryId,
            }).ToList();
            return listadoProductosDescuento;
        }

        public void IncrementPriceByRestaurant(double increment, int restaurantId)
        {
            _productRepository.IncrementPriceByRestaurant(increment, restaurantId);
        }

        public ProductDto ModifyDiscount(int idProducto, double discount, int restaurantId)
        {
            if (restaurantId == _productRepository.GetRestaurantId(idProducto))
            {
                var exitoso = _productRepository.ModifyDiscount(idProducto, discount);
                if (exitoso)
                {
                    return GetProductById(idProducto);
                }
                throw new NotFoundException("El ID indicado no corresponde a ningún producto"); 
            }
            throw new Exception("No se pueden modificar productos de otro restaurante.");
        }

        public bool ModifyHappyHour(int productId, int restaurantId)
        {
            var productRepo = _productRepository.GetProductById(productId);
            if (productRepo == null)
            {
                throw new NotFoundException("El producto seleccionado no existe.");
            }
            if ( restaurantId == _productRepository.GetRestaurantId(productId))
            {
                return _productRepository.ModifyHappyHour(productId);
            }
            throw new Exception("No se pueden modificar productos de otro restaurante.");
        }

        public ProductDto UpdateProduct(UpdateProductDto productDto, int restaurantId)
        {
            var productoRepo = _productRepository.GetProductById(productDto.ProductId);
            if (productoRepo != null && restaurantId == productoRepo.RestaurantId)
            {
                Product product = new Product()
                {
                    ProductId = productDto.ProductId,
                    ProductName = productDto.ProductName,
                    ProductDescription = productDto.ProductDescription,
                    Price = productDto.Price,
                    Discount = productDto.Discount,
                    HappyHour = productDto.HappyHour,
                    Agotado = productDto.Agotado,
                };
                Product productUpdated = _productRepository.UpdateProduct(product);

                ProductDto productResponseDto = new ProductDto()
                {
                    ProductId = productUpdated.ProductId,
                    ProductName = productUpdated.ProductName,
                    ProductDescription = productUpdated.ProductDescription,
                    Price = productUpdated.Price,
                    Discount = productUpdated.Discount,
                    HappyHour = productUpdated.HappyHour,
                    IsFavorite = productUpdated.IsFavorite,
                    Agotado = productUpdated.Agotado,
                    RestaurantId = productUpdated.RestaurantId,
                    CategoryId = productUpdated.CategoryId,
                };
                return productResponseDto;
            }
            else if (productoRepo == null) 
            {
                throw new NotFoundException("El producto buscado no existe");  
            }
            else
            {
                throw new Exception("No se pueden modificar productos de otro restaurante.");
            }
        }

        public int GetRestaurantId(int idProducto)
        {
            var restaurantId =  _productRepository.GetRestaurantId(idProducto);
            if (restaurantId != 0)
            {
                return restaurantId;
            }
            throw new NotFoundException("Restaurante o producto incorrecto");
        }

        public void ChangeFavorite(int idProducto)
        {
            var producto = GetProductById(idProducto);
            if (producto != null)
            {
                _productRepository.ChangeFavorite(idProducto);
                return;
            }
            throw new NotFoundException("El producto que busca no existe.");
        }

        public void ChangeDisponibilidad (int idProducto, int loggedRestaurantId)
        {
            var restauranteCorrespondiente = _productRepository.GetRestaurantId(idProducto);

            if (restauranteCorrespondiente == loggedRestaurantId)
            {
                var producto = GetProductById(idProducto);
                if (producto != null)
                {
                    _productRepository.ChangeDisponibilidad(idProducto);
                    return;
                }
                throw new NotFoundException("El producto que busca no existe.");
            }
            throw new Exception("No puede modificar un producto de otro restaurante");
        }

        public List<ProductDto> GetProductosDisponibles()
        {
            var listaProductsDto = _productRepository.GetProductsDisponibles().Select(product => new ProductDto()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                Price = product.Price,
                Discount = product.Discount,
                HappyHour = product.HappyHour,
                IsFavorite = product.IsFavorite,
                Agotado = product.Agotado,
                RestaurantId = product.RestaurantId,
                CategoryId = product.CategoryId,
            }).ToList();
            return listaProductsDto;
        }

    }
}
