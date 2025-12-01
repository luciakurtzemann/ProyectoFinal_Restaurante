using ProyectoFinal_Restaurante.Entities;
using ProyectoFinal_Restaurante.Models.DTOs.Requests;
using ProyectoFinal_Restaurante.Models.DTOs.Responses;

namespace ProyectoFinal_Restaurante.Services.Interfaces
{
    public interface IRestaurantService
    {
        public RestaurantDto CreateRestaurant(CreateRestaurantDto newRestaurant);
        public RestaurantDto UpdateRestaurant(UpdateRestaurantDto restaurant, int loggedRestaurant);
        public bool DeleteRestaurant(int restaurantId, int loggedRestaurant);
        public string ChangePassword(UpdateCredentialsDto updateCredentialsDto, int loggedRestaurant);
        public Restaurant? Authenticate(string email, string password);
        public RestaurantDto GetTopRestaurant();
        public DashboardDto GetResumenRestaurante(int restaurantId);
    }
}
