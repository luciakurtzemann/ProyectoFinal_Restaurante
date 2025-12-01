using ProyectoFinal_Restaurante.Entities;

namespace ProyectoFinal_Restaurante.Models.DTOs.Requests
{
    public class UpdateRestaurantDto
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? Phone { get; set; }
        public string? Address { get; set; }
    }
}
