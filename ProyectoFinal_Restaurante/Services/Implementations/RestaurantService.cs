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
        public string ChangePassword(int restaurantId, string newPassword)
        {
            throw new NotImplementedException();
            //terminar
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
                Name = newRestaurant.Name,
                Email = newRestaurant.Email,
                Phone = newRestaurant.Phone,
                Address = newRestaurant.Address,
            };
            return restaurantResponse;
        }

        public bool DeleteRestaurant(int restaurantId)
        {
            return _restaurantRepository.DeleteRestaurant(restaurantId);
        }

        public RestaurantDto UpdateRestaurant(UpdateRestaurantDto restaurant)       //VER LO DE CONTRASEÑA
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

            RestaurantDto restaurantResponse = new RestaurantDto()
            {
                Name = updatedRestaurant.Name,
                Email = updatedRestaurant.Email,
                Phone = updatedRestaurant.Phone,
                Address = updatedRestaurant.Address,
            };
            return restaurantResponse;
        }
    }
}
