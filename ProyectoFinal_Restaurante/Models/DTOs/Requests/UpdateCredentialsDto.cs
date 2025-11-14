using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal_Restaurante.Models.DTOs.Requests
{
    public class UpdateCredentialsDto
    {
        [Required]
        public int RestaurantId { get; set; }
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
