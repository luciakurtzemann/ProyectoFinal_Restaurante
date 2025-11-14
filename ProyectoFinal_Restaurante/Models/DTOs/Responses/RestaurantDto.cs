using ProyectoFinal_Restaurante.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal_Restaurante.Models.DTOs.Responses
{
    public class RestaurantDto
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? Phone { get; set; }
        public string? Address { get; set; }
    }
}
