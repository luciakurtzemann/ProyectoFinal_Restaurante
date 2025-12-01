using ProyectoFinal_Restaurante.Entities;
using ProyectoFinal_Restaurante.Exceptions;
using ProyectoFinal_Restaurante.Models.DTOs.Requests;
using ProyectoFinal_Restaurante.Models.DTOs.Responses;
using ProyectoFinal_Restaurante.Repositories.Interfaces;
using ProyectoFinal_Restaurante.Services.Interfaces;
using System.Numerics;

namespace ProyectoFinal_Restaurante.Services.Implementations
{
    public class RestaurantService : IRestaurantService
    {
        //INYECCIÓN DE DEPENDENCIAS
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public RestaurantService (IRestaurantRepository restaurantRepository, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _restaurantRepository = restaurantRepository;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }


        //MÉTODOS
        public string ChangePassword(UpdateCredentialsDto updateCredentialsDto, int loggedRestaurant)
        {
            if (loggedRestaurant == updateCredentialsDto.RestaurantId)
            {
                var changedPassword = _restaurantRepository.ChangePassword(updateCredentialsDto.RestaurantId, updateCredentialsDto.OldPassword, updateCredentialsDto.NewPassword);
                if (changedPassword != null)
                {
                    return changedPassword;
                }
                throw new NotFoundException("La contraseña indicada no coincide con la correcta.");
            }
            else
            {
                throw new Exception("No se puede cambiar la contraseña de otro restaurante");
            }
        }

        public RestaurantDto CreateRestaurant(CreateRestaurantDto newRestaurant)
        {
            Restaurant restaurant = new Restaurant()
            {
                Name = newRestaurant.Name,
                Email = newRestaurant.Email,
                Password = newRestaurant.Password,
                Phone = newRestaurant.Phone,
                Address = newRestaurant.Address,
            };
            Restaurant restaurantCreated = _restaurantRepository.CreateRestaurant (restaurant);

            RestaurantDto restaurantResponse = new RestaurantDto()
            {
                RestaurantId = restaurantCreated.RestaurantId,
                Name = restaurantCreated.Name,
                Email = restaurantCreated.Email,
                Phone = restaurantCreated.Phone,
                Address = restaurantCreated.Address,
            };
            return restaurantResponse;
        }

        public bool DeleteRestaurant(int restaurantId, int loggedRestaurant)
        {
            if (restaurantId == loggedRestaurant)
            {
                var restaurantToDelete = _restaurantRepository.DeleteRestaurant(restaurantId);
                if (restaurantToDelete != null)
                {
                    return true;
                }
                return false;
            }
            throw new Exception("No se puede eliminar una cuenta que no sea propia");
        }

        public RestaurantDto UpdateRestaurant(UpdateRestaurantDto restaurant, int loggedRestaurant)       //VER LO DE CONTRASEÑA y NAME (CREDENCIALES)
        {
            if (loggedRestaurant == restaurant.RestaurantId)
            {
                Restaurant restaurantToUpdate = new Restaurant()
                {
                    RestaurantId = restaurant.RestaurantId,
                    Name = restaurant.Name,
                    Email = restaurant.Email,
                    Phone = restaurant.Phone,
                    Address = restaurant.Address,
                };
                Restaurant updatedRestaurant = _restaurantRepository.UpdateRestaurant(restaurantToUpdate);
                if (updatedRestaurant != null)
                {
                    RestaurantDto restaurantResponse = new RestaurantDto()
                    {
                        RestaurantId = updatedRestaurant.RestaurantId,
                        Name = updatedRestaurant.Name,
                        Email = updatedRestaurant.Email,
                        Phone = updatedRestaurant.Phone,
                        Address = updatedRestaurant.Address,
                    };
                    return restaurantResponse;
                }
                throw new NotFoundException("El restaurante a actualizar no existe");
            }
            else
            {
                throw new Exception("No se puede actualizar un restaurante que no sea propio.");
            }
            
        }

        public Restaurant? Authenticate(string email, string password)
        {
            var restaurant = _restaurantRepository.GetByEmail (email);

            if (restaurant == null)
            {
                return null;
            }
            if (restaurant.Password == password)
            {
                return restaurant;
            }
            return null;
        }



        public RestaurantDto GetTopRestaurant()
        {
            var listadoRestaurantes = _restaurantRepository.GetRestaurantsList();
            var todosLosFavoritos = _productRepository.GetProductsFavorite();
            int maxFavoritos = 0;

            if (listadoRestaurantes != null)
            {
                var restauranteTop = listadoRestaurantes.OrderByDescending(x => todosLosFavoritos.Count(r => r.RestaurantId == x.RestaurantId)).FirstOrDefault();

                if (restauranteTop != null)
                {
                    RestaurantDto restaurantResponse = new RestaurantDto()
                    {
                        RestaurantId = restauranteTop.RestaurantId,
                        Name = restauranteTop.Name,
                        Email = restauranteTop.Email,
                        Phone = restauranteTop.Phone,
                        Address = restauranteTop.Address,
                    };
                    return restaurantResponse;
                }
                throw new Exception("No se pudo calcular el restaurante top.");
                  
            }
            else
            {
                throw new Exception("Aún no hay restaurantes agregados");
            }
        }

        public DashboardDto GetResumenRestaurante(int restaurantId)
        {
            var productosPropios = _productRepository.GetProductsByRestaurant(restaurantId);
            var categoriasPropias = _categoryRepository.GetCategoriesByRestaurant(restaurantId);
            
            DashboardDto resumen = new DashboardDto
            {
                totalProductos = productosPropios.Count(),
                totalCategorias = categoriasPropias.Count(),
                productosEnHappyHour = productosPropios.Count(x => x.HappyHour),
                productosConDescuento = productosPropios.Count(x => x.Discount > 0),
                productoMasCaro = productosPropios.OrderByDescending(x => x.Price).Select(x => x.ProductName).FirstOrDefault() ?? "Sin datos",
                productoMasBarato = productosPropios.OrderBy(x => x.Price).Select(x => x.ProductName).FirstOrDefault() ?? "Sin datos",
            };

            return resumen;
            
        }
    }
}
