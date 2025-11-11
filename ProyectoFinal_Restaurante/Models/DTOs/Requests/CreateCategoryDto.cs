using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal_Restaurante.Models.DTOs.Requests
{
    public class CreateCategoryDto
    {
        [Required]
        public string CategoryName { get; set; }
        public int RestaurantId { get; set; }
    }
}
