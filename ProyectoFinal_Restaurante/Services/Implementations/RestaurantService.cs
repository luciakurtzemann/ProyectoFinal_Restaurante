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
        }

        public RestaurantDto CreateRestaurant(CreateRestaurantDto newRestaurant)
        {
            throw new NotImplementedException();
        }

        public void DeleteRestaurant(int restaurantId)
        {
            throw new NotImplementedException();
        }

        public RestaurantDto UpdateRestaurant(UpdateRestaurantDto restaurant)
        {
            throw new NotImplementedException();
        }
    }
}
