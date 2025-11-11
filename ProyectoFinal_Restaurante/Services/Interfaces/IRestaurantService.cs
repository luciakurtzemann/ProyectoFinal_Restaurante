using ProyectoFinal_Restaurante.Entities;
using ProyectoFinal_Restaurante.Models.DTOs.Requests;
using ProyectoFinal_Restaurante.Models.DTOs.Responses;

namespace ProyectoFinal_Restaurante.Services.Interfaces
{
    public interface IRestaurantService
    {
        public RestaurantDto CreateRestaurant(CreateRestaurantDto newRestaurant);
        public RestaurantDto UpdateRestaurant(UpdateRestaurantDto restaurant);
        public bool DeleteRestaurant(int restaurantId);
        public string ChangePassword(int restaurantId, string newPassword);
    }
}
