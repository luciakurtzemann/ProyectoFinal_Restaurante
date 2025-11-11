using ProyectoFinal_Restaurante.Entities;

namespace ProyectoFinal_Restaurante.Repositories.Interfaces
{
    public interface IRestaurantRepository
    {
        public Restaurant CreateRestaurant (Restaurant newRestaurant);
        public Restaurant UpdateRestaurant (Restaurant restaurant);
        public void DeleteRestaurant(int restaurantId);
        public string ChangePassword (int restaurantId, string newPassword);
    }
}
