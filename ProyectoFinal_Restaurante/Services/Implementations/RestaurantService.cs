using ProyectoFinal_Restaurante.Entities;
using ProyectoFinal_Restaurante.Models.DTOs.Requests;
using ProyectoFinal_Restaurante.Models.DTOs.Responses;
using ProyectoFinal_Restaurante.Repositories.Interfaces;
using ProyectoFinal_Restaurante.Services.Interfaces;

namespace ProyectoFinal_Restaurante.Services.Implementations
{
    public class RestaurantService : IRestaurantService
    {
        //INYECCIÓN DE DEPENDENCIAS
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService (IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }


        //MÉTODOS
        public string ChangePassword(UpdateCredentialsDto updateCredentialsDto)
        {
            var changedPassword = _restaurantRepository.ChangePassword(updateCredentialsDto.RestaurantId, updateCredentialsDto.OldPassword, updateCredentialsDto.NewPassword);
            if (changedPassword != null)
            {
                return changedPassword;
            }
            throw new Exception("La contraseña indicada no coincide con la correcta.");
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

        public bool DeleteRestaurant(int restaurantId)
        {
            var restaurantToDelete = _restaurantRepository.DeleteRestaurant(restaurantId);
            if (restaurantToDelete != null)
            {
                return true;
            }
            return false;
        }

        public RestaurantDto UpdateRestaurant(UpdateRestaurantDto restaurant)       //VER LO DE CONTRASEÑA y NAME (CREDENCIALES)
        {
            Restaurant restaurantToUpdate = new Restaurant()
            {
                Name = restaurant.Name,
                Email = restaurant.Email,
                Password = restaurant.Password,
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
            throw new Exception("El restaurante a actualizar no existe");
        }
    }
}
