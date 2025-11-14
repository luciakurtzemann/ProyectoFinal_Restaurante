using ProyectoFinal_Restaurante.Entities;
using ProyectoFinal_Restaurante.Models.DTOs.Requests;

namespace ProyectoFinal_Restaurante.Repositories.Interfaces
{
    public interface IRestaurantRepository
    {
        public Restaurant CreateRestaurant (Restaurant newRestaurant);
        public Restaurant UpdateRestaurant (Restaurant restaurant);
        public Restaurant DeleteRestaurant(int restaurantId);
        public string ChangePassword(int restaurantId, string oldPassword, string newPassword);
    }
}
