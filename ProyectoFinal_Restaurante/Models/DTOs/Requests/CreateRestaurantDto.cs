using ProyectoFinal_Restaurante.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal_Restaurante.Models.DTOs.Requests
{
    public class CreateRestaurantDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        
        public int? Phone { get; set; }
        public string? Address { get; set; }
    }
}
